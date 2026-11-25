using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SistemaFarmacia
{
    public partial class Sistema : Form
    {
        int idAlterar;
        public Sistema()
        {
            InitializeComponent();
            
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCadastra_Click(object sender, EventArgs e)
        {
            marcador.Height = btnCadastra.Height;
            marcador.Top = btnCadastra.Top;
            tabControl1.SelectedTab = tabControl1.TabPages[0];
        }
        

        private void btnBusca_Click(object sender, EventArgs e)
        {
            marcador.Height = btnBusca.Height;
            marcador.Top = btnBusca.Top;
            tabControl1.SelectedTab = tabControl1.TabPages[1];
        }

        private void Sistema_Load(object sender, EventArgs e)
        {
            listaCBFormas();
            lista_gridPedidos();

        }
        public void listaCBFormas()
        {
            conectaBanco con = new conectaBanco();
            DataTable tabelaDados = new DataTable();
            tabelaDados = con.listaFormas();
            cbForma.DataSource = tabelaDados;
            cbForma.DisplayMember = "forma";
            cbForma.ValueMember = "idforma";

            cbAlteraForma.DisplayMember = "forma";
            cbAlteraForma.ValueMember = "idforma";
            cbAlteraForma.DataSource = tabelaDados;
        }
        void lista_gridPedidos()
        {
            conectaBanco con = new conectaBanco();
            dgPedidos.DataSource = con.listaPedidos();
            dgPedidos.Columns["idpedidos"].Visible = false;
        }

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            (dgPedidos.DataSource as DataTable).DefaultView.RowFilter =
                string.Format("paciente like '{0}%'", txtBusca.Text);
        
        }

        private void btnRemovePedido_Click(object sender, EventArgs e)
        {
            int linha = dgPedidos.CurrentRow.Index;
            int id = Convert.ToInt32(
                    dgPedidos.Rows[linha].Cells["idpedidos"].Value.ToString());
            DialogResult resp = MessageBox.Show("Tem certeza que deseja excluir?",
                "Remove Pedido", MessageBoxButtons.OKCancel);
            if (resp == DialogResult.OK)
            {
                conectaBanco con = new conectaBanco();
                bool retorno = con.deletaPedido(id);
                if (retorno == true)
                {
                    MessageBox.Show("Pedido excluído com sucesso!");
                    lista_gridPedidos();
                }// fim if retorno true
                else
                    MessageBox.Show(con.mensagem);
            }// fim if Ok Cancela
            else
                MessageBox.Show("Exclusão cancelada");

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            int linha = dgPedidos.CurrentRow.Index;// pega a linha selecionada
            idAlterar = Convert.ToInt32(
              dgPedidos.Rows[linha].Cells["idpedidos"].Value.ToString());
            txtAlteraPaciente.Text =
                 dgPedidos.Rows[linha].Cells["paciente"].Value.ToString();
            txtAlteraQuantidade.Text =
                dgPedidos.Rows[linha].Cells["quantidade"].Value.ToString();
            txtAlteraPrioridade.Text =
                dgPedidos.Rows[linha].Cells["prioridade"].Value.ToString();
            cbAlteraForma.Text =
                dgPedidos.Rows[linha].Cells["forma"].Value.ToString();
            tabControl1.SelectedTab = tabAlterar;// muda aba
        }

         private void btnConfirmaAlteracao_Click(object sender, EventArgs e)
        {

            conectaBanco con = new conectaBanco();
            Pedido novoPedido = new Pedido();
            novoPedido.Paciente = txtAlteraPaciente.Text;
            novoPedido.Quantidade = Convert.ToInt32(txtAlteraQuantidade.Text);
            novoPedido.Prioridade = Convert.ToInt32(txtAlteraPrioridade.Text);
            novoPedido.Forma = Convert.ToInt32(cbAlteraForma .SelectedValue.ToString());
            bool retorno = con.alteraPedido(novoPedido, idAlterar);
            if (retorno == false)
                MessageBox.Show(con.mensagem);
            else
                MessageBox.Show(" alteracao realizada com sucesso! ");
            
            limpaCampos();
            lista_gridPedidos();

        }

        private void bntAddForma_Click(object sender, EventArgs e)
        {
            FrmAddForma formForma = new FrmAddForma();
            this.Hide();
            formForma.ShowDialog();
            this.Close();
        }

        void limpaCampos()
        {
            txtpaciente.Clear();
            cbForma.Text = "";
            txtquantidade.Clear();
            txtprioridade.Clear();
            txtpaciente.Focus();
        }

        private void BtnConfirmaCadastro_Click(object sender, EventArgs e)
        {
            conectaBanco con = new conectaBanco();
            Pedido novoPedido = new Pedido();
            novoPedido.Paciente = txtpaciente.Text;
            novoPedido.Quantidade = Convert.ToInt32(txtquantidade.Text);
            novoPedido.Prioridade = Convert.ToInt32(txtprioridade.Text);
            novoPedido.Forma = Convert.ToInt32(cbForma.SelectedValue.ToString());
            bool retorno = con.inserePedido(novoPedido);
            if (retorno == false)
                MessageBox.Show(con.mensagem);

            limpaCampos();
            lista_gridPedidos();

        }

        private void cbForma_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
