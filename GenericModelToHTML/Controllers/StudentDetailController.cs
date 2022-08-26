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
            new User(){Id = 1, FirstName = "Danish", Age = 23, LastName = "Khan", Salary = "25000"},
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

            List<string> studentnew=new List<string>();
            var fieldType = new List<User>() { new User() }.First().GetType().GetProperties();
            foreach (var field in fieldType)
            {
                studentnew.Add(field.Name);
            }
            var myhtmlHeadTemplate = await _UserService.GetBody();

            string htmlHeadTemplate = myHtmlBodyMethod(myhtmlHeadTemplate);

            string extendedReturnHtmlForHead = users.extendedHtmlForHeadMethod(studentnew, htmlHeadTemplate);
            htmlHead = extendedReturnHtmlForHead;

            htmlFinal = WelcomeHTML(htmlHead);
            return new ContentResult
            {
                Content = htmlFinal,
                ContentType = MediaTypeNames.Text.Html,
                StatusCode = 200
            };
        }

        private string myHtmlBodyMethod(Document myhtmlHeadTemplate)
        {
            string htmlBody = myhtmlHeadTemplate.Content;
            return htmlBody;
        }


        private string WelcomeHTML(string htmlHead)
        {
            var html = System.IO.File.ReadAllText(@"./HtmlRender/Page.html");
            html = html.Replace("{{HtmlBody}}", htmlHead);
           // html = html.Replace("{{HtmlData}}", htmlBody);
            return html;
        }

    }
}

