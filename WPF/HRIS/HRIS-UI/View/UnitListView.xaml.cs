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
using HRIS_UI.Model;

namespace HRIS_UI.View
{
    /// <summary>
    /// Interaction logic for UnitListView.xaml
    /// </summary>
    public partial class UnitListView : UserControl
    {
        
        public UnitListView()
        {
            InitializeComponent();

            m_lstUnit.ItemsSource = ((App)Application.Current).GetController().UnitDataSource();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Get control that raised this event.
            var textBox = sender as TextBox;

            ((App)Application.Current).GetController().FilterUnitByPattern(textBox.Text);
        }

        private void PreMouseLeftDown(object sender, MouseButtonEventArgs e)
        {
            m_txtFilter.Text = "";
        }

        private void DataGridHyperlinkColumn_Click(object sender, RoutedEventArgs e)
        {
            int itemSelected = m_lstUnit.SelectedIndex;
            Unit unit = ((App)Application.Current).GetController().UnitDataSource().ElementAt(itemSelected);

            UnitDetailsView unitDetailsView = new UnitDetailsView();
            unitDetailsView.SetupUnitInfo(unit, null);

            //TODO: Adjust window position
            unitDetailsView.ShowDialog();
        }

        private void m_lstUnit_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridHyperlinkColumn_Click(null, null);
        }
    }
}
