using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TownManger.Domain.Abstract;
using TownManger.Domain.Entities;
using TownManger.Domain.Concrete;
using TownMangerWebUI.Models;

namespace TownMangerWebUI.Controllers
{
    
    public class AdminController : Controller
    {
        // GET: Admin


        private IResdientRepository repository;
        private IBuildingRepository repositoryB;
        private IFloorRepository repositoryF;
        private IUnitRepository repositoryU;




        public AdminController(IResdientRepository repo, IBuildingRepository repoB, IFloorRepository repoF,IUnitRepository repoU)
        {
            this.repository = repo;
            this.repositoryB = repoB;
            this.repositoryF = repoF;
            this.repositoryU = repoU;

        }

        //Admin

        public ActionResult Index()
        {
            return View();
        }












        public ActionResult ResdientIndex()
        {
          
        
            
            



            return View(repository.Resdients);
        }


        public ViewResult ResdientEdit(int resdientID)
        {
            Resdient resdient = repository.Resdients.FirstOrDefault(r => r.ResdientID == resdientID);
            
            ViewBag.BuildingID = new SelectList(repositoryB.Buildings, "BuildingID", "BuildingName",resdient.BuildingID);
            ViewBag.FloorID = new SelectList(repositoryF.Floors, "FloorID", "FloorName",resdient.FloorID);
            ViewBag.UnitID = new SelectList(repositoryU.Units, "UnitID", "UnitNumber",resdient.UnitID);

            return View(resdient);
        }


