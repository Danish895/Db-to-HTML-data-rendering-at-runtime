using AutoMapper;
using AutoMapper.QueryableExtensions;
using GenericModelToHTML.DataAccessLayer.Context;
using GenericModelToHTML.Extensions;
using GenericModelToHTML.Model;
using GenericModelToHTML.Service;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI;
using System.ComponentModel.DataAnnotations.Schema;
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
        private StudentDbContext _context;
        private IMapper _mapper;

        private List<User> users = new List<User>()
        {
            new User(){Id = 1, Age = 23, FirstName = "Danish", LastName = "Khan", Salary = "20000"},
            new User(){Id = 2, Age = 23, LastName = "Kumar", FirstName = "Munna",  Salary = "20000"},
            new User(){Id = 1, FirstName = "Danish", Age = 23, LastName = "Khan", Salary = "25000"},
        };
        public StudentDetailController(IUserService userService, IBackgroundJobClient backgroundJobClient, StudentDbContext context, IMapper mapper)
        {
            _UserService = userService;
            _BackgroundJobClient = backgroundJobClient;
            _context = context;
            _mapper = mapper;   
        }

        [HttpGet]
        public async Task<IEnumerable<DocumentDTO>> ModelFromDBs()
        {
            var data = await _context.DocumentDTOs.ToListAsync();
            return data;
        }
            // SQL STRING
            //string connString = "Server=localhost,1433; Database=StudentDatabase; User Id=sa; Password=Youtube2021;";

            //List<Document> Document = new List<Document>();

            //using (SqlConnection connection = new SqlConnection(connString))
            //{
            //    connection.Open(); Console.WriteLine("connection open");

            //    string query = @"SELECT * FROM dbo.Documents";

            //    using (SqlCommand cmd = new SqlCommand(query, connection))
            //    {
            //        using (SqlDataReader reader = cmd.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                var map = new Document();
            //                map.Id = reader.GetInt32("Id");
            //                map.Content = reader.GetString("Content");
            //                map.ContentType = reader.GetString("ContentType");
            //                map.Code = reader.GetString("Code");

            //                Document.Add(map);
            //            }
            //        }
            //    }
            //}
            //return Document;

            // USING AUTOMAPPER


            //return await _context.Documents
            //    .ProjectTo<DocumentDTO>(_mapper.ConfigurationProvider)

            //    .ToListAsync();

            //backgroundJobClient.Schedule<_HangFireService>(services =>
            //services.getsAllStudents(), Cron.Minutely)
            //RecurringJob.AddOrUpdate<IHangFireService>("fetching-data", services =>
            //services.getsAllStudents(), Cron.Hourly(5));
            //RecurringJob.AddOrUpdate<IHangFireService>("html-rendering", service => service.getsAllStudents(),
            //            Cron.Minutely);


            //string schema = tableAttribute.Schema;
            //string Name = tableAttribute.Name;

            //Console.WriteLine(tableAttribute.Schema);

            //foreach (var item in tableAttribute)
            //{
            //    var fieldTypes = item.GetType();

            //    foreach (var fieldOf in Documents)
            //    {
            //        var field = fieldTypes.GetProperty(fieldOf);
            //        Documents.Add(field.GetValue(item).ToString());
            //    }
            //}
        
    }
}

