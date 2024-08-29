using System.ComponentModel.DataAnnotations;

namespace ClinicApplication.Models
{
    public class TreatmentRecordModel
    {
        [Key]
        public int Id { get; set; }
        [Required,StringLength(100)]
        public string? PatientName { get; set; }

        [Required]
        public string? Procedure { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be a positive value")]
        public decimal AmountPaid { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be a positive value")]
        public decimal AmountCharge { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be a positive value")]
        public decimal Balance { get; set; }

        public DateTime DateSubmitted { get; set; } = DateTime.Now;

        [Required]
        public DateTime Recall { get; set; }









    }
}
