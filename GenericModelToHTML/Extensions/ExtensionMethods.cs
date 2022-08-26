using GenericModelToHTML.Model;
using System.Reflection;

namespace GenericModelToHTML.Extensions
{
    public static class ExtensionMethods
    {
        public static string extendedHtmlForHeadMethod<T>(this IEnumerable<T> studentModelObj, IEnumerable<string> students, string htmlHeadTemplate)
        {
           //string htmlHeadTemplate2 = System.IO.File.ReadAllText(@"htmlHeadTemplate");
            string htmlBodyTemplate = System.IO.File.ReadAllText(@"./HtmlRender/body.html");

            string startingHtml = String.Empty;
            string htmlReturnHead = String.Empty;   

            foreach (var field in students)
            {
               string html1 = htmlHeadTemplate.Replace("{{HtmlHeadData}}", field);
            
                htmlReturnHead += html1;
            }
            startingHtml = htmlReturnHead;
            string htmlReturn = "<tr>";
            foreach (var item in studentModelObj)
            {
                var fieldType = item.GetType();
                foreach (var fieldOf in students)
                {
                    var field = fieldType.GetProperty(fieldOf);
                    string html1 = htmlBodyTemplate.Replace("{{HtmlBodyData}}", field.GetValue(item).ToString());
                    htmlReturn += html1;
                }
                htmlReturn += "</tr>";
                startingHtml += htmlReturn;
                   htmlReturn = String.Empty;
            }
            return startingHtml;
        }
    }
}   
