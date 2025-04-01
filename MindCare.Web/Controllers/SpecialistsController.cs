using Microsoft.AspNetCore.Mvc;
using MindCare.BLL.Interfaces;
using MindCare.DAL.Entities;
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

        public async Task<ActionResult> Specialists()
        {
            var specialists = await _specialistService.GetAllAsync();
            var model = new SpecialistsViewModel { specialists = specialists };
            return View(model);
        }

        public async Task<ActionResult> Details(Guid id)
        {
            var specialist = await _specialistService.GetByIdAsync(id);
            if (specialist == null)
            {
                return NotFound();
            }

            return View(specialist);

        }

    }
}
