using GenericModelToHTML.Model;

namespace GenericModelToHTML.DataAccessLayer.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<Student>> AllStudent();

        Task<Document> GetBodyData();
        Task<bool> fileSaving(string htmlfiles);
        Task<String> GetHeadData();
        Task<String> GetPageData();
    }
}
