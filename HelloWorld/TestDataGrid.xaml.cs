using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;

namespace HelloWorld
{
    public partial class TestDataGrid : Page
    {
        public TestDataGrid()
        {
            this.InitializeComponent();

            //McDataGrid.ItemsSource = "One Two Three Four Five Six Seven Eight One Two Three Four Five Six Seven Eight One Two Three Four Five Six Seven Eight One Two Three Four Five Six Seven Eight".Split();

            List<EmployeeEntity> personEntities = new List<EmployeeEntity>();
            for (int i = 1; i <= 2500; i++)
            {
                personEntities.Add(new EmployeeEntity
                {
                    EmployeeId = i
                    ,
                    EmployeeName = string.Concat("Employee ", i)
                    ,
                    Age = 20 + i
                    ,
                    Salary = 5000 + i * 10
                    ,
                    DOJ = DateTime.Now.AddYears(-10).AddYears(i)
                    ,
                    IsInProject = i % 2 == 0 ? true : false
                });
            }

            McDataGrid.ItemsSource = personEntities;

        }
    }

    public class EmployeeEntity
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public DateTime DOJ { get; set; }
        public bool IsInProject { get; set; }
    }
}
