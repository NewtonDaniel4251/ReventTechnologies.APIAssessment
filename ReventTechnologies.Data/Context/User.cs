using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReventTechnologies.Data.Context
{
    public class User
    {
        [Key]
        public int Id { get; set; } 
        public string username { get; set; } = string.Empty;
        public byte[] PassworHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
