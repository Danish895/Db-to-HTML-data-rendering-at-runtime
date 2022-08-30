using GenericModelToHTML.Model;

namespace GenericModelToHTML.Service
{
    public interface IUserService
    {
        Task<IEnumerable<Student>> getAllStudents();
        Task<Document> GetBody();
        Task<bool> fileSavingInDb(string htmlFinal);
    }
}
