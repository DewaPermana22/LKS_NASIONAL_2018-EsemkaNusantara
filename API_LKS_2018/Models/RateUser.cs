using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_LKS_2018.Models
{
    [Table("TBL_RATE")]
    public class RateUser
    {
        [Key]
        public int ReviewId { get; set; }
        public int MemberId { get; set; }
        public string Photo { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
