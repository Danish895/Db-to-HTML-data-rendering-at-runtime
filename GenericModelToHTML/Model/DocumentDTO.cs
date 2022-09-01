using System.ComponentModel.DataAnnotations.Schema;

namespace GenericModelToHTML.Model
{
    [Table("Documents", Schema = "dbo")]
    public class DocumentDTO
    {
        public int Id { get; set; }
        public string ContentType { get; set; }
        public string Code { get; set; }
        public string Content { get; set; }
        
    }
}
