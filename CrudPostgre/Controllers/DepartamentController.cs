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
    public class DepartamentController : ControllerBase
    {
        [HttpPost]
        [Route("Create")]
        public void Create(Departament departament)
        {
            var query = @"insert into Departament(DepartamentName) values (@DepartamentName)";

            using (var conn = new NpgsqlConnection("Server=localhost;Database=mytestdb;User Id=postgres;Password=anonimo;"))
            {
                conn.Open();

                conn.Query(query, new { DepartamentName = departament.DepartamentName }).FirstOrDefault();
            }
        }

        [HttpGet]
        [Route("Read")]
        public List<Departament> Read()
        {
            string query = @"select * from Departament";

            using (var conn = new NpgsqlConnection("Server=localhost;Database=mytestdb;User Id=postgres;Password=anonimo;"))
            {
                conn.Open();

                var resp = conn.Query<Departament>(query).ToList();

                return resp;
            }
        }

        [HttpGet]
        [Route("ReadById/{departamentId}")]
        public Departament ReadById(int departamentId)
        {
            string query = @"select * from Departament where DepartamentId = @DepartamentId";

            using (var conn = new NpgsqlConnection("Server=localhost;Database=mytestdb;User Id=postgres;Password=anonimo;"))
            {
                conn.Open();

                var resp = conn.Query<Departament>(query, new { DepartamentId = departamentId }).FirstOrDefault();

                return resp;
            }
        }

        [HttpGet]
        [Route("ReadAll")]
        public List<DepartamentEmployee> ReadAll()
        {
            string query = @"select 
                             	D.DepartamentName as DpName,
                             	E.EmployeeName as EmpName,
                             	E.DateOfJoing as DateJoing
                             from Departament D
                             inner join Employee E on D.DepartamentName = E.Departament";

            using (var conn = new NpgsqlConnection("Server=localhost;Database=mytestdb;User Id=postgres;Password=anonimo;"))
            {
                conn.Open();

                var resp = conn.Query<DepartamentEmployee>(query).ToList();

                return resp;
            }
        }

        [HttpPut]
        [Route("Update")]
        public void Update(Departament departament)
        {
            var query = @"update Departament set
                          	DepartamentName = @DepartamentName
                          where DepartamentId = @DepartamentId";

            using (var conn = new NpgsqlConnection("Server=localhost;Database=mytestdb;User Id=postgres;Password=anonimo;"))
            {
                conn.Open();

                conn.Query(query,
                  new
                  {
                      DepartamentName = departament.DepartamentName,
                      DepartamentId = departament.DepartamentId
                  }).FirstOrDefault();

            }
        }

        [HttpDelete]
        [Route("Update/{departamentId}")]
        public void Delete(int departamentId)
        {
            var query = @"delete from Departament where DepartamentId = @DepartamentId";

            using (var conn = new NpgsqlConnection("Server=localhost;Database=mytestdb;User Id=postgres;Password=anonimo;"))
            {
                conn.Open();

                conn.Query(query, new { DepartamentId = departamentId }).FirstOrDefault();

            }
        }


    }
}