        public ViewResult CreateResdient()
        {
            ViewBag.BuildingID = new SelectList(repositoryB.Buildings, "BuildingID", "BuildingName");
           ViewBag.FloorID = new SelectList(repositoryF.Floors, "FloorID", "FloorName");


            ViewBag.UnitID = new SelectList(repositoryU.Units, "UnitID", "UnitID");


            return View("ResdientEdit", new Resdient());


        }
        public FileContentResult GetImage(int resdientID)
        {
            Resdient resdient = repository.Resdients
            .FirstOrDefault(p => p.ResdientID == resdientID);
            if (resdient != null)
            {
                return File(resdient.ImageData, resdient.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
        public JsonResult GetFloorBuildingDrop(int buildingID)
        {

            var Floors = repositoryF.Floors.Where(m=>m.BuildingID==buildingID);
            var Floornames = Floors.Select(m => new SelectListItem()
            {
                Value = m.FloorID.ToString(),
                Text = m.FloorName.ToString(),
               
            });

            return Json(Floornames, JsonRequestBehavior.AllowGet);



        }

        public JsonResult GetUnitFloorDrop(int floorID)
        {

            var units = repositoryU.Units.Where(m => m.FloorID == floorID).Where(m=>m.UnitNumber!=0);
            var Unitnames = units.Select(m => new SelectListItem()
            {
                Value = m.UnitID.ToString(),
                Text = m.UnitNumber.ToString(),
                
            });

            return Json(Unitnames, JsonRequestBehavior.AllowGet);



        }

        [HttpPost]
        public ActionResult ResdientEdit([Bind(Include = "ResdientID,NID,ResdientName,Mobile,FamilyRelationship,UnitID,BuildingID,FloorID,GarageUnitNum,CarNumber,ImagePath,ImageData,ImageMimeType,")] Resdient resdient, HttpPostedFileBase image = null)
        {
            if (1 == 1)
            {


                if (image != null)
                {
                    resdient.ImageMimeType = image.ContentType;
                    resdient.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(resdient.ImageData, 0, image.ContentLength);
                }
                repository.SaveResdient(resdient);
                repository.AddUnit(resdient);
                TempData["message"] = string.Format("{0} has been saved", resdient.ResdientName);
                return RedirectToAction("ResdientIndex");
            }
            else
            {// there is something wrong with the data values
                return View(resdient);
            }
        }


        [HttpPost]
        public ActionResult Delete(int resdientID)
        {
            Resdient deletedResdient = repository.DeleteResdient(resdientID);
            if (deletedResdient != null)
            {
                TempData["message"] = string.Format("{0} was deleted",
             deletedResdient.ResdientName);
            }
            return RedirectToAction("ResdientIndex");
        }
        //Building Actions



        public ViewResult BuildingIndex()
        {
            return View(repositoryB.Buildings);
        }


        [HttpGet]
        public ViewResult CreateBuilding()
        {
            return View("EditBuilding", new Building());
        }
        [HttpGet]
        public ViewResult EditBuilding(int buildingID)
        {
         
            Building building = repositoryB.Buildings.FirstOrDefault(r => r.BuildingID == buildingID);
            return View(building);
        }

        [HttpPost]
        public ActionResult EditBuilding(Building building)
        {
            if (1 == 1)
            {

                repositoryB.SaveBuilding(building);
                TempData["message"] = string.Format("{0} has been saved", building.BuildingName);
                return RedirectToAction("BuildingIndex");
            }
            else
            {// there is something wrong with the data values
                return View(building);
            }
        }


        public ActionResult DeleteBuilding(int buildingID)
        {
            Building deletedBuilding = repositoryB.DeleteBuilding(buildingID);
            if (deletedBuilding != null)
            {
                
                TempData["message"] = string.Format("{0} was deleted",
             deletedBuilding.BuildingName);
            }
            return RedirectToAction("BuildingIndex");

        }

        //Floors Actions



        public ViewResult FloorsIndex()
        {
            return View(repositoryF.Floors);
        }

        [HttpGet]
        public ViewResult FloorIndex(int buildingID)
        {
            IEnumerable<Floor> Floors = repositoryF.Floors.Where(f => f.BuildingID == buildingID);
            ViewBag.BuildingName = repositoryB.Buildings.FirstOrDefault(m => m.BuildingID == buildingID).BuildingName;

            return View(Floors);
        }
        [HttpGet]
        public ActionResult EditFloorUnits(int floorID)
        {
            Floor Floor = repositoryF.Floors.FirstOrDefault(r => r.FloorID == floorID);

            return View(Floor);

        }
        [HttpPost]
        public ActionResult EditFloorUnits(Floor floor)
        {
            
            repositoryF.SaveFloor(floor);
            TempData["message"] = string.Format("{0} has been saved", floor.FloorName);
            return RedirectToAction("FloorIndex","Admin",new { buildingID=floor.BuildingID });

        }


        //Create BuildingUnits

        public ActionResult CreateBuildingUnits ()
        {
            IEnumerable<Floor> Floors = repositoryF.Floors.ToList();
            foreach (var f  in Floors)

            {
                for (int i = 0; i < f.UnitNumbers; i++)

                {
                    Unit unit = new Unit
                    {
                        BuildingID = f.BuildingID,
                        FloorID=f.FloorID,


                    };
                  repositoryU.SaveUnit(unit);

                }


            }




            TempData["message"] = "Buildings are Created successfully";
            return RedirectToAction("BuildingManageIndex");
        }


        //Building Manage

       

        public ViewResult BuildingManageIndex()
        {
            return View(repositoryB.Buildings);
        }


        public ActionResult BuildingFloorUnit(int buildingID)
        {

            IEnumerable< Floor> floors = repositoryF.Floors.Where(r => r.BuildingID == buildingID);
            ViewBag.BuildingName = repositoryB.Buildings.FirstOrDefault(m => m.BuildingID == buildingID).BuildingName;

            return View(floors);

        }

        public ActionResult UnitFloorIndex(int floorID)
        {
        
            IEnumerable< Unit> units = repositoryU.Units.Where(r => r.FloorID == floorID).ToList();
            ViewBag.FloorName = repositoryF.Floors.FirstOrDefault(m => m.FloorID == floorID).FloorName;
            ViewBag.FloorID = floorID;


            return View(units);

        }
        
        public ActionResult UnitFloorEdit(int unitID)
        {

            Unit unit = repositoryU.Units.FirstOrDefault(r => r.UnitID == unitID);
            return View(unit);

        }
        [HttpPost]
        public ActionResult UnitFloorEdit(Unit unit)
        {

            repositoryU.SaveUnit(unit);
            return RedirectToAction("UnitFloorIndex",new {unit.FloorID});

        }



    }

    
}