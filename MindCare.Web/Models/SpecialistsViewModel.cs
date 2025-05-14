using MindCare.BLL.DTOs;

namespace MindCare.Web.Models;
public class SpecialistsViewModel
{
    public IEnumerable<SpecialistDto> specialists { get; set; } = new List<SpecialistDto>();
}
