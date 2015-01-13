using LinearAlgebraCalcLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LinearAlgebraCalc.Models
{
    public class VectorModelCollection : INotifyPropertyChanged
    {
        private VectorModel _selectedItem;
        public VectorModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        private ObservableCollection<VectorModel> _vectors;
        public ObservableCollection<VectorModel> Vectors
        {
            get { return _vectors; }
            set
            {
                _vectors = value;
                OnPropertyChanged("DataTableListVectors");
            }
        }

        //public ICommand DeleteCommand { get; set; }

        public VectorModelCollection()
        {
            Vectors = new ObservableCollection<VectorModel>();
            //DeleteCommand = new RelayCommand(DeleteSelected);
        }

        //private void DeleteSelected()
        //{
        //    if (null != SelectedItem)
        //    {
        //        Vectors.Remove(SelectedItem);
        //    }
        //}

        public void Add(VectorModel vect)
        {
            Vectors.Add(vect);
        }

        public List<Vector3> GetSelectedVectors()
        {
            List<Vector3> l = new List<Vector3>();
            foreach (VectorModel m in Vectors)
            {
                if (m.Use)
                {
                    l.Add(m.Vector);
                }
            }
            return l;
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
