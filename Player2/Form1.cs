using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using NAudio.Wave;
using Newtonsoft.Json;
using TagLib;

namespace Player2
{
    public partial class Form1 : Form
    {
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;
        private Timer timer;
        private int currentTrackIndex = 0;

        private readonly List<string> libraryTracks = new List<string>();
        private readonly List<Playlist> Playlists = new List<Playlist>();
        private Playlist currentPlaylist;

        private const string PlaylistsFileName = "playlists.json";
        private const string LibraryFileName = "library.json";

        public Form1()
        {
            InitializeComponent();
            panelPlaylist.BringToFront();

            // Активний трек синім у listBoxTracks
            listBoxTracks.DrawMode = DrawMode.OwnerDrawFixed;
            listBoxTracks.DrawItem += ListBoxTracks_DrawItem;

            LoadLibrary();
            LoadPlaylists();
            RefreshPlaylistButtons();
            InitializePlayer();

            ShowImageView();
        }

        private void ListBoxTracks_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            var lb = (ListBox)sender;
            bool isActiveTrack = (e.Index == currentTrackIndex);

            e.DrawBackground();
            Color textColor = Color.Black;
            if (isActiveTrack)
            {
                e.Graphics.FillRectangle(Brushes.LightBlue, e.Bounds);
                textColor = Color.Navy;
            }

            string text = lb.Items[e.Index].ToString();
            using (Brush brush = new SolidBrush(textColor))
                e.Graphics.DrawString(text, e.Font, brush, e.Bounds.X, e.Bounds.Y);

            e.DrawFocusRectangle();
        }

        private void LoadLibrary()
        {
            try
            {
                if (System.IO.File.Exists(LibraryFileName))
                {
                    var json = System.IO.File.ReadAllText(LibraryFileName);
                    libraryTracks.Clear();
                    libraryTracks.AddRange(JsonConvert.DeserializeObject<List<string>>(json));
                }
            }
            catch { }
        }

        private void LoadPlaylists()
        {
            try
            {
                if (System.IO.File.Exists(PlaylistsFileName))
                {
                    var json = System.IO.File.ReadAllText(PlaylistsFileName);
                    Playlists.Clear();
                    Playlists.AddRange(JsonConvert.DeserializeObject<List<Playlist>>(json));
                }
            }
            catch { }
        }

        private void SaveLibrary()
        {
            try
            {
                System.IO.File.WriteAllText(LibraryFileName, JsonConvert.SerializeObject(libraryTracks, Formatting.Indented));
            }
            catch { }
        }

        private void SavePlaylists()
        {
            try
            {
                System.IO.File.WriteAllText(PlaylistsFileName, JsonConvert.SerializeObject(Playlists, Formatting.Indented));
            }
            catch { }
        }

        private void RefreshPlaylistButtons()
        {
            flpPlaylists.Controls.Clear();

            var libBtn = new Button { Size = new Size(80, 80), Text = "Бібліотека" };
            libBtn.Click += (s, e) => ShowLibrary();
            flpPlaylists.Controls.Add(libBtn);

            for (int i = 0; i < Playlists.Count; i++)
            {
                var pl = Playlists[i];
                var btn = new Button { Size = new Size(80, 80), Text = pl.Name, Tag = i };
                btn.Click += PlaylistButton_Click;
                flpPlaylists.Controls.Add(btn);
            }

            var addBtn = new Button { Size = new Size(80, 80), Text = "+" };
            addBtn.Click += (s, e) => ShowNewPlaylistPanel();
            flpPlaylists.Controls.Add(addBtn);
        }

        private void InitializePlayer()
        {
            buttonPlayPause.Click += ButtonPlayPause_Click;
            buttonNext.Click += ButtonNext_Click;
            buttonPrevious.Click += ButtonPrevious_Click;
            buttonPlaylistToggle.Click += ButtonPlaylistToggle_Click;
            buttonQueueToggle.Click += ButtonQueueToggle_Click;
            buttonEllipsis.Click += ButtonEllipsis_Click;
            cmsPlaylistMenu.ItemClicked += CmsPlaylistMenu_ItemClicked;
            buttonCreate.Click += ButtonCreate_Click;
            buttonCancel.Click += ButtonCancel_Click;
            buttonAddToPlaylist.Click += ButtonAddToPlaylist_Click;
            buttonAddFromLibrary.Click += ButtonAddFromLibrary_Click;
            listBoxTracks.SelectedIndexChanged += ListBoxTracks_SelectedIndexChanged;
            listBoxPlaylistTracks.SelectedIndexChanged += ListBoxPlaylistTracks_SelectedIndexChanged;

            timer = new Timer { Interval = 1000 };
            timer.Tick += Timer_Tick;

            FormClosing += Form1_FormClosing;
        }

