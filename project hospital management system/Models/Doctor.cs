﻿using System;
using System.ComponentModel.DataAnnotations;

namespace project_hospital_management_system.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Specialization")]
        public string Specialization { get; set; }

        [Required]
        [Display(Name = "Contact Number")]
        [Phone]
        public string Phone { get; set; }
    }
}
