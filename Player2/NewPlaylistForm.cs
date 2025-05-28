using System;
using System.Windows.Forms;

namespace Player2
{
    public partial class NewPlaylistForm : Form
    {
        public string PlaylistName { get; private set; }

        // Конструктор з аргументом (назва плейліста або порожній рядок)
        public NewPlaylistForm(string initialName = "")
        {
            InitializeComponent();
            textBox1.Text = initialName;
            textBox1.SelectAll();
            textBox1.Focus();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            PlaylistName = textBox1.Text.Trim();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

