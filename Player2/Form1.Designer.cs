namespace Player2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        public System.Windows.Forms.ListBox listBoxTracks;
        public System.Windows.Forms.Button buttonPlayPause;
        public System.Windows.Forms.Button buttonNext;
        public System.Windows.Forms.Button buttonPrevious;
        public System.Windows.Forms.Button buttonPlaylistToggle;
        public System.Windows.Forms.Button buttonQueueToggle;
        public System.Windows.Forms.ProgressBar progressBar;
        public System.Windows.Forms.Label labelTime;
        public System.Windows.Forms.Label labelSongInfo;
        public System.Windows.Forms.Panel panelControls;
        public System.Windows.Forms.PictureBox pictureBoxMusic;
        public System.Windows.Forms.Label labelPlaylistName;

        public System.Windows.Forms.Panel panelPlaylist;
        public System.Windows.Forms.FlowLayoutPanel flpPlaylists;
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
            this.listBoxTracks = new System.Windows.Forms.ListBox();
            this.buttonPlayPause = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.buttonPlaylistToggle = new System.Windows.Forms.Button();
            this.buttonQueueToggle = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelSongInfo = new System.Windows.Forms.Label();
            this.panelControls = new System.Windows.Forms.Panel();
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
            this.panelControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMusic)).BeginInit();
            this.panelPlaylist.SuspendLayout();
            this.cmsPlaylistMenu.SuspendLayout();
            this.panelNewPlaylist.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxTracks
            // 
            this.listBoxTracks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxTracks.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.listBoxTracks.ItemHeight = 20;
            this.listBoxTracks.Location = new System.Drawing.Point(160, 30);
            this.listBoxTracks.Name = "listBoxTracks";
            this.listBoxTracks.Size = new System.Drawing.Size(665, 224);
            this.listBoxTracks.TabIndex = 12;
            // 
            // buttonPlayPause
            // 
            this.buttonPlayPause.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonPlayPause.BackColor = System.Drawing.Color.Green;
            this.buttonPlayPause.FlatAppearance.BorderSize = 0;
            this.buttonPlayPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlayPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold);
            this.buttonPlayPause.ForeColor = System.Drawing.Color.White;
            this.buttonPlayPause.Location = new System.Drawing.Point(462, 48);
            this.buttonPlayPause.Name = "buttonPlayPause";
            this.buttonPlayPause.Size = new System.Drawing.Size(75, 75);
            this.buttonPlayPause.TabIndex = 2;
            this.buttonPlayPause.Text = "▶️";
            this.buttonPlayPause.UseVisualStyleBackColor = false;
            // 
            // buttonNext
            // 
            this.buttonNext.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonNext.BackColor = System.Drawing.Color.Blue;
            this.buttonNext.FlatAppearance.BorderSize = 0;
            this.buttonNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.buttonNext.ForeColor = System.Drawing.Color.White;
            this.buttonNext.Location = new System.Drawing.Point(575, 60);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(50, 50);
            this.buttonNext.TabIndex = 3;
            this.buttonNext.Text = ">";
            this.buttonNext.UseVisualStyleBackColor = false;
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonPrevious.BackColor = System.Drawing.Color.Blue;
            this.buttonPrevious.FlatAppearance.BorderSize = 0;
            this.buttonPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.buttonPrevious.ForeColor = System.Drawing.Color.White;
            this.buttonPrevious.Location = new System.Drawing.Point(375, 60);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(50, 50);
            this.buttonPrevious.TabIndex = 4;
            this.buttonPrevious.Text = "<";
            this.buttonPrevious.UseVisualStyleBackColor = false;
            // 
            // buttonPlaylistToggle
            // 
            this.buttonPlaylistToggle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonPlaylistToggle.BackColor = System.Drawing.Color.DarkGray;
            this.buttonPlaylistToggle.FlatAppearance.BorderSize = 0;
            this.buttonPlaylistToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlaylistToggle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.buttonPlaylistToggle.ForeColor = System.Drawing.Color.White;
            this.buttonPlaylistToggle.Location = new System.Drawing.Point(100, 250);
            this.buttonPlaylistToggle.Name = "buttonPlaylistToggle";
            this.buttonPlaylistToggle.Size = new System.Drawing.Size(60, 60);
            this.buttonPlaylistToggle.TabIndex = 13;
            this.buttonPlaylistToggle.Text = "📁";
            this.buttonPlaylistToggle.UseVisualStyleBackColor = false;
            // 
            // buttonQueueToggle
            // 
            this.buttonQueueToggle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonQueueToggle.BackColor = System.Drawing.Color.Gray;
            this.buttonQueueToggle.FlatAppearance.BorderSize = 0;
            this.buttonQueueToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonQueueToggle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.buttonQueueToggle.ForeColor = System.Drawing.Color.White;
            this.buttonQueueToggle.Location = new System.Drawing.Point(825, 250);
            this.buttonQueueToggle.Name = "buttonQueueToggle";
            this.buttonQueueToggle.Size = new System.Drawing.Size(60, 60);
            this.buttonQueueToggle.TabIndex = 14;
            this.buttonQueueToggle.Text = "☰";
            this.buttonQueueToggle.UseVisualStyleBackColor = false;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(10, 15);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(960, 10);
            this.progressBar.TabIndex = 0;
            // 
            // labelTime
            // 
            this.labelTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTime.Location = new System.Drawing.Point(10, 30);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(60, 16);
            this.labelTime.TabIndex = 1;
            this.labelTime.Text = "00:00:00";
            // 
            // labelSongInfo
            // 
            this.labelSongInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSongInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelSongInfo.Location = new System.Drawing.Point(160, 270);
            this.labelSongInfo.Name = "labelSongInfo";
            this.labelSongInfo.Size = new System.Drawing.Size(665, 20);
            this.labelSongInfo.TabIndex = 15;
            this.labelSongInfo.Text = "Назва пісні - Виконавець";
            this.labelSongInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelControls
            // 
            this.panelControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControls.BackColor = System.Drawing.Color.LightGray;
            this.panelControls.Controls.Add(this.progressBar);
            this.panelControls.Controls.Add(this.labelTime);
            this.panelControls.Controls.Add(this.buttonPlayPause);
            this.panelControls.Controls.Add(this.buttonNext);
            this.panelControls.Controls.Add(this.buttonPrevious);
            this.panelControls.Location = new System.Drawing.Point(0, 316);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(982, 137);
            this.panelControls.TabIndex = 1;
            // 
            // pictureBoxMusic
            // 
            this.pictureBoxMusic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxMusic.Location = new System.Drawing.Point(160, 30);
            this.pictureBoxMusic.Name = "pictureBoxMusic";
            this.pictureBoxMusic.Size = new System.Drawing.Size(665, 224);
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
            this.labelPlaylistName.Location = new System.Drawing.Point(160, 5);
            this.labelPlaylistName.Name = "labelPlaylistName";
            this.labelPlaylistName.Size = new System.Drawing.Size(665, 20);
            this.labelPlaylistName.TabIndex = 11;
            this.labelPlaylistName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelPlaylistName.Visible = false;
            // 
            // panelPlaylist
            // 
            this.panelPlaylist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPlaylist.Controls.Add(this.flpPlaylists);
            this.panelPlaylist.Controls.Add(this.buttonEllipsis);
            this.panelPlaylist.Controls.Add(this.panelNewPlaylist);
            this.panelPlaylist.Controls.Add(this.listBoxPlaylistTracks);
            this.panelPlaylist.Controls.Add(this.buttonAddToPlaylist);
            this.panelPlaylist.Controls.Add(this.buttonAddFromLibrary);
            this.panelPlaylist.Location = new System.Drawing.Point(160, 5);
            this.panelPlaylist.Name = "panelPlaylist";
            this.panelPlaylist.Size = new System.Drawing.Size(665, 300);
            this.panelPlaylist.TabIndex = 11;
            this.panelPlaylist.Visible = false;
            // 
            // flpPlaylists
            // 
            this.flpPlaylists.AutoScroll = true;
            this.flpPlaylists.Location = new System.Drawing.Point(0, 0);
            this.flpPlaylists.Name = "flpPlaylists";
            this.flpPlaylists.Size = new System.Drawing.Size(635, 122);
            this.flpPlaylists.TabIndex = 0;
            // 
            // buttonEllipsis
            // 
            this.buttonEllipsis.ContextMenuStrip = this.cmsPlaylistMenu;
            this.buttonEllipsis.Location = new System.Drawing.Point(640, 3);
            this.buttonEllipsis.Name = "buttonEllipsis";
            this.buttonEllipsis.Size = new System.Drawing.Size(20, 20);
            this.buttonEllipsis.TabIndex = 1;
            this.buttonEllipsis.Text = "⋮";
            this.buttonEllipsis.UseVisualStyleBackColor = true;
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
            this.panelNewPlaylist.Controls.Add(this.textBoxNewName);
            this.panelNewPlaylist.Controls.Add(this.buttonCreate);
            this.panelNewPlaylist.Controls.Add(this.buttonCancel);
            this.panelNewPlaylist.Location = new System.Drawing.Point(200, 130);
            this.panelNewPlaylist.Name = "panelNewPlaylist";
            this.panelNewPlaylist.Size = new System.Drawing.Size(250, 100);
            this.panelNewPlaylist.TabIndex = 2;
            this.panelNewPlaylist.Visible = false;
            // 
            // textBoxNewName
            // 
            this.textBoxNewName.Location = new System.Drawing.Point(10, 20);
            this.textBoxNewName.Name = "textBoxNewName";
            this.textBoxNewName.Size = new System.Drawing.Size(230, 22);
            this.textBoxNewName.TabIndex = 0;
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(10, 55);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(100, 35);
            this.buttonCreate.TabIndex = 1;
            this.buttonCreate.Text = "Створити";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(140, 55);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 35);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Скасувати";
            // 
            // listBoxPlaylistTracks
            // 
            this.listBoxPlaylistTracks.FormattingEnabled = true;
            this.listBoxPlaylistTracks.ItemHeight = 16;
            this.listBoxPlaylistTracks.Location = new System.Drawing.Point(0, 125);
            this.listBoxPlaylistTracks.Name = "listBoxPlaylistTracks";
            this.listBoxPlaylistTracks.Size = new System.Drawing.Size(635, 164);
            this.listBoxPlaylistTracks.TabIndex = 3;
            this.listBoxPlaylistTracks.Visible = false;
            // 
            // buttonAddToPlaylist
            // 
            this.buttonAddToPlaylist.Location = new System.Drawing.Point(637, 270);
            this.buttonAddToPlaylist.Name = "buttonAddToPlaylist";
            this.buttonAddToPlaylist.Size = new System.Drawing.Size(25, 25);
            this.buttonAddToPlaylist.TabIndex = 4;
            this.buttonAddToPlaylist.Text = "+";
            this.buttonAddToPlaylist.Visible = false;
            // 
            // buttonAddFromLibrary
            // 
            this.buttonAddFromLibrary.Location = new System.Drawing.Point(637, 270);
            this.buttonAddFromLibrary.Name = "buttonAddFromLibrary";
            this.buttonAddFromLibrary.Size = new System.Drawing.Size(25, 25);
            this.buttonAddFromLibrary.TabIndex = 5;
            this.buttonAddFromLibrary.Text = "+";
            this.buttonAddFromLibrary.Visible = false;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(982, 453);
            this.Controls.Add(this.panelControls);
            this.Controls.Add(this.pictureBoxMusic);
            this.Controls.Add(this.labelPlaylistName);
            this.Controls.Add(this.listBoxTracks);
            this.Controls.Add(this.buttonPlaylistToggle);
            this.Controls.Add(this.buttonQueueToggle);
            this.Controls.Add(this.labelSongInfo);
            this.Controls.Add(this.panelPlaylist);
            this.Name = "Form1";
            this.Text = "Player2";
            this.panelControls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMusic)).EndInit();
            this.panelPlaylist.ResumeLayout(false);
            this.cmsPlaylistMenu.ResumeLayout(false);
            this.panelNewPlaylist.ResumeLayout(false);
            this.panelNewPlaylist.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}