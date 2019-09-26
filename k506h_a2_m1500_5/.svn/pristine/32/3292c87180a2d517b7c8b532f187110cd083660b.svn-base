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
    /// Interaction logic for UnitDetailsView.xaml
    /// </summary>
    public partial class UnitDetailsView : Window
    {
        private Unit m_objCurrentUnit = null;
        private Dictionary<Button, int> m_mapButtonID = new Dictionary<Button, int>();
        public UnitDetailsView()
        {
            InitializeComponent();
        }

        public void SetupUnitInfo(Unit unit, string strCampus)
        {
            if (m_gridClassInfo == null)
            {
                return;
            }

            if (m_objCurrentUnit == null)
            {
                m_objCurrentUnit = unit;
            }

            if (m_cmbCampus != null && m_cmbCampus.ItemsSource != null)
            {
                List<string> lstCampus = new List<string>();
                lstCampus.Add("All");
                lstCampus.Add(HRISModel.CampusEnumeToString(UTASCampus.Hobart));
                lstCampus.Add(HRISModel.CampusEnumeToString(UTASCampus.Launceston));
                lstCampus.Add(HRISModel.CampusEnumeToString(UTASCampus.CradleCoast));

                m_cmbCampus.ItemsSource = lstCampus;
            }

            //Create Hader
            CreateHeader();


            List<Class> lstClass = ((App)Application.Current).GetController().GetClassByUnit(unit.UnitCode);
            m_txtUnitName.Text = unit.UnitTitle;

            foreach(Class classInfo in lstClass)
            {
                if (! (string.IsNullOrEmpty(strCampus) || string.IsNullOrWhiteSpace(strCampus) || strCampus.Contains("All")))
                {
                    string strCampusItem = HRISModel.CampusEnumeToString(classInfo.Campus);
                    if (!strCampus.Contains(strCampusItem)) {
                        continue;
                    }
                }

                CreateRow(classInfo);
            }
        }

        private void CreateRow(Class classInfo)
        {
            RowDefinition row = new RowDefinition();
            row.Height = new GridLength(1, GridUnitType.Star);
            m_gridClassInfo.RowDefinitions.Add(new RowDefinition());

            Button btn = new Button();
            btn.Content = HRISModel.WeekDayEnumeToString(classInfo.Day);
            m_gridClassInfo.Children.Add(btn);
            Grid.SetRow(btn, m_gridClassInfo.RowDefinitions.Count - 1);
            Grid.SetColumn(btn, 0);

            btn = new Button();
            btn.Content = classInfo.Start.ToShortTimeString() + " ~ " + classInfo.End.ToShortTimeString();
            m_gridClassInfo.Children.Add(btn);
            Grid.SetRow(btn, m_gridClassInfo.RowDefinitions.Count - 1);
            Grid.SetColumn(btn, 1);

            btn = new Button();
            btn.Content = HRISModel.ClassEnumeToString(classInfo.Type);
            m_gridClassInfo.Children.Add(btn);
            Grid.SetRow(btn, m_gridClassInfo.RowDefinitions.Count - 1);
            Grid.SetColumn(btn, 2);

            btn = new Button();
            btn.Content = classInfo.Room;
            m_gridClassInfo.Children.Add(btn);
            Grid.SetRow(btn, m_gridClassInfo.RowDefinitions.Count - 1);
            Grid.SetColumn(btn, 3);

            btn = new Button();
            btn.Content = HRISModel.CampusEnumeToString(classInfo.Campus);
            m_gridClassInfo.Children.Add(btn);
            Grid.SetRow(btn, m_gridClassInfo.RowDefinitions.Count - 1);
            Grid.SetColumn(btn, 4);

            btn = new Button();
            Staff staff = ((App)Application.Current).GetController().GetStaff(classInfo.Staff);
            btn.Content = (staff.GivenName + " " + staff.FamilyName);
            m_mapButtonID.Add(btn, staff.ID);
            btn.Cursor = Cursors.Hand;
            btn.Foreground = Brushes.Blue;
            btn.Click += Staff_Button_Click;
            m_gridClassInfo.Children.Add(btn);
            Grid.SetRow(btn, m_gridClassInfo.RowDefinitions.Count - 1);
            Grid.SetColumn(btn, 5);
        }

        private void Staff_Button_Click(object sender, RoutedEventArgs e)
        {
            StaffDetailsView staffDetailsView = new StaffDetailsView();

            var btnStaff = sender as Button;
            int nID = m_mapButtonID[btnStaff];

            Staff staff = ((App)Application.Current).GetController().GetStaff(nID);

            if (staff == null)
            {
                return;
            }

            staffDetailsView.m_txtName.Text = staff.FamilyName + " " + staff.GivenName;
            staffDetailsView.Title = "Staff Details - " + staffDetailsView.m_txtName.Text;
            staffDetailsView.m_txtPhone.Text = staff.Phone;
            staffDetailsView.m_txtRoom.Text = staff.Room;
            staffDetailsView.m_txtEmail.Text = staff.Email;

            BitmapImage bmpPhoto = new BitmapImage();
            bmpPhoto.BeginInit();
            bmpPhoto.UriSource = new Uri(staff.Photo);
            bmpPhoto.EndInit();
            staffDetailsView.m_imgStaffPhoto.Source = bmpPhoto;

            staffDetailsView.m_txtCampus.Text = HRISModel.CampusEnumeToString(staff.Campus);
            staffDetailsView.m_lstUnitsOfTeaching.ItemsSource = ((App)Application.Current).GetController().GetUnitListByStaff(staff.ID);

            staffDetailsView.ShowDialog();
        }

        private void CreateHeader()
        {
            RowDefinition row = new RowDefinition();
            row.Height = new GridLength(1, GridUnitType.Star);
            m_gridClassInfo.RowDefinitions.Add(new RowDefinition());

            Button btn = new Button();
            btn.Content = "Day";
            btn.FontWeight = FontWeights.Bold;
            m_gridClassInfo.Children.Add(btn);
            Grid.SetRow(btn, m_gridClassInfo.RowDefinitions.Count - 1);
            Grid.SetColumn(btn, 0);

            btn = new Button();
            btn.Content = "Start - End Time";
            btn.FontWeight = FontWeights.Bold;
            m_gridClassInfo.Children.Add(btn);
            Grid.SetRow(btn, m_gridClassInfo.RowDefinitions.Count - 1);
            Grid.SetColumn(btn, 1);

            btn = new Button();
            btn.Content = "Type";
            btn.FontWeight = FontWeights.Bold;
            m_gridClassInfo.Children.Add(btn);
            Grid.SetRow(btn, m_gridClassInfo.RowDefinitions.Count - 1);
            Grid.SetColumn(btn, 2);

            btn = new Button();
            btn.Content = "Room Location";
            btn.FontWeight = FontWeights.Bold;
            m_gridClassInfo.Children.Add(btn);
            Grid.SetRow(btn, m_gridClassInfo.RowDefinitions.Count - 1);
            Grid.SetColumn(btn, 3);

            btn = new Button();
            btn.Content = "Campus";
            btn.FontWeight = FontWeights.Bold;
            m_gridClassInfo.Children.Add(btn);
            Grid.SetRow(btn, m_gridClassInfo.RowDefinitions.Count - 1);
            Grid.SetColumn(btn, 4);

            btn = new Button();
            btn.FontWeight = FontWeights.Bold;
            btn.Content = "Staff Member";
            m_gridClassInfo.Children.Add(btn);
            Grid.SetRow(btn, m_gridClassInfo.RowDefinitions.Count - 1);
            Grid.SetColumn(btn, 5);
        }

        private void m_cmbCampus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string strSelectedCampus = m_cmbCampus.SelectedValue.ToString();

            ClearContents();
            SetupUnitInfo(m_objCurrentUnit, strSelectedCampus);
        }

        private void ClearContents()
        {
            if (m_gridClassInfo == null)
            {
                return;
            }

            int nCount = m_gridClassInfo.Children.Count;
            m_gridClassInfo.Children.RemoveRange(0, nCount);
            nCount = m_gridClassInfo.RowDefinitions.Count;
            m_gridClassInfo.RowDefinitions.RemoveRange(0, nCount);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClashMapView clashMapView = new ClashMapView();

            clashMapView.ShowDialog();
        }

        private void m_btnStaff5_Click(object sender, RoutedEventArgs e)
        {
            var btnStaff = sender as Button;
            string strID = btnStaff.Content.ToString();


        }

        private void m_btnStaff4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void m_btnStaff3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void m_btnStaff2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void m_btnStaff1_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
