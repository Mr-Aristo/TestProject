using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using TestProjectUI.Models.Services;
using TestProjectUI.Models;
using TestProjectUI.Commands;
using System.Windows;

namespace TestProjectUI.ViewModel
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        EmployeeService service;
        public EmployeeViewModel()
        {
            service = new EmployeeService();
        }

        private List<EmployeeModel> employeeList;

        public List<EmployeeModel> EmployeeList
        {
            get { return employeeList; }
            set { employeeList = value; OnPropertyChange("EmployeeList"); }

        }
        private void LoadData()
        {
            //EmployeeList = service.GetAllEmployee();
        }
                       

        private EmployeeModel employee;

        public EmployeeModel EmployeeAdd
        {
            get { return employee; }
            set { employee = value; OnPropertyChange("EmployeeAdd"); }

        }


        public string EmployeeName
        {
            get { return employee.EmployeeName; }
            set { employee.EmployeeName = value; OnPropertyChange("EmployeeName"); }
        }

        public string EmployeeDescription
        {
            get { return employee.EmployeeDescription; }
            set { employee.EmployeeDescription = value; OnPropertyChange("EmployeeDescription"); }
        }


        #region Command
        private RelayCommand saveCommand;

        public RelayCommand SaveCommand
        {
            get { return saveCommand; }
            
        }
        public void Save()
        {
            try
            {
                 service.CreateEmployee(EmployeeAdd);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}
