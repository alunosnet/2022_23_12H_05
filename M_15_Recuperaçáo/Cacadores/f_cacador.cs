using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace M_15_Recuperaçáo.Cacadores
{
    public partial class f_cacador : Form
    {
        /*string foto = "";*/
        BaseDados bd;
        int ncacador_escolhido;
        int NrRegistosPorPagina = 5;
        int nrlinhas, nrpagina;
        public f_cacador(BaseDados bd)
        {
            this.bd = bd;
            InitializeComponent();
            AtualizaNrPaginas();
            AtualizaGrelha();
        }

        private void AtualizaGrelha()
        {
            dgCacadores.AllowUserToAddRows = false;
            dgCacadores.AllowUserToDeleteRows = false;
            dgCacadores.ReadOnly = true;

            if (cbPagina.SelectedIndex == -1)
                dgCacadores.DataSource = cacador.ListarTodos(bd);
            else
            {
                //Paginação
                int nrpagina = cbPagina.SelectedIndex + 1;
                int primeiroregisto = (nrpagina - 1) * NrRegistosPorPagina + 1;
                int ultimoregisto = primeiroregisto + NrRegistosPorPagina - 1;
                dgCacadores.DataSource = cacador.ListarTodos(bd, primeiroregisto, ultimoregisto);
            }

        }
        /// <summary>
        /// Escolher um ficheiro para servir de capa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ficheiro = new OpenFileDialog();
            ficheiro.InitialDirectory = "c:\\";
            ficheiro.Filter = "Imagens |*.jpg;*.png | Todos os ficheiros |*.*";
            ficheiro.Multiselect = false;
            if (ficheiro.ShowDialog() == DialogResult.OK)
            {
                string temp = ficheiro.FileName;
                if (System.IO.File.Exists(temp))
                {
                    pbFoto.Image = Image.FromFile(temp);
                    /*foto = temp;*/
                }
            }

        }
        /// <summary>
        /// Guardar na bd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button5_Click(object sender, EventArgs e)
        {
            //Validar os dados
            string nome = tbNome.Text;
            if (nome == "" || nome.Length < 3)
            {
                MessageBox.Show("Nome tem de ter pelo menos 3 letras.");
                tbNome.Focus();
                return;
            }
            string ncacador = tbCacador.Text;
            if (ncacador == "" || ncacador.Length < 0)
            {
                MessageBox.Show("O número do cacador tem de ter pelo menos 1 números.");
                tbNome.Focus();
                return;
            }
            DateTime data_nasc = dtDataNascimento.Value;
            if (data_nasc.Date.Year >= 2004)
            {
                MessageBox.Show("A data de nascimento tem de ser inferior a 2004.");
                dtDataNascimento.Focus();
                return;
            }
            
            //Criar um objeto cacador
            cacador cacador = new cacador();

            //Preencher as propriedades
            cacador.Nome = nome;
            cacador.Data_nasc = data_nasc;

            //Guardar na BD
            cacador.Guardar(bd);

            //Limpar o form
            LimparForm();
            AtualizaGrelha();
            AtualizaNrPaginas();
        }
        private void LimparForm()
        {
            tbNome.Text = "";
            tbCacador.Text = "";
            /*foto = "";*/
            pbFoto.Image = null;
            dtDataNascimento.Value = DateTime.Now;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ApagarRegisto();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Validar os dados
            string nome = tbNome.Text;
            if (nome == "" || nome.Length < 3)
            {
                MessageBox.Show("Nome tem de ter pelo menos 3 letras.");
                tbNome.Focus();
                return;
            }
            string ncacador = tbCacador.Text;
            if (ncacador == "" )
            {
                MessageBox.Show("O número do cacador tem de ter pelo menos 3 números.");
                tbCacador.Focus();
                return;
            }
            DateTime data_nasc = dtDataNascimento.Value;
            if (data_nasc > DateTime.Now)
            {
                MessageBox.Show("A data de nascimento tem de ser inferior ou igual à 2003.");
                dtDataNascimento.Focus();
                return;
            }

            //validar o form

            cacador cacador = new cacador();
            cacador.Ncacador = ncacador_escolhido;
            cacador.Nome = tbNome.Text;
            cacador.Data_nasc = dtDataNascimento.Value;

            cacador.Atualizar(bd);
            AtualizaGrelha();
             

        }
        
        

        private void ApagarRegisto()
        {
            if (ncacador_escolhido < 1)
            {
                MessageBox.Show("Tem de selecionar um cacçador primeiro. Clique com o botão esquerdo.");
                return;
            }
            //confirmar
            if (MessageBox.Show(
                "Tem a certeza que pretende eliminar o cacador selecionado?",
                "Confirmar",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //apagar da bd
                cacador.ApagarCacador(ncacador_escolhido, bd);


            }
            //limpar form
            LimparForm();
            //trocar botões
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            //Atualizar a grelha
            AtualizaGrelha();

            AtualizaNrPaginas();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LimparForm();
            button3.Visible = true;
            button4.Visible = true;
            button2.Visible = true;
            button5.Visible = true;
        }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            dgCacadores.DataSource = cacador.PesquisaPorNome(bd, textBox4.Text);
        }
        private void cbPagina_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizaGrelha();
        }

        void AtualizaNrPaginas()
        {
            cbPagina.Items.Clear();
            int nrlivros = cacador.NrRegistos(bd);
            int nrPaginas = (int)Math.Ceiling(nrlivros / (float)NrRegistosPorPagina);
            for (int i = 1; i <= nrPaginas; i++)
                cbPagina.Items.Add(i);
            /*para o caso de não existirem cacadores*/
            if (cbPagina.Items.Count == 0)
                cbPagina.Items.Add(1);
            cbPagina.SelectedIndex = 0;
        }

        private void dgCacadores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button2.Visible = true;

            int linha = dgCacadores.CurrentCell.RowIndex;
            if (linha == -1)
            {
                return;
            }
            int ncacador = int.Parse(dgCacadores.Rows[linha].Cells[0].Value.ToString());
            cacador escolhido = new cacador();
            escolhido.Procurar(ncacador, bd);
            tbNome.Text = escolhido.Nome;
            tbCacador.Text = escolhido.Ncacador.ToString();
            dtDataNascimento.Value = escolhido.Data_nasc;

            ncacador_escolhido = escolhido.Ncacador;
        }

        private void button6_Click(object sender, EventArgs e, object printDocument1)
        {
            
        }

        
    }
    
}
