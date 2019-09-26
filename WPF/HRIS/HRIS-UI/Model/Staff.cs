using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS_UI.Model
{
    public class Staff : INotifyPropertyChanged
    {
        private int __ID__;
        public int ID
        {
            get { return this.__ID__; }
            set
            {
                if (this.__ID__ != value)
                {
                    this.__ID__ = value;
                    this.NotifyPropertyChanged("ID");
                }
            }
        }

        private string __FamilyName__;
        public string FamilyName
        {
            get { return this.__FamilyName__; }
            set
            {
                if (this.__FamilyName__ != value)
                {
                    this.__FamilyName__ = value;
                    this.NotifyPropertyChanged("FamilyName");
                }
            }
        }

        private string __GivenName__;
        public string GivenName
        {
            get { return this.__GivenName__; }
            set
            {
                if (this.__GivenName__ != value)
                {
                    this.__GivenName__ = value;
                    this.NotifyPropertyChanged("GivenName");
                }
            }
        }

        private string __Title__;
        public string Title
        {
            get { return this.__Title__; }
            set
            {
                if (this.__Title__ != value)
                {
                    this.__Title__ = value;
                    this.NotifyPropertyChanged("Title");
                }
            }
        }

        private UTASCampus __Campus__;
        public UTASCampus Campus
        {
            get { return this.__Campus__; }
            set
            {
                if (this.__Campus__ != value)
                {
                    this.__Campus__ = value;
                    this.NotifyPropertyChanged("Campus");
                }
            }
        }

   
        /// <summary>
        /// 
        /// </summary>
        private string __Phone__;
        public string Phone
        {
            get { return this.__Phone__; }
            set
            {
                if (this.__Phone__ != value)
                {
                    this.__Phone__ = value;
                    this.NotifyPropertyChanged("Phone");
                }
            }
        }

        private string __Room__;
        public string Room
        {
            get { return this.__Room__; }
            set
            {
                if (this.__Room__ != value)
                {
                    this.__Room__ = value;
                    this.NotifyPropertyChanged("Room");
                }
            }
        }

        private string __Email__;
        public string Email
        {
            get { return this.__Email__; }
            set
            {
                if (this.__Email__ != value)
                {
                    this.__Email__ = value;
                    this.NotifyPropertyChanged("Email");
                }
            }
        }

        private string __Photo__;
        public string Photo
        {
            get { return this.__Photo__; }
            set
            {
                if (this.__Photo__ != value)
                {
                    this.__Photo__ = value;
                    this.NotifyPropertyChanged("Photo");
                }
            }
        }

        private StaffCategory __Category__;
        public StaffCategory Category
        {
            get { return this.__Category__; }
            set
            {
                if (this.__Category__ != value)
                {
                    this.__Category__ = value;
                    this.NotifyPropertyChanged("Category");
                }
            }
        }



        public Staff(string strFamilyName, string strGivenName,
            string strTitle)
        {
            FamilyName = strFamilyName;
            GivenName = strGivenName;
            Title = strTitle;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
