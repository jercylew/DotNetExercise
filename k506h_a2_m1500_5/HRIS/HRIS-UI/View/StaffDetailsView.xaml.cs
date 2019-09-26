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
using System.Windows.Shapes;
using HRIS_UI.Model;

namespace HRIS_UI.View
{
    /// <summary>
    /// Interaction logic for StaffDetailsView.xaml
    /// </summary>
    public partial class StaffDetailsView : Window
    {
        private int m_nStaffID;
        public StaffDetailsView()
        {
            InitializeComponent();

            SetAvailability();
        }

        private void SetAvailability()
        {
            DateTime dateTime = DateTime.Now;

            //Get consultation and class for this staff
            // Differnet day: free
            // Else compare time
            //List<Class> lstStaff
        }

        private void DataGridHyperlinkColumn_Click(object sender, RoutedEventArgs e)
        {
            var itemClicked = sender as DataGridHyperlinkColumn;

            Hyperlink link = e.OriginalSource as Hyperlink;
            Unit unit = link.DataContext as Unit;

            UnitDetailsView unitDetailsView = new UnitDetailsView();
            unitDetailsView.SetupUnitInfo(unit, null);

            //TODO: Adjust window position
            unitDetailsView.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StaffActivityGridView staffActivityGridView = new StaffActivityGridView();

            staffActivityGridView.ShowDialog();
        }
    }
}
