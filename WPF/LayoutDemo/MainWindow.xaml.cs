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

namespace LayoutDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Click_Me(object sender, RoutedEventArgs e)
        {
            //Button btn = sender as Button;
            //string str = btn.Content.ToString() + " button clicked";
            //MessageBox.Show(str);

            GridLayoutDemoWindow window = new GridLayoutDemoWindow();
            window.ShowDialog();
        }
    }
}
