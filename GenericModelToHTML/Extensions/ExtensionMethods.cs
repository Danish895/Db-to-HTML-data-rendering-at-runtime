using GenericModelToHTML.Model;

namespace GenericModelToHTML.Extensions
{
    public static class ExtensionMethods
    {
        
        public static string extendedHtmlForHeadMethod(this string html, Student studentModel)
        {
            var fieldType = studentModel.GetType().GetProperties();
            
            string htmlReturn = string.Empty;

            foreach (var field in fieldType)
            {
                if (field.GetValue(studentModel) == null)
                {
                    continue;
                }
                string html1 = html.Replace("{{HtmlHeaddata}}", field.Name);
                htmlReturn += html1;
            }
            return htmlReturn;
        }
        public static string extendedHtmlForBodyMethod(this string html, Student studentModel)
        {
            var fieldType = studentModel.GetType().GetProperties();

            string htmlReturn = string.Empty;
            foreach (var field in fieldType)
            {
                if (field.GetValue(studentModel) == null)
                {
                    continue;
                }
                string html1 = html.Replace("{{HtmlBodyData}}", field.GetValue(studentModel).ToString());
                htmlReturn += html1;
            }
            return htmlReturn;
        } 
    }
}   
