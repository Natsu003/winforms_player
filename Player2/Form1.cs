using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;
using NAudio.Wave;
using Newtonsoft.Json;
using TagFile = TagLib.File;

namespace Player2
{
    public partial class Form1 : Form
    {
        //Аудіо
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;
        private Timer timer;

        //Стани
        private int currentTrackIndex = -1;
        private bool isShuffle = false;
        private bool isRepeat = false;
        private readonly Random rnd = new Random();

        private List<int> shuffleOrder = new();
        private int shufflePos = -1;
        private bool suppressSelection = false;

        //Дані
        private readonly List<string> libraryTracks = new();
        private readonly List<Playlist> Playlists = new();
        private Playlist currentPlaylist;

        private const string LibraryFile = "library.json";
        private const string PlaylistsFile = "playlists.json";

        //Тема
        private readonly Color backDark = Color.FromArgb(30, 30, 30);
        private readonly Color foreDark = Color.Gainsboro;
        private readonly Color backLight = SystemColors.Control;
        private readonly Color foreLight = SystemColors.ControlText;

        private bool IsLightTheme()
        {
            try
            {
                using var k = Registry.CurrentUser.OpenSubKey(
                    @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize");
                return k == null || (int)k.GetValue("AppsUseLightTheme", 1) != 0;
            }
            catch { return true; }
        }
        private void ApplyTheme(bool light)
        {
            var back = light ? backLight : backDark;
            var fore = light ? foreLight : foreDark;

            BackColor = back;
            panelControls.BackColor = back;
            panelPlaylist.BackColor = back;

            trackBarProgress.BackColor = back;
            trackBarVolume.BackColor = back;

            listBoxPlaylistTracks.BackColor = back;
            listBoxPlaylistTracks.ForeColor = fore;
            labelSongInfo.ForeColor = fore;
            labelPlaylistName.ForeColor = fore;
            labelTime.ForeColor = fore;

            foreach (var b in panelControls.Controls.OfType<Button>())
            { b.BackColor = back; b.ForeColor = fore; }
            foreach (var b in flpPlaylists.Controls.OfType<Button>())
            { b.BackColor = back; b.ForeColor = fore; }
        }

        //WM_APPCOMMAND
        private const int WM_APPCOMMAND = 0x0319;
        private const int WM_SETTINGCHANGE = 0x001A;
        private const int APPCOMMAND_MEDIA_NEXTTRACK = 11;
        private const int APPCOMMAND_MEDIA_PREVIOUSTRACK = 12;
        private const int APPCOMMAND_MEDIA_STOP = 13;
        private const int APPCOMMAND_MEDIA_PLAY_PAUSE = 14;
        private const int APPCOMMAND_VOLUME_MUTE = 8;
        private const int APPCOMMAND_VOLUME_DOWN = 9;
        private const int APPCOMMAND_VOLUME_UP = 10;
        private static int GET_APPCOMMAND_LPARAM(int l) => (l >> 16) & 0x7FFF;

        //Конструктор
        public Form1()
        {
            InitializeComponent();

            using (var ms = new MemoryStream(Properties.Resources._5305559464683890721p))
                pictureBoxMusic.Image = Image.FromStream(ms);
            pictureBoxMusic.Visible = true;

            ApplyTheme(IsLightTheme());

            timer = new Timer { Interval = 500 };
            timer.Tick += Timer_Tick;

            flpPlaylists.MouseUp += flpPlaylists_MouseUp;
            listBoxPlaylistTracks.MouseUp += listBoxPlaylistTracks_MouseUp;

            LoadLibrary(); LoadPlaylists();
            RefreshPlaylistButtons();

            trackBarVolume.Value = 80;
            trackBarProgress.Value = 0;
            panelPlaylist.Visible = false;
            labelSongInfo.Visible = false;
        }

        //WndProc
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_APPCOMMAND)
            {
                int cmd = GET_APPCOMMAND_LPARAM(m.LParam.ToInt32());
                switch (cmd)
                {
                    case APPCOMMAND_MEDIA_PLAY_PAUSE: buttonPlayPause_Click_1(null, EventArgs.Empty); m.Result = IntPtr.Zero; return;
                    case APPCOMMAND_MEDIA_NEXTTRACK: GoToNext(); m.Result = IntPtr.Zero; return;
                    case APPCOMMAND_MEDIA_PREVIOUSTRACK: GoToPrevious(); m.Result = IntPtr.Zero; return;
                    case APPCOMMAND_MEDIA_STOP: Pause(); m.Result = IntPtr.Zero; return;
                    case APPCOMMAND_VOLUME_UP: trackBarVolume.Value = Math.Min(100, trackBarVolume.Value + 5); trackBarVolume_Scroll(null, EventArgs.Empty); m.Result = IntPtr.Zero; return;
                    case APPCOMMAND_VOLUME_DOWN: trackBarVolume.Value = Math.Max(0, trackBarVolume.Value - 5); trackBarVolume_Scroll(null, EventArgs.Empty); m.Result = IntPtr.Zero; return;
                    case APPCOMMAND_VOLUME_MUTE: trackBarVolume.Value = 0; trackBarVolume_Scroll(null, EventArgs.Empty); m.Result = IntPtr.Zero; return;
                }
            }
            else if (m.Msg == WM_SETTINGCHANGE)
            {
                ApplyTheme(IsLightTheme());   // реакція на зміну теми
            }

