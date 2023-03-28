using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReventTechnologies.Data.Context
{
    public class Registration
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter your first name")]
        public string first_Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your last name")]
        public string last_Name { get; set; } = string.Empty;
        public DateTime? DateCreated { get; set; }

        [Required(ErrorMessage = "Please enter your gender")]
        public string Gender { get; set; } = string.Empty;
        public DateTime?  DateOfBirth { get; set; }
    }
}
