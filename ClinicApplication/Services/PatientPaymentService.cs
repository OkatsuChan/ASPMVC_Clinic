using ClinicApplication.Data;
using ClinicApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicApplication.Services
{
    public class PatientPaymentService : IPatientPaymentService
    {
        private readonly ApplicationDbContext _context;

        public PatientPaymentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddPatientPaymentAsync(PatientPaymentModel patientPayment)
        {
            _context.Add(patientPayment);
            await _context.SaveChangesAsync();
        }

        public async Task<PatientPaymentListViewModel> GetPatientPaymentsAsync(DateTime? startDate, DateTime? endDate, int pageNumber = 1, int pageSize = 10)
        {
            var patientPayments = _context.PatientPayments.AsQueryable();

            if (startDate.HasValue)
            {
                patientPayments = patientPayments.Where(p => p.DateSubmitted >= startDate.Value.Date);
            }

            if (endDate.HasValue)
            {
                // Include all records until the end of the endDate
                var endOfDay = endDate.Value.Date.AddDays(1).AddTicks(-1);
                patientPayments = patientPayments.Where(p => p.DateSubmitted <= endOfDay);
            }

            var totalItems = await patientPayments.CountAsync();
            var items = await patientPayments
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PatientPaymentListViewModel
            {
                PatientPayments = items,
                CurrentPage = pageNumber,
                TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize),
                StartDate = startDate,
                EndDate = endDate
            };
        }
    }

}
