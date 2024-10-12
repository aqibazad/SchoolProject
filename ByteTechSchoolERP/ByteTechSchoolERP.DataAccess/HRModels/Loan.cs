using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ByteTechSchoolERP.DataAccess.Data;

namespace ByteTechSchoolERP.DataAccess.HRModels
{
    public class Loan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid? StaffId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? LoanAmount { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdateBy { get; set; }
        public Staff? Staff { get; set; }
    }
}
