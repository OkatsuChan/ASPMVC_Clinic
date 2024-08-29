using ClinicApplication.Models;

namespace ClinicApplication.Services
{
    public interface IPatientPaymentService
    {
        Task AddPatientPaymentAsync(PatientPaymentModel patientPayment);
        Task<PatientPaymentListViewModel> GetPatientPaymentsAsync(DateTime? startDate, DateTime? endDate, int pageNumber = 1, int pageSize = 10);
    }
}
