using GenericModelToHTML.Extensions;
using GenericModelToHTML.Model;
using GenericModelToHTML.Service;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace GenericModelToHTML.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentDetailController : ControllerBase
    {
        private IUserService _UserService;
        private List<User1> users = new List<User1>()
        {
            new User1(){Id = 1, Age = 23, FirstName = "Danish", LastName = "Khan", Salary = "20000"},
            new User1(){Id = 2, Age = 23, LastName = "Kumar", FirstName = "Munna",  Salary = "20000"},
            new User1(){Id = 1, FirstName = "Danish", Age = 23, LastName = "Khan", Salary = "25000"},
        };
        public StudentDetailController(IUserService userService)
        {
            _UserService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudentDetails()
        {
            var Detail = await _UserService.getAllStudents();
            string htmlHead = String.Empty;
            string htmlBody = String.Empty;
            string htmlFinal = String.Empty;

            IEnumerable<string> students = new List<string>();
            List<string> studentnew=new List<string>();
            var fieldType = new List<User>() { new User() }.First().GetType().GetProperties();
            foreach (var field in fieldType)
            {
                string hh = field.Name;
                students.ToList().Add(hh);
                studentnew.Add(hh);
            }
            System.Console.WriteLine(students);
            System.Console.WriteLine(studentnew);

            string extendedReturnHtmlForHead = users.extendedHtmlForHeadMethod( studentnew);
            htmlHead = extendedReturnHtmlForHead;

            string extendedReturnHtmlForBody = users.extendedHtmlForBodyMethod(studentnew );
            htmlBody = extendedReturnHtmlForBody;

            htmlFinal += WelcomeHTML(htmlHead, htmlBody);
            return new ContentResult
            {
                Content = htmlFinal,
                ContentType = MediaTypeNames.Text.Html,
                StatusCode = 200
            };
        }
        private string WelcomeHTML(string htmlHead, string htmlBody)
        {
            var html = System.IO.File.ReadAllText(@"./HtmlRender/Page.html");
            html = html.Replace("{{HtmlHead}}", htmlHead);
            html = html.Replace("{{HtmlData}}", htmlBody);
            return html;
        }
    }
}

