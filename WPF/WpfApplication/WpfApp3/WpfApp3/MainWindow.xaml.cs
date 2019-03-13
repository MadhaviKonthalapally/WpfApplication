using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
using System.Windows.Navigation;
namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EmployeeDetails1 employee = new EmployeeDetails1();
      
        DataClasses1DataContext context = new DataClasses1DataContext();
        bool isInsert=false;
        bool isEdit=false;
        public MainWindow()
        {
            InitializeComponent();
            SalaryDataGrid.Visibility = Visibility.Hidden;
            DateTime startDate = Convert.ToDateTime("01/01/2019");
            DateTime today = DateTime.Now;
            List<string> months = (Enumerable.Range(0, 13).Select(a => startDate.AddMonths(a))
                .TakeWhile(a => a <= today).Select(a => string.Concat(a.ToString("MMMM") + "-" + a.Year))).ToList();
            monthsComboBox.ItemsSource = months;
        }
  
        private void mnuNew_Click(object sender, RoutedEventArgs e)
        {
            EmployeeDataGrid.Visibility = Visibility.Visible;
            
        }
        private void mnuPaid_Click(object sender, RoutedEventArgs e)
        {

            EmployeeDataGrid.Visibility = Visibility.Hidden ;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            EmployeeDataGrid.ItemsSource = GetAllEmployees();
        }
        private ObservableCollection<EmployeeDetails1> GetAllEmployees()
        {
            var empResult = from emp in context.EmployeeDetails1s select emp;

            return new ObservableCollection<EmployeeDetails1>(empResult);
        }
        private void GetAllSalaries()
        {
            if (monthsComboBox.SelectedValue != null)
            {
                var salDetails = (from sal in context.SalaryDetails
                                  join emp in context.EmployeeDetails1s on sal.EmployeeId equals emp.ID
                                  where sal.PaidMonth == monthsComboBox.SelectedValue.ToString()
                                  select new { emp.Name, sal.PaidMonth, sal.PaidAmount }).ToList();
                SalaryDataGrid.ItemsSource = salDetails;
                SalaryDataGrid.Visibility = Visibility.Visible;
            }
        }
        
        private void OnmonthsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string currentMonth = e.AddedItems[0].ToString();
            GetAllSalaries();
           
        }
     
      
    
        private void EmployeeDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            EmployeeDetails1 emp = e.Row.DataContext as EmployeeDetails1;
            //var test = context.tblEmployees.FirstOrDefault(a => a.ID == emp.ID);
            //test.Name = emp.Name;
            //context.SubmitChanges();

            if (emp != null)
            {
                if (emp.ID > 0)
                {
                    isEdit = true;
                }
                else
                {
                    isEdit = false;
                }
            }
            if (isEdit)
            {
                var EditRecord = MessageBox.Show("Do you want to edit " + emp.Name + "?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (EditRecord == MessageBoxResult.Yes)
                {
               employee.Name = emp.Name;
                    employee.Gender = emp.Gender;
                    employee.Salary = emp.Salary;
                    employee.PayDate = emp.PayDate;
                    context.SubmitChanges();
                    EmployeeDataGrid.ItemsSource = GetAllEmployees();
                    MessageBox.Show(employee.ID + " " + employee.Name + " has added sucessfully.", "Add New Employee");
                }
                else
                    EmployeeDataGrid.ItemsSource = GetAllEmployees();
            }
            context.SubmitChanges();
            if (emp != null)
            {
                if (emp.ID > 0)
                {
                    isInsert = false;
                }
                else
                {
                    isInsert = true;
                }
            }

            if (isInsert)
            {
                var InsertRecord = MessageBox.Show("Do you want to add " + emp.Name + "?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (InsertRecord == MessageBoxResult.Yes)
                {
                    employee.Name = emp.Name;
                    employee.Gender = emp.Gender;
                    employee.Salary = emp.Salary;
                    employee.PayDate = emp.PayDate;
                    context.EmployeeDetails1s.InsertOnSubmit(employee);
                    context.SubmitChanges();
                    EmployeeDataGrid.ItemsSource = GetAllEmployees();
                    MessageBox.Show(employee.Name + " " + employee.Gender + "" +employee.Salary+" has added sucessfully.", "Add New Employee", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    EmployeeDataGrid.ItemsSource = GetAllEmployees();
            }
            context.SubmitChanges();
        }
        private void EmployeeDataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete && !isEdit)
            {
                var grid = (DataGrid)sender;
                if (grid.SelectedItems.Count > 0)
                {
                    var result = MessageBox.Show("Are you sure you want to delete this employee?", "Deleting Records", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                    if (result == MessageBoxResult.Yes)
                    {
                        foreach (var row in grid.SelectedItems)
                        {
                            EmployeeDetails1 employee = row as EmployeeDetails1;
                            context.EmployeeDetails1s.DeleteOnSubmit(employee);
                        }
                        context.SubmitChanges();
                        MessageBox.Show("Employee deleted sucessfully.", "Delete Employee", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                        EmployeeDataGrid.ItemsSource = GetAllEmployees();
                }
            }
        }
        private void EmployeeDataGrid_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            isInsert = true;
        }
        private void EmployeeDataGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            isEdit = true;
        }
     
    }
}
