﻿using System.ComponentModel.DataAnnotations;

namespace project_hospital_management_system.Models
{
    public class Medication
    {
        [Key]
        public int MedicationId { get; set; }

        [Required]
        [Display(Name = "Medication Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Dosage")]
        public string Dose { get; set; }
    }
}
