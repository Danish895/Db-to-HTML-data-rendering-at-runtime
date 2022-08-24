using GenericModelToHTML.Model;

namespace GenericModelToHTML.Extensions
{
    public static class ExtensionMethods
    {
        public static string extendedHtmlForHeadMethod<T>(this T studentModelObj)
        {
            var htmlHeadTemplate = System.IO.File.ReadAllText(@"./HtmlRender/head.html");

            var fieldType = studentModelObj.GetType().GetProperties();
            
            string htmlReturn = string.Empty;

            foreach (var field in fieldType)
            {
                if (field.GetValue(studentModelObj) == null)
                {
                    continue;
                }
                string html1 = htmlHeadTemplate.Replace("{{HtmlHeaddata}}", field.Name);
                htmlReturn += html1;
            }
            return htmlReturn;
        }
        public static string extendedHtmlForBodyMethod<T>(this T studentModelObj)
        {
            var htmlBodyTemplate = System.IO.File.ReadAllText(@"./HtmlRender/body.html");
            var fieldType = studentModelObj.GetType().GetProperties();

            string htmlReturn = String.Empty;
            string htmlBody = String.Empty;
            foreach (var field in fieldType)
            {
                if (field.GetValue(studentModelObj) == null)
                {
                    continue;
                }
                string myField = field.Name;
                
                //if(myField == )
                string html1 = htmlBodyTemplate.Replace("{{HtmlBodyData}}", field.GetValue(studentModelObj).ToString());
                htmlReturn += html1;
            }
            string extendedReturnHtmlForBodyData = extendedHtmlForRowBreakMethod(htmlReturn);
            htmlBody += extendedReturnHtmlForBodyData;
            return htmlBody;
        }
        private static string extendedHtmlForRowBreakMethod(string htmlBodyData)
        {
            string htmlReturn = String.Empty;

            var htmlBodyTemplate = System.IO.File.ReadAllText(@"./HtmlRender/RowBreak.html");

            string html1 = htmlBodyTemplate.Replace("{{RowBreaker}}", htmlBodyData);
            htmlReturn += html1;
            return htmlReturn;
        }
    }
}   