            base.WndProc(ref m);
        }

        //Відтворення (NAudio)
        private void SetAudioFile(string path)
        {
            if (!File.Exists(path)) return;

            outputDevice?.Stop(); outputDevice?.Dispose();
            audioFile?.Dispose();

            audioFile = new AudioFileReader(path) { Volume = trackBarVolume.Value / 100f };
            outputDevice = new WaveOutEvent(); outputDevice.Init(audioFile);

            labelSongInfo.Text = GetTitleAndArtist(path);
            ShowCoverImage(path);
        }
        private void Play()
        {
            if (outputDevice == null || audioFile == null) return;
            outputDevice.Play(); timer.Start(); buttonPlayPause.Text = "❚❚";
        }
        private void Pause()
        {
            outputDevice?.Pause(); timer.Stop(); buttonPlayPause.Text = "▶️";
        }

        //Кнопки
        private void buttonPlayPause_Click_1(object s, EventArgs e)
        { if (outputDevice == null) return; if (outputDevice.PlaybackState == PlaybackState.Playing) Pause(); else Play(); }
        private void buttonNext_Click_1(object s, EventArgs e) => GoToNext();
        private void buttonPrevious_Click_1(object s, EventArgs e) => GoToPrevious();

        private void buttonShuffle_Click(object s, EventArgs e)
        {
            isShuffle = !isShuffle;
            buttonShuffle.ForeColor = isShuffle ? Color.LimeGreen : SystemColors.ControlText;
            buttonShuffle.Text = isShuffle ? "✔" : "🔀";
            if (isShuffle)
            {
                int n = listBoxPlaylistTracks.Items.Count;
                shuffleOrder = Enumerable.Range(0, n).OrderBy(_ => rnd.Next()).ToList();
                shufflePos = shuffleOrder.IndexOf(currentTrackIndex);
                if (shufflePos == -1) shufflePos = 0;
            }
            else { shuffleOrder.Clear(); shufflePos = -1; }
        }
        private void buttonRepeat_Click(object s, EventArgs e)
        {
            isRepeat = !isRepeat;
            buttonRepeat.ForeColor = isRepeat ? Color.LimeGreen : SystemColors.ControlText;
            buttonRepeat.Text = isRepeat ? "✔" : "🔁";
        }

        //Перехід треків
        private void GoToNext()
        {
            int n = listBoxPlaylistTracks.Items.Count; if (n == 0) return;
            currentTrackIndex = isShuffle ? shuffleOrder[(shufflePos = (shufflePos + 1) % shuffleOrder.Count)] :
                                            (currentTrackIndex + 1) % n;
            listBoxPlaylistTracks.SelectedIndex = currentTrackIndex;
        }
        private void GoToPrevious()
        {
            int n = listBoxPlaylistTracks.Items.Count; if (n == 0) return;
            currentTrackIndex = isShuffle ? shuffleOrder[(shufflePos = (shufflePos - 1 + shuffleOrder.Count) % shuffleOrder.Count)] :
                                            (currentTrackIndex - 1 + n) % n;
            listBoxPlaylistTracks.SelectedIndex = currentTrackIndex;
        }

