using Microsoft.AspNetCore.Mvc;

namespace Laboratorium3zadanie
{
    public class TravelController : Controller
    {
        static DateOnly tempD1 = new DateOnly(2022,10,10);
        static DateOnly tempD2 = new DateOnly(2022, 10, 15);
        //static Travel temp = new Travel(0, "Egipt", tempD1, tempD2, "Kraków", "Warszawa", "Kamil", "Grzegorz");
        static Dictionary<int, Travel> _travels = new Dictionary<int, Travel>();
        public int index = 1;
        
        public IActionResult Index()
        {
            if (!_travels.ContainsKey(0))
            {
                //_travels[0] = temp;
            }
            return View(_travels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Travel model)
        {
            if(ModelState.IsValid)
            {
                model.Id = index++;
                _travels[model.Id] = model;
                return RedirectToAction("Index");
                //zapisz obiekt do bazy/kolekcji albo wykonaj operacje
            }
            return View();
        }
        public IActionResult Details(int id) {
            return View(_travels[id]);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_travels[id]);
        }
        [HttpPost]
        public IActionResult Delete(Travel model)
        {
            _travels.Remove(model.Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            if (_travels.Keys.Contains(id))
            {
                return View(_travels[id]);
            }
            else
            {
                return NotFound();
            };

        }
        [HttpPost]
        public IActionResult Update(Travel model)
        {
            if (ModelState.IsValid)
            {
                _travels[model.Id] = model;
            }
            return RedirectToAction("Index");
        }

        /*[HttpGet]
        public String Update(int? id)
        {
            return "Edycja " + id;
        }*/
    }
}
