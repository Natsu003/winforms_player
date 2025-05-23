using System.Drawing;

namespace Player2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        public System.Windows.Forms.Button buttonPlayPause;
        public System.Windows.Forms.Button buttonNext;
        public System.Windows.Forms.Button buttonPrevious;
        public System.Windows.Forms.Button buttonPlaylistToggle;
        public System.Windows.Forms.Label labelTime;
        public System.Windows.Forms.Label labelSongInfo;
        public System.Windows.Forms.Panel panelControls;
        public System.Windows.Forms.PictureBox pictureBoxMusic;
        public System.Windows.Forms.Label labelPlaylistName;

        public System.Windows.Forms.Panel panelPlaylist;
        public System.Windows.Forms.Button buttonEllipsis;
        public System.Windows.Forms.ContextMenuStrip cmsPlaylistMenu;
        public System.Windows.Forms.ToolStripMenuItem tsmiAddTracks;
        public System.Windows.Forms.ToolStripMenuItem tsmiSearchTracks;
        public System.Windows.Forms.ToolStripMenuItem tsmiRemoveTrack;
        public System.Windows.Forms.ToolStripMenuItem tsmiDeletePlaylist;
        public System.Windows.Forms.ToolStripMenuItem tsmiRenamePlaylist;

        public System.Windows.Forms.Panel panelNewPlaylist;
        public System.Windows.Forms.TextBox textBoxNewName;
        public System.Windows.Forms.Button buttonCreate;
        public System.Windows.Forms.Button buttonCancel;

        public System.Windows.Forms.ListBox listBoxPlaylistTracks;
        public System.Windows.Forms.Button buttonAddToPlaylist;
        public System.Windows.Forms.Button buttonAddFromLibrary;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonPlayPause = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.buttonPlaylistToggle = new System.Windows.Forms.Button();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelSongInfo = new System.Windows.Forms.Label();
            this.panelControls = new System.Windows.Forms.Panel();
            this.trackBarProgress = new System.Windows.Forms.TrackBar();
            this.buttonRepeat = new System.Windows.Forms.Button();
            this.buttonShuffle = new System.Windows.Forms.Button();
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.pictureBoxMusic = new System.Windows.Forms.PictureBox();
            this.labelPlaylistName = new System.Windows.Forms.Label();
            this.panelPlaylist = new System.Windows.Forms.Panel();
            this.flpPlaylists = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonEllipsis = new System.Windows.Forms.Button();
            this.cmsPlaylistMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAddTracks = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSearchTracks = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRemoveTrack = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeletePlaylist = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRenamePlaylist = new System.Windows.Forms.ToolStripMenuItem();
            this.panelNewPlaylist = new System.Windows.Forms.Panel();
            this.textBoxNewName = new System.Windows.Forms.TextBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.listBoxPlaylistTracks = new System.Windows.Forms.ListBox();
            this.buttonAddToPlaylist = new System.Windows.Forms.Button();
            this.buttonAddFromLibrary = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panelControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarProgress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMusic)).BeginInit();
            this.panelPlaylist.SuspendLayout();
            this.cmsPlaylistMenu.SuspendLayout();
            this.panelNewPlaylist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonPlayPause
            // 
            this.buttonPlayPause.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonPlayPause.BackColor = System.Drawing.Color.Green;
            this.buttonPlayPause.FlatAppearance.BorderSize = 0;
            this.buttonPlayPause.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonPlayPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold);
            this.buttonPlayPause.ForeColor = System.Drawing.Color.White;
            this.buttonPlayPause.Location = new System.Drawing.Point(462, 57);
            this.buttonPlayPause.Name = "buttonPlayPause";
            this.buttonPlayPause.Size = new System.Drawing.Size(75, 75);
            this.buttonPlayPause.TabIndex = 2;
            this.buttonPlayPause.Text = "▶️";
            this.toolTip1.SetToolTip(this.buttonPlayPause, "Відтворення/Пауза");
            this.buttonPlayPause.UseVisualStyleBackColor = false;
            this.buttonPlayPause.Click += new System.EventHandler(this.buttonPlayPause_Click_1);
            // 
            // buttonNext
            // 
            this.buttonNext.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonNext.BackColor = System.Drawing.Color.Blue;
            this.buttonNext.FlatAppearance.BorderSize = 0;
            this.buttonNext.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.buttonNext.ForeColor = System.Drawing.Color.White;
            this.buttonNext.Location = new System.Drawing.Point(575, 69);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(50, 50);
            this.buttonNext.TabIndex = 3;
            this.buttonNext.Text = ">";
            this.toolTip1.SetToolTip(this.buttonNext, "Наступний трек");
            this.buttonNext.UseVisualStyleBackColor = false;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click_1);
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonPrevious.BackColor = System.Drawing.Color.Blue;
            this.buttonPrevious.FlatAppearance.BorderSize = 0;
            this.buttonPrevious.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.buttonPrevious.ForeColor = System.Drawing.Color.White;
            this.buttonPrevious.Location = new System.Drawing.Point(375, 69);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(50, 50);
            this.buttonPrevious.TabIndex = 4;
            this.buttonPrevious.Text = "<";
            this.toolTip1.SetToolTip(this.buttonPrevious, "Попередній трек");
            this.buttonPrevious.UseVisualStyleBackColor = false;
            this.buttonPrevious.Click += new System.EventHandler(this.buttonPrevious_Click_1);
            // 
            // buttonPlaylistToggle
            // 
            this.buttonPlaylistToggle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonPlaylistToggle.BackColor = System.Drawing.Color.DarkGray;
            this.buttonPlaylistToggle.FlatAppearance.BorderSize = 0;
            this.buttonPlaylistToggle.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonPlaylistToggle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.buttonPlaylistToggle.ForeColor = System.Drawing.Color.White;
            this.buttonPlaylistToggle.Location = new System.Drawing.Point(118, 61);
            this.buttonPlaylistToggle.Name = "buttonPlaylistToggle";
            this.buttonPlaylistToggle.Size = new System.Drawing.Size(60, 60);
            this.buttonPlaylistToggle.TabIndex = 13;
            this.buttonPlaylistToggle.Text = "📁";
            this.toolTip1.SetToolTip(this.buttonPlaylistToggle, "Плейлисти");
            this.buttonPlaylistToggle.UseVisualStyleBackColor = false;
            this.buttonPlaylistToggle.Click += new System.EventHandler(this.buttonPlaylistToggle_Click_1);
            // 
            // labelTime
            // 
            this.labelTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTime.Location = new System.Drawing.Point(10, 57);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(70, 16);
            this.labelTime.TabIndex = 1;
            this.labelTime.Text = "00:00:00";
            // 
            // labelSongInfo
            // 
            this.labelSongInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSongInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelSongInfo.Location = new System.Drawing.Point(172, 288);
            this.labelSongInfo.Name = "labelSongInfo";
            this.labelSongInfo.Size = new System.Drawing.Size(665, 20);
            this.labelSongInfo.TabIndex = 15;
            this.labelSongInfo.Text = "Назва пісні - Виконавець";
            this.labelSongInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelControls
            // 
            this.panelControls.BackColor = System.Drawing.Color.LightGray;
            this.panelControls.Controls.Add(this.trackBarProgress);
            this.panelControls.Controls.Add(this.buttonRepeat);
            this.panelControls.Controls.Add(this.buttonShuffle);
            this.panelControls.Controls.Add(this.trackBarVolume);
            this.panelControls.Controls.Add(this.labelTime);
            this.panelControls.Controls.Add(this.buttonPlayPause);
            this.panelControls.Controls.Add(this.buttonNext);
            this.panelControls.Controls.Add(this.buttonPrevious);
            this.panelControls.Controls.Add(this.buttonPlaylistToggle);
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControls.Location = new System.Drawing.Point(0, 316);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(982, 137);
            this.panelControls.TabIndex = 1;
            // 
            // trackBarProgress
            // 
            this.trackBarProgress.BackColor = System.Drawing.Color.LightGray;
            this.trackBarProgress.Dock = System.Windows.Forms.DockStyle.Top;
            this.trackBarProgress.Location = new System.Drawing.Point(0, 0);
            this.trackBarProgress.Maximum = 100;
            this.trackBarProgress.Name = "trackBarProgress";
            this.trackBarProgress.Size = new System.Drawing.Size(982, 56);
            this.trackBarProgress.TabIndex = 18;
            this.trackBarProgress.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarProgress.Scroll += new System.EventHandler(this.trackBarProgress_Scroll);
            // 
            // buttonRepeat
            // 
            this.buttonRepeat.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonRepeat.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonRepeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonRepeat.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonRepeat.Location = new System.Drawing.Point(664, 75);
            this.buttonRepeat.Name = "buttonRepeat";
            this.buttonRepeat.Size = new System.Drawing.Size(30, 30);
            this.buttonRepeat.TabIndex = 17;
            this.buttonRepeat.Text = "🔁";
            this.toolTip1.SetToolTip(this.buttonRepeat, "Повторення");
            this.buttonRepeat.UseVisualStyleBackColor = true;
            this.buttonRepeat.Click += new System.EventHandler(this.buttonRepeat_Click);
            // 
            // buttonShuffle
            // 
            this.buttonShuffle.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonShuffle.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonShuffle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonShuffle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonShuffle.Location = new System.Drawing.Point(292, 75);
            this.buttonShuffle.Name = "buttonShuffle";
            this.buttonShuffle.Size = new System.Drawing.Size(30, 30);
            this.buttonShuffle.TabIndex = 16;
            this.buttonShuffle.Text = "🔀";
            this.toolTip1.SetToolTip(this.buttonShuffle, "Перемішати треки");
            this.buttonShuffle.UseVisualStyleBackColor = true;
            this.buttonShuffle.Click += new System.EventHandler(this.buttonShuffle_Click);
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarVolume.Location = new System.Drawing.Point(789, 70);
            this.trackBarVolume.Maximum = 100;
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Size = new System.Drawing.Size(154, 56);
            this.trackBarVolume.TabIndex = 15;
            this.trackBarVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.toolTip1.SetToolTip(this.trackBarVolume, "Керування гучністю");
            this.trackBarVolume.Value = 80;
            this.trackBarVolume.Scroll += new System.EventHandler(this.trackBarVolume_Scroll);
            // 
            // pictureBoxMusic
            // 
            this.pictureBoxMusic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxMusic.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxMusic.Name = "pictureBoxMusic";
            this.pictureBoxMusic.Size = new System.Drawing.Size(364, 285);
            this.pictureBoxMusic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxMusic.TabIndex = 10;
            this.pictureBoxMusic.TabStop = false;
            this.pictureBoxMusic.Visible = false;
            // 
            // labelPlaylistName
            // 
            this.labelPlaylistName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPlaylistName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelPlaylistName.Location = new System.Drawing.Point(-17, -11);
            this.labelPlaylistName.Name = "labelPlaylistName";
            this.labelPlaylistName.Size = new System.Drawing.Size(665, 20);
            this.labelPlaylistName.TabIndex = 11;
            this.labelPlaylistName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelPlaylistName.Visible = false;
            // 
            // panelPlaylist
            // 
            this.panelPlaylist.Controls.Add(this.flpPlaylists);
            this.panelPlaylist.Controls.Add(this.buttonEllipsis);
            this.panelPlaylist.Controls.Add(this.panelNewPlaylist);
            this.panelPlaylist.Controls.Add(this.listBoxPlaylistTracks);
            this.panelPlaylist.Controls.Add(this.buttonAddToPlaylist);
            this.panelPlaylist.Controls.Add(this.buttonAddFromLibrary);
            this.panelPlaylist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPlaylist.Location = new System.Drawing.Point(0, 0);
            this.panelPlaylist.Name = "panelPlaylist";
            this.panelPlaylist.Size = new System.Drawing.Size(614, 285);
            this.panelPlaylist.TabIndex = 11;
            this.panelPlaylist.Visible = false;
            // 
            // flpPlaylists
            // 
            this.flpPlaylists.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpPlaylists.AutoSize = true;
            this.flpPlaylists.Location = new System.Drawing.Point(0, 0);
            this.flpPlaylists.Name = "flpPlaylists";
            this.flpPlaylists.Size = new System.Drawing.Size(580, 85);
            this.flpPlaylists.TabIndex = 6;
            this.toolTip1.SetToolTip(this.flpPlaylists, "Список плейлистів");
            // 
            // buttonEllipsis
            // 
            this.buttonEllipsis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEllipsis.AutoSize = true;
            this.buttonEllipsis.ContextMenuStrip = this.cmsPlaylistMenu;
            this.buttonEllipsis.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonEllipsis.Location = new System.Drawing.Point(582, 4);
            this.buttonEllipsis.Name = "buttonEllipsis";
            this.buttonEllipsis.Size = new System.Drawing.Size(30, 30);
            this.buttonEllipsis.TabIndex = 1;
            this.buttonEllipsis.Text = "⋮";
            this.toolTip1.SetToolTip(this.buttonEllipsis, "Меню");
            this.buttonEllipsis.UseVisualStyleBackColor = true;
            this.buttonEllipsis.Click += new System.EventHandler(this.buttonEllipsis_Click_1);
            // 
            // cmsPlaylistMenu
            // 
            this.cmsPlaylistMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsPlaylistMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddTracks,
            this.tsmiSearchTracks,
            this.tsmiRemoveTrack,
            this.tsmiDeletePlaylist,
            this.tsmiRenamePlaylist});
            this.cmsPlaylistMenu.Name = "cmsPlaylistMenu";
            this.cmsPlaylistMenu.Size = new System.Drawing.Size(258, 124);
            this.cmsPlaylistMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmsPlaylistMenu_ItemClicked_1);
            // 
            // tsmiAddTracks
            // 
            this.tsmiAddTracks.Name = "tsmiAddTracks";
            this.tsmiAddTracks.Size = new System.Drawing.Size(257, 24);
            this.tsmiAddTracks.Text = "Додати треки";
            // 
            // tsmiSearchTracks
            // 
            this.tsmiSearchTracks.Name = "tsmiSearchTracks";
            this.tsmiSearchTracks.Size = new System.Drawing.Size(257, 24);
            this.tsmiSearchTracks.Text = "Пошук треків";
            // 
            // tsmiRemoveTrack
            // 
            this.tsmiRemoveTrack.Name = "tsmiRemoveTrack";
            this.tsmiRemoveTrack.Size = new System.Drawing.Size(257, 24);
            this.tsmiRemoveTrack.Text = "Видалити трек";
            // 
            // tsmiDeletePlaylist
            // 
            this.tsmiDeletePlaylist.Name = "tsmiDeletePlaylist";
            this.tsmiDeletePlaylist.Size = new System.Drawing.Size(257, 24);
            this.tsmiDeletePlaylist.Text = "Видалити плейлист";
            // 
            // tsmiRenamePlaylist
            // 
            this.tsmiRenamePlaylist.Name = "tsmiRenamePlaylist";
            this.tsmiRenamePlaylist.Size = new System.Drawing.Size(257, 24);
            this.tsmiRenamePlaylist.Text = "Перейменувати плейлист";
            // 
            // panelNewPlaylist
            // 
            this.panelNewPlaylist.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelNewPlaylist.AutoSize = true;
            this.panelNewPlaylist.Controls.Add(this.textBoxNewName);
            this.panelNewPlaylist.Controls.Add(this.buttonCreate);
            this.panelNewPlaylist.Controls.Add(this.buttonCancel);
            this.panelNewPlaylist.Location = new System.Drawing.Point(137, 97);
            this.panelNewPlaylist.Name = "panelNewPlaylist";
            this.panelNewPlaylist.Size = new System.Drawing.Size(250, 102);
            this.panelNewPlaylist.TabIndex = 2;
            this.panelNewPlaylist.Visible = false;
            // 
            // textBoxNewName
            // 
            this.textBoxNewName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNewName.Location = new System.Drawing.Point(10, 20);
            this.textBoxNewName.Name = "textBoxNewName";
            this.textBoxNewName.Size = new System.Drawing.Size(230, 22);
            this.textBoxNewName.TabIndex = 0;
            // 
            // buttonCreate
            // 
            this.buttonCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCreate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonCreate.Location = new System.Drawing.Point(10, 55);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(100, 42);
            this.buttonCreate.TabIndex = 1;
            this.buttonCreate.Text = "Створити";
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click_1);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonCancel.Location = new System.Drawing.Point(140, 55);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 42);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Скасувати";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click_1);
            // 
            // listBoxPlaylistTracks
            // 
            this.listBoxPlaylistTracks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxPlaylistTracks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxPlaylistTracks.ColumnWidth = 10;
            this.listBoxPlaylistTracks.FormattingEnabled = true;
            this.listBoxPlaylistTracks.HorizontalExtent = 10;
            this.listBoxPlaylistTracks.ItemHeight = 16;
            this.listBoxPlaylistTracks.Location = new System.Drawing.Point(29, 122);
            this.listBoxPlaylistTracks.Margin = new System.Windows.Forms.Padding(6);
            this.listBoxPlaylistTracks.Name = "listBoxPlaylistTracks";
            this.listBoxPlaylistTracks.Size = new System.Drawing.Size(545, 160);
            this.listBoxPlaylistTracks.TabIndex = 3;
            this.toolTip1.SetToolTip(this.listBoxPlaylistTracks, "Список відтворення");
            this.listBoxPlaylistTracks.Visible = false;
            this.listBoxPlaylistTracks.SelectedIndexChanged += new System.EventHandler(this.listBoxPlaylistTracks_SelectedIndexChanged);
            // 
            // buttonAddToPlaylist
            // 
            this.buttonAddToPlaylist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddToPlaylist.AutoSize = true;
            this.buttonAddToPlaylist.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonAddToPlaylist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.buttonAddToPlaylist.Location = new System.Drawing.Point(580, 217);
            this.buttonAddToPlaylist.Name = "buttonAddToPlaylist";
            this.buttonAddToPlaylist.Size = new System.Drawing.Size(30, 30);
            this.buttonAddToPlaylist.TabIndex = 4;
            this.buttonAddToPlaylist.Text = "+";
            this.toolTip1.SetToolTip(this.buttonAddToPlaylist, "Додати трек до плейлиста");
            this.buttonAddToPlaylist.Visible = false;
            this.buttonAddToPlaylist.Click += new System.EventHandler(this.buttonAddToPlaylist_Click);
            // 
            // buttonAddFromLibrary
            // 
            this.buttonAddFromLibrary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddFromLibrary.AutoSize = true;
            this.buttonAddFromLibrary.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonAddFromLibrary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.buttonAddFromLibrary.Location = new System.Drawing.Point(580, 251);
            this.buttonAddFromLibrary.Name = "buttonAddFromLibrary";
            this.buttonAddFromLibrary.Size = new System.Drawing.Size(30, 30);
            this.buttonAddFromLibrary.TabIndex = 5;
            this.buttonAddFromLibrary.Text = "+";
            this.toolTip1.SetToolTip(this.buttonAddFromLibrary, "Додавання треків до бібліотеки");
            this.buttonAddFromLibrary.Visible = false;
            this.buttonAddFromLibrary.Click += new System.EventHandler(this.buttonAddFromLibrary_Click_1);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panelPlaylist);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pictureBoxMusic);
            this.splitContainer1.Size = new System.Drawing.Size(982, 285);
            this.splitContainer1.SplitterDistance = 614;
            this.splitContainer1.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(982, 453);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panelControls);
            this.Controls.Add(this.labelPlaylistName);
            this.Controls.Add(this.labelSongInfo);
            this.Name = "Form1";
            this.Text = "Player2";
            this.panelControls.ResumeLayout(false);
            this.panelControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarProgress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMusic)).EndInit();
            this.panelPlaylist.ResumeLayout(false);
            this.panelPlaylist.PerformLayout();
            this.cmsPlaylistMenu.ResumeLayout(false);
            this.panelNewPlaylist.ResumeLayout(false);
            this.panelNewPlaylist.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel flpPlaylists;
        private System.Windows.Forms.TrackBar trackBarVolume;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button buttonRepeat;
        private System.Windows.Forms.Button buttonShuffle;
        private System.Windows.Forms.TrackBar trackBarProgress;
    }
}