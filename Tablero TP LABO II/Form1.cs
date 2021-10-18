using ModeloTablero;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_LABO_II;
using System.Drawing.Printing;
using System.IO;
using System.Reflection;
using System.Security.Permissions;


namespace Tablero_TP_LABO_II
{
    public partial class Form1 : Form
    {
        //Referencia a la clase Tablero. Contiene todos los valores del tablero
        static Tablero MiTablero = new Tablero(8);


        //LISTA DE PIEZAS SE PUEDE CHARLAR ERA SOLO PARA VER
        static List<string> Lista_Piezas = new List<string>()
        {
           "Caballo",
           "Caballo",
           "Torre",
           "Torre",
           "Alfil_Negro",
           "Alfil_Blanco",
           "Reina",
           "Rey"
        };
        
   

        //Matriz de 2 dimensiones de botones
        public Button[,] Matriz_Botones = new Button[MiTablero.Tam, MiTablero.Tam];

        bool Solucion = false;

        public Form1()
        {
            InitializeComponent();
            ArmarMatriz();
            
            while(Solucion==false)
            {
                Solucion=Backtraking();
            }
            

        }



        private bool Backtraking()
        {
            Random myObject = new Random();
            int ranNum1 = myObject.Next(3, 4);
            int ranNum2 = myObject.Next(3, 4);

            //METODO DE PODA
                //COLOCAMOS REINA EN ALGUNO DE LOS CUATRO CUADRADOS CENTRALES
                comboBox1.Text = "Reina";
                Lista_Piezas.Remove("Reina");
                Matriz_Botones_Click(Matriz_Botones[ranNum1, ranNum2],null);
                

                //COLOCAMOS TORRE EN LA ESQUINA SUPERIOR IZQUIERDA POSICION(0,0)
                comboBox1.Text = "Torre";
                Matriz_Botones_Click(Matriz_Botones[0, 0], null);






            return true;
        }

        private void ArmarMatriz()
        {
            //SE CREAN LOS BOTONES Y SE LOS COLOCAN EN EL PANEL
            int buttonSize = panel1.Width / MiTablero.Tam;

            //EL PANEL TIENE QUE SER UN CUADRADO ENTONCES LE DOY FORMA
            panel1.Height = panel1.Width;

            //CICLO FOR PARA RECORRER ARRAY
            for (int i = 0; i < MiTablero.Tam; i++)
            {
                for (int j = 0; j < MiTablero.Tam; j++)
                {
                    //Creo cada boton y le doy forma
                    Matriz_Botones[i, j] = new Button();
                    Matriz_Botones[i, j].Height = buttonSize;
                    Matriz_Botones[i, j].Width = buttonSize;

                    //Que pasa si toco un boton coloco funcion
                    Matriz_Botones[i, j].Click += Matriz_Botones_Click;
                    //AGREGO LOS BOTONES AL PANEL
                    panel1.Controls.Add(Matriz_Botones[i, j]);

                    //COLOCO CADA BOTON EN UNA POSICION ESPECIFICA
                    Matriz_Botones[i, j].Location = new Point(j * buttonSize, i * buttonSize);

                    //LE DOY COLOR A LOS BOTONES 
                    if (i%2 == 0 && j%2 == 0)
                    {
                        Matriz_Botones[i, j].BackColor = Color.FromArgb(217, 217, 217);
                    }
                    if (i % 2 == 0 && j % 2 != 0) 
                    {
                        Matriz_Botones[i, j].BackColor = Color.FromArgb(146, 146, 146);
                    }
                    if (i % 2 != 0 && j % 2 == 0)
                    {
                        Matriz_Botones[i, j].BackColor = Color.FromArgb(146, 146, 146);
                    }
                    if (i % 2 != 0 && j % 2 != 0)
                    {
                        Matriz_Botones[i, j].BackColor = Color.FromArgb(217, 217, 217);
                    }

                    //MUESTRO EN CADA BOTON LA POSICION QUE OCUPA
                    Matriz_Botones[i, j].Text = i + "|" + j;

                    //GUARDO DATOS EN LA OPCION TAG DE LA MATRIZ
                    //GUARDO LOS DATOS COMO UNA POSICION EN CORDENADAS X,Y
                    Matriz_Botones[i, j].Tag = new Point(i, j);
                }
            }
            
        }

