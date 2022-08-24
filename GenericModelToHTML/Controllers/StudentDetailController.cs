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
        public StudentDetailController(IUserService userService)
        {
            _UserService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudentDetails()
        {
            var Detail  = await _UserService.getAllStudents();

                string htmlHead = String.Empty;
                string htmlBody = String.Empty;
                string htmlFinal = String.Empty;
                {
                    foreach (var studentDetail  in Detail)
                    {
                        string extendedReturnHtmlForHead = studentDetail.extendedHtmlForHeadMethod<Student>();
                        htmlHead = extendedReturnHtmlForHead;
                        
                        string extendedReturnHtmlForBody = studentDetail.extendedHtmlForBodyMethod<Student>();
                        htmlBody += extendedReturnHtmlForBody;
                    }
                     htmlFinal = WelcomeHTML(htmlHead, htmlBody);
                }                
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

