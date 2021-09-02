using FizzBook.Areas.Master.Models.Hotels;
using FizzBook.Areas.Master.Models.Setup;
using FizzBook.Areas.Repository;
using FizzBook.HotelModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBook.Areas.Master.Controllers
{
    [Area("Master")]
    public class SetupController : Controller
    {
        private readonly IHotelsRepository _hotelsRepository;
        private readonly FizzHotleBookingContext _context;
        private readonly ISetupRepository _setupRepository;

        public SetupController(ISetupRepository setupRepository,
            IHotelsRepository hotelsRepository, FizzHotleBookingContext context)
        {
            _hotelsRepository = hotelsRepository;
            _context = context;
            _setupRepository = setupRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult HotelTypes()
        {
            var hotelTypes = _setupRepository.GetHotelTypes();
            return View(hotelTypes);
        }

        //Get: Setup/AddorEditHotelType
        //Get: Setup/AddorEditHotelType/5
        [HttpGet]
        public IActionResult AddHotelType()
        {
            return PartialView();
        }
        //POST: Setup/AddHotelType
        public IActionResult AddHotelType(HotelTypes hotelType)
        {
            if (ModelState.IsValid)
            {
                _setupRepository.AddHotelType(hotelType);
            }
            return Json("");
        }

        [HttpGet]
        public IActionResult EditHotelType(Guid id)
        {
            var hotelType = _setupRepository.FindHotelTypeById(id);

            return PartialView(hotelType);
        }
        //POST: Setup/AddHotelType

        [HttpPost]
        public IActionResult EditHotelType(HotelTypesModel hotelType)
        {
            if (ModelState.IsValid)
            {
                _setupRepository.EditHotelType(hotelType);
            }
            return Json("");
        }
        public IActionResult DeleteHotelType(Guid id)
        {
            _setupRepository.DeleteHotelTypeById(id);
            return RedirectToAction("HotelTypes");
        }

        public IActionResult RoomTypes()
        {
            var roomTypes = _setupRepository.GetRoomTypes();
            var model = new List<RoomTypesModel>();
            foreach (var item in roomTypes)
            {
                var obj = new RoomTypesModel()
                {
                    Id = item.Id,
                    Description = item.Description,
                    Name = item.Name,
                    IsDeleted = item.IsDeleted
                };
                model.Add(obj);
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult AddRoomType()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult AddRoomType(RoomTypes roomType)
        {
            if (ModelState.IsValid)
            {
                _setupRepository.AddRoomType(roomType);
            }
            return Json("");
        }

        [HttpGet]
        public IActionResult EditRoomType(Guid id)
        {
            var roomType = _setupRepository.FindRoomTypeById(id);

            return PartialView(roomType);
        }
        //POST: Setup/EditRoomType

        [HttpPost]
        public IActionResult EditRoomType(RoomTypesModel roomType)
        {
            if (ModelState.IsValid)
            {
                _setupRepository.EditRoomType(roomType);
            }
            return Json("");
        }
        public IActionResult DeleteRoomType(Guid id)
        {
            _setupRepository.DeleteRoomTypeById(id);
            return RedirectToAction("RoomTypes");
        }

        public IActionResult Cities()
        {
            var cities = _setupRepository.GetCities();
            List<CitiesModel> model = new List<CitiesModel>();
            foreach (var city in cities)
            {
                var contryName = _hotelsRepository.CountryNameById(city.CountryId);
                var item = new CitiesModel()
                {
                    Id = city.Id,
                    CityName = city.CityName,
                    Description = city.Description,
                    CountryName = contryName
                };
                model.Add(item);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult AddCity()
        {
            var countries = _hotelsRepository.allCountries().ToList();
            var model = new CitiesModel
            {
                Countries = countries.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToList()
            };
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult AddCity(CitiesModel city)
        {
            if (ModelState.IsValid)
            {
                var model = new Cities()
                {
                    Id = city.Id,
                    CityName = city.CityName,
                    Description = city.Description,
                    CountryId = city.CountryId
                };
                _setupRepository.AddCity(model);
            }
            return Json("");
        }
        [HttpGet]
        public IActionResult EditCity(Guid id)
        {
            var city = _setupRepository.FindCityById(id);
            var countries = _hotelsRepository.allCountries().ToList();
            var model = new CitiesModel
            {
                Id = city.Id,
                CityName = city.CityName,
                Description = city.Description,
                CountryId = city.CountryId,
                Countries = countries.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToList()
            };
            return PartialView(model);
        }
        //POST: Setup/EditRoomType
        [HttpPost]
        public IActionResult EditCity(CitiesModel cityModel)
        {
            if (ModelState.IsValid)
            {
                _setupRepository.EditCity(cityModel);
            }
            return Json("");
        }
        public IActionResult DeleteCity(Guid id)
        {
            _setupRepository.DeleteCityById(id);
            return RedirectToAction("Cities");
        }
        public IActionResult Companies()
        {
            var companies = _setupRepository.Companies();
            return View(companies);
        }
        [HttpGet]
        public IActionResult AddCompany()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCompany([FromBody] Companies company)
        {
            if (ModelState.IsValid)
            {
                _setupRepository.AddCompany(company);
            }
            return Json("");
        }
        [HttpGet]
        public IActionResult EditCompany(Guid id)
        {
            var company = _setupRepository.FindCompanyById(id);

            return PartialView(company);
        }
        //POST: Setup/EditRoomType

        [HttpPost]
        public IActionResult EditCompany(CompaniesModel companyModel)
        {
            if (ModelState.IsValid)
            {
                _setupRepository.EditCompany(companyModel);
            }
            return Json("");
        }
        public IActionResult DeleteCompany(Guid id)
        {
            _setupRepository.DeleteCompanyById(id);
            return RedirectToAction("Companies");
        }



        public IActionResult RoomServiceBooking()
        {
            var roomServiceBooking = _setupRepository.GetRoomServiceBooking();
            return View(roomServiceBooking);
        }
        public IActionResult DeleteRoomServiceBooking(int id)
        {
            _setupRepository.DeleteRoomServiceBookingById(id);
            return RedirectToAction("RoomServiceBooking");
        }

        [HttpGet]
        public IActionResult AddEditRoomServiceBooking(int id)
        {
            var model = new RoomServiceBooking();
            if (id != 0)
            {
                var tmep = _context.RoomServiceBooking.Where(p => p.Id == id).FirstOrDefault();
                if (tmep != null)
                {
                    model.Name = tmep.Name;
                    model.Price = tmep.Price;
                    model.Id = tmep.Id;
                }
            }
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult AddEditRoomServiceBooking(RoomServiceBooking model)
        {

            if (ModelState.IsValid)
            {
                if (model.Id != 0)
                {
                    var temp = _context.RoomServiceBooking.Where(p => p.Id == model.Id).FirstOrDefault();
                    temp.Name = model.Name;
                    temp.Price = model.Price;

                    _context.Update(temp);
                    _context.SaveChanges();
                }
                else
                {
                    var temp = new RoomServiceBooking()
                    {
                        //Id = Guid.NewGuid(),
                        Name = model.Name,
                        Price = model.Price

                    };
                    _context.Add(temp);
                    _context.SaveChanges();
                }
            }
            return Json("");
        }


        public IActionResult TableServiceBooking()
        {
            var tableServiceBooking = _setupRepository.GetTableServiceBooking();
            return View(tableServiceBooking);
        }

        public IActionResult DeleteTableServiceBooking(int id)
        {
            _setupRepository.DeleteTableServiceBookingById(id);
            return RedirectToAction("TableServiceBooking");
        }

        [HttpGet]
        public IActionResult AddEditTableServiceBooking(int id)
        {
            var model = new TableServiceBooking();
            if (id != 0)
            {
                var tmep = _context.TableServiceBooking.Where(p => p.Id == id).FirstOrDefault();
                if (tmep != null)
                {
                    model.Name = tmep.Name;
                    model.Price = tmep.Price;
                    model.Id = tmep.Id;
                }
            }
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult AddEditTableServiceBooking(TableServiceBooking model)
        {

            if (ModelState.IsValid)
            {
                if (model.Id != 0)
                {
                    var temp = _context.TableServiceBooking.Where(p => p.Id == model.Id).FirstOrDefault();
                    temp.Name = model.Name;
                    temp.Price = model.Price;

                    _context.Update(temp);
                    _context.SaveChanges();
                }
                else
                {
                    var temp = new TableServiceBooking()
                    {
                        //Id = Guid.NewGuid(),
                        Name = model.Name,
                        Price = model.Price
                    };
                    _context.Add(temp);
                    _context.SaveChanges();
                }
            }
            return Json("");
        }


        public IActionResult HallServiceBooking()
        {
            var hallServiceBooking = _setupRepository.GetHallServiceBooking();
            return View(hallServiceBooking);
        }

        public IActionResult DeleteHallServiceBooking(int id)
        {
            _setupRepository.DeleteRoomServiceBookingById(id);
            return RedirectToAction("HallServiceBooking");
        }

        [HttpGet]
        public IActionResult AddEditHallServiceBooking(int id)
        {
            var model = new HallServiceBookingModel();
            if (id != 0)
            {
                var tmep = _context.HallServiceBooking.Where(p => p.Id == id).FirstOrDefault();
                if (tmep != null)
                {
                    model.Name = tmep.Name;
                    model.Price = tmep.Price;
                    model.Id = tmep.Id;
                }
            }
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult AddEditHallServiceBooking(HallServiceBookingModel model)
        {

            if (ModelState.IsValid)
            {
                if (model.Id != 0)
                {
                    var temp = _context.HallServiceBooking.Where(p => p.Id == model.Id).FirstOrDefault();
                    temp.Name = model.Name;
                    temp.Price = model.Price;

                    _context.Update(temp);
                    _context.SaveChanges();
                }
                else
                {
                    var temp = new HallServiceBooking()
                    {
                        //Id = Guid.NewGuid(),
                        Name = model.Name,
                        Price = model.Price

                    };
                    _context.HallServiceBooking.Add(temp);
                    _context.SaveChanges();
                }
            }
            return Json("");
        }

    }
}
