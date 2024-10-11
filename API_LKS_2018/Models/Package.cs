using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_LKS_2018.Models
{
    [Table("Package")]
    public class Package
    {
        [Key]
        public int PkgId { get; set; }
        public string NamePkg { get; set; }
        public int Price { get; set; }
        public string Deskripsi { get; set; }
    }
}
