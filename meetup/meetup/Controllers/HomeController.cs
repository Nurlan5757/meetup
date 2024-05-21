using meetup.DLA;
using meetup.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace meetup.Controllers
{
    public class HomeController (meetupContext _context): Controller
    {
        public async Task<IActionResult> Index()
        {
            return View(await _context.Meets.Select(s=>new GetMeetAdminVM
            {
                id = s.Id,
                Name = s.Name,
                Subtitle=s.Subtitle,
            }).ToListAsync());
        }
    }
}
