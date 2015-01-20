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

    // http://blogs.u2u.be/diederik/post/2009/09/30/Validation-in-a-WPF-DataGrid.aspx

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private VectorModelCollection _vectorCollection;
        public VectorModelCollection VectorCollection { get { return _vectorCollection; } set { _vectorCollection = value; } }

        public Fraction scalarValue { get; set; }

        Vector2 result;

        public MainWindow()
        {
            InitializeComponent();
            
            scalarValue = new Fraction(1, 2);

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
            this.VectorCollection.Add(new VectorModel()
            {
                Use = true,
                Vector = new Vector3(3, 4, 0)
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
            List<Vector2> l = VectorCollection.GetSelectedVectors();

            if (l.Count() < 1)
            {
                Text(addSubtractCanvas, 10, 10, "You need to select more vectors.", Color.FromRgb(255, 0, 0));
                return;
            }

            int y = 10;
            Text(addSubtractCanvas, 10, y, "Add:", Color.FromRgb(255, 0, 0));
            foreach (Vector2 m in l)
            {
                    if (result == null)
                    {
                        result = m;
                    }
                    else
                    {
                        result = result + m;
                    }
                    Text(addSubtractCanvas, 10, y += 15, m.ToString(), Color.FromRgb(255, 0, 0));
            }
            Text(addSubtractCanvas, 10, y += 15, "result:", Color.FromRgb(255, 0, 0));
            Text(addSubtractCanvas, 10, y += 15, result.ToString(), Color.FromRgb(255, 0, 0));
        }

        private void Subtract_Button_Click(object sender, RoutedEventArgs e)
        {
            addSubtractCanvas.Children.Clear();
            result = null;
            List<Vector2> l = VectorCollection.GetSelectedVectors();

            if (l.Count() < 1)
            {
                Text(addSubtractCanvas, 10, 10, "You need to select more vectors.", Color.FromRgb(255, 0, 0));
                return;
            }

            int y = 10;
            Text(addSubtractCanvas, 10, y, "Subtract:", Color.FromRgb(255, 0, 0));
            foreach (Vector2 m in l)
            {
                if (result == null)
                {
                    result = m;
                }
                else
                {
                    result = result - m;
                }
                Text(addSubtractCanvas, 10, y += 15, m.ToString(), Color.FromRgb(255, 0, 0));                
            }
            Text(addSubtractCanvas, 10, y += 15, "result:", Color.FromRgb(255, 0, 0));
            Text(addSubtractCanvas, 10, y += 15, result.ToString(), Color.FromRgb(255, 0, 0));
        }

        private void Multiply_Button_Click(object sender, RoutedEventArgs e)
        {
            multiplyCanvas.Children.Clear();
            result = null;
            List<Vector2> l = VectorCollection.GetSelectedVectors();

            if (l.Count() != 1)
            {
                Text(multiplyCanvas, 10, 10, "You can only select 1 vector.", Color.FromRgb(255, 0, 0));
                return;
            }

            Vector2 vectToUse = l[0];

            int y = 10;
            Text(multiplyCanvas, 10, y, "Multiply:", Color.FromRgb(255, 0, 0));
            foreach (Vector2 m in l)
            {
                Text(multiplyCanvas, 10, y += 15, vectToUse.ToString(), Color.FromRgb(255, 0, 0));
                Text(multiplyCanvas, 10, y += 15, "x " + scalarValue.ToString(), Color.FromRgb(255, 0, 0));
                result = vectToUse * scalarValue;
            }
            Text(multiplyCanvas, 10, y += 15, "result:", Color.FromRgb(255, 0, 0));
            Text(multiplyCanvas, 10, y += 15, result.ToString(), Color.FromRgb(255, 0, 0));
        }

        private void Normalize_Button_Click(object sender, RoutedEventArgs e)
        {
            normalizeCanvas.Children.Clear();
            result = null;
            List<Vector2> l = VectorCollection.GetSelectedVectors();

            if (l.Count() != 1)
            {
                Text(normalizeCanvas, 10, 10, "You can only select 1 vector.", Color.FromRgb(255, 0, 0));
                return;
            }

            Vector2 vectToUse = l[0];

            int y = 10;
            Text(normalizeCanvas, 10, y, "Normailze:", Color.FromRgb(255, 0, 0));
            Text(normalizeCanvas, 10, y += 15, vectToUse.ToString(), Color.FromRgb(255, 0, 0));
            Text(normalizeCanvas, 10, y += 15, "result:", Color.FromRgb(255, 0, 0));
            Text(normalizeCanvas, 10, y += 15, vectToUse.Normalize().ToString(), Color.FromRgb(255, 0, 0));
        }

        private void Length_Button_Click(object sender, RoutedEventArgs e)
        {
            lengthCanvas.Children.Clear();
            result = null;
            List<Vector2> l = VectorCollection.GetSelectedVectors();

            if (l.Count() != 1)
            {
                Text(lengthCanvas, 10, 10, "You can only select 1 vector.", Color.FromRgb(255, 0, 0));
                return;
            }

            Vector2 vectToUse = l[0];

            int y = 10;
            Text(lengthCanvas, 10, y, "Length:", Color.FromRgb(255, 0, 0));
            Text(lengthCanvas, 10, y += 15, vectToUse.ToString(), Color.FromRgb(255, 0, 0));
            Text(lengthCanvas, 10, y += 15, "result:", Color.FromRgb(255, 0, 0));
            Text(lengthCanvas, 10, y += 15, vectToUse.Length().ToString(), Color.FromRgb(255, 0, 0));
        }

        private void Cross_Button_Click(object sender, RoutedEventArgs e)
        {
            crossCanvas.Children.Clear();
            result = null;
            List<Vector2> l = VectorCollection.GetSelectedVectors();

            if (l.Count() != 2)
            {
                Text(crossCanvas, 10, 10, "You must select 2 vectors.", Color.FromRgb(255, 0, 0));
                return;
            }

            if (l[0] is Vector3)
            {
                Text(crossCanvas, 10, 10, "The first vector is only a Vector2.", Color.FromRgb(255, 0, 0));
                return;
            }
            if (!l[1] is Vector3)
            {
                Text(crossCanvas, 10, 10, "The second vector is only a Vector2.", Color.FromRgb(255, 0, 0));
                return;
            }
            Vector3 vecta = l[0] as Vector3;
            Vector3 vectb = l[1] as Vector3;

            int y = 10;
            Text(crossCanvas, 10, y, "Cross product:", Color.FromRgb(255, 0, 0));
            Text(crossCanvas, 10, y += 15, vecta.ToString(), Color.FromRgb(255, 0, 0));
            Text(crossCanvas, 10, y += 15, vectb.ToString(), Color.FromRgb(255, 0, 0));

            result = vecta.Cross(vectb);
            Text(crossCanvas, 10, y += 15, "result:", Color.FromRgb(255, 0, 0));
            Text(crossCanvas, 10, y += 15, result.ToString(), Color.FromRgb(255, 0, 0));
        }

        private void Dot_Button_Click(object sender, RoutedEventArgs e)
        {
            dotCanvas.Children.Clear();
            result = null;
            List<Vector2> l = VectorCollection.GetSelectedVectors();

            if (l.Count() != 2)
            {
                Text(dotCanvas, 10, 10, "You must select 2 vectors.", Color.FromRgb(255, 0, 0));
                return;
            }

            Vector2 vecta = l[0];
            Vector2 vectb = l[1];

            int y = 10;
            Text(dotCanvas, 10, y, "Dot product:", Color.FromRgb(255, 0, 0));
            Text(dotCanvas, 10, y += 15, vecta.ToString(), Color.FromRgb(255, 0, 0));
            Text(dotCanvas, 10, y += 15, vectb.ToString(), Color.FromRgb(255, 0, 0));
            Text(dotCanvas, 10, y += 15, "result:", Color.FromRgb(255, 0, 0));
            Text(dotCanvas, 10, y += 15, vecta.Dot(vectb).ToString(), Color.FromRgb(255, 0, 0));
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
