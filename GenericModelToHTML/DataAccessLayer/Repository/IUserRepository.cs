using GenericModelToHTML.Model;

namespace GenericModelToHTML.DataAccessLayer.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<Student>> AllStudent();

        Task<Document> GetBodyData();
        Task<String> GetHeadData();
        Task<String> GetPageData();
    }
}
