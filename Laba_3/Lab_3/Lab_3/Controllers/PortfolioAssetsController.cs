using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab_3;
using Lab_3.Models;

namespace Lab_3.Controllers
{
    public class PortfolioAssetsController : Controller
    {
        private readonly ApplicationContext _context;

        public PortfolioAssetsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: PortfolioAssets
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.PortfolioAssets.Include(p => p.Asset).Include(p => p.Portfolio);
            return View(await applicationContext.ToListAsync());
        }

        // GET: PortfolioAssets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfolioAsset = await _context.PortfolioAssets
                .Include(p => p.Asset)
                .Include(p => p.Portfolio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (portfolioAsset == null)
            {
                return NotFound();
            }

            return View(portfolioAsset);
        }

        // GET: PortfolioAssets/Create
        public IActionResult Create()
        {
            ViewData["AssetId"] = new SelectList(_context.Assets, "Id", "Id");
            ViewData["PortfolioId"] = new SelectList(_context.Portfolios, "Id", "Id");
            return View();
        }

        // POST: PortfolioAssets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PortfolioId,AssetId,Quantity")] PortfolioAsset portfolioAsset)
        {
            if (ModelState.IsValid)
            {
                _context.Add(portfolioAsset);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssetId"] = new SelectList(_context.Assets, "Id", "Id", portfolioAsset.AssetId);
            ViewData["PortfolioId"] = new SelectList(_context.Portfolios, "Id", "Id", portfolioAsset.PortfolioId);
            return View(portfolioAsset);
        }

        // GET: PortfolioAssets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfolioAsset = await _context.PortfolioAssets.FindAsync(id);
            if (portfolioAsset == null)
            {
                return NotFound();
            }
            ViewData["AssetId"] = new SelectList(_context.Assets, "Id", "Id", portfolioAsset.AssetId);
            ViewData["PortfolioId"] = new SelectList(_context.Portfolios, "Id", "Id", portfolioAsset.PortfolioId);
            return View(portfolioAsset);
        }

        // POST: PortfolioAssets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PortfolioId,AssetId,Quantity")] PortfolioAsset portfolioAsset)
        {
            if (id != portfolioAsset.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(portfolioAsset);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PortfolioAssetExists(portfolioAsset.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssetId"] = new SelectList(_context.Assets, "Id", "Id", portfolioAsset.AssetId);
            ViewData["PortfolioId"] = new SelectList(_context.Portfolios, "Id", "Id", portfolioAsset.PortfolioId);
            return View(portfolioAsset);
        }

        // GET: PortfolioAssets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfolioAsset = await _context.PortfolioAssets
                .Include(p => p.Asset)
                .Include(p => p.Portfolio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (portfolioAsset == null)
            {
                return NotFound();
            }

            return View(portfolioAsset);
        }

        // POST: PortfolioAssets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var portfolioAsset = await _context.PortfolioAssets.FindAsync(id);
            if (portfolioAsset != null)
            {
                _context.PortfolioAssets.Remove(portfolioAsset);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PortfolioAssetExists(int id)
        {
            return _context.PortfolioAssets.Any(e => e.Id == id);
        }
    }
}
