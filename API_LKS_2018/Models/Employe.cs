using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_LKS_2018.Models
{
    [Table("MsEmploye")]
    public class Employe
    {
        public int EmployeId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
