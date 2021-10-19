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
        //FUNCION PARA OBTENER TAMAÑO DEL TABLERO NxN
        public int Tam { get; set; }

        //FUNCION PARA OBTENER LA CELDA DE LA MATRIZ[i,j]
        public Celda[,] Matriz { get; set; }
        
        //CONSTRUCTOR DEL TABLERO
        public Tablero(int s)
        {

            Tam = s;
            
            Matriz = new Celda[Tam, Tam];
            //ASIGNA A CADA LUGAR DE LA MATRIZ[i,j] UNA CELDA CON SU POSICION(i,j)
            for (int i = 0; i < Tam; i++)
            {
                for (int j = 0; j < Tam; j++)
                {
                    Matriz[i, j] = new Celda(i, j);
                }
            }
        }
        //Probablemente  hay que cambiar "string chessPiece" por Pieza1 de tipo Pieza

        //FUNCION PARA MARCAR DE ACUERDO A LA PIEZA QUE SE LE PASA LAS POSICIONES A LAS QUE ATACA
        public void MarcarProx_MovLegal(Celda CeldaActual, string PiezaAjedrez) 
        {
            //Paso 1: Borrar todos los movimientos legales previos
            //BASICAMENTE LIMPIA EL TABLERO
            for (int i = 0; i < Tam; i++)
            {
                for (int j = 0; j < Tam; j++)
                {
                    Matriz[i, j].Legal_Movim = false;
                    Matriz[i, j].Ocupados = false;
                }
            }

            //CAMBIA LA POSICION DONDE SE COLOCA LA PIEZA A OCUPADO
            Matriz[CeldaActual.NroFila, CeldaActual.NroColumna].Ocupados = true;

            


            //Paso 2: Buscar todos los movientos legales y marcar las celdas como 1
            switch(PiezaAjedrez)
            {
                //PENSAMOS HACER DINAMIC CAST PARA CADA UNA DE LAS PIEZAS
               case "Caballo1":
                    if (VerificarLugar(CeldaActual.NroFila-2,CeldaActual.NroColumna-1))
                    {
                        Matriz[CeldaActual.NroFila - 2, CeldaActual.NroColumna - 1].Legal_Movim = true;
                    }
                    if(VerificarLugar(CeldaActual.NroFila + 2, CeldaActual.NroColumna + 1))
                    {
                        Matriz[CeldaActual.NroFila + 2, CeldaActual.NroColumna + 1].Legal_Movim = true;
                    }
                    if(VerificarLugar(CeldaActual.NroFila + 2, CeldaActual.NroColumna - 1))
                    {
                        Matriz[CeldaActual.NroFila + 2, CeldaActual.NroColumna - 1].Legal_Movim = true;
                    }
                    if(VerificarLugar(CeldaActual.NroFila - 2, CeldaActual.NroColumna + 1))
                    {
                        Matriz[CeldaActual.NroFila - 2, CeldaActual.NroColumna + 1].Legal_Movim = true;
                    }
                    if(VerificarLugar(CeldaActual.NroFila + 1, CeldaActual.NroColumna + 2))
                    {
                        Matriz[CeldaActual.NroFila + 1, CeldaActual.NroColumna + 2].Legal_Movim = true;
                    }
                    if (VerificarLugar(CeldaActual.NroFila + 1, CeldaActual.NroColumna - 2))
                    {
                        Matriz[CeldaActual.NroFila + 1, CeldaActual.NroColumna - 2].Legal_Movim = true;
                    }
                    if (VerificarLugar(CeldaActual.NroFila - 1, CeldaActual.NroColumna + 2))
                    {
                        Matriz[CeldaActual.NroFila - 1, CeldaActual.NroColumna + 2].Legal_Movim = true;
                    }
                    if (VerificarLugar(CeldaActual.NroFila - 1, CeldaActual.NroColumna - 2))
                    {
                        Matriz[CeldaActual.NroFila - 1, CeldaActual.NroColumna - 2].Legal_Movim = true;
                    }
                    break;

                case "Caballo2":
                    if (VerificarLugar(CeldaActual.NroFila - 2, CeldaActual.NroColumna - 1))
                    {
                        Matriz[CeldaActual.NroFila - 2, CeldaActual.NroColumna - 1].Legal_Movim = true;
                    }
                    if (VerificarLugar(CeldaActual.NroFila + 2, CeldaActual.NroColumna + 1))
                    {
                        Matriz[CeldaActual.NroFila + 2, CeldaActual.NroColumna + 1].Legal_Movim = true;
                    }
                    if (VerificarLugar(CeldaActual.NroFila + 2, CeldaActual.NroColumna - 1))
                    {
                        Matriz[CeldaActual.NroFila + 2, CeldaActual.NroColumna - 1].Legal_Movim = true;
                    }
                    if (VerificarLugar(CeldaActual.NroFila - 2, CeldaActual.NroColumna + 1))
                    {
                        Matriz[CeldaActual.NroFila - 2, CeldaActual.NroColumna + 1].Legal_Movim = true;
                    }
                    if (VerificarLugar(CeldaActual.NroFila + 1, CeldaActual.NroColumna + 2))
                    {
                        Matriz[CeldaActual.NroFila + 1, CeldaActual.NroColumna + 2].Legal_Movim = true;
                    }
                    if (VerificarLugar(CeldaActual.NroFila + 1, CeldaActual.NroColumna - 2))
                    {
                        Matriz[CeldaActual.NroFila + 1, CeldaActual.NroColumna - 2].Legal_Movim = true;
                    }
                    if (VerificarLugar(CeldaActual.NroFila - 1, CeldaActual.NroColumna + 2))
                    {
                        Matriz[CeldaActual.NroFila - 1, CeldaActual.NroColumna + 2].Legal_Movim = true;
                    }
                    if (VerificarLugar(CeldaActual.NroFila - 1, CeldaActual.NroColumna - 2))
                    {
                        Matriz[CeldaActual.NroFila - 1, CeldaActual.NroColumna - 2].Legal_Movim = true;
                    }
                    break;

                case "Rey":
                    if (VerificarLugar(CeldaActual.NroFila - 1, CeldaActual.NroColumna))
                    {
                        Matriz[CeldaActual.NroFila - 1, CeldaActual.NroColumna].Legal_Movim = true;
                    }
                    if (VerificarLugar(CeldaActual.NroFila + 1, CeldaActual.NroColumna))
                    {
                        Matriz[CeldaActual.NroFila + 1, CeldaActual.NroColumna].Legal_Movim = true;
                    }
                    if (VerificarLugar(CeldaActual.NroFila - 1, CeldaActual.NroColumna-1))
                    {
                        Matriz[CeldaActual.NroFila - 1, CeldaActual.NroColumna - 1].Legal_Movim = true;
                    }
                    if (VerificarLugar(CeldaActual.NroFila + 1, CeldaActual.NroColumna+1))
                    {
                        Matriz[CeldaActual.NroFila + 1, CeldaActual.NroColumna+1].Legal_Movim = true;
                    }
                    if (VerificarLugar(CeldaActual.NroFila, CeldaActual.NroColumna-1))
                    {
                        Matriz[CeldaActual.NroFila, CeldaActual.NroColumna-1].Legal_Movim = true;
                    }
                    if (VerificarLugar(CeldaActual.NroFila, CeldaActual.NroColumna+1))
                    {
                        Matriz[CeldaActual.NroFila , CeldaActual.NroColumna+1].Legal_Movim = true;
                    }
                    if (VerificarLugar(CeldaActual.NroFila - 1, CeldaActual.NroColumna+1))
                    {
                        Matriz[CeldaActual.NroFila - 1, CeldaActual.NroColumna+1].Legal_Movim = true;
                    }
                    if (VerificarLugar(CeldaActual.NroFila + 1, CeldaActual.NroColumna-1))
                    {
                        Matriz[CeldaActual.NroFila + 1, CeldaActual.NroColumna-1].Legal_Movim = true;
                    }
                    break;
                case "Reina":
                    //ABAJO 
                    for (int i = CeldaActual.NroFila+1; i < Tam ; i++)
                    {
                        if (VerificarLugar(i, CeldaActual.NroColumna))
                        {
                            Matriz[i, CeldaActual.NroColumna].Legal_Movim = true;
                        }
                    }
                    //ARRIBA
                    for (int i = CeldaActual.NroFila-1; i >= 0; i--)
                    {
                        if (VerificarLugar(i, CeldaActual.NroColumna))
                        {
                            Matriz[i, CeldaActual.NroColumna].Legal_Movim = true;
                        }
                 
                    }

                    //PARA LA DERECHA
                    for (int j = CeldaActual.NroColumna+1; j < Tam; j++)
                    {
                        if (VerificarLugar(CeldaActual.NroFila, j))
                        {
                            Matriz[CeldaActual.NroFila, j].Legal_Movim = true;
                        }
                    }
                    //PARA LA IZQUIERDA
                    for (int j = CeldaActual.NroColumna-1; j >= 0 ; j--)
                    {
                        if (VerificarLugar(CeldaActual.NroFila, j))
                        {
                            Matriz[CeldaActual.NroFila, j].Legal_Movim = true;
                        }
                    }

                    //DIAGONAL HACIA ABAJO DERECHA
                    int r = CeldaActual.NroColumna;

                    for (int i=CeldaActual.NroFila + 1; i < Tam; i++)
                    {
                        r++;
                        if (VerificarLugar(i,r))
                        {
                            Matriz[i,r].Legal_Movim = true;
                        }
                    }
                    //DIAGONAL HACIA ARRIBA IZQUIERDA
                    r = CeldaActual.NroColumna;
                    for ( int i= CeldaActual.NroFila-1; i >= 0; i--)
                    {
                        r--;
                        if (VerificarLugar(i,r))
                        {
                            Matriz[i,r].Legal_Movim = true;
                        }
                    }
                    //DIAGONAL HACIA ARRIBA DERECHA
                    r = CeldaActual.NroColumna;
                    for (int i = CeldaActual.NroFila-1; i >= 0; i--)
                    {
                        r++;
                        if (VerificarLugar(i, r))
                        {
                            Matriz[i, r].Legal_Movim = true;
                        }
                    }
                    //DIAGONAL HACIA ABAJO IZQUIERDA
                    r = CeldaActual.NroColumna;
                    for (int i = CeldaActual.NroFila + 1 ; i < Tam; i++)
                    {
                        r--;
                        if (VerificarLugar(i, r))
                        {
                            Matriz[i, r].Legal_Movim = true;
                        }
                        
                    }
                    break;

                case "Torre1":
                    //ABAJO 
                    for (int i = CeldaActual.NroFila + 1; i < Tam; i++)
                    {
                        if (VerificarLugar(i, CeldaActual.NroColumna))
                        {
                            Matriz[i, CeldaActual.NroColumna].Legal_Movim = true;
                        }
                    }
                    //ARRIBA
                    for (int i = CeldaActual.NroFila - 1; i >= 0; i--)
                    {
                        if (VerificarLugar(i, CeldaActual.NroColumna))
                        {
                            Matriz[i, CeldaActual.NroColumna].Legal_Movim = true;
                        }

                    }

                    //PARA LA DERECHA
                    for (int j = CeldaActual.NroColumna + 1; j < Tam; j++)
                    {
                        if (VerificarLugar(CeldaActual.NroFila, j))
                        {
                            Matriz[CeldaActual.NroFila, j].Legal_Movim = true;
                        }
                    }
                    //PARA LA IZQUIERDA
                    for (int j = CeldaActual.NroColumna - 1; j >= 0; j--)
                    {
                        if (VerificarLugar(CeldaActual.NroFila, j))
                        {
                            Matriz[CeldaActual.NroFila, j].Legal_Movim = true;
                        }
                    }
                    break;

                case "Torre2":
                    //ABAJO 
                    for (int i = CeldaActual.NroFila + 1; i < Tam; i++)
                    {
                        if (VerificarLugar(i, CeldaActual.NroColumna))
                        {
                            Matriz[i, CeldaActual.NroColumna].Legal_Movim = true;
                        }
                    }
                    //ARRIBA
                    for (int i = CeldaActual.NroFila - 1; i >= 0; i--)
                    {
                        if (VerificarLugar(i, CeldaActual.NroColumna))
                        {
                            Matriz[i, CeldaActual.NroColumna].Legal_Movim = true;
                        }

                    }

                    //PARA LA DERECHA
                    for (int j = CeldaActual.NroColumna + 1; j < Tam; j++)
                    {
                        if (VerificarLugar(CeldaActual.NroFila, j))
                        {
                            Matriz[CeldaActual.NroFila, j].Legal_Movim = true;
                        }
                    }
                    //PARA LA IZQUIERDA
                    for (int j = CeldaActual.NroColumna - 1; j >= 0; j--)
                    {
                        if (VerificarLugar(CeldaActual.NroFila, j))
                        {
                            Matriz[CeldaActual.NroFila, j].Legal_Movim = true;
                        }
                    }
                    break;

                case "Alfil_Negro":

                    //DIAGONAL HACIA ABAJO DERECHA
                    r = CeldaActual.NroColumna;

                    for (int i = CeldaActual.NroFila + 1; i < Tam; i++)
                    {
                        r++;
                        if (VerificarLugar(i, r))
                        {
                            Matriz[i, r].Legal_Movim = true;
                        }
                    }
                    //DIAGONAL HACIA ARRIBA IZQUIERDA
                    r = CeldaActual.NroColumna;
                    for (int i = CeldaActual.NroFila - 1; i >= 0; i--)
                    {
                        r--;
                        if (VerificarLugar(i, r))
                        {
                            Matriz[i, r].Legal_Movim = true;
                        }
                    }
                    //DIAGONAL HACIA ARRIBA DERECHA
                    r = CeldaActual.NroColumna;
                    for (int i = CeldaActual.NroFila - 1; i >= 0; i--)
                    {
                        r++;
                        if (VerificarLugar(i, r))
                        {
                            Matriz[i, r].Legal_Movim = true;
                        }
                    }
                    //DIAGONAL HACIA ABAJO IZQUIERDA
                    r = CeldaActual.NroColumna;
                    for (int i = CeldaActual.NroFila + 1; i < Tam; i++)
                    {
                        r--;
                        if (VerificarLugar(i, r))
                        {
                            Matriz[i, r].Legal_Movim = true;
                        }

                    }
                    
                    break;

                case "Alfil_Blanco":

                    //DIAGONAL HACIA ABAJO DERECHA
                    r = CeldaActual.NroColumna;

                    for (int i = CeldaActual.NroFila + 1; i < Tam; i++)
                    {
                        r++;
                        if (VerificarLugar(i, r))
                        {
                            Matriz[i, r].Legal_Movim = true;
                        }
                    }
                    //DIAGONAL HACIA ARRIBA IZQUIERDA
                    r = CeldaActual.NroColumna;
                    for (int i = CeldaActual.NroFila - 1; i >= 0; i--)
                    {
                        r--;
                        if (VerificarLugar(i, r))
                        {
                            Matriz[i, r].Legal_Movim = true;
                        }
                    }
                    //DIAGONAL HACIA ARRIBA DERECHA
                    r = CeldaActual.NroColumna;
                    for (int i = CeldaActual.NroFila - 1; i >= 0; i--)
                    {
                        r++;
                        if (VerificarLugar(i, r))
                        {
                            Matriz[i, r].Legal_Movim = true;
                        }
                    }
                    //DIAGONAL HACIA ABAJO IZQUIERDA
                    r = CeldaActual.NroColumna;
                    for (int i = CeldaActual.NroFila + 1; i < Tam; i++)
                    {
                        r--;
                        if (VerificarLugar(i, r))
                        {
                            Matriz[i, r].Legal_Movim = true;
                        }

                    }

                    break;

            }
        }

        public void DesmarcarLugares(Celda CeldaActual, string PiezaAjedrez)
        {
            {

                //CAMBIA LA POSICION DONDE SE COLOCA LA PIEZA A OCUPADO
                Matriz[CeldaActual.NroFila, CeldaActual.NroColumna].Ocupados = false;




                //Paso 2: Buscar todos los movientos legales y marcar las celdas como 1
                switch (PiezaAjedrez)
                {
                    //PENSAMOS HACER DINAMIC CAST PARA CADA UNA DE LAS PIEZAS
                    case "Caballo1":
                        if (VerificarLugar(CeldaActual.NroFila - 2, CeldaActual.NroColumna - 1))
                        {
                            Matriz[CeldaActual.NroFila - 2, CeldaActual.NroColumna - 1].Legal_Movim = false;
                        }
                        if (VerificarLugar(CeldaActual.NroFila + 2, CeldaActual.NroColumna + 1))
                        {
                            Matriz[CeldaActual.NroFila + 2, CeldaActual.NroColumna + 1].Legal_Movim = false;
                        }
                        if (VerificarLugar(CeldaActual.NroFila + 2, CeldaActual.NroColumna - 1))
                        {
                            Matriz[CeldaActual.NroFila + 2, CeldaActual.NroColumna - 1].Legal_Movim = false;
                        }
                        if (VerificarLugar(CeldaActual.NroFila - 2, CeldaActual.NroColumna + 1))
                        {
                            Matriz[CeldaActual.NroFila - 2, CeldaActual.NroColumna + 1].Legal_Movim = false;
                        }
                        if (VerificarLugar(CeldaActual.NroFila + 1, CeldaActual.NroColumna + 2))
                        {
                            Matriz[CeldaActual.NroFila + 1, CeldaActual.NroColumna + 2].Legal_Movim = false;
                        }
                        if (VerificarLugar(CeldaActual.NroFila + 1, CeldaActual.NroColumna - 2))
                        {
                            Matriz[CeldaActual.NroFila + 1, CeldaActual.NroColumna - 2].Legal_Movim = false;
                        }
                        if (VerificarLugar(CeldaActual.NroFila - 1, CeldaActual.NroColumna + 2))
                        {
                            Matriz[CeldaActual.NroFila - 1, CeldaActual.NroColumna + 2].Legal_Movim = false;
                        }
                        if (VerificarLugar(CeldaActual.NroFila - 1, CeldaActual.NroColumna - 2))
                        {
                            Matriz[CeldaActual.NroFila - 1, CeldaActual.NroColumna - 2].Legal_Movim = false;
                        }
                        break;

                    case "Caballo2":
                        if (VerificarLugar(CeldaActual.NroFila - 2, CeldaActual.NroColumna - 1))
                        {
                            Matriz[CeldaActual.NroFila - 2, CeldaActual.NroColumna - 1].Legal_Movim = false;
                        }
                        if (VerificarLugar(CeldaActual.NroFila + 2, CeldaActual.NroColumna + 1))
                        {
                            Matriz[CeldaActual.NroFila + 2, CeldaActual.NroColumna + 1].Legal_Movim = false;
                        }
                        if (VerificarLugar(CeldaActual.NroFila + 2, CeldaActual.NroColumna - 1))
                        {
                            Matriz[CeldaActual.NroFila + 2, CeldaActual.NroColumna - 1].Legal_Movim = false;
                        }
                        if (VerificarLugar(CeldaActual.NroFila - 2, CeldaActual.NroColumna + 1))
                        {
                            Matriz[CeldaActual.NroFila - 2, CeldaActual.NroColumna + 1].Legal_Movim = false;
                        }
                        if (VerificarLugar(CeldaActual.NroFila + 1, CeldaActual.NroColumna + 2))
                        {
                            Matriz[CeldaActual.NroFila + 1, CeldaActual.NroColumna + 2].Legal_Movim = false;
                        }
                        if (VerificarLugar(CeldaActual.NroFila + 1, CeldaActual.NroColumna - 2))
                        {
                            Matriz[CeldaActual.NroFila + 1, CeldaActual.NroColumna - 2].Legal_Movim = false;
                        }
                        if (VerificarLugar(CeldaActual.NroFila - 1, CeldaActual.NroColumna + 2))
                        {
                            Matriz[CeldaActual.NroFila - 1, CeldaActual.NroColumna + 2].Legal_Movim = false;
                        }
                        if (VerificarLugar(CeldaActual.NroFila - 1, CeldaActual.NroColumna - 2))
                        {
                            Matriz[CeldaActual.NroFila - 1, CeldaActual.NroColumna - 2].Legal_Movim = false;
                        }
                        break;

                    case "Rey":
                        if (VerificarLugar(CeldaActual.NroFila - 1, CeldaActual.NroColumna))
                        {
                            Matriz[CeldaActual.NroFila - 1, CeldaActual.NroColumna].Legal_Movim = false;
                        }
                        if (VerificarLugar(CeldaActual.NroFila + 1, CeldaActual.NroColumna))
                        {
                            Matriz[CeldaActual.NroFila + 1, CeldaActual.NroColumna].Legal_Movim = false;
                        }
                        if (VerificarLugar(CeldaActual.NroFila - 1, CeldaActual.NroColumna - 1))
                        {
                            Matriz[CeldaActual.NroFila - 1, CeldaActual.NroColumna - 1].Legal_Movim = false;
                        }
                        if (VerificarLugar(CeldaActual.NroFila + 1, CeldaActual.NroColumna + 1))
                        {
                            Matriz[CeldaActual.NroFila + 1, CeldaActual.NroColumna + 1].Legal_Movim = false;
                        }
                        if (VerificarLugar(CeldaActual.NroFila, CeldaActual.NroColumna - 1))
                        {
                            Matriz[CeldaActual.NroFila, CeldaActual.NroColumna - 1].Legal_Movim = false;
                        }
                        if (VerificarLugar(CeldaActual.NroFila, CeldaActual.NroColumna + 1))
                        {
                            Matriz[CeldaActual.NroFila, CeldaActual.NroColumna + 1].Legal_Movim = false;
                        }
                        if (VerificarLugar(CeldaActual.NroFila - 1, CeldaActual.NroColumna + 1))
                        {
                            Matriz[CeldaActual.NroFila - 1, CeldaActual.NroColumna + 1].Legal_Movim = false;
                        }
                        if (VerificarLugar(CeldaActual.NroFila + 1, CeldaActual.NroColumna - 1))
                        {
                            Matriz[CeldaActual.NroFila + 1, CeldaActual.NroColumna - 1].Legal_Movim = false;
                        }
                        break;
                    case "Reina":
                        //ABAJO 
                        for (int i = CeldaActual.NroFila + 1; i < Tam; i++)
                        {
                            if (VerificarLugar(i, CeldaActual.NroColumna))
                            {
                                Matriz[i, CeldaActual.NroColumna].Legal_Movim = false;
                            }
                        }
                        //ARRIBA
                        for (int i = CeldaActual.NroFila - 1; i >= 0; i--)
                        {
                            if (VerificarLugar(i, CeldaActual.NroColumna))
                            {
                                Matriz[i, CeldaActual.NroColumna].Legal_Movim = false;
                            }

                        }

                        //PARA LA DERECHA
                        for (int j = CeldaActual.NroColumna + 1; j < Tam; j++)
                        {
                            if (VerificarLugar(CeldaActual.NroFila, j))
                            {
                                Matriz[CeldaActual.NroFila, j].Legal_Movim = false;
                            }
                        }
                        //PARA LA IZQUIERDA
                        for (int j = CeldaActual.NroColumna - 1; j >= 0; j--)
                        {
                            if (VerificarLugar(CeldaActual.NroFila, j))
                            {
                                Matriz[CeldaActual.NroFila, j].Legal_Movim = false;
                            }
                        }

                        //DIAGONAL HACIA ABAJO DERECHA
                        int r = CeldaActual.NroColumna;

                        for (int i = CeldaActual.NroFila + 1; i < Tam; i++)
                        {
                            r++;
                            if (VerificarLugar(i, r))
                            {
                                Matriz[i, r].Legal_Movim = false;
                            }
                        }
                        //DIAGONAL HACIA ARRIBA IZQUIERDA
                        r = CeldaActual.NroColumna;
                        for (int i = CeldaActual.NroFila - 1; i >= 0; i--)
                        {
                            r--;
                            if (VerificarLugar(i, r))
                            {
                                Matriz[i, r].Legal_Movim = false;
                            }
                        }
                        //DIAGONAL HACIA ARRIBA DERECHA
                        r = CeldaActual.NroColumna;
                        for (int i = CeldaActual.NroFila - 1; i >= 0; i--)
                        {
                            r++;
                            if (VerificarLugar(i, r))
                            {
                                Matriz[i, r].Legal_Movim = false;
                            }
                        }
                        //DIAGONAL HACIA ABAJO IZQUIERDA
                        r = CeldaActual.NroColumna;
                        for (int i = CeldaActual.NroFila + 1; i < Tam; i++)
                        {
                            r--;
                            if (VerificarLugar(i, r))
                            {
                                Matriz[i, r].Legal_Movim = false;
                            }

                        }
                        break;

                    case "Torre1":
                        //ABAJO 
                        for (int i = CeldaActual.NroFila + 1; i < Tam; i++)
                        {
                            if (VerificarLugar(i, CeldaActual.NroColumna))
                            {
                                Matriz[i, CeldaActual.NroColumna].Legal_Movim = false;
                            }
                        }
                        //ARRIBA
                        for (int i = CeldaActual.NroFila - 1; i >= 0; i--)
                        {
                            if (VerificarLugar(i, CeldaActual.NroColumna))
                            {
                                Matriz[i, CeldaActual.NroColumna].Legal_Movim = false;
                            }

                        }

                        //PARA LA DERECHA
                        for (int j = CeldaActual.NroColumna + 1; j < Tam; j++)
                        {
                            if (VerificarLugar(CeldaActual.NroFila, j))
                            {
                                Matriz[CeldaActual.NroFila, j].Legal_Movim = false;
                            }
                        }
                        //PARA LA IZQUIERDA
                        for (int j = CeldaActual.NroColumna - 1; j >= 0; j--)
                        {
                            if (VerificarLugar(CeldaActual.NroFila, j))
                            {
                                Matriz[CeldaActual.NroFila, j].Legal_Movim = false;
                            }
                        }
                        break;

                    case "Torre2":
                        //ABAJO 
                        for (int i = CeldaActual.NroFila + 1; i < Tam; i++)
                        {
                            if (VerificarLugar(i, CeldaActual.NroColumna))
                            {
                                Matriz[i, CeldaActual.NroColumna].Legal_Movim = false;
                            }
                        }
                        //ARRIBA
                        for (int i = CeldaActual.NroFila - 1; i >= 0; i--)
                        {
                            if (VerificarLugar(i, CeldaActual.NroColumna))
                            {
                                Matriz[i, CeldaActual.NroColumna].Legal_Movim = false;
                            }

                        }

                        //PARA LA DERECHA
                        for (int j = CeldaActual.NroColumna + 1; j < Tam; j++)
                        {
                            if (VerificarLugar(CeldaActual.NroFila, j))
                            {
                                Matriz[CeldaActual.NroFila, j].Legal_Movim = false;
                            }
                        }
                        //PARA LA IZQUIERDA
                        for (int j = CeldaActual.NroColumna - 1; j >= 0; j--)
                        {
                            if (VerificarLugar(CeldaActual.NroFila, j))
                            {
                                Matriz[CeldaActual.NroFila, j].Legal_Movim = false;
                            }
                        }
                        break;

                    case "Alfil_Negro":

                        //DIAGONAL HACIA ABAJO DERECHA
                        r = CeldaActual.NroColumna;

                        for (int i = CeldaActual.NroFila + 1; i < Tam; i++)
                        {
                            r++;
                            if (VerificarLugar(i, r))
                            {
                                Matriz[i, r].Legal_Movim = false;
                            }
                        }
                        //DIAGONAL HACIA ARRIBA IZQUIERDA
                        r = CeldaActual.NroColumna;
                        for (int i = CeldaActual.NroFila - 1; i >= 0; i--)
                        {
                            r--;
                            if (VerificarLugar(i, r))
                            {
                                Matriz[i, r].Legal_Movim = false;
                            }
                        }
                        //DIAGONAL HACIA ARRIBA DERECHA
                        r = CeldaActual.NroColumna;
                        for (int i = CeldaActual.NroFila - 1; i >= 0; i--)
                        {
                            r++;
                            if (VerificarLugar(i, r))
                            {
                                Matriz[i, r].Legal_Movim = false;
                            }
                        }
                        //DIAGONAL HACIA ABAJO IZQUIERDA
                        r = CeldaActual.NroColumna;
                        for (int i = CeldaActual.NroFila + 1; i < Tam; i++)
                        {
                            r--;
                            if (VerificarLugar(i, r))
                            {
                                Matriz[i, r].Legal_Movim = false;
                            }

                        }

                        break;

                    case "Alfil_Blanco":

                        //DIAGONAL HACIA ABAJO DERECHA
                        r = CeldaActual.NroColumna;

                        for (int i = CeldaActual.NroFila + 1; i < Tam; i++)
                        {
                            r++;
                            if (VerificarLugar(i, r))
                            {
                                Matriz[i, r].Legal_Movim = false;
                            }
                        }
                        //DIAGONAL HACIA ARRIBA IZQUIERDA
                        r = CeldaActual.NroColumna;
                        for (int i = CeldaActual.NroFila - 1; i >= 0; i--)
                        {
                            r--;
                            if (VerificarLugar(i, r))
                            {
                                Matriz[i, r].Legal_Movim = false;
                            }
                        }
                        //DIAGONAL HACIA ARRIBA DERECHA
                        r = CeldaActual.NroColumna;
                        for (int i = CeldaActual.NroFila - 1; i >= 0; i--)
                        {
                            r++;
                            if (VerificarLugar(i, r))
                            {
                                Matriz[i, r].Legal_Movim = false;
                            }
                        }
                        //DIAGONAL HACIA ABAJO IZQUIERDA
                        r = CeldaActual.NroColumna;
                        for (int i = CeldaActual.NroFila + 1; i < Tam; i++)
                        {
                            r--;
                            if (VerificarLugar(i, r))
                            {
                                Matriz[i, r].Legal_Movim = false;
                            }

                        }

                        break;

                }
            }
        }

        // FUNCION REINICIA TODO EL TABLERO
        public void ReiniciarTablero()
        {
            for (int i = 0; i < Tam; i++)
            {
                for (int j = 0; j < Tam; j++)
                {
                    Matriz[i, j].Ocupados = false;
                    Matriz[i, j].Legal_Movim = false;
                }
            }
        }


        //VERIFICA SI LA COORDENADA PASADA EXISTE EN EL TABLERO SINO RETORNA FALSE
        private bool VerificarLugar(int x1, int y2)
        {
            if (x1>=0 && x1<Tam && y2>=0 &&  y2< Tam)
            {
              

                  return true;
                
            }
            else
            {
                return false;
            }
        }


    }


   
}
