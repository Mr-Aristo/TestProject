using DevExpress.ClipboardSource.SpreadsheetML;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectUI.Models
{
    public class EmployeeModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private int id;
        public int EmployeeID { get { return id; } set { id = value; OnPropertyChanged("Id"); } }


        private string name;
        public string EmployeeName { get { return name; } set { name = value; OnPropertyChanged("Name"); } }


        private string description;
        public string EmployeeDescription { get { return description;  } set { description = value; OnPropertyChanged("Description"); } }

        public ObservableCollection<EmployeeModel> SubItems { get; set; } = new ObservableCollection<EmployeeModel> { };
        public ObservableCollection<EmployeeModel> Parent { get; set; }
    }
}
