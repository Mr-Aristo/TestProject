using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TestProjectUI.Models;
using TestProjectUI.Models.Services;

namespace TestProjectUI.Views
{
    /// <summary>
    /// Interaction logic for CreateWindow.xaml
    /// </summary>
    public partial class CreateWindow : Window
    {
        public CreateWindow()
        {
            InitializeComponent();
        }

        private void SimpleButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeService ep = new EmployeeService();
            EmployeeModel md = new EmployeeModel();

            md.EmployeeName = EmpName.Text;
            md.EmployeeDescription = Description.Text;

            ep.CreateEmployee(md);

        }
    }
}
