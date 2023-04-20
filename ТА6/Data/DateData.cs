using System;
using System.ComponentModel.DataAnnotations;


namespace ТА6.Data
{
    public class DateData
    {
        [Required(ErrorMessage = "date can`t be null")]
        public DateTime date { get; set; }
    }
}
