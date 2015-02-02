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

            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    this.a[row, col] = new Fraction(0);
                }
            }
        }

        public static Mat operator +(Mat lhs, Mat rhs)
        {
            if (lhs.Rows == rhs.Rows && lhs.Columns == rhs.Columns)
            {
                Mat t = new Mat(lhs.Rows, lhs.Columns);
                for (int r = 0; r < lhs.Rows; r++)
                {
                    for (int c = 0; c < lhs.Columns; c++)
                    {

                        t.a[r, c] = (lhs.a[r, c] + rhs.a[r, c]);
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

        public override string ToString()
        {
            string res = "";

            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    res += a[row, col];

                    if (row < Rows - 1)
                        res += ",";
                }
                res += "\n";
            }
                //return (String.Format("({0},{1},{2}\n {3},{4},{5}\n {6},{7},{8})", this.a11, this.a12, this.a13, this.a21, this.a22, this.a23, this.a31, this.a32, this.a33));
            return res;
        }

        public static Mat Inverse(Mat m)
        {
            if (m.Rows != m.Columns)
            {
                throw new Exception("Can only find the inverse of a square matrix");
            }

            Mat identity = Mat.Identity(m.Rows);
            Mat left = m.Copy();
            Mat right = identity.Copy();


            //while (!left.Equals(identity) )
            //{

                for (int col = 0; col < left.Columns; col++)
                {
                    for (int row = 0; row < left.Rows; row++)
                    {

                        Fraction loc = left.a[row,col];
                        Fraction whatWeWant = (row == col) ? new Fraction(1) : new Fraction(0);

                        if (!loc.Equals(whatWeWant)) {

                            if (whatWeWant.Equals(new Fraction(0))) {

                                Fraction multValTop = left.a[row, col].Copy();
                                Fraction multValBot = left.a[col, col].Copy();

                                if (!multValBot.Equals(new Fraction(0))) {
                                    Fraction multScaler = (multValTop) / multValBot;
                                    multScaler = multScaler * -1;

                                    for(int i = 0; i < left.Columns; i++) {

                                        Fraction secondVal = left.a[col, i];
                                        secondVal = secondVal * multScaler;

                                        left.a[row, i] = left.a[row,i] + secondVal;

                                        secondVal = right.a[col, i];
                                        secondVal = secondVal * multScaler;

                                        right.a[row, i] = right.a[row, i] + secondVal;
                                    }
    
                                } else { // bot val is a 0


                                }
                            }
                            else
                            { // we want a 1

                                Fraction multValTop = new Fraction(1);
                                Fraction multValBot = left.a[row, col].Copy();

                                if (!multValBot.Equals(new Fraction(0)))
                                {
                                    Fraction multScaler = (multValTop) / multValBot;

                                    for (int i = 0; i < left.Columns; i++)
                                    {
                                        left.a[row, i] = left.a[row, i] * multScaler;

                                        right.a[row, i] = right.a[row, i] * multScaler;
                                    }

                                }
                                else
                                { // bot val is a 0

                                    bool notBeenSwapped = true;
                                    int curRow = row;
                                    for (int j = row; j < left.Rows && notBeenSwapped; j++)
                                    {
                                        if (left.a[j, col].Equals(new Fraction(0)))
                                        {
                                            // skip
                                        }
                                        else
                                        {
                                            for (int k = 0; k < left.Columns; k++)
                                            {
                                                Fraction t = left.a[curRow, k].Copy();
                                                left.a[curRow, k] = left.a[j, k];
                                                left.a[j, k] = t;

                                                t = right.a[curRow, k].Copy();
                                                right.a[curRow, k] = right.a[j, k];
                                                right.a[j, k] = t;

                                                notBeenSwapped = false;

                                            }
                                        }
                                    }
                                }
                            }
                        }
                        int asdls = 7;
                    }
                }
                int asdfjals = 7;
            //}
                if (!left.Equals(identity))
                {
                    right = null;
                }
            return right;
        }

        private Mat Copy()
        {
            Mat m = new Mat(this.Rows, this.Columns);
            for (int col = 0; col < this.Columns; col++)
            {
                for (int row = 0; row < this.Rows; row++)
                {
                    m.a[row, col] = this.a[row, col].Copy();
                }
            }
            return m;
        }

        private static Mat Identity(int p)
        {
            Mat m = new Mat(p, p);
            for (int col = 0; col < p; col++)
            {
                for (int row = 0; row < p; row++)
                {
                    m.a[row, col] = (row == col) ? new Fraction(1) : new Fraction(0);
                }
            }
            return m;
        }

        //private static Mat MatrixOfMinors(Mat m) {

        //    if (m.Rows == m.Columns) {

        //        if (m.Rows == 2) {
        //            //for (int i = 0; i < m.Columns; i++)
        //            //{
        //            //    for (int j = 0; j < m.Rows; j++)
        //            //    {
        //            //        Mat m = new Mat(2,2);



        //            //    }
        //            //}
        //        } else {
        //            for (int i = 0; i < m.Columns; i++)
        //            {
        //                for (int j = 0; j < m.Rows; j++)
        //                {
        //                    Mat smallerMat = new Mat(m.Rows - 1, m.Columns - 1);

        //                    bool skippedRow = false;
        //                    bool skippedCol = false;
        //                    for(int c = 0; c < m.Columns; c++) {
        //                        for(int r = 0; r < m.Rows; r++) {


        //                            if (c == i)
        //                            {
        //                                skippedCol = true;
        //                            }
        //                            if (r == j)
        //                            {
        //                                skippedRow = true;
        //                            }
        //                            int row = skippedRow ? r - 1 : r;
        //                            int col = skippedCol ? c - 1 : c;


                                    
        //                            smallerMat.a[row, col] = m.a[c,r];
        //                        }
        //                    }
        //                    Fraction placeVal = smallerMat.Determinate2();


        //                }
        //            }

        //        }

        //    } else {
        //        throw new FormatException("Can only find a matrix of minors for a square matrix.");
        //    }
        //    return null;
        //}

        //private Mat Invert2()
        //{
        //    if (this.Rows == this.Columns && this.Rows == 2)
        //    {
        //        Fraction d = Determinate2();

        //    }
        //    return null;
        //}

        //private Fraction Determinate2()
        //{
        //    if (this.Rows == this.Columns && this.Rows == 2)
        //    {
        //        return ((this.a[0, 0] * this.a[1, 1]) - (this.a[0, 1] * this.a[1, 0]));
        //    }
        //    return null;
        //}

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

        public override bool Equals(object obj)
        {
            Mat other = obj as Mat;

            if (other == null)
            {
                return false;
            }

            if (this.Rows != other.Rows || this.Columns != other.Columns)
            {
                return false;
            }

            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Columns; col++)
                {
                    if (!this.a[row, col].Equals(other.a[row, col]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
