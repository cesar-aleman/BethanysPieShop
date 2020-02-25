using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BethanysPieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRespository;
        private readonly ICategoryRepository _categoryRespository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRespository = pieRepository;
            _categoryRespository = categoryRepository;
        }

        public ViewResult List()
        {
            //ViewBag.CurrentCategory = "Cheese cakes";
            //going into pie repositories and taking all them bitches

            PiesListViewModel piesListViewModel = new PiesListViewModel();
            //loading view model with the pies repo.
            piesListViewModel.Pies = _pieRespository.AllPies;
            //here we are assigning value to the current category var set in view model
            piesListViewModel.CurrentCategory = "Cheese Cakes";
            return View(piesListViewModel);
        }

        //public ActionResult Test(Pie pie, Category category)
        //{
            //if(pie.CategoryId == category.CategoryId)
            //{
            //    categoryName == category.CategoryName;
            //}
            //var categoryName = pie.CategoryId
            //var categorgy = pie.Category.CategoryName;
            //return RedirectToAction("Details");
        //}

        public IActionResult Details(int id)
        {
            
            var pie = _pieRespository.GetPieById(id);
            //Test(pie);
            if(pie == null)
            {
                return NotFound();
            }
            return View(pie);
        }
    }
}
