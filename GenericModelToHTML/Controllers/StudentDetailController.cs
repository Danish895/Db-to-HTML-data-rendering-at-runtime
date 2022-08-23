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
            var Detail = await _UserService.getAllStudents();
            {
                var htmlHeadTemplate = System.IO.File.ReadAllText(@"./HtmlRender/head.html");
                var htmlBodyTemplate = System.IO.File.ReadAllText(@"./HtmlRender/body.html");
               
                string htmlHead = String.Empty;
                string htmlBody = String.Empty;
                string htmlFinal = String.Empty;

                {
                    foreach (var studentDetail in Detail)
                    {
                        string extendedReturnHtmlForHead = htmlHeadTemplate.extendedHtmlForHeadMethod(studentDetail);
                        htmlHead = extendedReturnHtmlForHead;
                        // string extendedReturnHtmlForBody = HtmlBodyMethod(studentDetail);
                        string extendedReturnHtmlForBody = htmlBodyTemplate.extendedHtmlForBodyMethod(studentDetail);
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
        }

        //If We do not want to use Extended method. Please uncomment below function

        //private string HtmlBodyMethod(Student studentDetail)
        //{
        //    var html = System.IO.File.ReadAllText(@"./HtmlRender/body.html");
        //    var fieldType = studentDetail.GetType().GetProperties();
        //    string html1 = string.Empty;
        //    string html3 = string.Empty;
        //        foreach (var field in fieldType)
        //        {
        //            if (field.GetValue(studentDetail) == null)
        //            {
        //                continue;
        //            }
        //        html1 = html.Replace("{{HtmlBodyData}}", field.GetValue(studentDetail).ToString());
        //        html3 += html1;
        //        }
        //        return html3;
        //}

        private string WelcomeHTML(string htmlHead, string htmlBody)
        {
            var html = System.IO.File.ReadAllText(@"./HtmlRender/Page.html");
            html = html.Replace("{{HtmlHead}}", htmlHead);
            html = html.Replace("{{HtmlData}}", htmlBody);
            return html;
        }
    }
}

