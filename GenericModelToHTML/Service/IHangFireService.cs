using GenericModelToHTML.Model;
using Microsoft.AspNetCore.Mvc;

namespace GenericModelToHTML.Service
{
    public interface IHangFireService
    {
        Task<ActionResult<IEnumerable<Student>>> getsAllStudents();
    }
}
