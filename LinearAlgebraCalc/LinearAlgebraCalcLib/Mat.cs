using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebraCalcLib
{
    public class Mat
    {
        public Fraction[,] a { get; set; }
        public int Rows { get; private set; }
        public int Columns { get; private set; }

        public Mat(int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;
            this.a = new Fraction[Rows, Columns];
        }

        public static Mat operator +(Mat lhs, Mat rhs)
        {
            if (lhs.Rows == rhs.Rows && lhs.Columns == rhs.Columns)
            {
                Mat t = new Mat(lhs.Rows, lhs.Columns);
                for (int r = 0; r < lhs.Rows;r++) {
                    for (int c = 0; c < lhs.Columns;c++) {

                        t.a[r,c] = (lhs.a[r,c] + rhs.a[r,c]);
                    }
                }
                return t;
            }
            throw new Exception("Cannot add matrices of different dimensions.");
        }

        public static Mat operator -(Mat lhs, Mat rhs)
        {
            if (lhs.Rows == rhs.Rows && lhs.Columns == rhs.Columns)
            {
                Mat t = new Mat(lhs.Rows, lhs.Columns);
                for (int r = 0; r < lhs.Rows; r++)
                {
                    for (int c = 0; c < lhs.Columns; c++)
                    {

                        t.a[r, c] = (lhs.a[r, c] - rhs.a[r, c]);
                    }
                }
                return t;
            }
            throw new Exception("Cannot subtract matrices of different dimensions.");
        }

        public static Mat operator *(Mat lhs, Mat rhs)
        {
            if (lhs.Columns == rhs.Rows)
            {
                Mat t = new Mat(lhs.Rows, rhs.Columns);

                for (int leftRow = 0; leftRow < lhs.Rows; leftRow++)
                {
                    for (int rightCol = 0; rightCol < rhs.Columns; rightCol++)
                    {
                        Fraction thisSpot = new Fraction(0);

                        for (int leftColRightRow = 0; leftColRightRow < lhs.Columns; leftColRightRow++)
                        {

                            thisSpot = thisSpot + (lhs.a[leftRow, leftColRightRow] * rhs.a[leftColRightRow, rightCol]);
                        }

                        t.a[leftRow, rightCol] = thisSpot;
                    }
                }
                return t;
            }
            throw new Exception("Cannot subtract matrices of different dimensions.");
        }

        public static Mat operator *(Mat lhs, double rhs)
        {
            Mat t = new Mat(lhs.Rows, lhs.Columns);
            for (int r = 0; r < lhs.Rows; r++)
            {
                for (int c = 0; c < lhs.Columns; c++)
                {
                    t.a[r, c] = (lhs.a[r, c] * rhs);
                }
            }
            return t;
        }

        //public override string ToString()
        //{
        //    return (String.Format("({0},{1},{2}\n {3},{4},{5}\n {6},{7},{8})", this.a11, this.a12, this.a13, this.a21, this.a22, this.a23, this.a31, this.a32, this.a33));
        //}

        public Mat Inverse()
        {
            if (this.Rows != this.Columns)
            {
                throw new Exception("Can only find the inverse of a square matrix");
            }

        }

        public Mat Transpose()
        {
            Mat t = new Mat(this.Columns, this.Rows);
            for (int r = 0; r < this.Rows; r++)
            {
                for (int c = 0; c < this.Columns; c++)
                {
                    t.a[c, r] = this.a[r, c];
                }
            }
            return t;
        }
    }
}
