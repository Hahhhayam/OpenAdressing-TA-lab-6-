using System;
using System.ComponentModel.DataAnnotations;


namespace ТА6.Data
{
    public class SurnameBirthData
    {
        [Required(ErrorMessage = "surname can`t be null")]
        [StringLength(70, MinimumLength = 10, ErrorMessage = "surname can`t be too long or too small (max 70, min 10)")]
        public string surname { get; set; }

        [Required(ErrorMessage = "date can`t be null")]
        public DateTime dateOfBirth { get; set; }
    }
}
