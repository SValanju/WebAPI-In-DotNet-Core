using WebAPI_In_DotNet_Core.DTOs.Requests;
using WebAPI_In_DotNet_Core.DTOs.Responses;

namespace WebAPI_In_DotNet_Core.Services.StudentService
{
    public interface IStudentService
    {
        BaseResponse CreateStudent(CreateStudentRequest request);

        BaseResponse StudentList();

        BaseResponse GetStudentById(long id);

        BaseResponse UpdateStudentById(long id, UpdateStudentRequest request);

        BaseResponse DeleteStudentById(long id);
    }
}
