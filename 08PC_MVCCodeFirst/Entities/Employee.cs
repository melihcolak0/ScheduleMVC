using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _08PC_MVCCodeFirst.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public decimal EmployeeSalary { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
