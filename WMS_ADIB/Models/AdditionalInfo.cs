using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WMS_ADIB.Models
{
    public class AdditionalInfo
    {
        [Key]
        public int InfoID { get; set; }

        [StringLength(500)]
        public string? Remark { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int GrandTotal { get; private set; }
    }
}
