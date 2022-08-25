using GenericModelToHTML.Model;
using System.Reflection;

namespace GenericModelToHTML.Extensions
{
    public static class ExtensionMethods
    {
        public static string extendedHtmlForHeadMethod<T>(this IEnumerable<T> studentModelObj)
        {
            var htmlHeadTemplate = System.IO.File.ReadAllText(@"./HtmlRender/head.html");

            string htmlReturn = String.Empty;
            //foreach (var item in studentModelObj)
                //var item = studentModelObj;
            //{
                var fieldType = studentModelObj.First().GetType().GetProperties();
                foreach (var field in fieldType)
                {
                    if (field.GetValue(studentModelObj.First()) == null)
                    {
                        continue;
                    }
                    Console.WriteLine(field.Name);
                    //Console.WriteLine(field.GetValue(studentModelObj.First()).ToString());
                    //Console.WriteLine("---------------");

                    //string valueCheck = field.Name;
                    string html1 = htmlHeadTemplate.Replace("{{HtmlHeadData}}", field.Name);
                    htmlReturn += html1;
                }
                return htmlReturn;
            //}

        }
        public static string extendedHtmlForBodyMethod<T>(this IEnumerable<T> studentModelObj)
        {
            var htmlBodyTemplate = System.IO.File.ReadAllText(@"./HtmlRender/body.html");

            //var fieldType = studentModelObj.GetType().GetProperties();
            string htmlReturn = String.Empty;
            string htmlBody = String.Empty;
            string html1 = String.Empty;
            foreach (var item in studentModelObj)
            {
                var fieldType = item.GetType().GetProperties();
                foreach (var field in fieldType)
                {
                    string myField = field.Name;
                    //string html1 = String.Empty;
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
