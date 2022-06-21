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
using System.Windows.Input;
using System.Windows.Data;
using System.Collections.ObjectModel;

namespace TestProjectUI.ViewModel
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        #region PropertyChangeEvent
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        static int index = 1;
        EmployeeService service;
        public EmployeeViewModel()
        {
            service = new EmployeeService();

            for (int i = 1; i < 2; i++)
            {
                EmployeeModel d = new EmployeeModel() { EmployeeID = index++, EmployeeName = $"Имя {index}", EmployeeDescription = $"Описание {index}", Parent = col };
                col.Add(d);
                for (int k = 1; k < 2; k++)
                    d.SubItems.Add(new EmployeeModel() { EmployeeID = index++, EmployeeName = $"Имя {index}", EmployeeDescription = $"Описание {index}", Parent = d.SubItems });
            }
            cvs.Source = col;
        }

        private ObservableCollection<EmployeeModel> col = new ObservableCollection<EmployeeModel>();
        private CollectionViewSource cvs = new CollectionViewSource();
        public ICollectionView View { get => cvs.View; }

        public ICommand Add { get => new RelayCommand(CmdAdd); }
        public ICommand Del { get => new RelayCommand(CmdDel); }

        private void CmdAdd(object obj)
        {
            List<EmployeeModel> ls = service.GetAllEmployee();

            EmployeeModel d0 = obj as EmployeeModel;
            d0?.SubItems.Add(new EmployeeModel() { EmployeeID = index++, EmployeeName = $"Имя {index}", EmployeeDescription = $"Описание {index}", Parent = d0.SubItems });
        }

        private void CmdDel(object obj)
        {
            EmployeeModel d = obj as EmployeeModel;
            d?.Parent.Remove(d);
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


   
    }
}
