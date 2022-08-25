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
        private List<User> users = new List<User>()
        {
            new User(){Id = 1, Age = 23, FirstName = "Danish", LastName = "Khan", Salary = "20000"},
            new User(){Id = 2, Age = 23, LastName = "Kumar", FirstName = "Munna",  Salary = "20000"},
            new User(){Id = 1, FirstName = "Danish", Age = 23, LastName = "Khan", Salary = "20000"},
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

            List<string> students = new List<string>();
            var fieldType = Detail.GetType().GetProperties();
            foreach (var field in fieldType)
            {
                students.Add(field.Name);
            }
            Console.WriteLine(students);

            string extendedReturnHtmlForHead = Detail.extendedHtmlForHeadMethod();
            htmlHead = extendedReturnHtmlForHead;

            string extendedReturnHtmlForBody = Detail.extendedHtmlForBodyMethod();
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

