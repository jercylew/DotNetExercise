using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS_UI.Model
{
    public class Unit : INotifyPropertyChanged
    {
        private int __Coordinator__;
        public int Coordinator
        {
            get { return this.__Coordinator__; }
            set
            {
                if (this.__Coordinator__ != value)
                {
                    this.__Coordinator__ = value;
                    this.NotifyPropertyChanged("Coordinator");
                }
            }
        }

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

        private string __UnitTitle__;
        public string UnitTitle
        {
            get { return this.__UnitTitle__; }
            set
            {
                if (this.__UnitTitle__ != value)
                {
                    this.__UnitTitle__ = value;
                    this.NotifyPropertyChanged("UnitTitle");
                }
            }
        }

        public Unit(string strUnitCode, string strUnitTitle)
        {
            UnitCode = strUnitCode;
            UnitTitle = strUnitTitle;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
