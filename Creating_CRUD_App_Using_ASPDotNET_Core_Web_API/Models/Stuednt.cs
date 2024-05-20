using System.ComponentModel.DataAnnotations;

namespace Creating_CRUD_App_Using_ASPDotNET_Core_Web_API.Models
{
   
        public class Stuednt
        {
            public int id { get; set; }
        [Required]
            public string name { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public string age { get; set; }
        [Required]
        public string standard { get; set; }
        [Required]
        public string fatherNeme { get; set; }
        }


    
}
