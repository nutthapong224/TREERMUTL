
using Microsoft.AspNetCore.Mvc;
using TREERMUTL.Data;

namespace TREERMUTL.Controllers
{
    public class TREERMUTLController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHost;

        public TREERMUTLController(AppDbContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;
        }

        public IActionResult Index()
        {
            List<TREERMUTLCREATE> countries;
            countries = _context.TREERMUTLCREATESS.ToList();
            return View(countries);
        }

        [HttpGet]
        public IActionResult Create()
        {
            TREERMUTLCREATE country = new TREERMUTLCREATE();
            return View(country);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(TREERMUTLCREATE country)
        {
            string uniqueFileName = GetProfilePhotoFileName(country);
            country.PhotoUrl = uniqueFileName;


            _context.Add(country);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            TREERMUTLCREATE customer = _context.TREERMUTLCREATESS.Where(c => c.Id == Id).FirstOrDefault();
            return View(customer);
        }
        private string GetProfilePhotoFileName(TREERMUTLCREATE customer)
        {
            string uniqueFileName = null;

            if (customer.ProfilePhoto != null)
            {
                string uploadsFolder = Path.Combine(_webHost.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + customer.ProfilePhoto.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    customer.ProfilePhoto.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {

            TREERMUTLCREATE country = GetCountry(Id);
            return View(country);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit(TREERMUTLCREATE country)
        {
            if (country.ProfilePhoto != null)
            {
                string uniqueFileName = GetProfilePhotoFileName(country);
                country.PhotoUrl = uniqueFileName;
            }
            _context.Attach(country);
            _context.Entry(country).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private TREERMUTLCREATE GetCountry(int id)
        {
            TREERMUTLCREATE country;
            country = _context.TREERMUTLCREATESS
             .Where(c => c.Id == id).FirstOrDefault();
            return country;

        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            TREERMUTLCREATE customer = _context.TREERMUTLCREATESS.Where(c => c.Id == Id).FirstOrDefault();

            return View(customer);
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Delete(TREERMUTLCREATE country)
        {

            _context.Attach(country);
            _context.Entry(country).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
