using GenericModelToHTML.Model;

namespace GenericModelToHTML.DataAccessLayer.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<Student>> AllStudent();
    }
}
