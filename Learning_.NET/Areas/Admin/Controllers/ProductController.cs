using Learning_DotNet.DataAccess.Repository.IRepository;
using Learning_DotNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Learning_DotNet.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Product> objProductList = _unitOfWork.Product.GetAll().ToList();
                 return View(objProductList);
        }

        public IActionResult Create()
        {
            IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem        //Projections in EF core
            {
                Text = u.Name,
                Value = u.Id.ToString()

            });

            ViewBag.CategoryList = CategoryList;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product obj)
        {
            //if (obj.Title == obj.Di)
            //{
            //    ModelState.AddModelError("name", "The Displayorder cannot exactly match the Name");
            //}


            //if (obj.Title == null && obj.ISBN == null && obj.ListPrice == 0 && obj.Author == null)
            //{
            //    ModelState.AddModelError("", "Enter the details correctly");
            //}
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? productfromDb = _unitOfWork.Product.Get(u => u.Id == id);
            //Category? categoryfromDb1 = _db.Categories.FirstOrDefault(u=>u.Id ==id);
            //Category? categoryfromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();

            if (productfromDb == null)
            {
                return NotFound();
            }
            return View(productfromDb);
        }


        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product Updated Successfully";
                return RedirectToAction("Index");

            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? productfromDb = _unitOfWork.Product.Get(u => u.Id == id);


            if (productfromDb == null)
            {
                return NotFound();
            }
            return View(productfromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Product? obj = _unitOfWork.Product.Get(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Product.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");




        }

    }
    }

