using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCadastro
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserLogin.Text.Equals("adm")
                && txtSenhaLogin.Text.Equals("123"))
            {
                Sistema sistema = new Sistema();
                this.Hide();
                sistema.ShowDialog();
                this.Close();
            }
            else
                MessageBox.Show("Usuario ou senha incorreto!");
        }
    }
}
