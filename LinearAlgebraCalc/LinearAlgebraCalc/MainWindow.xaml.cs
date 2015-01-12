using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LinearAlgebraCalc.Models;
using LinearAlgebraCalcLib;

namespace LinearAlgebraCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private VectorModelCollection _vectorCollection;
        public VectorModelCollection VectorCollection { get { return _vectorCollection; } set { _vectorCollection = value; } }
        
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            this.VectorCollection = new VectorModelCollection();
            this.VectorCollection.Add(new VectorModel()
            {
                Use = true,
                Vector = new Vector3(1, 1, 0)
            });
            this.VectorCollection.Add(new VectorModel()
            {
                Use = true,
                Vector = new Vector3(
                    new Fraction(1, 2),
                    new Fraction(1, 2),
                    new Fraction(1, 2))
            });
        }
    }
}
