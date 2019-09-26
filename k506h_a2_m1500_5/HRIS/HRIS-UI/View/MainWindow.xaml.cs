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
using HRIS_UI.Controller;
using HRIS_UI.View;

namespace HRIS_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HRISController m_objHRISController;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void SetController(HRISController objController)
        {
            m_objHRISController = objController;

            /**
             m_objHRISController = ((App)Application.Current).GetController();
             */
        }

        public void ShowStaffList()
        {
            Button_Click_Staff(null, null);
        }

        private void Button_Click_Staff(object sender, RoutedEventArgs e)
        {
            //Show Staff list view
            m_btnStaff.IsChecked = true;
            m_btnUnit.IsChecked = false;
            m_btnHeatMap.IsChecked = false;

            //Send request of loading staff info from database to controller
            m_objHRISController.LoadStaffInfo();

            //Controller take over the work of processing UI request
            m_grdHRInfoGrid.Children.Clear();
            m_grdHRInfoGrid.Children.Add(new StaffListView());
        }

        private void Button_Click_Unit(object sender, RoutedEventArgs e)
        {
            //Show Unit view
            m_btnStaff.IsChecked = false;
            m_btnHeatMap.IsChecked = false;

            //Send request of loading unit info from database to controller
            m_objHRISController.LoadUnitInfo();

            //Controller take over the work of processing UI request
            m_grdHRInfoGrid.Children.Clear();
            m_grdHRInfoGrid.Children.Add(new UnitListView());
        }

        private void Button_Click_Heatmap(object sender, RoutedEventArgs e)
        {
            //Show heat map
            m_btnStaff.IsChecked = false;
            m_btnUnit.IsChecked = false;

            //Controller take over the work of processing UI request
            m_grdHRInfoGrid.Children.Clear();
            m_grdHRInfoGrid.Children.Add(new HeatMapView());
        }

        private void Button_Click_Home(object sender, RoutedEventArgs e)
        {
            //Return to home page
            m_btnStaff.IsChecked = false;
            m_btnUnit.IsChecked = false;
            m_btnHeatMap.IsChecked = false;

            //Controller take over the work of processing UI request
            m_grdHRInfoGrid.Children.Clear();
            m_grdHRInfoGrid.Children.Add(new HomePage());
        }
    }
}
