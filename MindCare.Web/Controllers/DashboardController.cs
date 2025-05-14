using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MindCare.BLL.Abstraction;
using MindCare.BLL.DTOs;
using MindCare.DAL.Entities;

namespace MindCare.Web.Controllers;

[Authorize(Roles = "Admin")]
public class DashboardController : Controller
{
    private readonly ISpecialistService _specialistService;

    public DashboardController(ISpecialistService specialistService)
    {
        _specialistService = specialistService;
    }

    public async Task<IActionResult> Index()
    {
        var list = await _specialistService.GetAllSpecialistsAsync();
        return View(list);
    }

    public IActionResult Create()
    {
        return View(new SpecialistDto());
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(SpecialistDto model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var entity = new Specialist
        {
            Id = Guid.NewGuid(),
            FullName = model.FullName,
            Description = model.Description,
            Specialization = model.Specialization,
            ImageUrl = model.ImageUrl,
            PricePerSession = model.PricePerSession,
            Rating = model.Rating
        };
        await _specialistService.CreateSpecialistAsync(entity);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _specialistService.DeleteSpecialistAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