        private void Matriz_Botones_Click(object sender, EventArgs e)
        {
            //OBTENGO NUMERO DE FILA Y COLUMNA DEL BOTON
            //CON "(BUTTON)"  CASTEO EL SENDER QUE ES UN OBJETO A UN BOTTON, ES DECIR PROMETO QUE VA A SER UN BOTON
            Button clickedButton = (Button)sender;
            
            //SE CREA UNA POSION DE TIPO POINT Y LE ALMACENO LO QUE SE HABIA GUARDADO EN EL TAG
            Point Lugar = (Point)clickedButton.Tag;

            //CREO VARIABLES PARA ALMACENAR LO EXTRAIDO CON VARIABLE LUGAR
            int x = Lugar.X;
            int y = Lugar.Y;

            Celda Celda_Actual = MiTablero.Matriz[x, y];
            //DEPENDE D ELO QUE SE ELIJA SE CREA UNA VARIABLE Y LUEGO SE CALCULAN LOS MOVIMIENTOS POSIBLES
            if (comboBox1.Text=="Caballo")
            {
                Caballo Caballo1 = new Caballo();
                MiTablero.MarcarProx_MovLegal(Celda_Actual, Caballo1);
                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Iconos Ajedrez\Caballo.jpg");

                Matriz_Botones[x, y].BackgroundImage = Image.FromFile(path);
                Matriz_Botones[x, y].BackgroundImageLayout = ImageLayout.Zoom;
            }
            if (comboBox1.Text == "Torre")
            {
                Torre Torre1 = new Torre();
                MiTablero.MarcarProx_MovLegal(Celda_Actual, Torre1);
                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Iconos Ajedrez\Torre.jpg");

                Matriz_Botones[x, y].BackgroundImage = Image.FromFile(path);
                Matriz_Botones[x, y].BackgroundImageLayout = ImageLayout.Zoom;
            }
            if (comboBox1.Text == "Alfil")
            {
                Alfil Alfil1 = new Alfil();
                MiTablero.MarcarProx_MovLegal(Celda_Actual, Alfil1);
                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Iconos Ajedrez\Alfil.jpg");

                Matriz_Botones[x, y].BackgroundImage = Image.FromFile(path);
                Matriz_Botones[x, y].BackgroundImageLayout = ImageLayout.Zoom;

            }
            if (comboBox1.Text == "Rey")
            {
                Rey Rey1 = new Rey();
                MiTablero.MarcarProx_MovLegal(Celda_Actual, Rey1);
                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Iconos Ajedrez\Rey.jpg");

                Matriz_Botones[x, y].BackgroundImage = Image.FromFile(path);
                Matriz_Botones[x, y].BackgroundImageLayout = ImageLayout.Zoom;

            }
            if (comboBox1.Text == "Reina")
            {
                Reina Reina1 = new Reina();
                MiTablero.MarcarProx_MovLegal(Celda_Actual, Reina1);
                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Iconos Ajedrez\Reina.jpg");

                Matriz_Botones[x, y].BackgroundImage = Image.FromFile(path);
                Matriz_Botones[x, y].BackgroundImageLayout = ImageLayout.Zoom;

            }

            for (int i = 0; i < MiTablero.Tam; i++)
            {
                for (int j = 0; j < MiTablero.Tam; j++)
                {
                    if (MiTablero.Matriz[i,j].Legal_Movim==true)
                    {
                        Matriz_Botones[i, j].BackColor = Color.FromArgb(32, 32, 32);
                    }
                }
            }



        }

       

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
