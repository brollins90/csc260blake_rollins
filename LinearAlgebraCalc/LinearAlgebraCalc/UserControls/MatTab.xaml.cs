using System;
using System.Collections.Generic;
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
using LinearAlgebraCalcLib;
using LinearAlgebraCalc.Models;
using System.Collections.ObjectModel;

namespace LinearAlgebraCalc.UserControls
{
    /// <summary>
    /// Interaction logic for MatTab.xaml
    /// </summary>
    public partial class MatTab : UserControl
    {

        public ObservableCollection<MatViewModel> MatCollection { get; set; }
        public Mat Result { get; set; }
        public Fraction addRValue { get; set; }
        public Fraction addCValue { get; set; }
        public Fraction scalarValue { get; set; }

        public MatTab()
        {
            InitializeComponent();
            DataContext = this;
            scalarValue = new Fraction(1, 2);
            addCValue = new Fraction(3);
            addRValue = new Fraction(3);

            MatCollection = new ObservableCollection<MatViewModel>();
            MatCollection.Add(new MatViewModel(Mat.Identity(3)));
            MatCollection.Add(new MatViewModel(Mat.Identity(3), true));
            MatCollection.Add(new MatViewModel(new Mat(2, 3), true));
            MatCollection.Add(new MatViewModel(Mat.Identity(2)));
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


        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            addSubtractCanvas.Children.Clear();
            Result = null;
            IEnumerable<MatViewModel> l = MatCollection.Where(x => x.Use);

            if (l.Count() < 1)
            {
                Text(addSubtractCanvas, 10, 10, "You need to select more matrices.", Color.FromRgb(255, 0, 0));
                return;
            }
            try
            {
                int y = 10;
                Text(addSubtractCanvas, 10, y, "Add:", Color.FromRgb(255, 0, 0));
                foreach (MatViewModel m in l)
                {
                    if (Result == null)
                    {
                        Result = m.m;
                    }
                    else
                    {
                        Result = Result + m.m;
                    }
                    string matString = m.m.ToString();
                    string[] lines = matString.Split('\n');
                    foreach (string line in lines)
                    {
                        Text(addSubtractCanvas, 10, y += 15, line, Color.FromRgb(255, 0, 0));
                    }
                }
                Text(addSubtractCanvas, 10, y += 15, "result:", Color.FromRgb(255, 0, 0));
                Text(addSubtractCanvas, 10, y += 15, Result.ToString(), Color.FromRgb(255, 0, 0));
            }
            catch (Exception ex)
            {
                addSubtractCanvas.Children.Clear();
                int y = 10;
                Result = null;
                Text(addSubtractCanvas, 10, y += 15, "Error:", Color.FromRgb(255, 0, 0));
                Text(addSubtractCanvas, 10, y += 15, ex.Message, Color.FromRgb(255, 0, 0));
            }
        }

        private void Subtract_Button_Click(object sender, RoutedEventArgs e)
        {
            addSubtractCanvas.Children.Clear();
            Result = null;
            IEnumerable<MatViewModel> l = MatCollection.Where(x => x.Use);

            if (l.Count() < 1)
            {
                Text(addSubtractCanvas, 10, 10, "You need to select more matrices.", Color.FromRgb(255, 0, 0));
                return;
            }
            try
            {
                int y = 10;
                Text(addSubtractCanvas, 10, y, "Subtract:", Color.FromRgb(255, 0, 0));
                foreach (MatViewModel m in l)
                {
                    if (Result == null)
                    {
                        Result = m.m;
                    }
                    else
                    {
                        Result = Result - m.m;
                    }
                    string matString = m.m.ToString();
                    string[] lines = matString.Split('\n');
                    foreach (string line in lines)
                    {
                        Text(addSubtractCanvas, 10, y += 15, line, Color.FromRgb(255, 0, 0));
                    }
                }
                Text(addSubtractCanvas, 10, y += 15, "result:", Color.FromRgb(255, 0, 0));
                Text(addSubtractCanvas, 10, y += 15, Result.ToString(), Color.FromRgb(255, 0, 0));
            }
            catch (Exception ex)
            {
                addSubtractCanvas.Children.Clear();
                int y = 10;
                Result = null;
                Text(addSubtractCanvas, 10, y += 15, "Error:", Color.FromRgb(255, 0, 0));
                Text(addSubtractCanvas, 10, y += 15, ex.Message, Color.FromRgb(255, 0, 0));
            }
        }

