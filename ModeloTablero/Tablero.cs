using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_LABO_II;

namespace ModeloTablero
{
    public class Tablero
    {
        public int Size { get; set; }

        public Celda[,] Matriz { get; set; }
        
        public Tablero(int s)
        {
            Size = s;
            Matriz = new Celda[Size, Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Matriz[i, j] = new Celda(i, j);
                }
            }
        }
    
        public void MarcarProx_MovLegal(Celda CeldaActual, Piezas PiezaAjedrez) //Probablemente  hay que cambiar "string chessPiece" por Pieza1 de tipo Pieza
        {
            //Paso 1: Borrar todos los movimientos legales previos
            //BASICAMENTE LIMPIA EL TABLERO
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Matriz[i, j].Legal_Movim = false;
                    Matriz[i, j].Ocupados = false;
                }
            }

            Matriz[CeldaActual.NroFila, CeldaActual.NroColumna].Ocupados = true;

            Caballo caballo = new Caballo();
            Alfil alfil = new Alfil();
            Rey rey = new Rey();
            Reina reina = new Reina();
            Torre torre = new Torre();


            //Paso 2: Buscar todos los movientos legales y marcar las celdas como 1
            switch(PiezaAjedrez)
            {
                //PENSAMOS HACER DINAMIC CAST PARA CADA UNA DE LAS PIEZAS
               case Caballo pieza_caballo:
                    Matriz[CeldaActual.NroFila + 2, CeldaActual.NroColumna +1].Legal_Movim = true;
                    Matriz[CeldaActual.NroFila + 2, CeldaActual.NroColumna - 1].Legal_Movim = true;
                    Matriz[CeldaActual.NroFila - 2, CeldaActual.NroColumna + 1].Legal_Movim = true;
                    Matriz[CeldaActual.NroFila - 2, CeldaActual.NroColumna - 1].Legal_Movim = true;
                    Matriz[CeldaActual.NroFila + 1, CeldaActual.NroColumna + 2].Legal_Movim = true;
                    Matriz[CeldaActual.NroFila + 1, CeldaActual.NroColumna - 2].Legal_Movim = true;
                    Matriz[CeldaActual.NroFila - 1, CeldaActual.NroColumna + 2].Legal_Movim = true;
                    Matriz[CeldaActual.NroFila - 1, CeldaActual.NroColumna - 2].Legal_Movim = true;

                    break;
                case Rey pieza_rey:
                    Matriz[CeldaActual.NroFila - 1, CeldaActual.NroColumna].Legal_Movim = true;
                    Matriz[CeldaActual.NroFila + 1, CeldaActual.NroColumna].Legal_Movim = true;
                    Matriz[CeldaActual.NroFila - 1, CeldaActual.NroColumna - 1].Legal_Movim = true;
                    Matriz[CeldaActual.NroFila + 1, CeldaActual.NroColumna + 1].Legal_Movim = true;
                    Matriz[CeldaActual.NroFila , CeldaActual.NroColumna - 1].Legal_Movim = true;
                    Matriz[CeldaActual.NroFila , CeldaActual.NroColumna + 1].Legal_Movim = true;
                    Matriz[CeldaActual.NroFila - 1, CeldaActual.NroColumna + 1].Legal_Movim = true;
                    Matriz[CeldaActual.NroFila + 1, CeldaActual.NroColumna - 1].Legal_Movim = true;

                    break;
                case Reina pieza_reina:
                    //ABAJO 
                    for (int i = CeldaActual.NroFila+1; i < Size ; i++)
                    {
                        Matriz[i, CeldaActual.NroColumna].Legal_Movim = true;
                    }
                    //ARRIBA
                    for (int i = CeldaActual.NroFila-1; i >= 0; i--)
                    {
                        Matriz[i, CeldaActual.NroColumna].Legal_Movim = true;
                    }

                    //PARA LA DERECHA
                    for (int j = CeldaActual.NroColumna+1; j < Size; j++)
                    {
                        Matriz[CeldaActual.NroFila,j].Legal_Movim = true;
                    }
                    //PARA LA IZQUIERDA
                    for (int j = CeldaActual.NroColumna-1; j >= 0 ; j--)
                    {
                        Matriz[CeldaActual.NroFila, j].Legal_Movim = true;
                    }

                    //DIAGONAL HACIA ABAJO DERECHA
                    int r = CeldaActual.NroColumna;

                    for (int i=CeldaActual.NroFila + 1; i < Size; i++)
                    {
                        r++;
                        Matriz[i, r].Legal_Movim = true;
                    }
                    //DIAGONAL HACIA ARRIBA IZQUIERDA
                    r = CeldaActual.NroColumna;
                    for ( int i= CeldaActual.NroFila-1; i >= 0; i--)
                    {
                        r--;
                        Matriz[i, r].Legal_Movim = true;
                    }
                    //DIAGONAL HACIA ARRIBA DERECHA
                    r = CeldaActual.NroColumna;
                    for (int i = CeldaActual.NroFila-1; i >= 0; i--)
                    {
                        r++;
                        Matriz[i,r].Legal_Movim = true;
                    }
                    //DIAGONAL HACIA ABAJO IZQUIERDA
                    r = CeldaActual.NroColumna;
                    for (int i = CeldaActual.NroFila + 1 ; i < Size; i++)
                    {
                        r--;
                        Matriz[i, r].Legal_Movim = true;
                    }
                    break;

                case Torre pieza_torre:
                    //ABAJO 
                    for (int i = CeldaActual.NroFila + 1; i < Size; i++)
                    {
                        Matriz[i, CeldaActual.NroColumna].Legal_Movim = true;
                    }
                    //ARRIBA
                    for (int i = CeldaActual.NroFila - 1; i >= 0; i--)
                    {
                        Matriz[i, CeldaActual.NroColumna].Legal_Movim = true;
                    }

                    //PARA LA DERECHA
                    for (int j = CeldaActual.NroColumna + 1; j < Size; j++)
                    {
                        Matriz[CeldaActual.NroFila, j].Legal_Movim = true;
                    }
                    //PARA LA IZQUIERDA
                    for (int j = CeldaActual.NroColumna - 1; j >= 0; j--)
                    {
                        Matriz[CeldaActual.NroFila, j].Legal_Movim = true;
                    }
                    break;

                case Alfil pieza_alfil:

                    //DIAGONAL HACIA ABAJO DERECHA
                     r = CeldaActual.NroColumna;

                    for (int i = CeldaActual.NroFila + 1; i < Size; i++)
                    {
                        r++;
                        Matriz[i, r].Legal_Movim = true;
                    }
                    //DIAGONAL HACIA ARRIBA IZQUIERDA
                    r = CeldaActual.NroColumna;
                    for (int i = CeldaActual.NroFila - 1; i >= 0; i--)
                    {
                        r--;
                        Matriz[i, r].Legal_Movim = true;
                    }
                    //DIAGONAL HACIA ARRIBA DERECHA
                    r = CeldaActual.NroColumna;
                    for (int i = CeldaActual.NroFila - 1; i >= 0; i--)
                    {
                        r++;
                        Matriz[i, r].Legal_Movim = true;
                    }
                    //DIAGONAL HACIA ABAJO IZQUIERDA
                    r = CeldaActual.NroColumna;
                    for (int i = CeldaActual.NroFila + 1; i < Size; i++)
                    {
                        r--;
                        Matriz[i, r].Legal_Movim = true;
                    }
                    break;

            }
        }
    }
}
