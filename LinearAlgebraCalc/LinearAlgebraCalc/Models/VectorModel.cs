using System;
using LinearAlgebraCalcLib;
using System.ComponentModel;

namespace LinearAlgebraCalc.Models
{
    public class VectorModel : INotifyPropertyChanged
    {
        private bool _Use;

        public bool Use
        {
            get { return _Use; }
            set { _Use = value; }
        }

        private Vector3 _Vector;

        public Vector3 Vector
        {
            get { return _Vector; }
            set { _Vector = value; }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string property)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        #endregion
               
    }
}
