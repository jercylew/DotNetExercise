using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS_UI.Model
{
    class DBWrapper
    {
        private static DBWrapper m_sMyself;
        private string m_strDBDriver;
        private string m_strUser;
        private string m_strPassword;
        private string m_strSQLCmd;


        private DBWrapper()
        {
            LoadConfig();
        }

        
        private void LoadConfig()
        {
            // TODO: Load config from a XML file, if cannot find
            // the XML file, just hard code it here
        }

        public bool Open()
        {
            return true;
        }

        public bool Close()
        {
            return true;
        }

        public bool Query()
        {
            return true;
        }

        public static DBWrapper GetInstance()
        {
            if (m_sMyself == null)
            {
                m_sMyself = new DBWrapper();
            }

            return m_sMyself;
        }
    }
}
