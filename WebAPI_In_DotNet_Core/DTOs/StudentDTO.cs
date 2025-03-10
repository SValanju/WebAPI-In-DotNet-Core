﻿using System.ComponentModel.DataAnnotations;

namespace WebAPI_In_DotNet_Core.DTOs
{
    public class StudentDTO
    {
        [Required]
        public long id { get; set; }

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
    }
}
