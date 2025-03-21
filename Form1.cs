using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

public partial class Form1 : Form
{
    private string connectionString = "Data Source=DESKTOP-872EEN\\SYAWALIAAAZ;Initial Catalog=OrganisasiMahasiswa;Integrated Security=True";

    // Deklarasi kontrol
    private TextBox txtNIM, txtNama, txtEmail, txtTelepon, txtAlamat;
    private DataGridView dgvMahasiswa;
    private Button btnTambah, btnHapus, btnUbah, btnRefresh;
    private Label lblNIM, lblNama, lblEmail, lblTelepon, lblAlamat;

    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        LoadData(); // Memanggil fungsi untuk memuat data ke DataGridView saat form dimuat
    }

    private void ClearForm()
    {
        txtNIM.Clear();
        txtNama.Clear();
        txtEmail.Clear();
        txtTelepon.Clear();
        txtAlamat.Clear();
        txtNIM.Focus();
    }

    private void LoadData()
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            try
            {
                conn.Open();
                string query = "SELECT NIM AS [NIM], Nama, Email, Telepon, Alamat FROM Mahasiswa";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvMahasiswa.AutoGenerateColumns = true;
                dgvMahasiswa.DataSource = dt;

                ClearForm(); // Auto Clear setelah LoadData
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void BtnTambah_Click(object sender, EventArgs e)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNIM.Text) || string.IsNullOrWhiteSpace(txtNama.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtTelepon.Text))
                {
                    MessageBox.Show("Harap isi semua data!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                conn.Open();
                string query = "INSERT INTO Mahasiswa (NIM, Nama, Email, Telepon, Alamat) VALUES (@NIM, @Nama, @Email, @Telepon, @Alamat)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NIM", txtNIM.Text.Trim());
                    cmd.Parameters.AddWithValue("@Nama", txtNama.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Telepon", txtTelepon.Text.Trim());
                    cmd.Parameters.AddWithValue("@Alamat", txtAlamat.Text.Trim());

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Data tidak berhasil ditambahkan!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void BtnHapus_Click(object sender, EventArgs e)
    {
        if (dgvMahasiswa.SelectedRows.Count > 0)
        {
            DialogResult confirm = MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        string nim = dgvMahasiswa.SelectedRows[0].Cells["NIM"].Value.ToString();
                        conn.Open();
                        string query = "DELETE FROM Mahasiswa WHERE NIM = @NIM";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@NIM", nim);
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Data berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadData();
                                ClearForm();
                            }
                            else
                            {
                                MessageBox.Show("Data tidak ditemukan atau gagal dihapus!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        else
        {
            MessageBox.Show("Pilih data yang akan dihapus!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void BtnUbah_Click(object sender, EventArgs e)
    {
        if (dgvMahasiswa.SelectedRows.Count > 0)
        {
            DialogResult confirm = MessageBox.Show("Yakin ingin mengubah data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        // Ambil NIM dari baris yang dipilih
                        string nim = dgvMahasiswa.SelectedRows[0].Cells["NIM"].Value.ToString();

                        // Validasi input
                        if (string.IsNullOrWhiteSpace(txtNIM.Text) || string.IsNullOrWhiteSpace(txtNama.Text) ||
                            string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtTelepon.Text))
                        {
                            MessageBox.Show("Harap isi semua data!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        conn.Open();
                        string query = "UPDATE Mahasiswa SET Nama = @Nama, Email = @Email, Telepon = @Telepon, Alamat = @Alamat WHERE NIM = @NIM";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            // Tambahkan parameter
                            cmd.Parameters.AddWithValue("@NIM", nim);
                            cmd.Parameters.AddWithValue("@Nama", txtNama.Text.Trim());
                            cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                            cmd.Parameters.AddWithValue("@Telepon", txtTelepon.Text.Trim());
                            cmd.Parameters.AddWithValue("@Alamat", txtAlamat.Text.Trim());

                            // Eksekusi perintah update
                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Data berhasil diubah!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadData(); // Memuat ulang data
                                ClearForm(); // Mengosongkan form
                            }
                            else
                            {
                                MessageBox.Show("Data tidak ditemukan atau gagal diubah!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        else
        {
            MessageBox.Show("Pilih data yang akan diubah!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void BtnRefresh_Click(object sender, EventArgs e)
    {
        LoadData();
    }

    private void dgvMahasiswa_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            DataGridViewRow row = dgvMahasiswa.Rows[e.RowIndex];

            txtNIM.Text = row.Cells[0].Value.ToString();
            txtNama.Text = row.Cells[1]?.Value.ToString();
            txtEmail.Text = row.Cells[2]?.Value.ToString();
            txtTelepon.Text = row.Cells[3]?.Value.ToString();
            txtAlamat.Text = row.Cells[4]?.Value.ToString();
        }
    }

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

        // Label
        this.lblNIM = new System.Windows.Forms.Label();
        this.lblNama = new System.Windows.Forms.Label();
        this.lblEmail = new System.Windows.Forms.Label();
        this.lblTelepon = new System.Windows.Forms.Label();
        this.lblAlamat = new System.Windows.Forms.Label();

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
        // Label NIM
        // 
        this.lblNIM.AutoSize = true;
        this.lblNIM.Location = new System.Drawing.Point(50, 33);
        this.lblNIM.Name = "lblNIM";
        this.lblNIM.Size = new System.Drawing.Size(30, 13);
        this.lblNIM.Text = "NIM:";

        // 
        // Label Nama
        // 
        this.lblNama.AutoSize = true;
        this.lblNama.Location = new System.Drawing.Point(50, 63);
        this.lblNama.Name = "lblNama";
        this.lblNama.Size = new System.Drawing.Size(38, 13);
        this.lblNama.Text = "Nama:";

        // 
        // Label Email
        // 
        this.lblEmail.AutoSize = true;
        this.lblEmail.Location = new System.Drawing.Point(50, 93);
        this.lblEmail.Name = "lblEmail";
        this.lblEmail.Size = new System.Drawing.Size(38, 13);
        this.lblEmail.Text = "Email:";

        // 
        // Label Telepon
        // 
        this.lblTelepon.AutoSize = true;
        this.lblTelepon.Location = new System.Drawing.Point(50, 123);
        this.lblTelepon.Name = "lblTelepon";
        this.lblTelepon.Size = new System.Drawing.Size(54, 13);
        this.lblTelepon.Text = "Telepon:";

        // 
        // Label Alamat
        // 
        this.lblAlamat.AutoSize = true;
        this.lblAlamat.Location = new System.Drawing.Point(50, 153);
        this.lblAlamat.Name = "lblAlamat";
        this.lblAlamat.Size = new System.Drawing.Size(45, 13);
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
        this.Load += new System.EventHandler(this.Form1_Load);
    }
}