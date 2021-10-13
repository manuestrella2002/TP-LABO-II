using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_LABO_II
{
    public partial class Menu_Principal : Form
    {
        public Menu_Principal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tablero Tablero1 = new Tablero();
            

            this.Hide();
            //LLAMAR A FUNCION JUGAR()


        }

        private void button_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


}
