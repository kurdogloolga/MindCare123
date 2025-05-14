using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MindCare.BLL.Abstraction;
using MindCare.BLL.DTOs;
using MindCare.DAL.Entities;
using MindCare.Web.Models;
using System.Security.Claims;

namespace MindCare.Web.Controllers
{
    [Authorize]
    public class AppointmentController : BaseController
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IAvailabilityService _availabilityService;
        private readonly ISpecialistService _specialistService;

        public AppointmentController(
            IAppointmentService appointmentService,
            IAvailabilityService availabilityService,
            ISpecialistService specialistService)
        {
            _appointmentService = appointmentService;
            _availabilityService = availabilityService;
            _specialistService = specialistService;
        }

        [HttpGet]
        public async Task<IActionResult> Book(Guid specialistId)
        {
            var specialist = await _specialistService.GetSpecialistByIdAsync(specialistId);
            var slots = await _availabilityService.GetAvailabilitiesBySpecialistAsync(specialistId, DateTime.Today);

            var model = new AppointmentFormViewModel
            {
                SpecialistId = specialistId,
                SpecialistName = specialist.FullName,
                AvailableSlots = slots.ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Book(AppointmentFormViewModel model)
        {
            var slot = await _availabilityService.GetAvailabilityByIdAsync(model.AvailabilityId);
            if (slot == null || slot.IsBooked)
            {
                ModelState.AddModelError("", "Selected time slot is no longer available.");
                return View(model);
            }

            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var appointmentDto = new AppointmentDto
            {
                SpecialistId = model.SpecialistId,
                UserId = userId,
                AppointmentDateTime = slot.Date.ToDateTime(TimeOnly.FromTimeSpan(slot.Time)),
                Mode = model.Mode,
                Reason = model.Reason
            };

            await _appointmentService.BookAppointmentAsync(appointmentDto);
            slot.IsBooked = true;
            await _availabilityService.UpdateAvailabilityAsync(slot);

            return RedirectToAction("Success");
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}

