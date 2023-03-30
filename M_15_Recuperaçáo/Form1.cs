using M_15_Recuperaçáo.Armas;
using M_15_Recuperaçáo.Cacadores;
using M_15_Recuperaçáo.Pontuacao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M_15_Recuperaçáo
{
    public partial class Form1 : Form
    {
        BaseDados bd = new BaseDados("bd_2");
        public Form1()
        {
            InitializeComponent();
        }
        public void TopArmas()
        {
            string sql = @"SELECT Nome, count(*) as [Nr pontuacao] From Pontuacao inner join Cacador on pontuacao.Npontuacao = cacador.Ncacador
                        ~GROUP by Pontuacao.npontuacao ORDER BY count(*) DESC";
        }
        /// <summary>
        /// Abre o form dos livros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void caçadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f_cacador f_Cacador = new f_cacador(bd);
            f_Cacador.Show();
        }

        private void armasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f_arma f_Arma = new f_arma(bd);
            f_Arma.Show();
        }

        private void pontuaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f_pontuacao f_Pontuacao = new f_pontuacao(bd);
            f_Pontuacao.Show();
        }
    }
}
