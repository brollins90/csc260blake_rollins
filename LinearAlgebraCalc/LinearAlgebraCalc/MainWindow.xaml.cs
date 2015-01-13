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

        Vector3 result;

        public MainWindow()
        {
            InitializeComponent();
            this.result = null;
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
        private void Text(Canvas c, double x, double y, string text, Color color)
        {
            //
            TextBlock textBlock = new TextBlock();
            textBlock.Text = text;
            textBlock.Foreground = new SolidColorBrush(color);
            Canvas.SetLeft(textBlock, x);
            Canvas.SetTop(textBlock, y);
            c.Children.Add(textBlock);
        }
        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            addSubtractCanvas.Children.Clear();
            result = null;

            int y = 10;
            Text(addSubtractCanvas, 10, y, "Add:", Color.FromRgb(255, 0, 0));
            foreach (VectorModel m in VectorCollection.Vectors)
            {
                if (m.Use)
                {
                    if (result == null)
                    {
                        result = m.Vector;
                    }
                    else
                    {
                        result = result + m.Vector;
                    }
                    Text(addSubtractCanvas, 10, y += 15, m.Vector.ToString(), Color.FromRgb(255, 0, 0));
                }
            }
            Text(addSubtractCanvas, 10, y += 15, "result:", Color.FromRgb(255, 0, 0));
            Text(addSubtractCanvas, 10, y += 15, result.ToString(), Color.FromRgb(255, 0, 0));
        }

        private void Subtract_Button_Click(object sender, RoutedEventArgs e)
        {
            addSubtractCanvas.Children.Clear();
            result = null;

            int y = 10;
            Text(addSubtractCanvas, 10, y, "Subtract:", Color.FromRgb(255, 0, 0));
            foreach (VectorModel m in VectorCollection.Vectors)
            {
                if (m.Use)
                {
                    if (result == null)
                    {
                        result = m.Vector;
                    }
                    else
                    {
                        result = result - m.Vector;
                    }
                    Text(addSubtractCanvas, 10, y += 15, m.Vector.ToString(), Color.FromRgb(255, 0, 0));
                }
            }
            Text(addSubtractCanvas, 10, y += 15, "result:", Color.FromRgb(255, 0, 0));
            Text(addSubtractCanvas, 10, y += 15, result.ToString(), Color.FromRgb(255, 0, 0));
        }

        private void Multiply_Button_Click(object sender, RoutedEventArgs e)
        {
            multiplyCanvas.Children.Clear();
            result = null;

            Vector3 vectToUse = null;
            Fraction scalar = new Fraction(1,2);

            int y = 10;
            Text(multiplyCanvas, 10, y, "Multiply:", Color.FromRgb(255, 0, 0));
            foreach (VectorModel m in VectorCollection.Vectors)
            {
                if (m.Use)
                {
                    if (vectToUse == null)
                    {
                        vectToUse = m.Vector;
                        Text(multiplyCanvas, 10, y += 15, m.Vector.ToString(), Color.FromRgb(255, 0, 0));
                        result = vectToUse * scalar;
                    }
                    else
                    {
                        Text(multiplyCanvas, 10, y += 15, "You can only select one vector to multiply with a scalar", Color.FromRgb(255, 0, 0));
                    }
                }
            }
            Text(multiplyCanvas, 10, y += 15, "result:", Color.FromRgb(255, 0, 0));
            Text(multiplyCanvas, 10, y += 15, result.ToString(), Color.FromRgb(255, 0, 0));
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            if (result != null)
            {
                VectorCollection.Add(new VectorModel()
                {
                    Use = false,
                    Vector = result
                });
            }
        }

        
    }
}
