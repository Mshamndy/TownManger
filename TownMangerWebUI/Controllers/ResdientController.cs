using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TownManger.Domain.Abstract;
using TownManger.Domain.Entities;
using TownMangerWebUI.Models;

namespace TownMangerWebUI.Controllers
{
    public class ResdientController : Controller
    {
        // GET: Resdient

        public IResdientRepository repository;


        public ResdientController(IResdientRepository resdientRepository)
            {
            this.repository = resdientRepository;
        }
        public ActionResult Index()
        {
            return View();
        }

        //public ViewResult List(string Building, int page = 1)
        //{
        //    ResdientViewModel model = new ResdientViewModel
        //    {
        //        Resdient = repository.Resdients.Where(p => Building == null || p.Category == category).OrderBy(p => p.ProductID)
        //    .Skip((page - 1) * PageSize).Take(PageSize),
        //        PagingInfo = new PagingInfo
        //        {
        //            CurrentPage = page,
        //            ItemsPerPage = PageSize,
        //            //TotalItems = repository.Products.Count()
        //            TotalItems = category == null ? repository.Products.Count() : repository.Products.Where(e => e.Category == category).Count()
        //        },
        //        CurrentCategory = category
        //    };
        //    return View(model);
        //}



        public FileContentResult GetImage(int resdientID)
        {
            Resdient resdient = repository.Resdients.FirstOrDefault(p => p.ResdientID == resdientID);
            if (resdient != null)
            {
                return File(resdient.ImageData, resdient.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
    
}