using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using ytBookStore.Models.Domain;
using ytBookStore.Repositories.Abstract;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;

namespace ytBookStore.Controllers
{
    public class GenreController : Controller
    {

        private readonly IGenreService service;
        public GenreController(IGenreService service)
        {
                this.service = service;
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Genre model)
        {
            if (!ModelState.IsValid)
            {

            return View(model);
            }
            var result= service.Add(model);
            if(result)
            {
                TempData["msg"] = "Added successfully!";
                return RedirectToAction(nameof(Add));
            }
            TempData["msg"] = "Error has occured on server side";
            return View();
        }
        public IActionResult Update(int id)
        {
            var record=service.FindById(id);
            return View(record);
        }

        [HttpPost]
        public IActionResult Update(Genre model)
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
