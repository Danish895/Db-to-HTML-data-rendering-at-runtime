using GenericModelToHTML.Extensions;
using GenericModelToHTML.Model;
using GenericModelToHTML.Service;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<IEnumerable<Student>>> getStudents()

        {
            string yui = string.Empty;
            //backgroundJobClient.Schedule<_HangFireService>(services =>
            //services.getsAllStudents(), Cron.Minutely)
            //RecurringJob.AddOrUpdate<IHangFireService>("fetching-data", services =>
            //services.getsAllStudents(), Cron.Hourly(5));
            //RecurringJob.AddOrUpdate<IHangFireService>("html-rendering", service => service.getsAllStudents(),
            //            Cron.Minutely);
            return Ok();
        }

    }
}

