using System.Collections.Generic;

namespace ClinicApplication.Models
{
    public class PatientPaymentListViewModel
    {
        public List<PatientPaymentModel> PatientPayments { get; set; } = new List<PatientPaymentModel>();
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public DateTime? StartDate { get; set; } 
        public DateTime? EndDate { get; set; }
    }
}
