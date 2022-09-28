using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA220928
{
    public partial class FrmInsert : Form
    {
        public FrmInsert()
        {
            InitializeComponent();
        }

        private void BtnHozzaadas_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbNev.Text) || string.IsNullOrEmpty(tbTel.Text))
            {
                MessageBox.Show(
                    icon: MessageBoxIcon.Error,
                    caption: "HIBA",
                    text: "Nem írtál be nevet vagy számot b+!",
                    buttons: MessageBoxButtons.OK);
            }
            else
            {
                using SqlConnection conn = new(Program.ConnectionString);
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter()
                {
                    InsertCommand = new(
                        cmdText: "INSERT INTO nevek VALUES " +
                        $"('{tbNev.Text}', '{tbTel.Text}');",
                        connection: conn)
                };
                adapter.InsertCommand.ExecuteNonQuery();
                this.Close();
            }
        }
    }
}
