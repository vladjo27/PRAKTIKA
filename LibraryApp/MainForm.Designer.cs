namespace LibraryApp
{
    partial class MainForm
    {
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabBooks;
        private System.Windows.Forms.TabPage tabReaders;
        private System.Windows.Forms.TabPage tabCheckouts;

        private System.Windows.Forms.DataGridView dgvBooks;
        private System.Windows.Forms.DataGridView dgvReaders;
        private System.Windows.Forms.DataGridView dgvCheckouts;

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnManageUsers;

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabBooks = new System.Windows.Forms.TabPage();
            this.tabReaders = new System.Windows.Forms.TabPage();
            this.tabCheckouts = new System.Windows.Forms.TabPage();

            this.dgvBooks = new System.Windows.Forms.DataGridView();
            this.dgvReaders = new System.Windows.Forms.DataGridView();
            this.dgvCheckouts = new System.Windows.Forms.DataGridView();

            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            this.btnManageUsers = new System.Windows.Forms.Button();

            this.tabControl.SuspendLayout();
            this.tabBooks.SuspendLayout();
            this.tabReaders.SuspendLayout();
            this.tabCheckouts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReaders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckouts)).BeginInit();
            this.SuspendLayout();
            // 
            // Tab control
            // 
            this.tabBooks.Controls.Add(this.dgvBooks);
            this.tabBooks.Text = "Книги";
            this.tabReaders.Controls.Add(this.dgvReaders);
            this.tabReaders.Text = "Читатели";
            this.tabCheckouts.Controls.Add(this.dgvCheckouts);
            this.tabCheckouts.Text = "Выдачи";

            this.dgvBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReaders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCheckouts.Dock = System.Windows.Forms.DockStyle.Fill;

            this.tabControl.Controls.Add(this.tabBooks);
            this.tabControl.Controls.Add(this.tabReaders);
            this.tabControl.Controls.Add(this.tabCheckouts);
            this.tabControl.Location = new System.Drawing.Point(12, 40);
            this.tabControl.Size = new System.Drawing.Size(760, 370);
            // 
            // Buttons and label
            // 
            this.lblUser.Location = new System.Drawing.Point(12, 10);
            this.lblUser.AutoSize = true;

            this.btnSave.Text = "Сохранить";
            this.btnSave.Location = new System.Drawing.Point(12, 420);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnExit.Text = "Выход";
            this.btnExit.Location = new System.Drawing.Point(130, 420);
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);

            this.btnManageUsers.Text = "Пользователи";
            this.btnManageUsers.Location = new System.Drawing.Point(250, 420);
            this.btnManageUsers.Click += new System.EventHandler(this.btnManageUsers_Click);

            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnManageUsers);
            this.Text = "Библиотека";
            this.tabControl.ResumeLayout(false);
            this.tabBooks.ResumeLayout(false);
            this.tabReaders.ResumeLayout(false);
            this.tabCheckouts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReaders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckouts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}