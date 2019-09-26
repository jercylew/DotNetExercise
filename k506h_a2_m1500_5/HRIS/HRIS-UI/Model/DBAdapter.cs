using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS_UI.Model
{
    class DBAdapter
    {
        private DBWrapper m_dbWrapper;
        private const string m_strConn = "Database=kit206;Data Source = alacritas.cis.utas.edu.au; User Id = kit206; Password=kit206;SslMode=none";

        public DBAdapter()
        {
            m_dbWrapper = DBWrapper.GetInstance();
        }

        public void GetRows(string strTable, List<string> lstFields,
            string strWhere)
        {

        }

        public void DoLoadUnitInfoFromDB(ref List<Unit> lstUnitInfo)
        {
            lstUnitInfo.Clear();

            MySqlConnection conn = new MySqlConnection(m_strConn);
            try
            {
                var unitDataSet = new DataSet();
                var unitAdapter = new MySqlDataAdapter("select * from unit", conn);
                unitAdapter.Fill(unitDataSet, "unit");

                foreach (DataRow row in unitDataSet.Tables["unit"].Rows)
                {
                    Unit unit = new Unit(row["code"].ToString(),
                        row["title"].ToString());

                    unit.Coordinator = Int32.Parse(row["coordinator"].ToString());
                    lstUnitInfo.Add(unit);
                }
            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public void DoLoadStaffInfoFromDB(ref List<Staff> lstAllStaff)
        {
            if (lstAllStaff.Count > 0)
            {
                return;
            }

            MySqlConnection conn = new MySqlConnection(m_strConn);
            try
            {
                var staffDataSet = new DataSet();
                var staffAdapter = new MySqlDataAdapter("select * from staff order by family_name, given_name", conn);
                staffAdapter.Fill(staffDataSet, "staff");

                foreach (DataRow row in staffDataSet.Tables["staff"].Rows)
                {
                    Staff staff = new Staff(row["given_name"].ToString(),
                        row["family_name"].ToString(), row["title"].ToString());

                    staff.Email = row["email"].ToString();
                    staff.Room = row["room"].ToString();
                    staff.Phone = row["phone"].ToString();
                    staff.Photo = row["photo"].ToString();
                    staff.ID = Int32.Parse(row["id"].ToString());
                    staff.Campus = HRISModel.StringToCampusEnume(row["campus"].ToString());
                    staff.Category = HRISModel.StringToCategoryEnume(row["category"].ToString());

                    lstAllStaff.Add(staff);
                }
            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public void DoLoadConsultationFromDB(ref List<Consultation> lstAllConsultation)
        {
            if (lstAllConsultation.Count > 0)
            {
                return;
            }

            MySqlConnection conn = new MySqlConnection(m_strConn);
            try
            {
                var consultDataSet = new DataSet();
                var consulAdapter = new MySqlDataAdapter("select * from consultation", conn);
                consulAdapter.Fill(consultDataSet, "consultation");

                foreach (DataRow row in consultDataSet.Tables["consultation"].Rows)
                {
                    Consultation consult = new Consultation();

                    consult.StaffID = Int32.Parse(row["staff_id"].ToString());
                    consult.Day = HRISModel.StringToWeekDay(row["day"].ToString());
                    consult.Start = DateTime.Parse(row["start"].ToString());
                    consult.End = DateTime.Parse(row["end"].ToString());

                    lstAllConsultation.Add(consult);
                }
            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public void DoLoadClassInfoFromDB(ref List<Class> lstAllClass)
        {
            if (lstAllClass.Count > 0)
            {
                return;
            }

            MySqlConnection conn = new MySqlConnection(m_strConn);
            try
            {
                var classDataSet = new DataSet();
                var classAdapter = new MySqlDataAdapter("select * from class", conn);
                classAdapter.Fill(classDataSet, "class");

                foreach (DataRow row in classDataSet.Tables["class"].Rows)
                {
                    Class classInfo = new Class();

                    classInfo.Campus = HRISModel.StringToCampusEnume(row["campus"].ToString());
                    classInfo.Day = HRISModel.StringToWeekDay(row["day"].ToString());
                    classInfo.Room = row["room"].ToString();
                    classInfo.Staff = Int32.Parse(row["staff"].ToString());
                    classInfo.UnitCode = row["unit_code"].ToString();
                    classInfo.Type = HRISModel.StringToClassType(row["type"].ToString());
                    classInfo.Start = DateTime.Parse(row["start"].ToString());
                    classInfo.End = DateTime.Parse(row["end"].ToString());

                    lstAllClass.Add(classInfo);
                }
            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

#if false
        public void DoGetTimetableForUnit(string strUnitCode, ref List<Class> lstClass)
        {
            //Get list of class
            //select * from class where unit_code='KIT501'

            //Get list of consultation
            //select * from consultation where staff_id in (select staff from class where unit_code='KIT501');

            MySqlConnection conn = new MySqlConnection(m_strConn);
            try
            {
                var varDataSet = new DataSet();
                var varAdapter = new MySqlDataAdapter(string.Format("select * from class where unit_code='%s'", strUnitCode), conn);
                varAdapter.Fill(varDataSet, "class");

                foreach (DataRow row in varDataSet.Tables["class"].Rows)
                {
                    Class classInfo = new Class();

                    classInfo.Campus = HRISModel.StringToCampusEnume(row["campus"].ToString());
                    classInfo.Day = HRISModel.StringToWeekDay(row["day"].ToString());
                    classInfo.Room = row["room"].ToString();
                    classInfo.Staff = Int32.Parse(row["staff"].ToString());
                    classInfo.UnitCode = row["unit_code"].ToString();
                    classInfo.Type = HRISModel.StringToClassType(row["type"].ToString());
                    classInfo.Start = DateTime.Parse(row["start"].ToString());
                    classInfo.End = DateTime.Parse(row["end"].ToString());

                    lstClass.Add(classInfo);
                }
            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
#endif
    }
}
