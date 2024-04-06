using System.ComponentModel.DataAnnotations;

namespace WebAPI_In_DotNet_Core.DTOs.Requests
{
    public class UpdateStudentRequest : CreateStudentRequest
    {
        [Required]
        public DateTime updated_at { get; set; } = DateTime.Now;
    }
}
