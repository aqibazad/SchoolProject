using ByteTechSchoolERP.DataAccess.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ByteTechSchoolERP.DataAccess.HRModels
{
    public class Payroll
    {
        public int PayrollId { get; set; }
        public Guid StaffId { get; set; }
        public DateTime PayPeriodStartDate { get; set; }
        public DateTime PayPeriodEndDate { get; set; }
		[Column(TypeName = "decimal(18, 2)")]
		public decimal GrossSalary { get; set; }
		[Column(TypeName = "decimal(18, 2)")]
		public decimal NetSalary { get; set; }
        public Staff? Staff { get; set; }
    }
}
