using M_15_Recuperaçáo.Cacadores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M_15_Recuperaçáo.Armas
{
    public partial class f_arma : Form
    {
        BaseDados bd;
        int narma_escolhido;
        public f_arma(BaseDados bd)
        {
            InitializeComponent();
            this.bd = bd;
            AtualizarGrelha();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                //Validar os dados
                string nome_arma = tbNome.Text;
                if (nome_arma == "" || nome_arma.Length < 3)
                {
                    MessageBox.Show("Nome tem de ter pelo menos 3 letras.");
                    tbNome.Focus();
                    return;
                }

                DateTime data_aquisicao = dtData_aquisicao.Value;
                if (data_aquisicao.Date.Year > 2024)
                {
                    MessageBox.Show("A data de aquisicao tem de ser inferior a data atual.");
                    dtData_aquisicao.Focus();
                    return;
                }
                int preco;
                if (int.TryParse(tbPreco.Text, out preco) == false)
                {
                    MessageBox.Show("O preço tem de ser superior ou igual a zero.");
                    tbPreco.Focus();
                    return;
                }
                //Criar um objeto
                arma arma = new arma();

                //Preencher as propriedades
                arma.Nome = nome_arma;
                arma.Data_Aquisicao = data_aquisicao;
                arma.Preco = preco;

                //Guardar na bd
                arma.Guardar(bd);

                //limpar form
                tbNome.Text = "";
                tbNarma.Text = "";
                tbPreco.Text = "";

                //atualizar grid
                AtualizarGrelha();

            }
        }

        private void AtualizarGrelha()
        {
            dgArmas.AllowUserToAddRows = false;
            dgArmas.AllowUserToDeleteRows = false;
            dgArmas.ReadOnly = true;
            dgArmas.DataSource = arma.ListarTodos(bd);
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            ApagarRegisto();
            
        }

        private void ApagarRegisto()
        {
            if (narma_escolhido < 1)
            {

                MessageBox.Show("Tem de selecionar uma arma primeiro. Clique com o botão esquerdo.");
                return;
            }
            //confirmar
            if (MessageBox.Show(
                "Tem a certeza que pretende eliminar a arma selecionada?",
                "Confirmar",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                Pontuacao.pontuacao.ApagarArma(narma_escolhido, bd);
                arma.ApagarArma(narma_escolhido, bd);

                LimparForm();
                AtualizarGrelha();
            }
        }

        private void LimparForm()
        {
            tbNome.Text = "";
            tbPreco.Text = "";
            tbNarma.Text = "";
            dtData_aquisicao.Value = DateTime.Now;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Validar os dados
            string nome = tbNome.Text;
            if (nome == "" || nome.Length < 3)
            {
                MessageBox.Show("Nome tem de ter pelo menos 3 letras.");
                tbNome.Focus();
                return;
            }

            DateTime data_aquisicao = dtData_aquisicao.Value;
            if (data_aquisicao > DateTime.Now)
            {
                MessageBox.Show("A data de aquisição tem de ser inferior ou igual à data atual.");
                dtData_aquisicao.Focus();
                return;
            }

            decimal preco;
            if (decimal.TryParse(tbPreco.Text, out preco) == false)
            {
                MessageBox.Show("O preço tem de ser superior ou igual a zero.");
                tbPreco.Focus();
                return;
            }

            //validar o form

            arma armas = new arma();
            armas.Narma = narma_escolhido;
            armas.Nome = tbNome.Text;
            armas.Data_Aquisicao = dtData_aquisicao.Value;
            armas.Atualizar(bd);
            AtualizarGrelha();


        }


        private void dgArmas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int linha = dgArmas.CurrentCell.RowIndex;
            if (linha == -1)
            {
                return;
            }
            int ncacador = int.Parse(dgArmas.Rows[linha].Cells[0].Value.ToString());
            arma escolhido = new arma();
            escolhido.Procurar(ncacador, bd);
            tbNome.Text = escolhido.Nome;
            tbPreco.Text = escolhido.Preco.ToString();
            tbNarma.Text = escolhido.Narma.ToString();

            narma_escolhido = escolhido.Narma;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            dgArmas.DataSource = arma.PesquisaPorNome(bd, textBox4.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LimparForm();
            button3.Visible = true;
            button4.Visible = true;
            button2.Visible = true;
        }
    }
}