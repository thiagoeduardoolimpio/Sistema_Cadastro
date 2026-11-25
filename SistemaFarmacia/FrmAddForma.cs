using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFarmacia
{
    public partial class FrmAddForma : Form
    {
        public FrmAddForma()
        {
            InitializeComponent();
        }

        private void FrmAddForma_Load(object sender, EventArgs e)
        {

        }

        private void txtpaciente_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnConfirmaCadastro_Click(object sender, EventArgs e)
        {
            conectaBanco con = new conectaBanco();
            bool retorno = con.insereForma(txtaddforma.Text);
            if (retorno == false)
                MessageBox.Show(con.mensagem);
            else
                MessageBox.Show("Forma adicionada com sucesso");
            txtaddforma.Clear();
            txtaddforma.Focus();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Sistema formSistema = new Sistema();
            this.Close();
            formSistema.Show();
        }
    }
}
