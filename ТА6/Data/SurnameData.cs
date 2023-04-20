using System.ComponentModel.DataAnnotations;


namespace ТА6.Data
{
    internal class SurnameData
    {
        [Required(ErrorMessage = "surname can`t be null")]
        [StringLength(70, MinimumLength = 10, ErrorMessage = "surname can`t be soo long (max 70)")]
        public string surname { get; set; }
    }
}
