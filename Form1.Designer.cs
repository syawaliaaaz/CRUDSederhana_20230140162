namespace CRUDSederhana // Ganti dengan namespace Anda jika perlu
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.txtNIM = new System.Windows.Forms.TextBox();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtTelepon = new System.Windows.Forms.TextBox();
            this.txtAlamat = new System.Windows.Forms.TextBox();
            this.dgvMahasiswa = new System.Windows.Forms.DataGridView();
            this.btnTambah = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnUbah = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblNIM = new System.Windows.Forms.Label();
            this.lblNama = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblTelepon = new System.Windows.Forms.Label();
            this.lblAlamat = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMahasiswa)).BeginInit();
            this.SuspendLayout();

            // 
            // txtNIM
            // 
            this.txtNIM.Location = new System.Drawing.Point(100, 30);
            this.txtNIM.Name = "txtNIM";
            this.txtNIM.Size = new System.Drawing.Size(200, 20);

            // 
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(100, 60);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(200, 20);

            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(100, 90);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 20);

            // 
            // txtTelepon
            // 
            this.txtTelepon.Location = new System.Drawing.Point(100, 120);
            this.txtTelepon.Name = "txtTelepon";
            this.txtTelepon.Size = new System.Drawing.Size(200, 20);

            // 
            // txtAlamat
            // 
            this.txtAlamat.Location = new System.Drawing.Point(100, 150);
            this.txtAlamat.Name = "txtAlamat";
            this.txtAlamat.Size = new System.Drawing.Size(200, 20);

            // 
            // dgvMahasiswa
            // 
            this.dgvMahasiswa.Location = new System.Drawing.Point(50, 180);
            this.dgvMahasiswa.Size = new System.Drawing.Size(500, 200);
            this.dgvMahasiswa.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMahasiswa_CellClick);

            // 
            // btnTambah
            // 
            this.btnTambah.Location = new System.Drawing.Point(320, 30);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(75, 23);
            this.btnTambah.Text = "Tambah";
            this.btnTambah.Click += new System.EventHandler(this.BtnTambah_Click);

            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(320, 60);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(75, 23);
            this.btnHapus.Text = "Hapus";
            this.btnHapus.Click += new System.EventHandler(this.BtnHapus_Click);

            // 
            // btnUbah
            // 
            this.btnUbah.Location = new System.Drawing.Point(320, 90);
            this.btnUbah.Name = "btnUbah";
            this.btnUbah.Size = new System.Drawing.Size(75, 23);
            this.btnUbah.Text = "Ubah";
            this.btnUbah.Click += new System.EventHandler(this.BtnUbah_Click);

            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(320, 120);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);

            // 
            // lblNIM
            // 
            this.lblNIM.AutoSize = true;
            this.lblNIM.Location = new System.Drawing.Point(50, 33);
            this.lblNIM.Name = "lblNIM";
            this.lblNIM.Text = "NIM:";

            // 
            // lblNama
            // 
            this.lblNama.AutoSize = true;
            this.lblNama.Location = new System.Drawing.Point(50, 63);
            this.lblNama.Name = "lblNama";
            this.lblNama.Text = "Nama:";

            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(50, 93);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Text = "Email:";

            // 
            // lblTelepon
            // 
            this.lblTelepon.AutoSize = true;
            this.lblTelepon.Location = new System.Drawing.Point(50, 123);
            this.lblTelepon.Name = "lblTelepon";
            this.lblTelepon.Text = "Telepon:";

            // 
            // lblAlamat
            // 
            this.lblAlamat.AutoSize = true;
            this.lblAlamat.Location = new System.Drawing.Point(50, 153);
            this.lblAlamat.Name = "lblAlamat";
            this.lblAlamat.Text = "Alamat:";

            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.txtNIM);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtTelepon);
            this.Controls.Add(this.txtAlamat);
            this.Controls.Add(this.dgvMahasiswa);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnUbah);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblNIM);
            this.Controls.Add(this.lblNama);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblTelepon);
            this.Controls.Add(this.lblAlamat);
            this.Name = "Form1";
            this.Text = "Data Mahasiswa";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMahasiswa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}