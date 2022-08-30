using GenericModelToHTML.Extensions;
using GenericModelToHTML.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace GenericModelToHTML.Service
{
    public class HangFireService : IHangFireService
    {
        private IUserService _UserService;
        private IEmailService _EmailService;
        private List<User> users = new List<User>()
        {
            new User(){Id = 1, Age = 23, FirstName = "Danish", LastName = "Khan", Salary = "20000"},
            new User(){Id = 2, Age = 23, LastName = "Kumar", FirstName = "Munna",  Salary = "20000"},
            new User(){Id = 1, FirstName = "Danish", Age = 23, LastName = "Khan", Salary = "25000"},
        };
        public HangFireService(IUserService userService, IEmailService emailService)
        {
            _UserService = userService;
            _EmailService = emailService;
        }

        public async Task<ActionResult<IEnumerable<Student>>> getsAllStudents()
        {
            var Detail = await _UserService.getAllStudents();
            string htmlHead = String.Empty;
            string htmlBody = String.Empty;
            string htmlFinal = String.Empty;


            List<string> studentnew = new List<string>();
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

            bool EmailSent = _EmailService.sendEmail(htmlFinal);
            if (EmailSent)
            {
                Console.WriteLine("Email sent successfully");
            }

            bool htmlInDb = await _UserService.fileSavingInDb(htmlFinal);
            if (htmlInDb)
            {
                Console.WriteLine("File saved successfully in db");
            }

            return new ContentResult
            {
                Content = htmlFinal,
                ContentType = MediaTypeNames.Text.Html,
                StatusCode = 200
            };
            Console.WriteLine(htmlFinal);
        }

        private string myHtmlBodyMethod(Document myhtmlHeadTemplate)
        {
            string htmlBody = myhtmlHeadTemplate.Content;
            return htmlBody;
        }

        private string WelcomeHTML(string htmlBody)
        {
            var html = System.IO.File.ReadAllText(@"./HtmlRender/Page.html");
            html = html.Replace("{{HtmlBody}}", htmlBody);
            
            return html;
        }
    }
}
