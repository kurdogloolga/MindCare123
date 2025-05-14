using Microsoft.AspNetCore.Mvc;
using MindCare.BLL.Abstraction;
using MindCare.Web.Models;

namespace MindCare.Web.Controllers
{
    public class SpecialistsController : BaseController
    {
        private readonly ISpecialistService _specialistService;

        public SpecialistsController(ISpecialistService specialistService)
            : base()
        {
            _specialistService = specialistService;
        }

        public async Task<ActionResult> Index()
        {
            var specialists = await _specialistService.GetAllSpecialistsAsync();
            var model = new SpecialistsViewModel { specialists = specialists };
            return View(model);
        }

        public async Task<ActionResult> Details(Guid id)
        {
            var specialist = await _specialistService.GetSpecialistByIdAsync(id);
            return View(specialist);

        }

    }
}