        //Список
        private void listBoxPlaylistTracks_SelectedIndexChanged(object s, EventArgs e)
        {
            if (suppressSelection) return;
            if (listBoxPlaylistTracks.SelectedItem is TrackItem ti)
            {
                if (audioFile != null && string.Equals(audioFile.FileName, ti.FilePath, StringComparison.OrdinalIgnoreCase)) return;
                currentTrackIndex = listBoxPlaylistTracks.SelectedIndex;
                if (isShuffle) shufflePos = shuffleOrder.IndexOf(currentTrackIndex);
                SetAudioFile(ti.FilePath); Play();
            }
        }
        private void listBoxPlaylistTracks_MouseUp(object s, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            int idx = listBoxPlaylistTracks.IndexFromPoint(e.Location);
            listBoxPlaylistTracks.SelectedIndex = idx;
            cmsPlaylistMenu.Items.Clear();
            if (idx >= 0) cmsPlaylistMenu.Items.Add(tsmiRemoveTrack);
            cmsPlaylistMenu.Show(listBoxPlaylistTracks, e.Location);
        }

        //Таймер
        private void Timer_Tick(object s, EventArgs e)
        {
            if (audioFile == null) return;

            labelTime.Text = audioFile.CurrentTime.ToString(@"hh\:mm\:ss");

            if (audioFile.TotalTime.TotalSeconds > 0)
                trackBarProgress.Value = (int)(audioFile.CurrentTime.TotalSeconds /
                                               audioFile.TotalTime.TotalSeconds * 100);

            if (audioFile.CurrentTime >= audioFile.TotalTime)
            {
                if (isRepeat) { audioFile.Position = 0; outputDevice.Play(); }
                else GoToNext();
            }
        }
        private void trackBarProgress_Scroll(object s, EventArgs e)
        { if (audioFile != null) audioFile.CurrentTime = TimeSpan.FromSeconds(audioFile.TotalTime.TotalSeconds * trackBarProgress.Value / 100.0); }
        private void trackBarVolume_Scroll(object s, EventArgs e)
        { if (audioFile != null) audioFile.Volume = trackBarVolume.Value / 100f; }

        // Панель плейлистів
        private void buttonPlaylistToggle_Click_1(object s, EventArgs e)
        { panelPlaylist.Visible = !panelPlaylist.Visible; if (panelPlaylist.Visible) { if (currentPlaylist != null) ShowCurrentPlaylist(); else ShowLibrary(); } }

        private void PlaylistButton_Click(object s, EventArgs e)
        { currentPlaylist = Playlists[(int)((Button)s!).Tag]; ShowCurrentPlaylist(); }

        private void flpPlaylists_MouseUp(object s, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            var btn = flpPlaylists.GetChildAtPoint(e.Location) as Button;
            cmsPlaylistMenu.Items.Clear();
            if (btn?.Text == "Бібліотека") cmsPlaylistMenu.Items.Add(tsmiSearchTracks);
            else if (btn?.Text != "+" && btn != null)
            {
                cmsPlaylistMenu.Items.Add(tsmiAddTracks);
                cmsPlaylistMenu.Items.Add(tsmiRenamePlaylist);
                cmsPlaylistMenu.Items.Add(tsmiDeletePlaylist);
            }
        }
        private void buttonEllipsis_Click_1(object s, EventArgs e)
        {
            cmsPlaylistMenu.Items.Clear();
            if (currentPlaylist == null) cmsPlaylistMenu.Items.Add(tsmiSearchTracks);
            else
            {
                cmsPlaylistMenu.Items.Add(tsmiAddTracks);
                cmsPlaylistMenu.Items.Add(tsmiRenamePlaylist);
                cmsPlaylistMenu.Items.Add(tsmiDeletePlaylist);
            }
            cmsPlaylistMenu.Show(buttonEllipsis, new Point(0, buttonEllipsis.Height));
        }
        private void cmsPlaylistMenu_ItemClicked_1(object s, ToolStripItemClickedEventArgs e)
        {
            var i = e.ClickedItem;
            if (i == tsmiAddTracks && currentPlaylist != null) buttonAddToPlaylist_Click(null, null);
            else if (i == tsmiSearchTracks) buttonAddFromLibrary_Click_1(null, null);
            else if (i == tsmiRemoveTrack)
            {
                if (listBoxPlaylistTracks.SelectedItem is TrackItem ti)
                {
                    if (currentPlaylist != null) { currentPlaylist.Tracks.Remove(ti.FilePath); SavePlaylists(); ShowCurrentPlaylist(); }
                    else { libraryTracks.Remove(ti.FilePath); Playlists.ForEach(pl => pl.Tracks.Remove(ti.FilePath)); SaveLibrary(); SavePlaylists(); ShowLibrary(); }
                }
            }
            else if (i == tsmiDeletePlaylist && currentPlaylist != null) { Playlists.Remove(currentPlaylist); currentPlaylist = null; SavePlaylists(); RefreshPlaylistButtons(); ShowLibrary(); }
            else if (i == tsmiRenamePlaylist && currentPlaylist != null) ShowNewPlaylistPanel(rename: true);
        }

