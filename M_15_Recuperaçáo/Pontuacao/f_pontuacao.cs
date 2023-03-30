using M_15_Recuperaçáo.Armas;
using M_15_Recuperaçáo.Cacadores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M_15_Recuperaçáo.Pontuacao
{
    public partial class f_pontuacao : Form
    {
        BaseDados bd;
        int npontuacao_escolhido;
        public f_pontuacao(BaseDados bd)
        {
            InitializeComponent();
            this.bd = bd;
            AtualizaGrelha();
            Atualizacbarma();
            Atualizacbcacador();
        }

        private void Atualizacbcacador()
        {
            cbcacador.Items.Clear();
            DataTable dados = cacador.ListarTodos(bd);
            foreach (DataRow dr in dados.Rows)
            {
                cacador cacador = new cacador();
                cacador.Ncacador = int.Parse(dr["ncacador"].ToString());
                cacador.Nome = dr["nome"].ToString();
                cbcacador.Items.Add(cacador);
            }
        }

        private void Atualizacbarma()
        {
            cbarma.Items.Clear();
            DataTable dados = arma.ListarTodos(bd);
            foreach (DataRow dr in dados.Rows)
            {
                arma arma  = new arma();
                arma.Narma = int.Parse(dr["narma"].ToString());
                arma.Nome = dr["nome_arma"].ToString();
                cbarma.Items.Add(arma);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Validar os dados
            string nome = tbNpontuacao.Text;
            if (nome == "" || nome.Length < 0)
            {
                MessageBox.Show("A pontuação tem de ser pelo menos 0.");
                tbNpontuacao.Focus();
                return;
            }

            if (cbcacador.SelectedIndex == -1)
            {
                MessageBox.Show("Escolha um cacador");
                return;
            }

            if (cbarma.SelectedIndex == -1)
            {
                MessageBox.Show("Escolha uma arma");
                return;
            }

            DateTime data_pontuacao = dtdata_pontuacao.Value;
            if (data_pontuacao.Date.Year >= 2024)
            {
                MessageBox.Show("A data da pontuacao tem de ser inferior a data atual.");
                dtdata_pontuacao.Focus();
                return;
            }

            //Criar um objeto cacador
            //pontuacao pontuacao = new pontuacao();

            pontuacao pontuacao = new pontuacao();
            int ncacador = pontuacao.devolveIDCacador(bd, cbcacador.SelectedItem.ToString());
            int narma = pontuacao.devolveIDArma(bd, cbarma.SelectedItem.ToString());

            pontuacao = new pontuacao(0,ncacador,narma,data_pontuacao);
            //Preencher as propriedades

            //pontuacao.data_pontuacao = data_pontuacao;
            

            //Guardar na Bd
            pontuacao.Guardar(bd);

            //Limpar o form
            LimparForm();
            AtualizaGrelha();
            
        }

        private void LimparForm()
        {
            tbNpontuacao.Text = "";
            cbcacador.Text = "";
            cbarma.Text = "";
            dtdata_pontuacao.Value = DateTime.Now;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ApagarRegisto();
        }

        private void ApagarRegisto()
        {
            if (npontuacao_escolhido < 1)
            {
                MessageBox.Show("Tem de selecionar uma pontuação primeiro. Clique com o botão esquerdo.");
                return;
            }
            //confirmar
            if (MessageBox.Show(
                "Tem a certeza que pretende eliminar a pontuação selecionada?",
                "Confirmar",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //apagar da bd
                pontuacao.ApagarPontuacao(npontuacao_escolhido, bd);


            }
            //limpar form
            LimparForm();
            //trocar botões
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button1.Visible = true;

            //Atualizar a grelha
            AtualizaGrelha();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LimparForm();
            button3.Visible = true;
            button4.Visible = true;
            button2.Visible = true;
            button1.Visible = true;

        }

        private void AtualizaGrelha()
        {
            dgpontuacao.AllowUserToAddRows = false;
            dgpontuacao.AllowUserToDeleteRows = false;
            dgpontuacao.ReadOnly = true;
            dgpontuacao.DataSource = pontuacao.ListarTodos(bd);

            
                
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Validar os dados
            string nome = tbNpontuacao.Text;
            if (nome == "" || nome.Length < 0)
            {
                MessageBox.Show("A pontuação tem de ser pelo menos 0.");
                tbNpontuacao.Focus();
                return;
            }

            if (cbcacador.SelectedIndex == -1)
            {
                MessageBox.Show("Escolha um cacador");
                return;
            }

            if (cbarma.SelectedIndex == -1)
            {
                MessageBox.Show("Escolha uma arma");
                return;
            }

            DateTime data_pontuacao = dtdata_pontuacao.Value;
            if (data_pontuacao.Date.Year >= 2024)
            {
                MessageBox.Show("A data da pontuacao tem de ser inferior a data atual.");
                dtdata_pontuacao.Focus();
                return;
            }

            pontuacao pontuacao = new pontuacao();

            pontuacao.npontuacao = npontuacao_escolhido;

            cacador cacador = (cacador)cbcacador.SelectedItem;
            pontuacao.ncacador = cacador.Ncacador;
            pontuacao.npontuacao = npontuacao_escolhido;
            arma armas = (arma)cbarma.SelectedItem;
            pontuacao.narma = armas.Narma;

            pontuacao.Atualizar(bd);
            AtualizaGrelha();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button3.Visible = true;
            button4.Visible = true;
            button1.Visible = true;
            button2.Visible = true;

            int linha = dgpontuacao.CurrentCell.RowIndex;
            if (linha == -1)
            {
                return;
            }
            int npontuacao = int.Parse(dgpontuacao.Rows[linha].Cells[0].Value.ToString());
            pontuacao escolhido = new pontuacao();
            escolhido.Procurar(npontuacao, bd);
            cbcacador.Text = escolhido.ncacador.ToString();
            cbarma.Text = escolhido.narma.ToString();
            dtdata_pontuacao.Value = escolhido.data_pontuacao;
            tbNpontuacao.Text = escolhido.npontuacao.ToString();

            npontuacao_escolhido = escolhido.npontuacao;
        }
    }
    
}
