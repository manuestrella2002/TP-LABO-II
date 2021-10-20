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
           "Caballo1",
           "Caballo2",
           "Torre1",
           "Torre2",
           "Alfil_Negro",
           "Alfil_Blanco",
           "Reina",
           "Rey"
        };
        static List<string> Lista_Piezas_Sacadas = new List<string>()
        {
           
        };



        //Matriz de 2 dimensiones de botones
        public Button[,] Matriz_Botones = new Button[MiTablero.Tam, MiTablero.Tam];

        bool Solucion = false;

        public Form1()
        {
            InitializeComponent();
            ArmarMatriz();

            

            Poda();


            Backtracking();
            

            //if (Solucion==true)
            //{
            //    MessageBox.Show("Funcionó");
            //}


        }

        private void Poda()
        {
            Random myObject = new Random();
            int ranNum1 = myObject.Next(3, 4);
            int ranNum2 = myObject.Next(3, 4);

            //METODO DE PODA
            //COLOCAMOS REINA EN ALGUNO DE LOS CUATRO CUADRADOS CENTRALES
            comboBox1.Text = "Reina";
            Lista_Piezas.Remove(comboBox1.Text);
            Matriz_Botones_Click(Matriz_Botones[ranNum1, ranNum2], null);


            //COLOCAMOS TORRE EN LA ESQUINA SUPERIOR IZQUIERDA POSICION(0,0)
            comboBox1.Text = "Torre1";
            Lista_Piezas.Remove(comboBox1.Text);
            Matriz_Botones_Click(Matriz_Botones[0, 0], null);

            //COLOCAMOS TORRE EN LA ESQUINA SUPERIOR IZQUIERDA POSICION(7,7)
            comboBox1.Text = "Torre2";
            Lista_Piezas.Remove(comboBox1.Text);
            Matriz_Botones_Click(Matriz_Botones[7, 7], null);

        }
        public bool VerificarSolucion()
        {
            int contador = 0;
            for (int i = 0; i < MiTablero.Tam; i++)
            {
                for (int j = 0; j < MiTablero.Tam; j++)
                {
                    if (MiTablero.Matriz[i,j].Ocupados==true || MiTablero.Matriz[i, j].Legal_Movim == true)
                    {
                        //MessageBox.Show("Hay"+ contador);
                        contador++;
                    }
                }
            }
            if (contador==64)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Backtracking()//N ES NUMERO PIEZAS
        {
            /*
                // if `N` queens are placed successfully, print the solution
                //if (Fila == 8)
                //{
                //    return true;
                //}
                ////Random myObject = new Random();
                ////int ranNum1 = myObject.Next(0, Lista_Piezas.Count);

                // place queen at every square in the current row `r`
                // and recur for each valid movement
                //for (int i = 2; i < MiTablero.Tam-1; i++)
                //{
                //    // if no two queens threaten each other
                //    if (ChequearLugares(Fila, i))
                //    {
                //        // place queen on the current square

                //        Matriz_Botones_Click(Matriz_Botones[Fila, i], null);


                //        // recur for the next row


                //        //// backtrack and remove the queen from the current square
                //        //MiTablero.Matriz[Fila,i].Ocupados=false;
                //    }
                //}
            */
            if (VerificarSolucion() == true)
            {
                return true;
            }
            else
            {
                Random myObject = new Random();
                int ranNum1 = myObject.Next(0, Lista_Piezas.Count);

                comboBox1.Text = Lista_Piezas[ranNum1];


                for (int i = 1; i < 7; i++)
                {
                    for (int j = 1; j < 7; j++)
                    {
                        if (ChequearLugares(i, j) == false)
                        {
                            Matriz_Botones_Click(Matriz_Botones[i, j], null);
                            Lista_Piezas_Sacadas.Add(comboBox1.Text);
                            Lista_Piezas.Remove(comboBox1.Text);

                            if (Lista_Piezas.Count == 0)
                            {
                                if (VerificarSolucion() == false)
                                {
                                    MiTablero.DesmarcarLugares(MiTablero.Matriz[i, j], Lista_Piezas_Sacadas.Last());
                                    Lista_Piezas.Add(Lista_Piezas_Sacadas.Last());
                                    Lista_Piezas_Sacadas.RemoveAt(Lista_Piezas_Sacadas.Count - 1);
                                    Backtracking();
                                }

                                break;
                            }
                            Backtracking();
                        }
                    }
                }

                return true;
            }
        }
        public bool ChequearLugares(int fila, int columna)
        {
            //if (comboBox1.Text == "Reina")
            //{
            //    // return 0 if two queens share the same column
            //    for (int i = 0; i < fila; i++)
            //    {
            //        if (MiTablero.Matriz[i, columna].Ocupados == true || MiTablero.Matriz[i, columna].Legal_Movim == true)
            //        {
            //            return false;
            //        }
            //    }

            //    // return 0 if two queens share the same `` diagonal
            //    for (int i = fila, j = columna; i >= 0 && j >= 0; i--, j--)
            //    {
            //        if (MiTablero.Matriz[i, j].Ocupados == true || MiTablero.Matriz[i, j].Legal_Movim == true)
            //        {
            //            return false;
            //        }
            //    }

            //    // return 0 if two queens share the same `/` diagonal
            //    for (int i = fila, j = columna; i >= 0 && j < Lista_Piezas.Count; i--, j++)
            //    {
            //        if (MiTablero.Matriz[i, j].Ocupados == true || MiTablero.Matriz[i, j].Legal_Movim == true)
            //        {
            //            return false;
            //        }
            //    }
            //    return true;
            //}


            //return true;
            if (MiTablero.Matriz[fila,columna].Ocupados==true || MiTablero.Matriz[fila,columna].Legal_Movim==true)
            {
                return true;
            }
            else
            {
                return false;
            }


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
                        Matriz_Botones[i, j].BackColor = Color.FromArgb(217, 217, 217);//BLANCO
                    }
                    if (i % 2 == 0 && j % 2 != 0) 
                    {
                        Matriz_Botones[i, j].BackColor = Color.FromArgb(146, 146, 146);//GRIS
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
        //METODO PARA REINICIAR BOTONES Y EL TABLERO
        private void ReiniciarMatrizBotones()
        {
            int buttonSize = panel1.Width / MiTablero.Tam;

            //EL PANEL TIENE QUE SER UN CUADRADO ENTONCES LE DOY FORMA
            panel1.Height = panel1.Width;
            for (int i = 0; i < MiTablero.Tam; i++)
            {
                for (int j = 0; j < MiTablero.Tam; j++)
                {
                    Matriz_Botones[i, j].Height = buttonSize;
                    Matriz_Botones[i, j].Width = buttonSize;
                    Matriz_Botones[i, j].BackgroundImage = default;
                    

                    if (i % 2 == 0 && j % 2 == 0)
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

                }
            }
        }


        private void Matriz_Botones_Click(object sender, EventArgs e)
        {
            //OBTENGO NUMERO DE FILA Y COLUMNA DEL BOTON
            //CON "(BUTTON)"  CASTEO EL SENDER QUE ES UN OBJETO A UN BOTTON, ES DECIR PROMETO QUE VA A SER UN BOTON
            Button clickedButton = (Button)sender;
            
            //SE CREA UNA POSICION DE TIPO POINT Y LE ALMACENO LO QUE SE HABIA GUARDADO EN EL TAG
            Point Lugar = (Point)clickedButton.Tag;

            //CREO VARIABLES PARA ALMACENAR LO EXTRAIDO CON VARIABLE LUGAR DE TIPO POINT
            int x = Lugar.X;
            int y = Lugar.Y;

            /*
             * NOTAR QUE LA MATRIZ DE BOTONES NO ES LO MISMO QUE LA MATRIZ DE "MiTablero", ESTA ÚLTIMA ALMACENA LAS POSICIONES OCUPADAS POR 
             * LAS PIEZAS Y LOS LUGARES A LOS QUE ATACAN. LA PRIMERA MATRIZ SOLO SE USA PARA MOSTAR EN EL FORM.
             * 
             */

           //CREA UNA CELDA AUXILIAR PARA OBTENER LA CELDA DEL TABLERO EN LA POSICION (X,Y)
            Celda Celda_Actual = MiTablero.Matriz[x, y];
            //DEPENDE DE LO QUE SE ELIJA SE CREA UNA VARIABLE Y LUEGO SE CALCULAN LOS MOVIMIENTOS POSIBLES

            ////BUSCO SI LA PIEZA YA SE ELIMINO
            //if (Lista_Piezas.BinarySearch(comboBox1.Text)<0)
            //{
            //    return;
            //}
           
           

            if (comboBox1.Text=="Caballo1")
            {
                
                MiTablero.MarcarProx_MovLegal(Celda_Actual, comboBox1.Text);

                //POSICION DE LA FOTO DEL CABALLO
                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Iconos Ajedrez\Caballo.jpg");
                Matriz_Botones[x, y].BackgroundImage = Image.FromFile(path);
                Matriz_Botones[x, y].BackgroundImageLayout = ImageLayout.Zoom;

            }
            if (comboBox1.Text == "Caballo2")
            {

                MiTablero.MarcarProx_MovLegal(Celda_Actual, comboBox1.Text);

                //POSICION DE LA FOTO DEL CABALLO
                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Iconos Ajedrez\Caballo.jpg");
                Matriz_Botones[x, y].BackgroundImage = Image.FromFile(path);
                Matriz_Botones[x, y].BackgroundImageLayout = ImageLayout.Zoom;

            }
            if (comboBox1.Text == "Torre1")
            {
                MiTablero.MarcarProx_MovLegal(Celda_Actual, comboBox1.Text);

                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Iconos Ajedrez\Torre.jpg");

                Matriz_Botones[x, y].BackgroundImage = Image.FromFile(path);
                Matriz_Botones[x, y].BackgroundImageLayout = ImageLayout.Zoom;
            }
            if (comboBox1.Text == "Torre2")
            {
                MiTablero.MarcarProx_MovLegal(Celda_Actual, comboBox1.Text);

                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Iconos Ajedrez\Torre.jpg");

                Matriz_Botones[x, y].BackgroundImage = Image.FromFile(path);
                Matriz_Botones[x, y].BackgroundImageLayout = ImageLayout.Zoom;
            }
            //REVISAR ACA LO DE LOS ALFILES
            if (comboBox1.Text == "Alfil_Blanco")
            {
                MiTablero.MarcarProx_MovLegal(Celda_Actual, comboBox1.Text);
                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Iconos Ajedrez\Alfil.jpg");

                Matriz_Botones[x, y].BackgroundImage = Image.FromFile(path);
                Matriz_Botones[x, y].BackgroundImageLayout = ImageLayout.Zoom;

            }
            if (comboBox1.Text == "Alfil_Negro")
            {
                MiTablero.MarcarProx_MovLegal(Celda_Actual, comboBox1.Text);
                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Iconos Ajedrez\Alfil.jpg");

                Matriz_Botones[x, y].BackgroundImage = Image.FromFile(path);
                Matriz_Botones[x, y].BackgroundImageLayout = ImageLayout.Zoom;

            }
            if (comboBox1.Text == "Rey")
            {
                MiTablero.MarcarProx_MovLegal(Celda_Actual, comboBox1.Text);
                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Iconos Ajedrez\Rey.jpg");

                Matriz_Botones[x, y].BackgroundImage = Image.FromFile(path);
                Matriz_Botones[x, y].BackgroundImageLayout = ImageLayout.Zoom;

            }
            if (comboBox1.Text == "Reina")
            {
                MiTablero.MarcarProx_MovLegal(Celda_Actual, comboBox1.Text);
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

        private void button1_Click(object sender, EventArgs e)
        {
            ReiniciarMatrizBotones();
            MiTablero.ReiniciarTablero();
        }
    }
}

