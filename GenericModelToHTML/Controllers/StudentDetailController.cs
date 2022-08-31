using GenericModelToHTML.Extensions;
using GenericModelToHTML.Model;
using GenericModelToHTML.Service;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mime;

namespace GenericModelToHTML.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentDetailController : ControllerBase
    {
        private IUserService _UserService;
        private IBackgroundJobClient _BackgroundJobClient;

        private List<User> users = new List<User>()
        {
            new User(){Id = 1, Age = 23, FirstName = "Danish", LastName = "Khan", Salary = "20000"},
            new User(){Id = 2, Age = 23, LastName = "Kumar", FirstName = "Munna",  Salary = "20000"},
            new User(){Id = 1, FirstName = "Danish", Age = 23, LastName = "Khan", Salary = "25000"},
        };
        public StudentDetailController(IUserService userService, IBackgroundJobClient backgroundJobClient)
        {
            _UserService = userService;
            _BackgroundJobClient = backgroundJobClient;
        }

        [HttpGet]
        public IEnumerable<Document> ModelFromDB()

        {
            string connString = "Server=localhost, 1433;Database=StudentDatabase;User Id=sa;Password=Youtube2021;";

            List<Document> Document = new List<Document>();

            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open(); Console.WriteLine("connection open");
                string query = @"SELECT * FROM dbo.Documents";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            var map = new Document();
                            map.Id = reader.GetInt32("Id");
                            map.Content = reader.GetString("Content");
                            map.ContentType = reader.GetString("ContentType");
                            map.Code = reader.GetString("Code");

                            Document.Add(map);
                        }
                    }
                }
            }
            return Document;

            //backgroundJobClient.Schedule<_HangFireService>(services =>
            //services.getsAllStudents(), Cron.Minutely)
            //RecurringJob.AddOrUpdate<IHangFireService>("fetching-data", services =>
            //services.getsAllStudents(), Cron.Hourly(5));
            //RecurringJob.AddOrUpdate<IHangFireService>("html-rendering", service => service.getsAllStudents(),
            //            Cron.Minutely);

        }
    }
}

