using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gavebod2.Models;
using Gavebod2.Services;

namespace Gavebod2.Controllers
{
    public class GiftsController : Controller
    {

        private readonly IAPIService api;
        public GiftsController(IAPIService apiService)
        {
            api = apiService;
        }

        // GET: Gifts
        public async Task<IActionResult> Index()
        {
            List<Gift> gifts = await api.GetAll<List<Gift>>("Gifts");
            return View(gifts);
        }

        // GET: Gifts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gift = await api.GetObject<Gift>("Gifts", (int)id);
            if (gift == null)
            {
                return NotFound();
            }

            return View(gift);
        }

        // GET: Gifts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gifts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,BoyGift,GirlGift")] Gift gift)
        { 
            if (ModelState.IsValid && (gift.BoyGift || gift.GirlGift))
            {
                api.InsertObject("Gifts", gift);
                return RedirectToAction(nameof(Index));
            }
            return View(gift);
        }

        // GET: Gifts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gift = await api.GetObject<Gift>("Gifts", (int)id);
            if (gift == null)
            {
                return NotFound();
            }
            return View(gift);
        }

        // POST: Gifts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GiftNumber,Title,Description,CreationDate,BoyGift,GirlGift")] Gift gift)
        {
            throw new NotImplementedException();
            //if (id != gift.GiftNumber)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(gift);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!GiftExists(gift.GiftNumber))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(gift);
        }

        // GET: Gifts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            api.DeleteObject("Gifts", (int)id);

            return RedirectToAction("Index");
        }

        // POST: Gifts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            throw new NotImplementedException();
            //var gift = await _context.Gift.FindAsync(id);
            //_context.Gift.Remove(gift);
            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
        }

        private bool GiftExists(int id)
        {
            throw new NotImplementedException();
            //return _context.Gift.Any(e => e.GiftNumber == id);
        }
    }
}
