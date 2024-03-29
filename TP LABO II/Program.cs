﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModeloTablero;

namespace TP_LABO_II
{
    class Program
    {
        //HAY UNA SOLA COPIA DEL TABLERO EN EL PROGRAMA POR ESO EL STATIC
        static Tablero MiTablero = new Tablero(8);
       //CREACION DE TODAS LAS PIEZAS
        static Caballo Caballo1 = new Caballo();
        static Caballo Caballo2 = new Caballo();
        static Torre Torre1 = new Torre();
        static Torre Torre2 = new Torre();
        static Alfil Alfil1 = new Alfil();
        static Alfil Alfil2 = new Alfil();
        static Rey Rey1 = new Rey();
        static Reina Reina1 = new Reina();


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

       
        static void Main(string[] args)
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Menu_Principal());

            //MOSTAR EL TABLERO VACIO
            ImprimirTablero(MiTablero);

            //PIDO UNA CORDENADA X,Y DE DONDE PONER LA PIEZA
            Celda Celda_Actual = ColocarCeldaActual(6,5);
            Celda_Actual.Ocupados = true;
            Celda_Actual = ColocarCeldaActual(0, 0);
            Celda_Actual.Ocupados = true;
            //CALCULO DE TODOS LOS MOVIMIENTOS LEGALES POSIBLES, ES DECIR, A DONDE SE PUEDE MOVER LA FICHA
            MiTablero.MarcarProx_MovLegal(Celda_Actual, "Torre");
            MiTablero.MarcarProx_MovLegal(Celda_Actual, "Caballo");



            //VUELVO A IMPIRMIR PARA VERIFICAR
            ImprimirTablero(MiTablero);



        }

        //private void Poda()
        //{
        //    Random myObject = new Random();
        //    int ranNum1 = myObject.Next(3, 4);
        //    int ranNum2 = myObject.Next(3, 4);

        //    //METODO DE PODA
        //    //COLOCAMOS REINA EN ALGUNO DE LOS CUATRO CUADRADOS CENTRALES
        //    comboBox1.Text = "Reina";
        //    Lista_Piezas.Remove(comboBox1.Text);
        //    Matriz_Botones_Click(Matriz_Botones[ranNum1, ranNum2], null);


        //    //COLOCAMOS TORRE EN LA ESQUINA SUPERIOR IZQUIERDA POSICION(0,0)
        //    comboBox1.Text = "Torre";
        //    Lista_Piezas.Remove(comboBox1.Text);
        //    Matriz_Botones_Click(Matriz_Botones[0, 0], null);

        //}

        //METODO PARA DAR CORDENADAS X,Y SE RETORNA UNA POSICION DE UNA CELDA
        private static Celda ColocarCeldaActual(int Fila_Actual, int Columna_Actual)
        {
   

            MiTablero.Matriz[Fila_Actual, Columna_Actual].Ocupados = true;


            return MiTablero.Matriz[Fila_Actual, Columna_Actual];
        }

        //Imprime el Tablero en la consola. Usar x para el lugar de la pieza, + para movimientos legales y .
        public static void ImprimirTablero(Tablero miTablero)
        {
            for (int i = 0; i < miTablero.Tam; i++)
            {
                for (int j = 0; j < miTablero.Tam; j++)
                {
                    Celda C_aux = miTablero.Matriz[i, j];
                    if (C_aux.Ocupados==true)
                    {
                        Console.Write("|X|");
                    }
                    else if(C_aux.Legal_Movim==true)
                    {
                        Console.Write("|+|");
                    }
                    else
                    {
                        Console.Write("|.|");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("========================");

        }
    }
}


