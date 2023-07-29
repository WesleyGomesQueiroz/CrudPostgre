using CrudPostgre.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Collections.Generic;
using System.Linq;

namespace CrudPostgre.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        [HttpPost]
        [Route("Create")]
        public void Create(Employee employee)
        {
            var query = @"call create_employee(@EmployeeName, @Departament, @PhotoFileName)";

            using (var conn = new NpgsqlConnection("Server=localhost;Database=mytestdb;User Id=postgres;Password=anonimo;"))
            {
                conn.Open();

                conn.Query(query, new
                {
                    EmployeeName = employee.EmployeeName,
                    Departament = employee.Departament,
                    PhotoFileName = employee.PhotoFileName,
                }).FirstOrDefault();
            }
        }

        [HttpGet]
        [Route("Read")]
        public List<Employee> Read()
        {
            string query = @"select * from read_employee()";

            using (var conn = new NpgsqlConnection("Server=localhost;Database=mytestdb;User Id=postgres;Password=anonimo;"))
            {
                conn.Open();

                var resp = conn.Query<Employee>(query).ToList();

                return resp;
            }
        }

        [HttpGet]
        [Route("ReadById/{employeeId}")]
        public Employee ReadById(int employeeId)
        {
            string query = @"select * from read_by_id_employee(@EmployeeId)";

            using (var conn = new NpgsqlConnection("Server=localhost;Database=mytestdb;User Id=postgres;Password=anonimo;"))
            {
                conn.Open();

                var resp = conn.Query<Employee>(query, new { EmployeeId = employeeId }).FirstOrDefault();

                return resp;
            }
        }

        [HttpPut]
        [Route("Update")]
        public void Update(Employee employee)
        {
            var query = @"call update_employee(@EmployeeId, @EmployeeName, @Departament, @PhotoFileName)";

            using (var conn = new NpgsqlConnection("Server=localhost;Database=mytestdb;User Id=postgres;Password=anonimo;"))
            {
                conn.Open();

                conn.Query(query, new
                {
                    EmployeeName = employee.EmployeeName,
                    Departament = employee.Departament,
                    PhotoFileName = employee.PhotoFileName,
                    EmployeeId = employee.EmployeeId,
                }).FirstOrDefault();
            }
        }
        
        [HttpDelete]
        [Route("Delete/{employeeId}")]
        public void Delete(int employeeId)
        {
            var query = @"call delete_employee(@EmployeeId)";

            using (var conn = new NpgsqlConnection("Server=localhost;Database=mytestdb;User Id=postgres;Password=anonimo;"))
            {
                conn.Open();

                conn.Query(query, new { EmployeeId = employeeId, }).FirstOrDefault();
            }
        }
    }
}
