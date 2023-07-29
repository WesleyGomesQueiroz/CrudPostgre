using System;

namespace CrudPostgre.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Departament { get; set; }
        public DateTime DateOfJoing { get; set; }
        public string PhotoFileName { get; set; }
    }
}
