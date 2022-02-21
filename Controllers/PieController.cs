using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult List()
        {
            //ViewBag.CurrentCategory = "Cheese cakes";
            //return View(_pieRepository.AllPies);

            PiesListViewModel piesListViewModel = new PiesListViewModel();
            piesListViewModel.Pies = _pieRepository.AllPies;
            piesListViewModel.CurrentCategory = "Cheese cakes";

            return View(piesListViewModel);
        }

        //[Route("[controller]/Details/{id}")]
        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie == null)
            {
                return NotFound();
            }

            return View(pie);
        }

        //[Route("[controller]/Details/{id}")]
        //[HttpPost]
        //public IActionResult Details(int id, string review)
        //{
        //    var pie = _pieRepository.GetPieById(id);
        //    if (pie == null)
        //    {
        //        _logger.LogWarning(LogEventIds.GetPieIdNotFound, new Exception("Pie not found"), "Pie with id {0} not found", id);
        //        return NotFound();
        //    }

        //    string encodedReview = _htmlEncoder.Encode(review);

        //    _pieReviewRepository.AddPieReview(new PieReview() { Pie = pie, Review = encodedReview });

        //    return View(new PieDetailViewModel() { Pie = pie });
        //}

    }
}
