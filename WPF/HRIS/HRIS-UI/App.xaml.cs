using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using HRIS_UI.Controller;

namespace HRIS_UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private HRISController m_ctrlHRISController;

        private void HRISAppStartup(object sender, StartupEventArgs e)
        {
            MainWindow wndHRISMainWindow = new MainWindow();
            m_ctrlHRISController = new HRISController(new Model.HRISModel(), wndHRISMainWindow);

            wndHRISMainWindow.SetController(m_ctrlHRISController);
            // Show the window
            wndHRISMainWindow.Show();
            //wndHRISMainWindow.ShowStaffList();
        }

        public HRISController GetController()
        {
            return m_ctrlHRISController;
        }
    }
}
