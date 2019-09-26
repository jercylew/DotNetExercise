using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRIS_UI.Model;

namespace HRIS_UI.Controller
{
    public class HRISController
    {
        HRISModel m_objHRISModel;
        MainWindow m_objMainWindow;

        public HRISController(HRISModel objHRISModel, MainWindow objMainWindow)
        {
            m_objHRISModel = objHRISModel;
            m_objMainWindow = objMainWindow;
        }

        //Control Logic
        public void LoadStaffInfo()
        {
            m_objHRISModel.LoadStaffInfoFromDB();
        }

        public void LoadUnitInfo()
        {
            m_objHRISModel.LoadUnitInfoFromDB();
        }

        public Staff GetStaff(int nID)
        {
            return m_objHRISModel.GetStaffByID(nID);
        }

        public void FilterStaffByPattern(string strPattern)
        {
            m_objHRISModel.DoFilterStaffByPattern(strPattern);
        }

        public void FilterStaffByCategory(StaffCategory category)
        {
            m_objHRISModel.DoFilterStaffByCategory(category);
        }

        public void FilterUnitByPattern(string strPattern)
        {
            m_objHRISModel.DoFilterUnitByPattern(strPattern);
        }

        public List<Unit> GetUnitListByStaff(int nStaffID)
        {
            return m_objHRISModel.DoGetUnitListByStaff(nStaffID);
        }

        public List<Class> GetClassByUnit(string strUnitCode)
        {
            return m_objHRISModel.DoGetClassByUnit(strUnitCode);
        }

        public List<Class> GetTimeTableForUnit(string strUnitCode)
        {
            return m_objHRISModel.DoGetTimetableForUnit(strUnitCode);
        }

        public List<Class> GetClassListForStaff(int nID)
        {
            return m_objHRISModel.DoGetGetClassListForStaff(nID);
        }

        public List<Consultation> GetConsultationListForStaff(int nID)
        {
            return m_objHRISModel.GetConsultationListForStaff(nID);
        }

        public ref ObservableCollection<Staff> StaffDataSource()
        {
            return ref m_objHRISModel.StaffList();
        }

        public ref ObservableCollection<Unit> UnitDataSource()
        {
            return ref m_objHRISModel.UnitList();
        }
    }
}
