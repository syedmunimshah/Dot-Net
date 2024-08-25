using System.ComponentModel.DataAnnotations;

namespace InsertJsonData.Models
{
    public class CakeModel
    {
        [Key]
        public int Id { get; set; }
        public int CakeId { get; set; }
        public string CakeType { get; set; }
        public string CakeName { get; set; }
        public double CakePpu { get; set; }
        public int BatterID { get; set; }
        public string BatterType { get; set; }
        public string ToppingId { get; set; }
        public string ToppingType { get; set; }
    }
}
