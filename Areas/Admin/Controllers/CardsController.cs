using BusinessMVC.Context;
using BusinessMVC.Models;
using BusinessMVC.ViewModels.AuthorVM;
using BusinessMVC.ViewModels.CardVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusinessMVC.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class CardsController : Controller
    {
        BusinessContext _db { get; }

        public CardsController(BusinessContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _db.Cards.Select(X => new CardListItemVM
            {
                Title = X.Title,
                Id = X.Id,
                AuthorId = X.AuthorId,
                Description = X.Description,
                Image = X.Image
            }).ToListAsync();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]




        public async Task<IActionResult> Create(CardCreateVM vm)
        {

            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            Card card = new Card
            {
                Description = vm.Description,
                Image = vm.Image,
                AuthorId = vm.AuthorId,
                Title = vm.Title,
            };
            await _db.Cards.AddAsync(card);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id < 0) return BadRequest();
            var data = await _db.Cards.FindAsync(id);
            if (data == null) return NotFound();
            _db.Cards.Remove(data);
            return View(new CardUpdateVM
            {
                Title=data.Title,
                Id = data.Id,
                AuthorId = data.AuthorId,
                Description = data.Description,
                Image = data.Image,
            });

        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, CardUpdateVM vm)
        {
            if (id == null || id < 0) return BadRequest();
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var data = await _db.Cards.FindAsync(id);
            if (data == null) return NotFound();
            data.Title = vm.Title;
            data.Description = vm.Description;
            data.Image = vm.Image;
            data.AuthorId = vm.AuthorId;
            data.Description = vm.Description;
            
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }





        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null || Id < 0) return BadRequest();
            var data = await _db.Cards.FindAsync(Id);
            if (data == null) return NotFound();
            _db.Cards.Remove(data);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
