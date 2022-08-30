using GenericModelToHTML.DataAccessLayer.Repository;
using GenericModelToHTML.Model;

namespace GenericModelToHTML.Service
{
    public class UserService : IUserService
    {
        private IUserRepository _UserRepository;
        public UserService(IUserRepository userRepository)
        {
            _UserRepository = userRepository;
        }

        public async Task<IEnumerable<Student>> getAllStudents()
        {
            var detail = await _UserRepository.AllStudent();
            return detail;
        }

        public async Task<Document> GetBody()
        {
            var detail = await _UserRepository.GetBodyData();
            return detail;
        }
        public async Task<bool> fileSavingInDb(string htmlfiles)
        {
            bool detail = await _UserRepository.fileSaving(htmlfiles);
            return detail;
        }
    }
}
