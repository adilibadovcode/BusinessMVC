using BusinessMVC.Context;
using BusinessMVC.Models;
using BusinessMVC.ViewModels.AuthorVM;
using BusinessMVC.ViewModels.CardVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusinessMVC.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class AuthorController : Controller
    {
        BusinessContext _db { get; }

        public AuthorController(BusinessContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _db.Authors.Select(X => new AuthorListItemVM
            {
                
                Name = X.Name,
                Id = X.Id,
            }).ToListAsync();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AuthorCreateVM vm)
        {
           
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            Author author = new Author
            {
                Name = vm.Name,
            };
            await _db.Authors.AddAsync(author);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }




        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id < 0) return BadRequest();
            var data = await _db.Authors.FindAsync(id);
            if (data == null) return NotFound();
            _db.Authors.Remove(data);
            return View(new AuthorUpdateVM
            {
                Name = data.Name,
             
            });

        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, AuthorUpdateVM vm)
        {
            if (id == null || id < 0) return BadRequest();
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var data = await _db.Authors.FindAsync(id);
            if (data == null) return NotFound();
            data.Name = vm.Name;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null || Id < 0) return BadRequest();
            var data = await _db.Authors.FindAsync(Id);
            if (data == null) return NotFound();
            _db.Authors.Remove(data);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
