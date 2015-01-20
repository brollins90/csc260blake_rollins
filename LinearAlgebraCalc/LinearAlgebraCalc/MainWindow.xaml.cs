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

        private VectorModelCollection _vectorCollection2;
        public VectorModelCollection VectorCollection2 { get { return _vectorCollection2; } set { _vectorCollection2 = value; } }

        private VectorModelCollection _vectorCollection3;
        public VectorModelCollection VectorCollection3 { get { return _vectorCollection3; } set { _vectorCollection3 = value; } }

        public Fraction scalarValue2 { get; set; }
        public Fraction scalarValue3 { get; set; }

        Vector2 result2;
        Vector3 result3;

        public MainWindow()
        {
            InitializeComponent();

            scalarValue2 = new Fraction(1, 2);
            scalarValue3 = new Fraction(1, 2);

            this.result2 = null;
            this.result3 = null;
            this.DataContext = this;

            this.VectorCollection2 = new VectorModelCollection();
            this.VectorCollection2.Add(new VectorModel()
            {
                Use = true,
                Vector = new Vector2(1, 1)
            });
            this.VectorCollection2.Add(new VectorModel()
            {
                Use = true,
                Vector = new Vector2(2, 2)
            });

            this.VectorCollection3 = new VectorModelCollection();
            this.VectorCollection3.Add(new VectorModel()
            {
                Use = true,
                Vector = new Vector3(
                    new Fraction(1, 2),
                    new Fraction(1, 2),
                    new Fraction(1, 2))
            });
            this.VectorCollection3.Add(new VectorModel()
            {
                Use = true,
                Vector = new Vector3(1, 1, 0)
            });
            this.VectorCollection3.Add(new VectorModel()
            {
                Use = true,
                Vector = new Vector3(2, 2, 2)
            });
            this.VectorCollection3.Add(new VectorModel()
            {
                Use = true,
                Vector = new Vector3(3, 4, 0)
            });
        }
        private void Text(Canvas c, double x, double y, string text, Color color)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = text;
            textBlock.Foreground = new SolidColorBrush(color);
            Canvas.SetLeft(textBlock, x);
            Canvas.SetTop(textBlock, y);
            c.Children.Add(textBlock);
        }

        private void Add3_Button_Click(object sender, RoutedEventArgs e)
        {
            addSubtractCanvas3.Children.Clear();
            result3 = null;
            List<Vector3> l = VectorCollection3.GetSelectedVectors3();

            if (l.Count() < 1)
            {
                Text(addSubtractCanvas3, 10, 10, "You need to select more vectors.", Color.FromRgb(255, 0, 0));
                return;
            }

            int y = 10;
            Text(addSubtractCanvas3, 10, y, "Add:", Color.FromRgb(255, 0, 0));
            foreach (Vector3 m in l)
            {
                if (result3 == null)
                {
                    result3 = m;
                }
                else
                {
                    result3 = result3 + m;
                }
                Text(addSubtractCanvas3, 10, y += 15, m.ToString(), Color.FromRgb(255, 0, 0));
            }
            Text(addSubtractCanvas3, 10, y += 15, "result:", Color.FromRgb(255, 0, 0));
            Text(addSubtractCanvas3, 10, y += 15, result3.ToString(), Color.FromRgb(255, 0, 0));
        }

        private void Add2_Button_Click(object sender, RoutedEventArgs e)
        {
            addSubtractCanvas2.Children.Clear();
            result2 = null;
            List<Vector2> l = VectorCollection2.GetSelectedVectors2();

            if (l.Count() < 1)
            {
                Text(addSubtractCanvas2, 10, 10, "You need to select more vectors.", Color.FromRgb(255, 0, 0));
                return;
            }

            int y = 10;
            Text(addSubtractCanvas2, 10, y, "Add:", Color.FromRgb(255, 0, 0));
            foreach (Vector2 m in l)
            {
                if (result2 == null)
                {
                    result2 = m;
                }
                else
                {
                    result2 = result2 + m;
                }
                Text(addSubtractCanvas2, 10, y += 15, m.ToString(), Color.FromRgb(255, 0, 0));
            }
            Text(addSubtractCanvas2, 10, y += 15, "result:", Color.FromRgb(255, 0, 0));
            Text(addSubtractCanvas2, 10, y += 15, result2.ToString(), Color.FromRgb(255, 0, 0));
        }

        private void Subtract3_Button_Click(object sender, RoutedEventArgs e)
        {
            addSubtractCanvas3.Children.Clear();
            result3 = null;
            List<Vector3> l = VectorCollection3.GetSelectedVectors3();

            if (l.Count() < 1)
            {
                Text(addSubtractCanvas3, 10, 10, "You need to select more vectors.", Color.FromRgb(255, 0, 0));
                return;
            }

            int y = 10;
            Text(addSubtractCanvas3, 10, y, "Subtract:", Color.FromRgb(255, 0, 0));
            foreach (Vector3 m in l)
            {
                if (result3 == null)
                {
                    result3 = m;
                }
                else
                {
                    result3 = result3 - m;
                }
                Text(addSubtractCanvas3, 10, y += 15, m.ToString(), Color.FromRgb(255, 0, 0));
            }
            Text(addSubtractCanvas3, 10, y += 15, "result:", Color.FromRgb(255, 0, 0));
            Text(addSubtractCanvas3, 10, y += 15, result3.ToString(), Color.FromRgb(255, 0, 0));
        }

        private void Subtract2_Button_Click(object sender, RoutedEventArgs e)
        {
            addSubtractCanvas2.Children.Clear();
            result2 = null;
            List<Vector2> l = VectorCollection2.GetSelectedVectors2();

            if (l.Count() < 1)
            {
                Text(addSubtractCanvas2, 10, 10, "You need to select more vectors.", Color.FromRgb(255, 0, 0));
                return;
            }

            int y = 10;
            Text(addSubtractCanvas2, 10, y, "Subtract:", Color.FromRgb(255, 0, 0));
            foreach (Vector2 m in l)
            {
                if (result2 == null)
                {
                    result2 = m;
                }
                else
                {
                    result2 = result2 - m;
                }
                Text(addSubtractCanvas2, 10, y += 15, m.ToString(), Color.FromRgb(255, 0, 0));
            }
            Text(addSubtractCanvas2, 10, y += 15, "result:", Color.FromRgb(255, 0, 0));
            Text(addSubtractCanvas2, 10, y += 15, result2.ToString(), Color.FromRgb(255, 0, 0));
        }

        private void Multiply3_Button_Click(object sender, RoutedEventArgs e)
        {
            multiplyCanvas3.Children.Clear();
            result3 = null;
            List<Vector3> l = VectorCollection3.GetSelectedVectors3();

            if (l.Count() != 1)
            {
                Text(multiplyCanvas3, 10, 10, "You can only select 1 vector.", Color.FromRgb(255, 0, 0));
                return;
            }

            Vector3 vectToUse = l[0];

            int y = 10;
            Text(multiplyCanvas3, 10, y, "Multiply:", Color.FromRgb(255, 0, 0));
            foreach (Vector3 m in l)
            {
                Text(multiplyCanvas3, 10, y += 15, vectToUse.ToString(), Color.FromRgb(255, 0, 0));
                Text(multiplyCanvas3, 10, y += 15, "x " + scalarValue3.ToString(), Color.FromRgb(255, 0, 0));
                result3 = vectToUse * scalarValue3;
            }
            Text(multiplyCanvas3, 10, y += 15, "result:", Color.FromRgb(255, 0, 0));
            Text(multiplyCanvas3, 10, y += 15, result3.ToString(), Color.FromRgb(255, 0, 0));
        }

        private void Multiply2_Button_Click(object sender, RoutedEventArgs e)
        {
            multiplyCanvas2.Children.Clear();
            result2 = null;
            List<Vector2> l = VectorCollection2.GetSelectedVectors2();

            if (l.Count() != 1)
            {
                Text(multiplyCanvas2, 10, 10, "You can only select 1 vector.", Color.FromRgb(255, 0, 0));
                return;
            }

            Vector2 vectToUse = l[0];

            int y = 10;
            Text(multiplyCanvas2, 10, y, "Multiply:", Color.FromRgb(255, 0, 0));
            foreach (Vector2 m in l)
            {
                Text(multiplyCanvas2, 10, y += 15, vectToUse.ToString(), Color.FromRgb(255, 0, 0));
                Text(multiplyCanvas2, 10, y += 15, "x " + scalarValue2.ToString(), Color.FromRgb(255, 0, 0));
                result2 = vectToUse * scalarValue2;
            }
            Text(multiplyCanvas2, 10, y += 15, "result:", Color.FromRgb(255, 0, 0));
            Text(multiplyCanvas2, 10, y += 15, result2.ToString(), Color.FromRgb(255, 0, 0));
        }

        private void Normalize3_Button_Click(object sender, RoutedEventArgs e)
        {
            normalizeCanvas3.Children.Clear();
            result3 = null;
            List<Vector3> l = VectorCollection3.GetSelectedVectors3();

            if (l.Count() != 1)
            {
                Text(normalizeCanvas3, 10, 10, "You can only select 1 vector.", Color.FromRgb(255, 0, 0));
                return;
            }

            Vector3 vectToUse = l[0];

            int y = 10;
            Text(normalizeCanvas3, 10, y, "Normailze:", Color.FromRgb(255, 0, 0));
            Text(normalizeCanvas3, 10, y += 15, vectToUse.ToString(), Color.FromRgb(255, 0, 0));
            Text(normalizeCanvas3, 10, y += 15, "result:", Color.FromRgb(255, 0, 0));
            Text(normalizeCanvas3, 10, y += 15, vectToUse.Normalize().ToString(), Color.FromRgb(255, 0, 0));
        }

        private void Normalize2_Button_Click(object sender, RoutedEventArgs e)
        {
            normalizeCanvas2.Children.Clear();
            result2 = null;
            List<Vector2> l = VectorCollection2.GetSelectedVectors2();

            if (l.Count() != 1)
            {
                Text(normalizeCanvas2, 10, 10, "You can only select 1 vector.", Color.FromRgb(255, 0, 0));
                return;
            }

            Vector2 vectToUse = l[0];

            int y = 10;
            Text(normalizeCanvas2, 10, y, "Normailze:", Color.FromRgb(255, 0, 0));
            Text(normalizeCanvas2, 10, y += 15, vectToUse.ToString(), Color.FromRgb(255, 0, 0));
            Text(normalizeCanvas2, 10, y += 15, "result:", Color.FromRgb(255, 0, 0));
            Text(normalizeCanvas2, 10, y += 15, vectToUse.Normalize().ToString(), Color.FromRgb(255, 0, 0));
        }

        private void Length3_Button_Click(object sender, RoutedEventArgs e)
        {
            lengthCanvas3.Children.Clear();
            result3 = null;
            List<Vector3> l = VectorCollection3.GetSelectedVectors3();

            if (l.Count() != 1)
            {
                Text(lengthCanvas3, 10, 10, "You can only select 1 vector.", Color.FromRgb(255, 0, 0));
                return;
            }

            Vector3 vectToUse = l[0];

            int y = 10;
            Text(lengthCanvas3, 10, y, "Length:", Color.FromRgb(255, 0, 0));
            Text(lengthCanvas3, 10, y += 15, vectToUse.ToString(), Color.FromRgb(255, 0, 0));
            Text(lengthCanvas3, 10, y += 15, "result:", Color.FromRgb(255, 0, 0));
            Text(lengthCanvas3, 10, y += 15, vectToUse.Length().ToString(), Color.FromRgb(255, 0, 0));
        }

        private void Length2_Button_Click(object sender, RoutedEventArgs e)
        {
            lengthCanvas2.Children.Clear();
            result2 = null;
            List<Vector2> l = VectorCollection2.GetSelectedVectors2();

            if (l.Count() != 1)
            {
                Text(lengthCanvas2, 10, 10, "You can only select 1 vector.", Color.FromRgb(255, 0, 0));
                return;
            }

            Vector2 vectToUse = l[0];

            int y = 10;
            Text(lengthCanvas2, 10, y, "Length:", Color.FromRgb(255, 0, 0));
            Text(lengthCanvas2, 10, y += 15, vectToUse.ToString(), Color.FromRgb(255, 0, 0));
            Text(lengthCanvas2, 10, y += 15, "result:", Color.FromRgb(255, 0, 0));
            Text(lengthCanvas2, 10, y += 15, vectToUse.Length().ToString(), Color.FromRgb(255, 0, 0));
        }

        private void Cross3_Button_Click(object sender, RoutedEventArgs e)
        {
            crossCanvas3.Children.Clear();
            result3 = null;
            List<Vector3> l = VectorCollection3.GetSelectedVectors3();

            if (l.Count() != 2)
            {
                Text(crossCanvas3, 10, 10, "You must select 2 vectors.", Color.FromRgb(255, 0, 0));
                return;
            }

            Vector3 vecta = l[0];
            Vector3 vectb = l[1];

            int y = 10;
            Text(crossCanvas3, 10, y, "Cross product:", Color.FromRgb(255, 0, 0));
            Text(crossCanvas3, 10, y += 15, vecta.ToString(), Color.FromRgb(255, 0, 0));
            Text(crossCanvas3, 10, y += 15, vectb.ToString(), Color.FromRgb(255, 0, 0));

            result3 = vecta.Cross(vectb);
            Text(crossCanvas3, 10, y += 15, "result:", Color.FromRgb(255, 0, 0));
            Text(crossCanvas3, 10, y += 15, result3.ToString(), Color.FromRgb(255, 0, 0));
        }

        private void Dot3_Button_Click(object sender, RoutedEventArgs e)
        {
            dotCanvas3.Children.Clear();
            result3 = null;
            List<Vector3> l = VectorCollection3.GetSelectedVectors3();

            if (l.Count() != 2)
            {
                Text(dotCanvas3, 10, 10, "You must select 2 vectors.", Color.FromRgb(255, 0, 0));
                return;
            }

            Vector3 vecta = l[0];
            Vector3 vectb = l[1];

            int y = 10;
            Text(dotCanvas3, 10, y, "Dot product:", Color.FromRgb(255, 0, 0));
            Text(dotCanvas3, 10, y += 15, vecta.ToString(), Color.FromRgb(255, 0, 0));
            Text(dotCanvas3, 10, y += 15, vectb.ToString(), Color.FromRgb(255, 0, 0));
            Text(dotCanvas3, 10, y += 15, "result:", Color.FromRgb(255, 0, 0));
            Text(dotCanvas3, 10, y += 15, vecta.Dot(vectb).ToString(), Color.FromRgb(255, 0, 0));
        }

        private void Dot2_Button_Click(object sender, RoutedEventArgs e)
        {
            dotCanvas2.Children.Clear();
            result2 = null;
            List<Vector2> l = VectorCollection2.GetSelectedVectors2();

            if (l.Count() != 2)
            {
                Text(dotCanvas2, 10, 10, "You must select 2 vectors.", Color.FromRgb(255, 0, 0));
                return;
            }

            Vector2 vecta = l[0];
            Vector2 vectb = l[1];

            int y = 10;
            Text(dotCanvas2, 10, y, "Dot product:", Color.FromRgb(255, 0, 0));
            Text(dotCanvas2, 10, y += 15, vecta.ToString(), Color.FromRgb(255, 0, 0));
            Text(dotCanvas2, 10, y += 15, vectb.ToString(), Color.FromRgb(255, 0, 0));
            Text(dotCanvas2, 10, y += 15, "result:", Color.FromRgb(255, 0, 0));
            Text(dotCanvas2, 10, y += 15, vecta.Dot(vectb).ToString(), Color.FromRgb(255, 0, 0));
        }

        private void Save3_Button_Click(object sender, RoutedEventArgs e)
        {
            if (result3 != null)
            {
                VectorCollection3.Add(new VectorModel()
                {
                    Use = false,
                    Vector = result3
                });
            }
        }

        private void Save2_Button_Click(object sender, RoutedEventArgs e)
        {
            if (result2 != null)
            {
                VectorCollection2.Add(new VectorModel()
                {
                    Use = false,
                    Vector = result2
                });
            }
        }

        
    }
}
