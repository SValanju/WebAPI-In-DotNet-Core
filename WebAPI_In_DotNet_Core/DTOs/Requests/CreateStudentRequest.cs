using System.ComponentModel.DataAnnotations;

namespace WebAPI_In_DotNet_Core.DTOs.Requests
{
    public class CreateStudentRequest
    {
        [Required]
        public string first_name { get; set; }

        [Required]
        public string last_name { get; set; }

        [Required]
        public string address { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string contact_number { get; set; }

        [Required]
        public string username { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        public DateTime created_at { get; set; } = DateTime.Now;
    }
}
