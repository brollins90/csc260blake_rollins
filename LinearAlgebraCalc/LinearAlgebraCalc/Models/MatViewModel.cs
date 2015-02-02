using LinearAlgebraCalcLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebraCalc.Models
{
    public class MatViewModel
    {
        private bool _Use;

        public bool Use
        {
            get { return _Use; }
            set { _Use = value; }
        }

        private Mat _Mat;

        public Mat m
        {
            get { return _Mat; }
            set { _Mat = value; }
        }

        public MatViewModel(Mat m, bool use = false)
        {
            this.Use = use;
            this.m = m;
        }

        public Fraction this[int row, int col]
        {
            get { return m.a[row, col]; }
            set { m.a[row, col] = value; }
        }
    }
}
