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
                Vector = new Vector3(
                    new Fraction(1, 2),
                    new Fraction(1, 2),
                    new Fraction(1, 2))
            });
            this.VectorCollection.Add(new VectorModel()
            {
                Use = true,
                Vector = new Vector3(1, 1, 0)
            });
            this.VectorCollection.Add(new VectorModel()
            {
                Use = true,
                Vector = new Vector3(2, 2, 2)
            });
        }
        private void AddSubtractText(double x, double y, string text, Color color)
        {
            //
            TextBlock textBlock = new TextBlock();
            textBlock.Text = text;
            textBlock.Foreground = new SolidColorBrush(color);
            Canvas.SetLeft(textBlock, x);
            Canvas.SetTop(textBlock, y);
            addSubtractCanvas.Children.Add(textBlock);
        }
        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            addSubtractCanvas.Children.Clear();
            Vector3 res = null;

            int y = 10;
            AddSubtractText(10, y, "Add:", Color.FromRgb(255, 0, 0));
            foreach (VectorModel m in VectorCollection.Vectors)
            {
                if (res == null)
                {
                    res = m.Vector;
                }
                else
                {
                    res = res + m.Vector;
                }
                AddSubtractText(10, y+= 15, m.Vector.ToString(), Color.FromRgb(255, 0, 0));
            }
            AddSubtractText(10, y += 15, "result:", Color.FromRgb(255, 0, 0));
            AddSubtractText(10, y += 15, res.ToString(), Color.FromRgb(255, 0, 0));
        }

        private void Subtract_Button_Click(object sender, RoutedEventArgs e)
        {
            addSubtractCanvas.Children.Clear();

            Vector3 res = null;

            int y = 10;
            AddSubtractText(10, y, "Subtract:", Color.FromRgb(255, 0, 0));
            foreach (VectorModel m in VectorCollection.Vectors)
            {
                if (res == null)
                {
                    res = m.Vector;
                }
                else
                {
                    res = res - m.Vector;
                }
                AddSubtractText(10, y += 15, m.Vector.ToString(), Color.FromRgb(255, 0, 0));
            }
            AddSubtractText(10, y += 15, "result:", Color.FromRgb(255, 0, 0));
            AddSubtractText(10, y += 15, res.ToString(), Color.FromRgb(255, 0, 0));
        }

        
    }
}
