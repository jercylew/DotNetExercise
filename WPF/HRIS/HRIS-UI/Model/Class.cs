using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace HRIS_UI.Model
{
    public class Class : INotifyPropertyChanged
    {
        private string __UnitCode__;
        public string UnitCode
        {
            get { return this.__UnitCode__; }
            set
            {
                if (this.__UnitCode__ != value)
                {
                    this.__UnitCode__ = value;
                    this.NotifyPropertyChanged("UnitCode");
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

        private DayOfWeek __Day__;
        public DayOfWeek Day
        {
            get { return this.__Day__; }
            set
            {
                if (this.__Day__ != value)
                {
                    this.__Day__ = value;
                    this.NotifyPropertyChanged("Day");
                }
            }
        }

        private DateTime __Start__;
        public DateTime Start
        {
            get { return this.__Start__; }
            set
            {
                if (this.__Start__ != value)
                {
                    this.__Start__ = value;
                    this.NotifyPropertyChanged("Start");
                }
            }
        }

        private DateTime __End__;
        public DateTime End
        {
            get { return this.__End__; }
            set
            {
                if (this.__End__ != value)
                {
                    this.__End__ = value;
                    this.NotifyPropertyChanged("End");
                }
            }
        }

        private ClassType __Type__;
        public ClassType Type
        {
            get { return this.__Type__; }
            set
            {
                if (this.__Type__ != value)
                {
                    this.__Type__ = value;
                    this.NotifyPropertyChanged("Type");
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

        //Use staff ID to link the staff
        private int __Staff__;
        public int Staff
        {
            get { return this.__Staff__; }
            set
            {
                if (this.__Staff__ != value)
                {
                    this.__Staff__ = value;
                    this.NotifyPropertyChanged("Staff");
                }
            }
        }

        //For observation of property change
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
