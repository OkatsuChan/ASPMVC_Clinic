using ClinicApplication.Data;
using ClinicApplication.Models;
using ClinicApplication.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicApplication.Controllers
{
    public class PatientPaymentsController : Controller
    {
        private readonly IPatientPaymentService _patientPaymentService;

        public PatientPaymentsController(IPatientPaymentService patientPaymentService)
        {
            _patientPaymentService = patientPaymentService;
        }

        // GET: PatientPayments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PatientPayments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PatientName,AmountPaid,AmountCharge,PaymentMethod,Procedure")] PatientPaymentModel patientPayment)
        {
            if (ModelState.IsValid)
            {
                await _patientPaymentService.AddPatientPaymentAsync(patientPayment);
                return RedirectToAction(nameof(Index));
            }
            return View(patientPayment);
        }

        // GET: PatientPayments
        public async Task<IActionResult> Index(DateTime? startDate, DateTime? endDate, int pageNumber = 1, int pageSize = 10)
        {
            var viewModel = await _patientPaymentService.GetPatientPaymentsAsync(startDate, endDate, pageNumber, pageSize);
            return View(viewModel);
        }
    }
}
