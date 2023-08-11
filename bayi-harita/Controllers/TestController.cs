using Microsoft.AspNetCore.Mvc;
using System.Web;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExcelDataReader;
using System.Text;
using bayi_harita.Models;

namespace bayi_harita.Controllers
{
    public class TestController : Controller
    {
        BayiRepository bayiRepository;

        public TestController(BayiRepository bayiRepository)
        {
            this.bayiRepository = bayiRepository;
        }

        public IActionResult Harita()
        {
            List<Bayi> bayiler = bayiRepository.GetAll().ToList();
            bayiler.ForEach(bayi => { bayi.Il = bayi.Il.ToLower(); });
            return View(bayiler);
        }
    }
}
