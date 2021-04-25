using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupportApplication.Infrastractures;
using SupportApplication.Models;
using SupportApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportApplication.Controllers
{
    public class MessagesController : Controller
    {
        private IUnitOfWork _unitOfWork;
        

        public MessagesController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<IActionResult> Index()
        {
            var messages = await _unitOfWork.Messages.GetAllAsync();

            return View(messages);
        }

        public IActionResult Create()   
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Messages message)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Messages.CreateAsync(message);
                await _unitOfWork.SaveAsync();

                return RedirectToAction("Index");
            }

            return View(message);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var messages = await _unitOfWork.Messages.GetAsync(id);

            if (messages == null)
                return NotFound();

            return View(messages);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Messages message)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Messages.UpdateAsync(message);
                await _unitOfWork.SaveAsync();

                return RedirectToAction("Index");
            }

            return View(message);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _unitOfWork.Messages.DeleteAsync(id);
            await _unitOfWork.SaveAsync();

            return RedirectToAction("Index");
        }
    }
}
