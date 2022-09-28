using System.Data.SqlClient;

namespace WFA220928
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            DgvFeltolt();
        }

        private void TbKereses_TextChanged(object sender, EventArgs e)
        {
            dgvTelefonkonyv.Rows.Clear();
            using SqlConnection conn = new(Program.ConnectionString);
            conn.Open();
            var r = new SqlCommand(
                cmdText: 
                    "SELECT * FROM nevek " +
                    $"WHERE nev LIKE '{tbKereses.Text}%';",
                connection: conn).ExecuteReader();
            while(r.Read()) dgvTelefonkonyv.Rows.Add(r[0], r[1], r[2]);
        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            new FrmInsert().ShowDialog();
            DgvFeltolt();
        }

        private void DgvFeltolt()
        {
            dgvTelefonkonyv.Rows.Clear();
            using SqlConnection connenction = new(Program.ConnectionString);
            connenction.Open();
            string query =
                "SELECT * FROM nevek;";
            SqlCommand cmd = new(query, connenction);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dgvTelefonkonyv.Rows.Add(reader["id"], reader["nev"], reader["tel"]);
            }
        }
    }
}