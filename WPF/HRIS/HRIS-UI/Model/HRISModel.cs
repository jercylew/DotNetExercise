using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace HRIS_UI.Model
{
    public enum StaffCategory
    {
        All,
        Academic,
        Technical,
        Administrative,
        Casual
    }

    public enum UTASCampus
    {
        Hobart,
        Launceston,
        Sydney,
        CradleCoast
    }

    public enum ClassType
    {
        Lecture,
        Tutorial,
        Practical,
        Workshop
    }

    public class HRISModel
    {
        //TODO: For DB interaction
        private List<Staff> m_lstAllStaff = new List<Staff>();
        private List<Unit> m_lstAllUnit = new List<Unit>();
        private List<Class> m_lstAllClass = new List<Class>();
        private List<Consultation> m_lstAllConsultation = new List<Consultation>();
        private DBAdapter m_dbAdapter = new DBAdapter();

        private ObservableCollection<Staff> m_lstStaffInfo = new ObservableCollection<Staff>();
        private ObservableCollection<Unit> m_lstUnitInfo = new ObservableCollection<Unit>();

        public void LoadStaffInfoFromDB()
        {
            m_dbAdapter.DoLoadStaffInfoFromDB(ref m_lstAllStaff);
        }

        public void LoadConsultationFromDB()
        {
            m_dbAdapter.DoLoadConsultationFromDB(ref m_lstAllConsultation);
        }

        public void LoadUnitInfoFromDB()
        {
            m_dbAdapter.DoLoadUnitInfoFromDB(ref m_lstAllUnit);
        }

        public void LoadClassInfoFromDB()
        {
            m_dbAdapter.DoLoadClassInfoFromDB(ref m_lstAllClass);
        }

        public List<Class> DoGetTimetableForUnit(string strUnitCode)
        {
            if (m_lstAllClass.Count == 0)
            {
                LoadClassInfoFromDB();
            }

            //Get filtered list
            List<Class> lstFilteredClass;
            var varFilterQuery = from classInfo in m_lstAllClass //List of all staffs
                                 where (classInfo.UnitCode.Equals(strUnitCode))
                                 select classInfo;
            lstFilteredClass = new List<Class>(varFilterQuery);

            return lstFilteredClass;
        }

        public void DoFilterStaffByCategory(StaffCategory category)
        {
            m_lstStaffInfo.Clear();
            m_lstAllStaff.Clear();
            LoadStaffInfoFromDB();

            //Empty filter pattern means not filter
            if (category == StaffCategory.All)
            {
                foreach (Staff staff in m_lstAllStaff)
                {
                    m_lstStaffInfo.Add(staff);
                }

                return;
            }

            //Get filtered list
            List<Staff> lstFilteredStaff;
            var varFilterQuery = from staff in m_lstAllStaff //List of all staffs
                                 where (staff.Category == category)
                                 select staff;
            lstFilteredStaff = new List<Staff>(varFilterQuery);

            //Update to UI
            m_lstAllStaff.Clear();
            foreach (Staff staff in lstFilteredStaff)
            {
                m_lstStaffInfo.Add(staff);
                m_lstAllStaff.Add(staff);
            }
        }

        public void DoFilterStaffByPattern(string strPattern)
        {
            m_lstStaffInfo.Clear();

            //Empty filter pattern means not filter
            if (string.IsNullOrEmpty(strPattern) || strPattern.Contains("Type here to filter"))
            {
                foreach (Staff staff in m_lstAllStaff)
                {
                    m_lstStaffInfo.Add(staff);
                }

                return;
            }

            //Get filtered list
            List<Staff> lstFilteredStaff;
            var varFilterQuery = from staff in m_lstAllStaff //List of all staffs
                                 where (staff.FamilyName.ToLower().Contains(strPattern.ToLower()) ||
                                 staff.GivenName.ToLower().Contains(strPattern.ToLower()))
                                 select staff;
            lstFilteredStaff = new List<Staff>(varFilterQuery);

            //Update to UI
            foreach (Staff staff in lstFilteredStaff)
            {
                m_lstStaffInfo.Add(staff);
            }
        }

        public Staff GetStaffByID(int nID)
        {
            if (m_lstAllStaff.Count == 0)
            {
                LoadStaffInfoFromDB();
            }

            List<Staff> lstFilteredStaff;
            var varFilterQuery = from staff in m_lstAllStaff //List of all staffs
                                 where (staff.ID == nID)
                                 select staff;
            lstFilteredStaff = new List<Staff>(varFilterQuery);

            if (lstFilteredStaff.Count != 1)
            {
                return null;
            }

            return lstFilteredStaff[0];
        }

        public List<Unit> DoGetUnitListByStaff(int nStaffID)
        {
            if (m_lstAllUnit.Count == 0)
            {
                LoadUnitInfoFromDB();
            }

            List<Unit> lstFilteredUnit;
            var varFilterQuery = from unit in m_lstAllUnit
                                 where (unit.Coordinator == nStaffID)
                                 select unit;
            lstFilteredUnit = new List<Unit>(varFilterQuery);

            return lstFilteredUnit;
        }

        public List<Class> DoGetClassByUnit(string strUnitCode)
        {
            if (m_lstAllClass.Count == 0)
            {
                LoadClassInfoFromDB();
            }

            List<Class> lstFilteredClass;
            var varFilterQuery = from classInfo in m_lstAllClass
                                 where (classInfo.UnitCode == strUnitCode)
                                 select classInfo;
            lstFilteredClass = new List<Class>(varFilterQuery);

            return lstFilteredClass;
        }

        public List<Class> DoGetGetClassListForStaff(int nID)
        {
            if (m_lstAllClass.Count == 0)
            {
                LoadClassInfoFromDB();
            }

            List<Class> lstFilteredClass;
            var varFilterQuery = from classInfo in m_lstAllClass
                                 where (classInfo.Staff == nID)
                                 select classInfo;
            lstFilteredClass = new List<Class>(varFilterQuery);

            return lstFilteredClass;
        }

        public List<Consultation> GetConsultationListForStaff(int nID)
        {
            if (m_lstAllConsultation.Count == 0)
            {
                LoadConsultationFromDB();
            }

            List<Consultation> lstFiltered;
            var varFilterQuery = from consult in m_lstAllConsultation
                                 where (consult.StaffID == nID)
                                 select consult;
            lstFiltered = new List<Consultation>(varFilterQuery);

            return lstFiltered;
        }

        public void DoFilterUnitByPattern(string strPattern)
        {
            if (string.IsNullOrEmpty(strPattern) || strPattern.Contains("Type here to filter"))
            {
                m_lstAllUnit.Clear();
                m_lstUnitInfo.Clear();
                LoadUnitInfoFromDB();

                foreach (Unit unit in m_lstAllUnit)
                {
                    m_lstUnitInfo.Add(unit);
                }
                return;
            }

            List<Unit> lstFilteredUnit;
            var varFilterQuery = from unit in m_lstAllUnit
                                 where (unit.UnitCode.ToLower().Contains(strPattern.ToLower()) ||
                                 unit.UnitTitle.ToLower().Contains(strPattern.ToLower()))
                                 select unit;
            lstFilteredUnit = new List<Unit>(varFilterQuery);

            m_lstUnitInfo.Clear();
            foreach (Unit unit in lstFilteredUnit)
            {
                m_lstUnitInfo.Add(unit);
            }
        }

        public ref ObservableCollection<Staff> StaffList()
        {
            return ref m_lstStaffInfo;
        }

        public ref ObservableCollection<Unit> UnitList()
        {
            return ref m_lstUnitInfo;
        }

        public static string CampusEnumeToString(UTASCampus campus)
        {
            string strOutput = "";

            switch (campus)
            {
                case UTASCampus.Hobart:
                    strOutput = "Hobart";
                    break;
                case UTASCampus.Launceston:
                    strOutput = "Launceston";
                    break;
                case UTASCampus.Sydney:
                    strOutput = "Launceston";
                    break;
                case UTASCampus.CradleCoast:
                    strOutput = "Launceston";
                    break;
                default:
                    strOutput = "";
                    //Log("Unknown campus");
                    break;
            }

            return strOutput;
        }

        public static UTASCampus StringToCampusEnume(string campus)
        {
            UTASCampus campusEnume;

            switch (campus)
            {
                case "Hobart":
                    campusEnume = UTASCampus.Hobart;
                    break;
                case "Launceston":
                    campusEnume = UTASCampus.Launceston;
                    break;
                case "Sydney":
                    campusEnume = UTASCampus.Sydney;
                    break;
                case "CradleCoast":
                    campusEnume = UTASCampus.CradleCoast;
                    break;
                default:
                    campusEnume = UTASCampus.Hobart;
                    //Log("Unknown campus");
                    break;
            }

            return campusEnume;
        }

        public static string CategoryEnumeToString(StaffCategory category)
        {
            string strOutput = "";

            switch (category)
            {
                case StaffCategory.Academic:
                    strOutput = "Academic";
                    break;
                case StaffCategory.Administrative:
                    strOutput = "Administrative";
                    break;
                case StaffCategory.All:
                    strOutput = "All";
                    break;
                case StaffCategory.Casual:
                    strOutput = "Casual";
                    break;
                case StaffCategory.Technical:
                    strOutput = "Technical";
                    break;
                default:
                    strOutput = "";
                    //Log("Unknown category");
                    break;
            }

            return strOutput;
        }

        public static StaffCategory StringToCategoryEnume(string category)
        {
            StaffCategory categoryEnume;

            switch (category)
            {
                case "Academic":
                    categoryEnume = StaffCategory.Academic;
                    break;
                case "Admin":
                    categoryEnume = StaffCategory.Administrative;
                    break;
                case "All":
                    categoryEnume = StaffCategory.All;
                    break;
                case "Casual":
                    categoryEnume = StaffCategory.Casual;
                    break;
                case "Technical":
                    categoryEnume = StaffCategory.Technical;
                    break;
                default:
                    categoryEnume = StaffCategory.Academic;
                    break;
            }

            return categoryEnume;
        }

        public static string ClassEnumeToString(ClassType type)
        {
            string strOutput = "";

            switch (type)
            {
                case ClassType.Lecture:
                    strOutput = "Lecture";
                    break;
                case ClassType.Practical:
                    strOutput = "Practical";
                    break;
                case ClassType.Tutorial:
                    strOutput = "Tutorial";
                    break;
                case ClassType.Workshop:
                    strOutput = "Workshop";
                    break;
                default:
                    strOutput = "";
                    //Log("Unknown type");
                    break;
            }

            return strOutput;
        }

        public static ClassType StringToClassType(string type)
        {
            ClassType classType;

            switch (type)
            {
                case "Lecture":
                    classType = ClassType.Lecture;
                    break;
                case "Practical":
                    classType = ClassType.Practical;
                    break;
                case "Tutorial":
                    classType = ClassType.Tutorial;
                    break;
                case "Workshop":
                    classType = ClassType.Workshop;
                    break;
                default:
                    classType = ClassType.Lecture;
                    break;
            }

            return classType;
        }

        public static DayOfWeek StringToWeekDay(string strDay)
        {
            DayOfWeek dayOfWeek;

            switch (strDay)
            {
                case "Monday":
                    dayOfWeek = DayOfWeek.Monday;
                    break;
                case "Tuesday":
                    dayOfWeek = DayOfWeek.Tuesday;
                    break;
                case "Wednesday":
                    dayOfWeek = DayOfWeek.Wednesday;
                    break;
                case "Thursday":
                    dayOfWeek = DayOfWeek.Thursday;
                    break;
                case "Friday":
                    dayOfWeek = DayOfWeek.Friday;
                    break;
                case "Saturday":
                    dayOfWeek = DayOfWeek.Saturday;
                    break;
                case "Sunday":
                    dayOfWeek = DayOfWeek.Sunday;
                    break;
                default:
                    dayOfWeek = DayOfWeek.Monday;
                    break;
            }

            return dayOfWeek;
        }

        public static string WeekDayEnumeToString(DayOfWeek dayOfWeek)
        {
            string strOutput = "";

            switch (dayOfWeek)
            {
                case DayOfWeek.Monday:
                    strOutput = "Monday";
                    break;
                case DayOfWeek.Tuesday:
                    strOutput = "Tuesday";
                    break;
                case DayOfWeek.Wednesday:
                    strOutput = "Wednesday";
                    break;
                case DayOfWeek.Thursday:
                    strOutput = "Thursday";
                    break;
                case DayOfWeek.Friday:
                    strOutput = "Friday";
                    break;
                case DayOfWeek.Saturday:
                    strOutput = "Saturday";
                    break;
                case DayOfWeek.Sunday:
                    strOutput = "Sunday";
                    break;
                default:
                    strOutput = "";
                    //Log("Unknown type");
                    break;
            }

            return strOutput;
        }
    }
}
