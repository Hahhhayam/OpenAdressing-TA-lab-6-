using System.ComponentModel.DataAnnotations;


namespace ТА6.Data
{
    public class LengthData
    {
        [Range(10, 100)]
        public int length { get; set; }
    }
}