        // Новий/Rename плейлист
        private void ShowNewPlaylistPanel(bool rename = false)
        { panelNewPlaylist.Visible = true; textBoxNewName.Text = rename ? currentPlaylist?.Name : ""; buttonCreate.Text = rename ? "Перейменувати" : "Створити"; }
        private void buttonCreate_Click_1(object s, EventArgs e)
        {
            string name = textBoxNewName.Text.Trim();
            if (string.IsNullOrEmpty(name)) { MessageBox.Show("Введіть назву!"); return; }
            if (buttonCreate.Text == "Перейменувати" && currentPlaylist != null) currentPlaylist.Name = name;
            else Playlists.Add(new Playlist { Name = name });
            SavePlaylists(); panelNewPlaylist.Visible = false; textBoxNewName.Clear(); RefreshPlaylistButtons(); ShowLibrary();
        }
        private void buttonCancel_Click_1(object s, EventArgs e) { panelNewPlaylist.Visible = false; textBoxNewName.Clear(); }

        //Додати треки до плейлиста
        private void buttonAddToPlaylist_Click(object s, EventArgs e)
        {
            if (currentPlaylist == null) return;
            using var dlg = new Form { Text = "Додайте треки з бібліотеки", Size = new Size(400, 300), StartPosition = FormStartPosition.CenterParent };
            var clb = new CheckedListBox { Dock = DockStyle.Top, Height = 200 };
            foreach (var p in libraryTracks) clb.Items.Add(new DisplayTrack(p, GetTitleAndArtist(p)));
            var cancel = new Button { Text = "Скасувати", Dock = DockStyle.Left, Width = 80, DialogResult = DialogResult.Cancel };
            var ok = new Button { Text = "OK", Dock = DockStyle.Right, Width = 80, DialogResult = DialogResult.OK };
            var pnl = new Panel { Dock = DockStyle.Bottom, Height = 40 };
            pnl.Controls.Add(cancel); pnl.Controls.Add(ok);
            dlg.Controls.Add(clb); dlg.Controls.Add(pnl);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                foreach (int idx in clb.CheckedIndices)
                {
                    var dt = (DisplayTrack)clb.Items[idx];
                    if (!currentPlaylist.Tracks.Contains(dt.FilePath)) currentPlaylist.Tracks.Add(dt.FilePath);
                }
                SavePlaylists(); ShowCurrentPlaylist();
            }
        }

        // Додати треки до бібліотеки
        private void buttonAddFromLibrary_Click_1(object s, EventArgs e)
        {
            using var ofd = new OpenFileDialog { Filter = "Музика |*.mp3;*.wav;*.flac;*.aac;*.ogg|Відео|*.mp4;*.mkv;*.avi;*.mov;*.wmv", Multiselect = true };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (string f in ofd.FileNames.Where(File.Exists))
                    if (!libraryTracks.Contains(f)) libraryTracks.Add(f);
                SaveLibrary(); ShowLibrary();
            }
        }

        // Відображення списків
        private void ShowLibrary()
        {
            currentPlaylist = null; labelPlaylistName.Visible = false;
            suppressSelection = true;
            listBoxPlaylistTracks.Items.Clear();
            foreach (var p in libraryTracks) listBoxPlaylistTracks.Items.Add(new TrackItem { FilePath = p });
            if (currentTrackIndex >= 0 && currentTrackIndex < listBoxPlaylistTracks.Items.Count)
                listBoxPlaylistTracks.SelectedIndex = currentTrackIndex;
            suppressSelection = false;
            listBoxPlaylistTracks.Visible = true; buttonAddFromLibrary.Visible = true; buttonAddToPlaylist.Visible = false;
        }
        private void ShowCurrentPlaylist()
        {
            if (currentPlaylist == null) return;
            labelPlaylistName.Text = currentPlaylist.Name; labelPlaylistName.Visible = true;
            suppressSelection = true;
            listBoxPlaylistTracks.Items.Clear();
            foreach (var p in currentPlaylist.Tracks) listBoxPlaylistTracks.Items.Add(new TrackItem { FilePath = p });
            if (currentTrackIndex >= 0 && currentTrackIndex < listBoxPlaylistTracks.Items.Count)
                listBoxPlaylistTracks.SelectedIndex = currentTrackIndex;
            suppressSelection = false;
            listBoxPlaylistTracks.Visible = true; buttonAddToPlaylist.Visible = true; buttonAddFromLibrary.Visible = false;
        }

        // Кнопки плейлистів
        private void RefreshPlaylistButtons()
        {
            flpPlaylists.Controls.Clear();
            var libBtn = new Button { Text = "Бібліотека", Size = new Size(80, 80) };
            libBtn.Click += (s, e) => ShowLibrary();
            flpPlaylists.Controls.Add(libBtn);

            for (int i = 0; i < Playlists.Count; i++)
            {
                var b = new Button { Text = Playlists[i].Name, Tag = i, Size = new Size(80, 80) };
                b.Click += PlaylistButton_Click;
                flpPlaylists.Controls.Add(b);
            }

            var addBtn = new Button { Text = "+", Size = new Size(80, 80) };
            addBtn.Click += (s, e) => ShowNewPlaylistPanel();
            flpPlaylists.Controls.Add(addBtn);

            // підлаштувати кольори під тему
            ApplyTheme(IsLightTheme());
        }

        // Допоміжні
        private static string GetTitleAndArtist(string p)
        {
            try
            {
                var tf = TagFile.Create(p);
                string t = tf.Tag.Title ?? Path.GetFileNameWithoutExtension(p);
                string a = tf.Tag.FirstPerformer ?? "";
                return string.IsNullOrEmpty(a) ? t : $"{a} - {t}";
            }
            catch { return Path.GetFileNameWithoutExtension(p); }
        }
        private void ShowCoverImage(string path)
        {
            Image img = null;
            try { var tf = TagFile.Create(path); if (tf.Tag.Pictures?.Length > 0) img = Image.FromStream(new MemoryStream(tf.Tag.Pictures[0].Data.Data)); }
            catch { }
            if (img == null) using (var ms = new MemoryStream(Properties.Resources._5305559464683890721p)) img = Image.FromStream(ms);
            pictureBoxMusic.Image = img; pictureBoxMusic.Visible = true; labelSongInfo.Visible = true;
        }

        // Збереження/Завантаження
        private void LoadLibrary() { if (File.Exists(LibraryFile)) libraryTracks.AddRange(JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(LibraryFile))); }
        private void LoadPlaylists() { if (File.Exists(PlaylistsFile)) Playlists.AddRange(JsonConvert.DeserializeObject<List<Playlist>>(File.ReadAllText(PlaylistsFile))); }
        private void SaveLibrary() => File.WriteAllText(LibraryFile, JsonConvert.SerializeObject(libraryTracks, Formatting.Indented));
        private void SavePlaylists() => File.WriteAllText(PlaylistsFile, JsonConvert.SerializeObject(Playlists, Formatting.Indented));

        private void Form1_FormClosing(object s, FormClosingEventArgs e)
        { SaveLibrary(); SavePlaylists(); outputDevice?.Dispose(); audioFile?.Dispose(); }
    }

    // Доп.класи
    public class TrackItem { public string FilePath { get; set; } public override string ToString() => Path.GetFileName(FilePath); }
    public class Playlist { public string Name { get; set; } public List<string> Tracks { get; set; } = new(); }
    public class DisplayTrack { public string FilePath { get; } public string Display { get; } public DisplayTrack(string p, string d) { FilePath = p; Display = d; } public override string ToString() => Display; }
}
