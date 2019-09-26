using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for StaffListView.xaml
    /// </summary>
    public partial class StaffListView : UserControl
    {
        Dictionary<string, StaffCategory> m_mapCategoriesData = new Dictionary<string, StaffCategory>();

        public StaffListView()
        {
            InitializeComponent();

            InitCategories();
            m_lstStaff.ItemsSource = ((App)Application.Current).GetController().StaffDataSource(); //Bind to data source            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Get control that raised this event.
            var textBox = sender as TextBox;

            ((App)Application.Current).GetController().FilterStaffByPattern(textBox.Text);

            //TODO: Sleep
        }

        private void PreMouseLeftDown(object sender, MouseButtonEventArgs e)
        {
            m_txtFilter.Text = "";
        }

        private void m_lstStaff_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridHyperlinkColumn_Click(null, null);
        }

        private void DataGridHyperlinkColumn_Click(object sender, RoutedEventArgs e)
        {
            StaffDetailsView staffDetailsView = new StaffDetailsView();

            int itemSelected = m_lstStaff.SelectedIndex;
            Staff staff = ((App)Application.Current).GetController().StaffDataSource().ElementAt(itemSelected);
            PopulateContentForStaffDetails(ref staffDetailsView, staff);
            staffDetailsView.ShowDialog();
        }

        private void PopulateContentForStaffDetails(ref StaffDetailsView staffDetailsView, Staff staff)
        {
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
        }

        private void InitCategories()
        {
            m_mapCategoriesData.Add(HRISModel.CategoryEnumeToString(StaffCategory.All), StaffCategory.All);
            m_mapCategoriesData.Add(HRISModel.CategoryEnumeToString(StaffCategory.Academic), StaffCategory.Academic);
            m_mapCategoriesData.Add(HRISModel.CategoryEnumeToString(StaffCategory.Administrative), StaffCategory.Administrative);
            m_mapCategoriesData.Add(HRISModel.CategoryEnumeToString(StaffCategory.Casual), StaffCategory.Casual);
            m_mapCategoriesData.Add(HRISModel.CategoryEnumeToString(StaffCategory.Technical), StaffCategory.Technical);

            m_cmbCategory.ItemsSource = m_mapCategoriesData.Keys;
            m_cmbCategory.SelectedIndex = 0;
        }

        private void m_cmbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //PreMouseLeftDown(null, null);
            StaffCategory category = m_mapCategoriesData[m_cmbCategory.SelectedValue.ToString()];

            ((App)Application.Current).GetController().FilterStaffByCategory(category);
        }

        private void DataGridColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            //Implement our sorting here
            //StaffDetailsView staffDetailsView = new StaffDetailsView();
        }
    }
}