        private void ButtonAddFromLibrary_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog
            {
                Filter = "Музика і відео|*.mp3;*.wav;*.wma;*.flac;*.aac;*.ogg;*.mp4;*.mkv;*.avi;*.mov;*.wmv",
                Multiselect = true
            })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    foreach (var f in ofd.FileNames)
                        if (!libraryTracks.Contains(f) && System.IO.File.Exists(f))
                            libraryTracks.Add(f);
                    SaveLibrary();
                    ShowLibrary();
                }
            }
        }

        private void ShowLibrary()
        {
            currentPlaylist = null;
            labelPlaylistName.Visible = false;

            listBoxPlaylistTracks.Items.Clear();
            foreach (var f in libraryTracks)
                listBoxPlaylistTracks.Items.Add(new TrackItem { FilePath = f });

            listBoxPlaylistTracks.Visible = true;
            buttonAddFromLibrary.Visible = true;
            buttonAddToPlaylist.Visible = false;
            panelPlaylist.Visible = true;
            pictureBoxMusic.Visible = false;
            listBoxTracks.Visible = false;
            labelSongInfo.Visible = false;
        }

        private void PlaylistButton_Click(object sender, EventArgs e)
        {
            int idx = (int)((Button)sender).Tag;
            currentPlaylist = Playlists[idx];
            labelPlaylistName.Text = currentPlaylist.Name;
            labelPlaylistName.Visible = true;

            listBoxPlaylistTracks.Items.Clear();
            foreach (var f in currentPlaylist.Tracks)
                listBoxPlaylistTracks.Items.Add(new TrackItem { FilePath = f });

            listBoxPlaylistTracks.Visible = true;
            buttonAddToPlaylist.Visible = true;
            buttonAddFromLibrary.Visible = false;
            panelPlaylist.Visible = true;
            pictureBoxMusic.Visible = false;
            listBoxTracks.Visible = false;
            labelSongInfo.Visible = false;
        }

        private void ButtonPlaylistToggle_Click(object sender, EventArgs e)
        {
            panelPlaylist.Visible = !panelPlaylist.Visible;
            if (!panelPlaylist.Visible)
                ShowImageView();

            buttonAddToPlaylist.Visible = false;
            buttonAddFromLibrary.Visible = false;
        }

        private void ButtonQueueToggle_Click(object sender, EventArgs e)
        {
            if (listBoxTracks.Visible)
                ShowImageView();
            else
                ShowQueue();
        }

        private void ShowQueue()
        {
            pictureBoxMusic.Visible = false;
            listBoxPlaylistTracks.Visible = false;
            panelPlaylist.Visible = false;

            listBoxTracks.Items.Clear();
            if (currentPlaylist != null)
            {
                foreach (var f in currentPlaylist.Tracks)
                    listBoxTracks.Items.Add(new TrackItem { FilePath = f });
                labelPlaylistName.Text = currentPlaylist.Name;
                labelPlaylistName.Visible = true;
            }
            else
            {
                foreach (var f in libraryTracks)
                    listBoxTracks.Items.Add(new TrackItem { FilePath = f });
                labelPlaylistName.Visible = false;
            }

            listBoxTracks.Visible = true;
            labelSongInfo.Visible = true;

            if (listBoxTracks.Items.Count > 0 && currentTrackIndex >= 0 && currentTrackIndex < listBoxTracks.Items.Count)
                listBoxTracks.SelectedIndex = currentTrackIndex;

            buttonAddToPlaylist.Visible = false;
            buttonAddFromLibrary.Visible = false;
        }

        private void ShowImageView()
        {
            using (var ms = new MemoryStream(Properties.Resources._5305559464683890721p))
            {
                pictureBoxMusic.Image = Image.FromStream(ms);
            }
            pictureBoxMusic.Visible = true;
            listBoxTracks.Visible = false;
            listBoxPlaylistTracks.Visible = false;
            panelPlaylist.Visible = false;

            labelSongInfo.Visible = !string.IsNullOrEmpty(labelSongInfo.Text);
            labelPlaylistName.Visible = (currentPlaylist != null) && !string.IsNullOrEmpty(labelPlaylistName.Text);

            buttonAddToPlaylist.Visible = false;
            buttonAddFromLibrary.Visible = false;
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            ListBox active = listBoxTracks.Visible ? listBoxTracks : listBoxPlaylistTracks;
            if (active.Items.Count == 0) return;
            currentTrackIndex = (active.SelectedIndex + 1) % active.Items.Count;
            active.SelectedIndex = currentTrackIndex;
        }

        private void ButtonPrevious_Click(object sender, EventArgs e)
        {
            ListBox active = listBoxTracks.Visible ? listBoxTracks : listBoxPlaylistTracks;
            if (active.Items.Count == 0) return;
            currentTrackIndex = (active.SelectedIndex - 1 + active.Items.Count) % active.Items.Count;
            active.SelectedIndex = currentTrackIndex;
        }

        private void ListBoxTracks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxTracks.SelectedItem is TrackItem ti)
                PlayTrack(ti.FilePath);
        }

        private void ListBoxPlaylistTracks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPlaylistTracks.SelectedItem is TrackItem ti)
                PlayTrack(ti.FilePath);
        }

        private void ButtonPlayPause_Click(object sender, EventArgs e)
        {
            if (outputDevice == null || audioFile == null) return;
            if (outputDevice.PlaybackState == PlaybackState.Playing)
            {
                outputDevice.Pause();
                buttonPlayPause.Text = "▶️";
                timer.Stop();
            }
            else
            {
                outputDevice.Play();
                buttonPlayPause.Text = "⏸️";
                timer.Start();
            }
        }

        private void ButtonAddToPlaylist_Click(object sender, EventArgs e)
        {
            if (currentPlaylist == null) return;

            using (var dlg = new Form { Text = "Виберіть треки з бібліотеки", Size = new Size(400, 300) })
            {
                var clb = new CheckedListBox { Dock = DockStyle.Top, Height = 200 };

                foreach (var path in libraryTracks)
                {
                    string display = GetTitleAndArtist(path);
                    clb.Items.Add(new DisplayTrack(path, display));
                }

                var pnl = new Panel { Dock = DockStyle.Bottom, Height = 40 };
                var ok = new Button { Text = "OK", DialogResult = DialogResult.OK, Dock = DockStyle.Left, Width = 80 };
                var cancel = new Button { Text = "Скасувати", DialogResult = DialogResult.Cancel, Dock = DockStyle.Right, Width = 80 };
                pnl.Controls.Add(ok);
                pnl.Controls.Add(cancel);
                dlg.Controls.Add(clb);
                dlg.Controls.Add(pnl);
                dlg.AcceptButton = ok;
                dlg.CancelButton = cancel;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    foreach (int i in clb.CheckedIndices)
                    {
                        var dt = (DisplayTrack)clb.Items[i];
                        var path = dt.FilePath;
                        if (!currentPlaylist.Tracks.Contains(path))
                            currentPlaylist.Tracks.Add(path);
                    }
                    SavePlaylists();
                    PlaylistButton_Click(flpPlaylists.Controls[1 + Playlists.IndexOf(currentPlaylist)], null);
                }
            }
        }

        private string GetTitleAndArtist(string filePath)
        {
            try
            {
                var tfile = TagLib.File.Create(filePath);
                string artist = tfile.Tag.FirstPerformer ?? "";
                string title = tfile.Tag.Title ?? Path.GetFileNameWithoutExtension(filePath);
                if (!string.IsNullOrEmpty(artist))
                    return $"{artist} - {title}";
                else
                    return title;
            }
            catch
            {
                return Path.GetFileNameWithoutExtension(filePath);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (audioFile != null && outputDevice.PlaybackState == PlaybackState.Playing)
            {
                var current = audioFile.CurrentTime;
                labelTime.Text = current.ToString(@"hh\:mm\:ss");
                if (audioFile.TotalTime.TotalSeconds > 0)
                    progressBar.Value = (int)(current.TotalSeconds / audioFile.TotalTime.TotalSeconds * 100);
                else
                    progressBar.Value = 0;
            }
        }

        private void ButtonEllipsis_Click(object sender, EventArgs e)
        {
            cmsPlaylistMenu.Show(buttonEllipsis, new Point(0, buttonEllipsis.Height));
        }

        private void CmsPlaylistMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var item = e.ClickedItem;
            if (item == tsmiAddTracks && currentPlaylist != null)
            {
                ButtonAddToPlaylist_Click(null, null);
            }
            else if (item == tsmiSearchTracks)
            {
                ButtonAddFromLibrary_Click(null, null);
            }
            else if (item == tsmiRemoveTrack)
            {
                if (currentPlaylist != null)
                {
                    if (listBoxPlaylistTracks.SelectedItem is TrackItem ti)
                        currentPlaylist.Tracks.Remove(ti.FilePath);
                    SavePlaylists();
                    PlaylistButton_Click(flpPlaylists.Controls[1 + Playlists.IndexOf(currentPlaylist)], null);
                }
                else
                {
                    if (listBoxPlaylistTracks.SelectedItem is TrackItem ti)
                        libraryTracks.Remove(ti.FilePath);
                    SaveLibrary();
                    ShowLibrary();
                }
            }
            else if (item == tsmiDeletePlaylist && currentPlaylist != null)
            {
                Playlists.Remove(currentPlaylist);
                SavePlaylists();
                ShowLibrary();
                RefreshPlaylistButtons();
            }
            else if (item == tsmiRenamePlaylist && currentPlaylist != null)
            {
                ShowNewPlaylistPanel(rename: true);
            }
        }

        private void ShowNewPlaylistPanel(bool rename = false)
        {
            panelNewPlaylist.Visible = true;
            textBoxNewName.Text = rename ? currentPlaylist.Name : "";
            buttonCreate.Text = rename ? "Перейменувати" : "Створити";
        }

        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            var name = textBoxNewName.Text.Trim();
            if (string.IsNullOrEmpty(name)) { MessageBox.Show("Введіть назву"); return; }
            if (buttonCreate.Text == "Перейменувати" && currentPlaylist != null)
                currentPlaylist.Name = name;
            else
                Playlists.Add(new Playlist { Name = name });
            SavePlaylists();
            panelNewPlaylist.Visible = false;
            textBoxNewName.Clear();
            RefreshPlaylistButtons();
            ShowLibrary();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            panelNewPlaylist.Visible = false;
            textBoxNewName.Clear();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveLibrary();
            SavePlaylists();
        }

        private void PlayTrack(string path)
        {
            if (!System.IO.File.Exists(path)) return;

            try
            {
                outputDevice?.Stop();
                outputDevice?.Dispose();
                audioFile?.Dispose();

                audioFile = new AudioFileReader(path);
                outputDevice = new WaveOutEvent();
                outputDevice.Init(audioFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не вдалося відкрити файл: {ex.Message}");
                return;
            }

            labelSongInfo.Text = GetTitleAndArtist(path);
            labelSongInfo.Visible = true;

            if (listBoxTracks.Visible)
            {
                for (int i = 0; i < listBoxTracks.Items.Count; i++)
                    if (((TrackItem)listBoxTracks.Items[i]).FilePath == path)
                        currentTrackIndex = i;
                listBoxTracks.SelectedIndex = currentTrackIndex;
            }
            else if (listBoxPlaylistTracks.Visible)
            {
                for (int i = 0; i < listBoxPlaylistTracks.Items.Count; i++)
                    if (((TrackItem)listBoxPlaylistTracks.Items[i]).FilePath == path)
                        currentTrackIndex = i;
                listBoxPlaylistTracks.SelectedIndex = currentTrackIndex;
            }

            outputDevice.Play();
            buttonPlayPause.Text = "⏸";
            timer.Start();
        }
    }

    public class TrackItem
    {
        public string FilePath { get; set; }
        public override string ToString() => Path.GetFileName(FilePath);

        public override bool Equals(object obj)
        {
            if (obj is TrackItem t) return t.FilePath == FilePath;
            return false;
        }
        public override int GetHashCode() => FilePath.GetHashCode();
    }

    public class Playlist
    {
        public string Name { get; set; }
        public List<string> Tracks { get; set; } = new List<string>();
    }

    public class DisplayTrack
    {
        public string FilePath { get; set; }
        public string Display { get; set; }
        public DisplayTrack(string path, string display) { FilePath = path; Display = display; }
        public override string ToString() => Display;
    }
}
