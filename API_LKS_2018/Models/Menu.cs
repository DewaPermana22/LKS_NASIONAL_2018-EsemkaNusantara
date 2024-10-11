using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_LKS_2018.Models
{
    [Table("MsMenu")]
    public class Menu
    {
        [Key]
        public int menuid { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public string photo { get; set; }

    }
}
