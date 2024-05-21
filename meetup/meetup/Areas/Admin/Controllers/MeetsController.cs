using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using meetup.DLA;
using meetup.Models;
using meetup.ViewModels;

namespace meetup.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MeetsController : Controller
    {
        private readonly meetupContext _context;

        public MeetsController(meetupContext context)
        {
            _context = context;
        }

        // GET: Admin/Meets
        public async Task<IActionResult> Index()
        {
            return View(await _context.Meets.Select(p=>new GetMeetAdminVM { id=p.Id,Name=p.Name,Subtitle=p.Subtitle,image=p.image}).ToListAsync());
        }

       

        // GET: Admin/Meets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Meets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateMeetVM meetVM)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            

            _context.Add(new Meet { image = meetVM.Image, Name = meetVM.Name, Subtitle = meetVM.Subtitle, logo1 = meetVM.logo1, logo2 = meetVM.logo2, logo3 = meetVM.logo3 });
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Meets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meet = await _context.Meets.FindAsync(id);
            if (meet == null)
            {
                return NotFound();
            }    
            return View(meet);
        }

        // POST: Admin/Meets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, UpdateMeetVM updateVM)
        {
           if(Id==null && Id < 1)
            {
                return NotFound();
            }
            var exsited = await _context.Meets.FirstOrDefaultAsync(s => s.Id==Id);
            if(exsited == null)
            {
                return NotFound();
            }
            exsited.Name = updateVM.Name;
            exsited.Subtitle = updateVM.Subtitle;
            exsited.image = updateVM.Image;
            exsited.logo1 = updateVM.logo1;
            exsited.logo2 = updateVM.logo2; 
            exsited.logo3 = updateVM.logo3;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Meets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
           if (id == null) { return NotFound(); }
           var delete = await _context.Meets.FirstOrDefaultAsync(m => m.Id==id);
            if (delete == null)
            {
                return NotFound();
            }
            _context.Meets.Remove(delete);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
    }
}
