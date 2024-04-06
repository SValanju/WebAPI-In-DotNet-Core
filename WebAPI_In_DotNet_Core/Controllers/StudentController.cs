using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_In_DotNet_Core.DTOs.Requests;
using WebAPI_In_DotNet_Core.DTOs.Responses;
using WebAPI_In_DotNet_Core.Services.StudentService;

namespace WebAPI_In_DotNet_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;

        // constructor
        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        // endpoints
        [HttpPost("save")]
        public BaseResponse CreateStudent(CreateStudentRequest request)
        {
            return this.studentService.CreateStudent(request);
        }

        [HttpGet("list")]
        public BaseResponse StudentList()
        {
            return this.studentService.StudentList();
        }

        [HttpGet("{id}")]
        public BaseResponse GetStudentById(long id)
        {
            return this.studentService.GetStudentById(id);
        }

        [HttpPut("{id}")]
        public BaseResponse UpdateStudentById(long id, UpdateStudentRequest request)
        {
            return this.studentService.UpdateStudentById(id, request);
        }

        [HttpDelete("{id}")]
        public BaseResponse DeleteStudentById(long id)
        {
            return this.studentService.DeleteStudentById(id);
        }
    }
}
