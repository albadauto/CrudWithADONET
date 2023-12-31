﻿using System.ComponentModel.DataAnnotations;

namespace CrudWithADONET.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
