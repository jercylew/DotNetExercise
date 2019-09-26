using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS_UI.Model
{
    public class Consultation : INotifyPropertyChanged
    {
        private int __StaffID__;
        public int StaffID
        {
            get { return this.__StaffID__; }
            set
            {
                if (this.__StaffID__ != value)
                {
                    this.__StaffID__ = value;
                    this.NotifyPropertyChanged("StaffID");
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

        //For observation of property change
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