        private void Multiply_Button_Click(object sender, RoutedEventArgs e)
        {
            multiplyCanvas.Children.Clear();
            Result = null;
            IEnumerable<MatViewModel> l = MatCollection.Where(x => x.Use);

            if (l.Count() != 2)
            {
                Text(multiplyCanvas, 10, 10, "You need to select 2 matrices.", Color.FromRgb(255, 0, 0));
                return;
            }
            try
            {
                MatViewModel one = l.First();
                MatViewModel two = l.Last();

                int y = 10;
                Text(multiplyCanvas, 10, y, "Multiply:", Color.FromRgb(255, 0, 0));
                Result = one.m * two.m;

                string pstring = one.m.ToString() + "\n x \n" + two.m.ToString() + "\nresult:\n\n" + Result.ToString();
                string[] lines = pstring.Split('\n');
                foreach (string line in lines)
                {
                    Text(multiplyCanvas, 10, y += 15, line, Color.FromRgb(255, 0, 0));
                }
            }
            catch (Exception ex)
            {
                multiplyCanvas.Children.Clear();
                int y = 10;
                Result = null;
                Text(multiplyCanvas, 10, y += 15, "Error:", Color.FromRgb(255, 0, 0));
                Text(multiplyCanvas, 10, y += 15, ex.Message, Color.FromRgb(255, 0, 0));
            }
        }

        private void MultiplyScaler_Button_Click(object sender, RoutedEventArgs e)
        {
            multiplyScalarCanvas.Children.Clear();
            Result = null;
            IEnumerable<MatViewModel> l = MatCollection.Where(x => x.Use);

            if (l.Count() != 1)
            {
                Text(multiplyScalarCanvas, 10, 10, "You need to select 1 matrix.", Color.FromRgb(255, 0, 0));
                return;
            }
            try
            {
                MatViewModel one = l.First();
                int y = 10;
                Text(multiplyScalarCanvas, 10, y, "Multiply:", Color.FromRgb(255, 0, 0));
                Result = one.m * scalarValue;

                string pstring = one.m.ToString() + "\n x \n" + scalarValue.ToString() + "\nresult:\n\n" + Result.ToString();
                string[] lines = pstring.Split('\n');
                foreach (string line in lines)
                {
                    Text(multiplyScalarCanvas, 10, y += 15, line, Color.FromRgb(255, 0, 0));
                }
            }
            catch (Exception ex)
            {
                multiplyScalarCanvas.Children.Clear();
                int y = 10;
                Result = null;
                Text(multiplyScalarCanvas, 10, y += 15, "Error:", Color.FromRgb(255, 0, 0));
                Text(multiplyScalarCanvas, 10, y += 15, ex.Message, Color.FromRgb(255, 0, 0));
            }
        }

        private void Inverse_Button_Click(object sender, RoutedEventArgs e)
        {
            inverseCanvas.Children.Clear();
            Result = null;
            IEnumerable<MatViewModel> l = MatCollection.Where(x => x.Use);

            if (l.Count() != 1)
            {
                Text(inverseCanvas, 10, 10, "You can only select 1 matrix.", Color.FromRgb(255, 0, 0));
                return;
            }

            try
            {
                Mat m = l.First().m;
                Result = Mat.Inverse(m);
                if (Result == null)
                {
                    throw new Exception("There is no inverse for the matrix");
                }

                int y = 10;
                string matString = "Inverse:\n\n" + m.ToString() + "\n\nresult:\n\n" + Result.ToString();
                string[] lines = matString.Split('\n');
                foreach (string line in lines)
                {
                    Text(inverseCanvas, 10, y += 15, line, Color.FromRgb(255, 0, 0));
                }
            }
            catch (Exception ex)
            {
                inverseCanvas.Children.Clear();
                int y = 10;
                Result = null;
                Text(inverseCanvas, 10, y += 15, "Error:", Color.FromRgb(255, 0, 0));
                Text(inverseCanvas, 10, y += 15, ex.Message, Color.FromRgb(255, 0, 0));

            }
        }

        private void Transpose_Button_Click(object sender, RoutedEventArgs e)
        {
            transposeCanvas.Children.Clear();
            Result = null;
            IEnumerable<MatViewModel> l = MatCollection.Where(x => x.Use);

            if (l.Count() != 1)
            {
                Text(transposeCanvas, 10, 10, "You can only select 1 matrix.", Color.FromRgb(255, 0, 0));
                return;
            }
            try
            {
                Mat m = l.First().m;
                Result = m.Transpose();

                int y = 10;
                string matString = "Transpose:\n\n" + m.ToString() + "\n\nresult:\n\n" + Result.ToString();
                string[] lines = matString.Split('\n');
                foreach (string line in lines)
                {
                    Text(transposeCanvas, 10, y += 15, line, Color.FromRgb(255, 0, 0));
                }

            }
            catch (Exception ex)
            {
                multiplyScalarCanvas.Children.Clear();
                int y = 10;
                Result = null;
                Text(transposeCanvas, 10, y += 15, "Error:", Color.FromRgb(255, 0, 0));
                Text(transposeCanvas, 10, y += 15, ex.Message, Color.FromRgb(255, 0, 0));
            }
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Result != null)
            {
                MatCollection.Add(new MatViewModel(Result.Copy()));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int rows = (int)addRValue.ToDouble(0);
                int cols = (int)addCValue.ToDouble(0);
                MatCollection.Add(new MatViewModel(new Mat(rows, cols)));
            }
            catch (Exception) { }
        }

        private void Remove_Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.MatCollection.Clear();
        }
    }
}
