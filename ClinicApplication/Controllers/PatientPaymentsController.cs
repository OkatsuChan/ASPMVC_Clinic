using ClinicApplication.Data;
using ClinicApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicApplication.Controllers
{
    public class PatientPaymentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientPaymentsController(ApplicationDbContext context)
        {
            _context = context;
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
                _context.Add(patientPayment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patientPayment);
        }

        // GET: PatientPayments
        //public async Task<IActionResult> Index()
        //{
        //    var patientPayments = await _context.PatientPayments.ToListAsync();
        //    return View(patientPayments);
        //}

        // GET: PatientPayments
        public async Task<IActionResult> Index(DateTime? startDate, DateTime? endDate, int pageNumber = 1, int pageSize = 10)
        {
            
            var patientPayments = _context.PatientPayments.AsQueryable();

            if (startDate.HasValue)
            {
                patientPayments = patientPayments.Where(p => p.DateSubmitted >= startDate.Value.Date);
            }

            if (endDate.HasValue)
            {
                patientPayments = patientPayments.Where(p => p.DateSubmitted <= endDate.Value.Date);
            }

            var totalItems = await patientPayments.CountAsync();
            var items = await patientPayments
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var viewModel = new PatientPaymentListViewModel
            {
                PatientPayments = items,
                CurrentPage = pageNumber,
                TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize),
                StartDate = startDate,
                EndDate = endDate
            };

            return View(viewModel);
        }
    }
}
