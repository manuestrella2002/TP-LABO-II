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
        public int Tam { get; set; }

        public Celda[,] Matriz { get; set; }
        
        public Tablero(int s)
        {
            Tam = s;
            Matriz = new Celda[Tam, Tam];
            for (int i = 0; i < Tam; i++)
            {
                for (int j = 0; j < Tam; j++)
                {
                    Matriz[i, j] = new Celda(i, j);
                }
            }
        }
    
        public void MarcarProx_MovLegal(Celda CeldaActual, Piezas PiezaAjedrez) //Probablemente  hay que cambiar "string chessPiece" por Pieza1 de tipo Pieza
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
                    if (VerificarLugar(CeldaActual.NroFila-2,CeldaActual.NroColumna-1))
                    {
                        Matriz[CeldaActual.NroFila - 2, CeldaActual.NroColumna + 1].Legal_Movim = true;
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
                case Rey pieza_rey:
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
                case Reina pieza_reina:
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

                case Torre pieza_torre:
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

                case Alfil pieza_alfil:

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
        //VERIFICA SI LA COORDENADA PASADDA EXISTE EN EL TABLERO SINO RETORNA FALSE
        private bool VerificarLugar(int x1, int y2)
        {
            if (x1>=0 && x1<Tam && y2>=0 &&  y2< Tam)
            {
                //EL TRUE O FALSE SE PUEDE CAMBIAR POR ENUMS QUE DIGAN SEGURO Y NO SEGURO
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
