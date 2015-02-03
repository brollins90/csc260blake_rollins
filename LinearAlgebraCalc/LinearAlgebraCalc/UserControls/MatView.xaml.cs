using LinearAlgebraCalc.Models;
using LinearAlgebraCalc.ValidationRules;
using LinearAlgebraCalc.ValueConverters;
using LinearAlgebraCalcLib;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace LinearAlgebraCalc.UserControls
{
    /// <summary>
    /// Interaction logic for Mat2CalcControl.xaml
    /// </summary>
    public partial class MatView : UserControl
    {
        bool needToLoad = true;

        public MatView()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(UserControl1_Loaded);
        }

        void UserControl1_Loaded(object sender, RoutedEventArgs e)
        {

            if (needToLoad)
            {
                var mm = this.DataContext as MatViewModel;
                //var mm = new MatViewModel(new Mat(3, 3), true);

                //MatFrame = new Grid();

                for (int i = 0; i < mm.m.Rows; i++)
                {
                    MatFrame.RowDefinitions.Add(new RowDefinition());
                }
                for (int i = 0; i < mm.m.Columns; i++)
                {
                    MatFrame.ColumnDefinitions.Add(new ColumnDefinition());
                }

                for (int row = 0; row < MatFrame.RowDefinitions.Count; row++)
                {
                    for (int col = 0; col < MatFrame.ColumnDefinitions.Count; col++)
                    {
                        TextBox tb = new TextBox();
                        tb.VerticalAlignment = VerticalAlignment.Center;
                        tb.SetValue(Grid.ColumnProperty, col);
                        tb.SetValue(Grid.RowProperty, row);

                        Binding myBinding = new Binding();
                        myBinding.Source = mm;
                        myBinding.Path = new PropertyPath("[" + row + "," + col + "]");
                        myBinding.Mode = BindingMode.TwoWay;
                        //myBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                        myBinding.Converter = new FractionToStringValueConverter();
                        myBinding.ValidationRules.Add(new FractionParseValidationRule());
                        BindingOperations.SetBinding(tb, TextBox.TextProperty, myBinding);

                        MatFrame.Children.Add(tb);
                    }
                }
            } needToLoad = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
