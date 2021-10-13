using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_LABO_II
{
   public abstract class Piezas
    {
     protected bool color { get; set; }
        protected Point location { get; set; }
        protected List<Point> possibleMoves = new List<Point>();
        protected Image image { get; set; }

        public bool getColor()
        {
            return color;
        }

        public Point getLocation()
        {
            return location;
        }

        public void setLocation(Point newLocation)
        {
            location = newLocation;
        }

        public Image getImage()
        {
            return image;
        }

        public virtual List<Point> CalculateMoves(List<Piezas> Piezas)
        {
            return null;
        }

        public virtual void setHasMoved(bool newSetting)
        {
            return;
        }

        protected Piezas findChessPiece(Point location, List<Piezas> Piezas)
        {
            foreach (Piezas chessPiece in Piezas)
            {
                if (chessPiece.getLocation() == location)
                    return chessPiece;
            }
            return null;
        }

        protected void canMoveHorizontally(List<Piezas> Piezas)
        {

            Point temp = new Point(location,location.Y);
            Piezas tempChessPiece;
            temp.X++;

            while (temp.X < 8 && findChessPiece(temp, Piezas) == null)
            {
                possibleMoves.Add(temp);
                temp.X++;
            }
            tempChessPiece = findChessPiece(temp, Piezas);
            if (tempChessPiece != null && tempChessPiece.getColor() != this.getColor())
            {
                possibleMoves.Add(temp);
            }


            temp = location;
            temp.Y++;

            while (temp.Y < 8 && findChessPiece(temp, Piezas) == null)
            {
                possibleMoves.Add(temp);
                temp.Y++;
            }
            tempChessPiece = findChessPiece(temp, Piezas);
            if (tempChessPiece != null && tempChessPiece.getColor() != this.getColor())
            {
                possibleMoves.Add(temp);
            }


            temp = location;
            temp.X--;

            while (temp.X >= 0 && findChessPiece(temp, Piezas) == null)
            {
                possibleMoves.Add(temp);
                temp.X--;
            }
            tempChessPiece = findChessPiece(temp, Piezas);
            if (tempChessPiece != null && tempChessPiece.getColor() != this.getColor())
            {
                possibleMoves.Add(temp);
            }


            temp = location;
            temp.Y--;

            while (temp.Y >= 0 && findChessPiece(temp, Piezas) == null)
            {
                possibleMoves.Add(temp);
                temp.Y--;
            }
            tempChessPiece = findChessPiece(temp, Piezas);
            if (tempChessPiece != null && tempChessPiece.getColor() != this.getColor())
            {
                possibleMoves.Add(temp);
            }
        }

        protected void canMoveDiagonally(List<Piezas> Piezas)
        {

            Point temp = new Point(location.X, location.Y);
            Piezas tempChessPiece;


            temp.X++;
            temp.Y++;
            while (temp.X < 8 && temp.Y < 8 && findChessPiece(temp, Piezas) == null)
            {
                possibleMoves.Add(temp);
                temp.X++;
                temp.Y++;
            }
            tempChessPiece = findChessPiece(temp, Piezas);
            if (tempChessPiece != null && tempChessPiece.getColor() != this.getColor())
            {
                possibleMoves.Add(temp);
            }


            temp = location;
            temp.X--;
            temp.Y++;
            
            while (temp.X >= 0 && temp.Y < 8 && findChessPiece(temp, Piezas) == null)
            {
                possibleMoves.Add(temp);
                temp.X--;
                temp.Y++;
            }
            tempChessPiece = findChessPiece(temp, Piezas);
            if (tempChessPiece != null && tempChessPiece.getColor() != this.getColor())
            {
                possibleMoves.Add(temp);
            }


            temp = location;
            temp.X++;
            temp.Y--;

            while (temp.X < 8 && temp.Y >= 0 && findChessPiece(temp, Piezas) == null)
            {
                possibleMoves.Add(temp);
                temp.X++;
                temp.Y--;
            }
            tempChessPiece = findChessPiece(temp, Piezas);
            if (tempChessPiece != null && tempChessPiece.getColor() != this.getColor())
            {
                possibleMoves.Add(temp);
            }


            temp = location;
            temp.X--;
            temp.Y--;

            while (temp.X >= 0 && temp.Y >= 0 && findChessPiece(temp, Piezas) == null)
            {
                possibleMoves.Add(temp);
                temp.X--;
                temp.Y--;
            }
            tempChessPiece = findChessPiece(temp, Piezas);
            if (tempChessPiece != null && tempChessPiece.getColor() != this.getColor())
            {
                possibleMoves.Add(temp);
            }
        }
    }
}
