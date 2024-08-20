using System.ComponentModel.DataAnnotations;

namespace ClinicApplication.Models
{
    public class PatientPaymentModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string PatientName { get; set; } = string.Empty;

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be a positive value")]
        public decimal AmountPaid { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be a positive value")]
        public decimal AmountCharge { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateSubmitted { get; set; } = DateTime.Now;

        [Required]
        [StringLength(50)]
        public string PaymentMethod { get; set; }=string.Empty;

        [Required]
        [StringLength(50)]
        public string Procedure { get; set; } = string.Empty;
    }
}
