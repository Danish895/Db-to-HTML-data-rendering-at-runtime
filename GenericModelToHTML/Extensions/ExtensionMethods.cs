using GenericModelToHTML.Model;
using System.Reflection;

namespace GenericModelToHTML.Extensions
{
    public static class ExtensionMethods
    {
        public static string extendedHtmlForHeadMethod<T>(this IEnumerable<T> studentModelObj, IEnumerable<string> students)
        {
            var htmlHeadTemplate = System.IO.File.ReadAllText(@"./HtmlRender/head.html");

            //string htmlReturn = String.Empty;
            ////foreach (var item in studentModelObj)
            ////var item = studentModelObj;
            ////{
            //var fieldType = studentModelObj.First().GetType().GetProperties();
            //foreach (var field in fieldType)
            //{
            //    //if (field.GetValue(studentModelObj.First()) == null)
            //    //{
            //    //    continue;
            //    //}
            //    //Console.WriteLine(field.Name);
            //    //Console.WriteLine(field.GetValue(studentModelObj.First()).ToString());
            //    //Console.WriteLine("---------------");

            //    //string valueCheck = field.Name;
            //    string html1 = htmlHeadTemplate.Replace("{{HtmlHeadData}}", field.Name);
            //    htmlReturn += html1;
            //}
            //return htmlReturn;
            //}
            string html1 = studentModelObj.First().GetType().Name;
            //foreach (var item in studentModelObj)
            //var item = studentModelObj;
            //Console.WriteLine(htmlReturn);

            string htmlReturn = String.Empty;
            //var fieldType = students.ToString();
            foreach (var field in students)
            {
                html1 += htmlHeadTemplate.Replace("{{HtmlHeadData}}", field);
                htmlReturn += html1;
            }
            return html1;
        }

        public static string extendedHtmlForBodyMethod<T>(this IEnumerable<T> studentModelObj, IEnumerable<string> students)
        {
            var htmlBodyTemplate = System.IO.File.ReadAllText(@"./HtmlRender/body.html");

            //var fieldType = studentModelObj.GetType().GetProperties();
            string htmlReturn = String.Empty;
            string htmlBody = String.Empty;
            string html1 = String.Empty;
            foreach (var item in studentModelObj)
            {
                var fieldType = item.GetType();
                foreach (var fieldOf in students)
                {
                    //string myField = field.Name;
                    //string html1 = String.Empty;
                    var field = fieldType.GetProperty(fieldOf);
                    html1 = htmlBodyTemplate.Replace("{{HtmlBodyData}}", field.GetValue(item).ToString());
                    htmlReturn += html1;
                }
                string extendedReturnHtmlForBodyData = extendedHtmlForRowBreakMethod(htmlReturn);
                htmlBody += extendedReturnHtmlForBodyData;
                htmlReturn = String.Empty;
            }
            return htmlBody;
        }

        public static string extendedHtmlForRowBreakMethod( string htmlBodyData)
        {
            string htmlReturn = String.Empty;

            var htmlBodyTemplate = System.IO.File.ReadAllText(@"./HtmlRender/RowBreak.html");
            string html1 = htmlBodyTemplate.Replace("{{RowBreaker}}", htmlBodyData);
            htmlReturn += html1;
            return htmlReturn;
        }
    }
}   
