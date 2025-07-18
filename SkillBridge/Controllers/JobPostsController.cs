﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SkillBridge.Data;
using SkillBridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillBridge.Controllers
{
    public class JobPostsController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public JobPostsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        // GET: JobPosts
        public async Task<IActionResult> Index()
        {
            return View(await _context.JobPosts.ToListAsync());
        }

        // GET: JobPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobPost = await _context.JobPosts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobPost == null)
            {
                return NotFound();
            }

            return View(jobPost);
        }

        // GET: JobPosts/Create
        [Authorize(Roles = "Client")]
        public IActionResult Create()
        {
            return View();
        }


        // POST: JobPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Create(JobPost jobPost)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User); // inject UserManager in constructor
                jobPost.ClientId = user.Id;
                jobPost.PostedDate = DateTime.Now;

                _context.Add(jobPost);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Job posted successfully!";

                return RedirectToAction(nameof(Index));
            }

            return View(jobPost);
        }

        // GET: JobPosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobPost = await _context.JobPosts.FindAsync(id);
            if (jobPost == null)
            {
                return NotFound();
            }
            return View(jobPost);
        }

        // POST: JobPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,JobTitle,CompanyName,Location,Description,SkillsRequired,PostedDate")] JobPost jobPost)
        {
            if (id != jobPost.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobPostExists(jobPost.Id))
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
            return View(jobPost);
        }

        // GET: JobPosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobPost = await _context.JobPosts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobPost == null)
            {
                return NotFound();
            }

            return View(jobPost);
        }

        // POST: JobPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobPost = await _context.JobPosts.FindAsync(id);
            if (jobPost != null)
            {
                _context.JobPosts.Remove(jobPost);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobPostExists(int id)
        {
            return _context.JobPosts.Any(e => e.Id == id);
        }
    }
}
