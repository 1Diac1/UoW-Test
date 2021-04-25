using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupportApplication.Infrastractures;
using SupportApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportApplication.Controllers
{
    public class BookController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public BookController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<IActionResult> Index()
        {
            var books = await _unitOfWork.Books.GetAllAsync();

            return View(books);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Books.CreateAsync(book);
                await _unitOfWork.SaveAsync();

                return RedirectToAction("Index");
            }

            return View(book);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var books = await _unitOfWork.Books.GetAsync(id);

            if (books == null)
                return NotFound();

            return View(books);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Books.UpdateAsync(book);
                await _unitOfWork.SaveAsync();

                return RedirectToAction("Index");
            }

            return View(book);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _unitOfWork.Books.DeleteAsync(id);
            await _unitOfWork.SaveAsync();

            return RedirectToAction("Index");
        }
    }
}
