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

namespace SistemaCadastro
{
    public partial class Sistema : Form
    {

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
            listaCBGeneros();
            listaLivros();
        }

        void listaLivros()
        {
            ConectaBanco con = new ConectaBanco();
            dgLivros.DataSource = con.listaLivros(); 
        }

        public void listaCBGeneros()
        {
            ConectaBanco conecta = new ConectaBanco();
            DataTable tabelaDados = new DataTable();
            tabelaDados = conecta.listaGeneros();

            cbGenero.DataSource = tabelaDados;
            cbGenero.DisplayMember = "tipo";
            cbGenero.ValueMember = "id";
        }




        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            (dgLivros.DataSource as DataTable).DefaultView.RowFilter =
            string.Format("titulo like '{0}%'", txtBusca.Text);
        }

        private void btnRemoveBanda_Click(object sender, EventArgs e)
        {
           
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            
        }

         private void btnConfirmaAlteracao_Click(object sender, EventArgs e)
        {
           


        }

        private void bntAddGenero_Click(object sender, EventArgs e)
        {
          
        }

        void limpaCampos()
        {
            txtTitulo.Clear();
            cbGenero.Text = "";
            txtAutor.Clear();
            txtPublicacao.Clear();

        }

        private void BtnConfirmaCadastro_Click(object sender, EventArgs e)
        {
            ConectaBanco conecta = new ConectaBanco();

            Livro novoLivro = new Livro();
            novoLivro.Titulo = txtTitulo.Text;
            novoLivro.Autor = txtAutor.Text;
            novoLivro.Genero = Convert.ToInt32(cbGenero.SelectedValue.ToString());
            novoLivro.AnoPublicacao = Convert.ToInt32(txtPublicacao.Text);

            bool retorno = conecta.insereLivro(novoLivro);
            if (retorno)
            {
                MessageBox.Show(conecta.mensagem);
                limpaCampos();
            }
            else
            {
                MessageBox.Show(conecta.mensagem);

            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtAutor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtranking_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgBandas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
