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
    /// Interaction logic for StaffTimeTableView.xaml
    /// </summary>
    public partial class StaffTimeTableView : Window
    {
        public StaffTimeTableView()
        {
            InitializeComponent();
        }

        public void LoadData(string strUnitCode)
        {
            List<Class> lstClass = new List<Class>();
            lstClass = ((App)Application.Current).GetController().GetTimeTableForUnit(strUnitCode);

            foreach (Class classInfo in lstClass)
            {
                List<TextBox> lstTextBox = GetTextboxListForClass(classInfo);

                foreach (TextBox textBox in lstTextBox)
                {
                   textBox.Text = (HRISModel.ClassEnumeToString(classInfo.Type) + "\r\n" +
                   classInfo.Room + "  " + HRISModel.CampusEnumeToString(classInfo.Campus) + "\r\n" +
                   classInfo.Staff);
                }
            }
        }

        private List<TextBox> GetTextboxListForClass(Class classInfo)
        {
            List<TextBox> lstTextbox = new List<TextBox>();

            string strDay = HRISModel.WeekDayEnumeToString(classInfo.Day);
            int nHourStart = classInfo.Start.Hour;
            int nHourEnd = classInfo.End.Hour;

            for (int i = nHourStart;i < nHourEnd;i++)
            {
                string strButtonName = GenerateButtonName(strDay, i, i + 1);
                TextBox btnTimeTableItem = m_gridTimetable.FindName(strButtonName) as TextBox;
                lstTextbox.Add(btnTimeTableItem);
            }

            return lstTextbox;
        }

        private string GenerateButtonName(string strDay, int nStart, int nEnd)
        {
            return string.Format("m_txt{0}_{1}_{2}", strDay, nStart, nEnd);
        }
    }
}
