using BulkyWeb.Attributes;
using BulkyWeb.Models;
using BulkyWeb.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
	public class CategoryController(IUnitOfWork unitOfWork) : Controller
	{

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var categories = await unitOfWork.CategoryRepository.GetAllAsync();
			return View(categories);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateModel]
		public async Task<IActionResult> Create(Category category)
		{
			await unitOfWork.CategoryRepository.AddAsync(category);
			await unitOfWork.SaveChangesAsync();
			unitOfWork.CategoryRepository.Test();
			TempData["success"] = "Category was created successfully!";
			return RedirectToAction("Index");
		}

		[HttpGet]
		[Route("Category/Edit/{id:int}")]
		public async Task<IActionResult> Edit(int id)
		{
			var category = await unitOfWork.CategoryRepository.GetByIdAsync(id);
			if (category == null)
			{
				return RedirectToAction("Index", "NotFound");
			}
			return View(category);
		}

		[HttpPost]
		[Route("Category/Edit/{id:int}")]
		[ValidateModel]
		public async Task<IActionResult> Edit(Category category)
		{
			unitOfWork.CategoryRepository.Update(category);
			await unitOfWork.SaveChangesAsync();
			TempData["success"] = "Category was edited successfully!";
			return RedirectToAction("Index");
		}

		[HttpGet]
		[Route("Category/Delete/{id:int}")]
		public async Task<IActionResult> Delete(int id)
		{
			var category = await unitOfWork.CategoryRepository.GetByIdAsync(id);
			if (category == null)
			{
				return RedirectToAction("Index", "NotFound");
			}
			unitOfWork.CategoryRepository.Delete(category);
			await unitOfWork.SaveChangesAsync();
			TempData["success"] = "Category was removed successfully!";
			return RedirectToAction("Index");
		}
	}
}
