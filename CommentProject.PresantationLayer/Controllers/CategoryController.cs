﻿using CommentProject.BusinessLayer.Abstract;
using CommentProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CommentProject.PresantationLayer.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var values = _categoryService.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            category.CategoryStatus = true;
            _categoryService.Add(category);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCategory(int id)
        {
            var value = _categoryService.GetById(id);
            value.CategoryStatus = false;
            _categoryService.Update(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var value = _categoryService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            category.CategoryStatus = true;
            _categoryService.Update(category);
            return RedirectToAction("Index");
        }
    }
}
