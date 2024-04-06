using WebAPI_In_DotNet_Core.DTOs;
using WebAPI_In_DotNet_Core.DTOs.Requests;
using WebAPI_In_DotNet_Core.DTOs.Responses;
using WebAPI_In_DotNet_Core.Models;

namespace WebAPI_In_DotNet_Core.Services.StudentService
{
    public class StudentService : IStudentService
    {
        // variable to store private application DB context
        private readonly ApplicationDBContext context;

        public StudentService(ApplicationDBContext context)
        {
            this.context = context;
        }

        public BaseResponse CreateStudent(CreateStudentRequest request)
        {
            BaseResponse response;

            try
            {
                // Create new instance of student model
                StudentModel newStudent = new StudentModel();
                newStudent.firstname = request.first_name;
                newStudent.lastname = request.last_name;
                newStudent.address = request.address;
                newStudent.email = request.email;
                newStudent.contact_number = request.contact_number;

                using (context)
                {
                    context.Add(newStudent);
                    context.SaveChanges();
                }

                response = new BaseResponse
                {
                    status_code = StatusCodes.Status200OK,
                    data = new { message = "Successfully created the new student." }
                };

                return response;
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = "Internal Server Error: " + ex.Message }
                };

                return response;
            }
        }

        public BaseResponse StudentList()
        {
            BaseResponse response;

            try
            {
                List<StudentDTO> students = new List<StudentDTO>();

                using (context)
                {
                    // Get all the students from database and add to student list after convert them to student dto
                    context.Students.ToList().ForEach(student => students.Add(new StudentDTO
                    {
                        id = student.id,
                        first_name = student.firstname,
                        last_name = student.lastname,
                        address = student.address,
                        email = student.email,
                        contact_number = student.contact_number
                    }));
                }

                response = new BaseResponse
                {
                    status_code = StatusCodes.Status200OK,
                    data = new { students }
                };

                return response;
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = "Internal Server Error: " + ex.Message }
                };

                return response;
            }
        }

        public BaseResponse GetStudentById(long id)
        {
            BaseResponse response;

            try
            {
                StudentDTO student = new StudentDTO();

                using (context)
                {
                    StudentModel filteredStudent = context.Students.Where(student => student.id == id).FirstOrDefault();

                    if (filteredStudent != null)
                    {
                        student.id = filteredStudent.id;
                        student.first_name = filteredStudent.firstname;
                        student.last_name = filteredStudent.lastname;
                        student.address = filteredStudent.address;
                        student.email = filteredStudent.email;
                        student.contact_number = filteredStudent.contact_number;
                    }
                    else
                    {
                        student = null;
                    }
                }

                if (student != null)
                {
                    response = new BaseResponse
                    {
                        status_code = StatusCodes.Status200OK,
                        data = new { student }
                    };
                }
                else
                {
                    response = new BaseResponse
                    {
                        status_code = StatusCodes.Status400BadRequest,
                        data = new { message = "No student found!" }
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = "Internal Server Error: " + ex.Message }
                };

                return response;
            }
        }

        public BaseResponse UpdateStudentById(long id, UpdateStudentRequest request)
        {
            BaseResponse response;

            try
            {
                using (context)
                {
                    StudentModel filteredStudent = context.Students.Where(student => student.id == id).FirstOrDefault();

                    if (filteredStudent != null)
                    {
                        filteredStudent.firstname = request.first_name;
                        filteredStudent.lastname = request.last_name;
                        filteredStudent.address = request.address;
                        filteredStudent.email = request.email;
                        filteredStudent.contact_number = request.contact_number;

                        context.SaveChanges();

                        response = new BaseResponse
                        {
                            status_code = StatusCodes.Status200OK,
                            data = new { message = "Student updated successfully!" }
                        };
                    }
                    else
                    {
                        response = new BaseResponse
                        {
                            status_code = StatusCodes.Status400BadRequest,
                            data = new { message = "No student found!" }
                        };
                    }
                }

                return response;
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = "Internal Server Error: " + ex.Message }
                };

                return response;
            }
        }

        public BaseResponse DeleteStudentById(long id)
        {
            BaseResponse response;

            try
            {
                using (context)
                {
                    StudentModel studentToDelete = context.Students.Where(student => student.id == id).FirstOrDefault();

                    if (studentToDelete != null)
                    {
                        context.Students.Remove(studentToDelete);
                        context.SaveChanges();

                        response = new BaseResponse
                        {
                            status_code = StatusCodes.Status200OK,
                            data = new { message = "Student deleted successfully!" }
                        };
                    }
                    else
                    {
                        response = new BaseResponse
                        {
                            status_code = StatusCodes.Status400BadRequest,
                            data = new { message = "No student found!" }
                        };
                    }
                }

                return response;
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = "Internal Server Error: " + ex.Message }
                };

                return response;
            }
        }
    }
}
