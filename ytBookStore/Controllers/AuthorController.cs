using Microsoft.AspNetCore.Mvc;
using ytBookStore.Models.Domain;
using ytBookStore.Repositories.Abstract;

namespace ytBookStore.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService service;
        public AuthorController(IAuthorService service)
        {
            this.service = service;
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Author model)
        {
            if (!ModelState.IsValid)
            {

                return View(model);
            }
            var result = service.Add(model);
            if (result)
            {
                TempData["msg"] = "Added successfully!";
                return RedirectToAction(nameof(Add));
            }
            TempData["msg"] = "Error has occured on server side";
            return View();
        }
        public IActionResult Update(int id)
        {
            var record = service.FindById(id);
            return View(record);
        }

        [HttpPost]
        public IActionResult Update(Author model)
        {
            if (!ModelState.IsValid)
            {

                return View(model);
            }
            var result = service.Update(model);
            if (result)
            {

                return RedirectToAction("GetAll");
            }
            TempData["msg"] = "Error has occured on server side";
            return View();
        }

        public IActionResult Delete(int id)
        {
            var result = service.Delete(id);

            return RedirectToAction("GetAll");
        }

        public IActionResult GetAll()
        {

            var data = service.GetAll();
            return View(data);
        }
    }
    
}
