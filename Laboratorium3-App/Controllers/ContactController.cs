using Microsoft.AspNetCore.Mvc;
using Laboratorium3_App.Models;
namespace Laboratorium3_App.Controllers
{
    public class ContactController : Controller
    {
        static Dictionary<int, Contact> _contacts = new Dictionary<int, Contact>();
        public int index = 0;
        public IActionResult Index()
        {
            return View(_contacts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contact model)
        {
            if(ModelState.IsValid)
            {
                model.Id = index++;
                _contacts[model.Id] = model;
                return RedirectToAction("Index");
                //zapisz obiekt do bazy/kolekcji albo wykonaj operacje
            }
            return View();
        }
        public IActionResult Details(int id) {
            return View(_contacts[id]);
        }
        public IActionResult Delete(int id)
        {
            return View(_contacts[id]);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            if (_contacts.Keys.Contains(id))
            {
                return View(_contacts[id]);
            }
            else
            {
                return NotFound();
            };

        }
        [HttpPost]
        public IActionResult Update(Contact model)
        {
            if (ModelState.IsValid)
            {
                _contacts[model.Id] = model;
            }
            return View();
        }

        [HttpGet]
        public String Edit(int? id)
        {
            return "Edycja " + id;
        }
    }
}
