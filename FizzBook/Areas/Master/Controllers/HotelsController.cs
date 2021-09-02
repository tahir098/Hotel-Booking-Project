using FizzBook.Areas.Master.Models.Hotels;
using FizzBook.Areas.Repository;
using FizzBook.HotelModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Web;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBook.Areas.Master.Controllers
{
    [Area("Master")]
    public class HotelsController : Controller
    {
        private readonly ISetupRepository _setupRepository;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHotelsRepository _hotelsRepository;
        public FizzHotleBookingContext _Context { get; }
        public HotelsController(IWebHostEnvironment hostEnvironment, FizzHotleBookingContext context, IHotelsRepository hotelsRepository, ISetupRepository setupRepository)
        {
            _setupRepository = setupRepository;
            webHostEnvironment = hostEnvironment;
            _Context = context;
            _hotelsRepository = hotelsRepository;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Services()
        {
            var model = _Context.Services.Where(p => p.IsDeleted == null).ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult AddEditService(Guid id)
        {
            var model = new ServicesModel();
            if (id != Guid.Empty)
            {
                var tmep = _Context.Services.Where(p => p.Id == id).FirstOrDefault();
                if (tmep != null)
                {
                    model.ServiceName = tmep.ServiceName;
                    model.Id = tmep.Id;
                }
            }
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult AddEditService(ServicesModel model)
        {

            if (ModelState.IsValid)
            {
                if (model.Id != Guid.Empty)
                {
                    var temp = _Context.Services.Where(p => p.Id == model.Id).FirstOrDefault();
                    temp.ServiceName = model.ServiceName;
                    _Context.Update(temp);
                    _Context.SaveChanges();
                }
                else
                {
                    var temp = new Services()
                    {
                        Id = Guid.NewGuid(),
                        ServiceName = model.ServiceName
                    };
                    _Context.Add(temp);
                    _Context.SaveChanges();
                }
            }
            return Json("");
        }
        public IActionResult DeleteService(Guid id)
        {
            var temp = _Context.Services.Where(p => p.Id == id).FirstOrDefault();
            if (temp != null)
            {
                temp.IsDeleted = true;
                _Context.Update(temp);
                _Context.SaveChanges();
            }
            return Json("");
        }


        [HttpGet]
        public ActionResult GetCities(Guid id)
        {
            if (id != null)
            {
                IEnumerable<SelectListItem> cities = _setupRepository.GetCities(id);
                return Json(cities);
            }
            return null;
        }
        public ActionResult GetBuildings(Guid id)
        {
            if (id != null)
            {
                IEnumerable<SelectListItem> buildings = _hotelsRepository.GetBuildings(id);
                return Json(buildings);
            }
            return null;
        }
        public ActionResult GetFloors(Guid id)
        {
            if (id != null)
            {
                IEnumerable<SelectListItem> floors = _hotelsRepository.GetFloors(id);
                return Json(floors);
            }
            return null;
        }
        public IActionResult Buildings()
        {
            var buildings = _hotelsRepository.Buildings();
            List<BuildingModel> model = new List<BuildingModel>();
            foreach (var building in buildings)
            {
                var hotelName = _hotelsRepository.HotelNameById(building.HotelId);
                var item = new BuildingModel()
                {
                    Id = building.Id,
                    Name = building.Name,
                    Address = building.Address,
                    HotelId = building.HotelId,
                    HotelName = hotelName,
                    IsDeleted = building.IsDeleted
                };
                model.Add(item);
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult AddBuilding()
        {
            var hotels = _hotelsRepository.AllHotels();
            var model = new BuildingModel
            {
                Hotels = hotels.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.HotelName
                }).ToList()
            };
            return PartialView(model);
        }
        [HttpPost]
        public IActionResult AddBuilding(BuildingModel model)
        {

            if (ModelState.IsValid)
            {
                var building = new Buildings()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Address = model.Address,
                    HotelId = model.HotelId,
                    IsDeleted = model.IsDeleted
                };
                if(model.BuildingImage != null)
                {
                    var uniqueFileName = ImageUpload(model.BuildingImage);
                    building.ImageUrl = uniqueFileName;
                }
                _hotelsRepository.AddBuilding(building);
            }
            return Json("");
        }
        [HttpGet]
        public IActionResult EditBuilding(Guid id)
        {
            if (id != null)
            {
                var building = _hotelsRepository.FindBuildingById(id);
                var hotels = _hotelsRepository.AllHotels();
                var model = new BuildingModel()
                {
                    Id = building.Id,
                    Name = building.Name,
                    Address = building.Address,
                    ImageUrl = building.ImageUrl,
                    HotelId = building.HotelId,
                    Hotels = hotels.Select(x => new SelectListItem()
                    {
                        Value = x.Id.ToString(),
                        Text = x.HotelName
                    }).ToList(),
                };
                return PartialView(model);
            }
            else
            {
                var model = new BuildingModel();
                return PartialView(model);
            }
        }
        [HttpPost]
        public IActionResult EditBuilding(BuildingModel model)
        {
            if (ModelState.IsValid)
            {
                if(model.BuildingImage != null)
                {
                    var uniqueFileName = ImageUpload(model.BuildingImage);
                    model.ImageUrl = uniqueFileName;
                }
                _hotelsRepository.EditBuildding(model);
            }
            return Json("");
        }
        public IActionResult DeleteBuilding(Guid id)
        {
            if (id != null)
            {
                _hotelsRepository.DeleteBuilding(id);
            }
            return Json("");
        }
        public IActionResult Halls()
        {
            var halls = _hotelsRepository.Halls();
            List<HallModel> model = new List<HallModel>();
            foreach (var hall in halls)
            {
                var hotelName = _hotelsRepository.HotelNameById(hall.HotelId);
                var item = new HallModel()
                {
                    Id = hall.Id,
                    Name = hall.Name,
                    Height = hall.Height,
                    Description = hall.Description,
                    Length = hall.Length,
                    RoomSize = hall.RoomSize,
                    HotelName = hotelName,
                    ImageUrl = hall.ImageUrl,
                    Width = hall.Width,
                    HotelId = hall.HotelId,
                    IsDeleted = hall.IsDeleted

                };
                model.Add(item);
            }
            model.OrderBy(x => x.Name);
            return View(model);
        }
        [HttpGet]
        public IActionResult AddHall()
        {
            var hotels = _hotelsRepository.AllHotels();
            var buildings = _hotelsRepository.Buildings();
            var model = new HallModel
            {
                Hotels = hotels.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.HotelName
                }).ToList(),
                Buildings = new List<SelectListItem>()
                {
                   new SelectListItem
                   {
                       Value = null,
                       Text = " "
                   }
                },
                Floors = new List<SelectListItem>()
                {
                   new SelectListItem
                   {
                       Value = null,
                       Text = " "
                   }
                }
            };
            return PartialView(model);
        }
        [HttpPost]
        public IActionResult AddHall(HallModel hall)
        {
            if (ModelState.IsValid)
            {
                var model = new Hall()
                {
                    Id = hall.Id,
                    IsDeleted = hall.IsDeleted,
                    Length = hall.Length,
                    Width = hall.Width,
                    Name = hall.Name,
                    Height = hall.Height,
                    RoomSize = hall.RoomSize,
                    Description = hall.Description,
                    Fare = hall.Fare,
                    HotelId = hall.HotelId,
                    BuildingId = hall.BuildingId,
                    FloorId = hall.FloorId,
                };
                if(hall.HallImage != null)
                {
                    var ufn = ImageUpload(hall.HallImage);
                    model.ImageUrl = ufn;
                }
                _hotelsRepository.AddHall(model);
            }
            return Json("");
        }
        [HttpGet]
        public IActionResult EditHall(Guid id)
        {
            if (id != null)
            {
                var hall = _hotelsRepository.FindHallById(id);
                var hotels = _hotelsRepository.AllHotels();
                var buildings = _hotelsRepository.GetBuildings(hall.HotelId);
                var floors = _hotelsRepository.GetFloors(hall.BuildingId);
                var model = new HallModel()
                {
                    Id = hall.Id,
                    Name = hall.Name,
                    Description = hall.Description,
                    ImageUrl = hall.ImageUrl,
                    RoomSize = hall.RoomSize,
                    Length = hall.Length,
                    Width = hall.Width,
                    Height = hall.Height,
                    IsDeleted = hall.IsDeleted,
                    HotelId = hall.HotelId,
                    BuildingId = hall.BuildingId,
                    FloorId = hall.FloorId,
                    Fare = hall.Fare,
                    Hotels = hotels.Select(x => new SelectListItem()
                    {
                        Value = x.Id.ToString(),
                        Text = x.HotelName
                    }).ToList(),
                    Buildings = buildings.Select(x => new SelectListItem()
                    {
                        Value = x.Value,
                        Text = x.Text
                    }).ToList(),
                    Floors = floors.Select(x => new SelectListItem()
                    {
                        Value = x.Value,
                        Text = x.Text
                    }).ToList(),
                };
                return PartialView(model);
            }
            else
            {
                var model = new HallModel();
                return PartialView(model);
            }
        }
        [HttpPost]
        public IActionResult EditHall(HallModel model)
        {
            if (ModelState.IsValid)
            {
                var editedHall = new Hall()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    Length = model.Length,
                    Width = model.Width,
                    Height = model.Height,
                    IsDeleted = model.IsDeleted,
                    Fare = model.Fare,

                    HotelId = model.HotelId,
                    BuildingId = model.BuildingId,
                    FloorId = model.FloorId,
                };
                if(model.HallImage != null)
                {
                    var ufn = ImageUpload(model.HallImage);
                    editedHall.ImageUrl = ufn;
                }
                _hotelsRepository.EditHall(editedHall);
            }
            return Json("");
        }
        public IActionResult DeleteHall(Guid id)
        {
            if (id != null)
            {
                _hotelsRepository.DeleteHall(id);
            }
            return Json("");
        }
        public IActionResult Floors()
        {
            var floors = _hotelsRepository.Floors();
            List<FloorModel> model = new List<FloorModel>();
            foreach (var floor in floors)
            {
                var hotelName = _hotelsRepository.HotelNameById(floor.HotelId);
                var buildingName = _hotelsRepository.buildingNameById(floor.BuildingId);
                var item = new FloorModel()
                {
                    Id = floor.Id,
                    HotelName = hotelName,
                    BuildingName = buildingName,
                    FloorNo = floor.FloorNo,
                    IsDeleted = floor.IsDeleted
                };
                model.Add(item);
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult AddFloor()
        {
            var hotels = _hotelsRepository.AllHotels();
            var buildings = _hotelsRepository.Buildings();
            var model = new FloorModel
            {
                Hotels = hotels.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.HotelName
                }).ToList(),
                Buildings = new List<SelectListItem>()
                {
                   new SelectListItem
                   {
                       Value = null,
                       Text = " "
                   }
                }
            };
            return PartialView(model);
        }
        [HttpPost]
        public IActionResult AddFloor(FloorModel floor)
        {
            if (ModelState.IsValid)
            {
                var model = new Floors()
                {
                    Id = floor.Id,
                    FloorNo = floor.FloorNo,
                    IsDeleted = floor.IsDeleted,
                    BuildingId = floor.BuildingId,
                    HotelId = floor.HotelId,
                };
                if(floor.FloorImage != null)
                {
                    var ufn = ImageUpload(floor.FloorImage);
                    model.ImageUrl = ufn;
                }
                _hotelsRepository.AddFloor(model);
            }
            return Json("");
        }
        [HttpGet]
        public IActionResult EditFloor(Guid id)
        {
            if (id != null)
            {
                var floor = _hotelsRepository.FindFloorById(id);
                var hotels = _hotelsRepository.AllHotels();
                var buildings = _hotelsRepository.GetBuildings(floor.HotelId);
                var model = new FloorModel()
                {
                    Id = floor.Id,
                    BuildingId = floor.BuildingId,
                    HotelId = floor.HotelId,
                    FloorNo = floor.FloorNo,
                    ImageUrl = floor.ImageUrl,
                    Hotels = hotels.Select(x => new SelectListItem()
                    {
                        Value = x.Id.ToString(),
                        Text = x.HotelName
                    }).ToList(),
                    Buildings = buildings.Select(x => new SelectListItem()
                    {
                        Value = x.Value,
                        Text = x.Text
                    }).ToList(),
                };
                return PartialView(model);
            }
            else
            {
                var model = new HallModel();
                return PartialView(model);
            }
        }
        [HttpPost]
        public IActionResult EditFloor(FloorModel model)
        {
            if (ModelState.IsValid)
            {
                if(model.FloorImage != null)
                {
                    var ufn = ImageUpload(model.FloorImage);
                    model.ImageUrl = ufn;
                }
                _hotelsRepository.EditFloor(model);
            }
            return Json("");
        }
        public IActionResult DeleteFloor(Guid id)
        {
            if (id != null)
            {
                _hotelsRepository.DeleteHotel(id);
            }
            return Json("");
        }
        public IActionResult Rooms()
        {
            var rooms = _hotelsRepository.Rooms();
            List<RoomsModel> model = new List<RoomsModel>();
            foreach (var room in rooms)
            {
                var hotelName = _hotelsRepository.HotelNameById(room.HotelId);
                var buildingName = _hotelsRepository.buildingNameById(room.BuildingId);
                var floorNo = _hotelsRepository.FloorNoById(room.FloorId);
                var roomType = _setupRepository.FindRoomTypeById(room.TypeId);
                var roomTypeName = roomType.Name;
                var item = new RoomsModel()
                {
                    Id = room.Id,
                    BuildingId = room.BuildingId,
                    RoomNo = room.RoomNo,
                    FloorId = room.FloorId,
                    Description = room.Description,
                    BuildingName = buildingName,
                    HotelId = room.HotelId,
                    FarePerNight = room.FarePerNight,
                    HotelName = hotelName,
                    FloorNo = floorNo,
                    MaxNoOfPersons = room.MaxNoOfPersons,
                    NoOfBeds = room.NoOfBeds,
                    RoomView = room.RoomView,
                    TypeName = roomTypeName
                };
                model.Add(item);
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult AddRoom()
        {
            var hotels = _hotelsRepository.AllHotels();
            var roomTypes = _setupRepository.GetRoomTypes();
            var services = _Context.Services.Where(p => p.IsDeleted == null).ToList();
            var buildings = _hotelsRepository.Buildings();
            var floors = _hotelsRepository.Floors();
            var model = new RoomsModel
            {
                Hotels = hotels.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.HotelName
                }).ToList(),
                Services = services.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.ServiceName
                }).ToList(),
                Buildings = new List<SelectListItem>()
                {
                   new SelectListItem
                   {
                       Value = null,
                       Text = " "
                   }
                },
                Types = roomTypes.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToList(),
                Floors = new List<SelectListItem>()
                {
                   new SelectListItem
                   {
                       Value = null,
                       Text = " "
                   }
                }
            };
            return PartialView(model);
        }
        [HttpPost]
        public IActionResult AddRoom(RoomsModel room)
        {
            if (ModelState.IsValid)
            {
                var model = new Rooms()
                {
                    Id = Guid.NewGuid(),
                    TypeId = room.TypeId,
                    RoomNo = room.RoomNo,
                    MaxNoOfPersons = room.MaxNoOfPersons,
                    BuildingId = room.BuildingId,
                    Description = room.Description,
                    DiscountAmount = room.DiscountAmount,
                    FarePerNight = room.FarePerNight,
                    FloorId = room.FloorId,
                    HotelId = room.HotelId,
                    IsBooked = room.IsBooked,
                    IsDeleted = room.IsDeleted,
                    IsAvailable = true,
                    NoOfBeds = room.NoOfBeds,
                    RoomView = room.RoomView
                };
                if(room.RoomImage != null)
                {
                    string uniqueFileName = ImageUpload(room.RoomImage);
                    model.ImageUrl = uniqueFileName;
                }
                _hotelsRepository.AddRoom(model);
                foreach (var item in room.ServiceIds)
                {
                    var roomService = new RoomServices()
                    {
                        Id = Guid.NewGuid(),
                        RoomId = model.Id,
                        ServiceId = item
                    };
                    _Context.RoomServices.Add(roomService);
                    _Context.SaveChanges();
                }
            }
            return Json("");
        }
        [HttpGet]
        public IActionResult EditRoom(Guid id)
        {
            if (id != null)
            {
                var room = _hotelsRepository.FindRoomById(id);
                var roomServices = _Context.RoomServices.Where(p => p.RoomId == room.Id).ToList();
                var services = _Context.Services.Where(p => p.IsDeleted == null).ToList();
                var hotels = _hotelsRepository.AllHotels();
                var roomTypes = _setupRepository.GetRoomTypes();
                var buildings = _hotelsRepository.GetBuildings(room.HotelId);
                var floors = _hotelsRepository.GetFloors(room.BuildingId);
                var model = new RoomsModel
                {
                    Id = room.Id,
                    BuildingId = room.BuildingId,
                    FarePerNight = room.FarePerNight,
                    FloorId = room.FloorId,
                    HotelId = room.HotelId,
                    IsDeleted = room.IsDeleted,
                    MaxNoOfPersons = room.MaxNoOfPersons,
                    NoOfBeds = room.NoOfBeds,
                    RoomNo = room.RoomNo,
                    ImageUrl = room.ImageUrl,
                    RoomView = room.RoomView,
                    TypeId = room.TypeId,
                    Description = room.Description,
                    Buildings = buildings.Select(x => new SelectListItem()
                    {
                        Value = x.Value,
                        Text = x.Text
                    }).ToList(),
                    Types = roomTypes.Select(x => new SelectListItem()
                    {
                        Value = x.Id.ToString(),
                        Text = x.Name
                    }).ToList(),
                    Services = services.Select(x => new SelectListItem()
                    {
                        Value = x.Id.ToString(),
                        Text = x.ServiceName
                    }).ToList(),
                    Floors = floors.Select(x => new SelectListItem()
                    {
                        Value = x.Value,
                        Text = x.Text
                    }).ToList(),
                    Hotels = hotels.Select(x => new SelectListItem()
                    {
                        Value = x.Id.ToString(),
                        Text = x.HotelName
                    }).ToList()
                };
                model.ServiceIds = new List<Guid>();
                foreach (var service in roomServices)
                {
                    var serviceId = service.ServiceId;
                    model.ServiceIds.Add(serviceId);
                };
                model.ServiceIdsString = string.Join(",", model.ServiceIds);

                return PartialView(model);
            }
            else
            {
                var model = new HallModel();
                return PartialView(model);
            }
        }
        [HttpPost]
        public IActionResult EditRoom(RoomsModel model)
        {
            if (ModelState.IsValid)
            {
                var editedRoom = new Rooms()
                {
                    Id = model.Id,
                    TypeId = model.TypeId,
                    RoomNo = model.RoomNo,
                    MaxNoOfPersons = model.MaxNoOfPersons,
                    BuildingId = model.BuildingId,
                    Description = model.Description,
                    DiscountAmount = model.DiscountAmount,
                    FarePerNight = model.FarePerNight,
                    FloorId = model.FloorId,
                    HotelId = model.HotelId,
                    IsBooked = model.IsBooked,
                    IsDeleted = model.IsDeleted,
                    IsAvailable = true,
                    NoOfBeds = model.NoOfBeds,
                    RoomView = model.RoomView
                };
                if(model.RoomImage != null)
                {
                    string uniqueFileName = ImageUpload(model.RoomImage);
                    editedRoom.ImageUrl = uniqueFileName;
                }
                else
                {
                    editedRoom.ImageUrl = model.ImageUrl;
                }
                _hotelsRepository.EditRoom(editedRoom);
                var roomServices = _Context.RoomServices.Where(p => p.RoomId == model.Id);
                _Context.RemoveRange(roomServices);
                _Context.SaveChanges();
                foreach (var item in model.ServiceIds)
                {
                    var roomService = new RoomServices()
                    {
                        Id = Guid.NewGuid(),
                        RoomId = model.Id,
                        ServiceId = item
                    };
                    _Context.RoomServices.Add(roomService);
                    _Context.SaveChanges();
                }
            }
            return Json("");
        }
        private string ImageUpload(IFormFile Image)
        {
            string uniqueFileName = null;

            if (Image != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Image.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        public IActionResult DeleteRoom(Guid id)
        {
            if (id != null)
            {
                _hotelsRepository.DeleteRoom(id);
            }
            return Json("");
        }
        public IActionResult Tables()
        {
            var tables = _hotelsRepository.Tables();
            List<TableModel> model = new List<TableModel>();
            foreach (var table in tables)
            {
                var hotelName = _hotelsRepository.HotelNameById(table.HotelId);
                var buildingName = _hotelsRepository.buildingNameById(table.BuildingId);
                var floorNo = _hotelsRepository.FloorNoById(table.FloorId);
                var item = new TableModel()
                {
                    Id = table.Id,
                    Description = table.Description,
                    BuildingId = table.BuildingId,
                    FarePerHour = table.FarePerHour,
                    FloorId = table.FloorId,
                    HotelName = hotelName,
                    BuildingName = buildingName,
                    FloorNo = floorNo,
                    HotelId = table.HotelId,
                    IsDeleted = table.IsDeleted,
                    MaxNoOfPersons = table.MaxNoOfPersons,
                    TableNo = table.TableNo,
                    TableView = table.TableView
                };
                model.Add(item);
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult AddTable()
        {
            var hotels = _hotelsRepository.AllHotels();
            var model = new TableModel
            {
                Hotels = hotels.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.HotelName
                }).ToList(),
                Buildings = new List<SelectListItem>()
                {
                   new SelectListItem
                   {
                       Value = null,
                       Text = " "
                   }
                },
                Floors = new List<SelectListItem>()
                {
                   new SelectListItem
                   {
                       Value = null,
                       Text = " "
                   }
                }
            };
            return PartialView(model);
        }
        [HttpPost]
        public IActionResult AddTable(TableModel table)
        {
            if (ModelState.IsValid)
            {
                var model = new Tables()
                {
                    Id = table.Id,
                    BuildingId = table.BuildingId,
                    IsDeleted = table.IsDeleted,
                    MaxNoOfPersons = table.MaxNoOfPersons,
                    TableNo = table.TableNo,
                    TableView = table.TableView,
                    HotelId = table.HotelId,
                    FloorId = table.FloorId,
                    IsAvailable = true,
                    FarePerHour = table.FarePerHour ?? 0,
                    Description = table.Description
                };
                if(table.TableImage != null)
                {
                    var ufn = ImageUpload(table.TableImage);
                    model.ImageUrl = ufn;
                }
                _hotelsRepository.AddTable(model);
            }
            return Json("");
        }
        [HttpGet]
        public IActionResult EditTable(Guid id)
        {
            if (id != null)
            {
                var table = _hotelsRepository.FindTableById(id);
                var hotels = _hotelsRepository.AllHotels();
                var buildings = _hotelsRepository.GetBuildings(table.HotelId);
                var floors = _hotelsRepository.GetFloors(table.BuildingId);
                var model = new TableModel()
                {
                    Id = table.Id,
                    TableNo = table.TableNo,
                    ImageUrl = table.ImageUrl,
                    Description = table.Description,
                    FarePerHour = table.FarePerHour,
                    MaxNoOfPersons = table.MaxNoOfPersons,
                    TableView = table.TableView,
                    IsDeleted = table.IsDeleted,
                    HotelId = table.HotelId,
                    IsAvailable = table.IsAvailable,
                    BuildingId = table.BuildingId,
                    FloorId = table.FloorId,
                    Hotels = hotels.Select(x => new SelectListItem()
                    {
                        Value = x.Id.ToString(),
                        Text = x.HotelName
                    }).ToList(),
                    Buildings = buildings.Select(x => new SelectListItem()
                    {
                        Value = x.Value,
                        Text = x.Text
                    }).ToList(),
                    Floors = floors.Select(x => new SelectListItem()
                    {
                        Value = x.Value,
                        Text = x.Text
                    }).ToList()
                };
                return PartialView(model);
            }
            else
            {
                var model = new TableModel();
                return PartialView(model);
            }
        }
        [HttpPost]
        public IActionResult EditTable(TableModel model)
        {
            if (ModelState.IsValid)
            {
                var editedTable = new Tables()
                {
                    Id = model.Id,
                    BuildingId = model.BuildingId,
                    Description = model.Description,
                    FarePerHour = model.FarePerHour ?? 0,
                    IsAvailable = model.IsAvailable,
                    FloorId = model.FloorId,
                    HotelId = model.HotelId,
                    TableNo = model.TableNo,
                    IsDeleted = model.IsDeleted,
                    MaxNoOfPersons = model.MaxNoOfPersons,
                    TableView = model.TableView
                };
                if(model.TableImage != null)
                {
                    var ufn = ImageUpload(model.TableImage);
                    editedTable.ImageUrl = ufn;
                }
                _hotelsRepository.EditTable(editedTable);
            }
            return Json("");
        }
        public IActionResult DeleteTable(Guid id)
        {
            if (id != null)
            {
                _hotelsRepository.DeleteTable(id);
            }
            return Json("");
        }

        [HttpGet]
        public IActionResult AddNewHotel()
        {
            var hoelTypes = _setupRepository.GetHotelTypes().ToList();
            var cities = _setupRepository.GetCities();
            var countries = _hotelsRepository.allCountries();
            var model = new HotelsModel
            {
                HotelTypes = hoelTypes.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Type
                }).ToList(),
                Cities = new List<SelectListItem>()
                {
                   new SelectListItem
                   {
                       Value = null,
                       Text = " "
                   }
                },
                Countries = countries.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToList()
            };
            return PartialView(model);
        }
        [HttpPost]
        public IActionResult AddNewHotel(HotelsModel hotel)
        {
            if (ModelState.IsValid)
            {
                var model = new Hotels()
                {
                    HotelAddress = hotel.HotelAddress,
                    HotelCityId = hotel.HotelCityId,
                    HotelCountryId = hotel.HotelCountryId,
                    HotelEmail = hotel.HotelEmail,
                    HotelLogo = hotel.HotelLogo,
                    HotelMobile = hotel.HotelMobile,
                    HotelName = hotel.HotelName,
                    HotelPhone = hotel.HotelPhone,
                    HotelTypeId = hotel.HotelTypeId,
                    HotelWebsite = hotel.HotelWebsite,
                    Password = hotel.Password,
                    Id = hotel.Id
                };
                if (hotel.HotelImage != null)
                {
                    var uniqueFileName = ImageUpload(hotel.HotelImage);
                    model.ImageUrl = uniqueFileName;
                }

                _hotelsRepository.addHotel(model);
            }
            return Json("");
        }
        public IActionResult AllHotels()
        {
            var hotels = _hotelsRepository.AllHotels();
            List<HotelsModel> model = new List<HotelsModel>();
            foreach (var hotel in hotels)
            {
                //var hotelTypeName = _setupRepository.GetHotelTypeName(hotel.HotelTypeId);
                var item = new HotelsModel()
                {
                    Id = hotel.Id,
                    HotelName = hotel.HotelName,
                    HotelPhone = hotel.HotelPhone,
                    HotelEmail = hotel.HotelEmail,
                    HotelAddress = hotel.HotelAddress,
                    HotelWebsite = hotel.HotelWebsite,
                    Password = hotel.Password
                };
                model.Add(item);
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult EditHotel(Guid id)
        {
            var hotel = _hotelsRepository.FindHotelById(id);
            var countries = _hotelsRepository.allCountries().ToList();
            var cities = _setupRepository.GetCities(hotel.HotelCountryId);
            //var hotelTypes = _setupRepository.GetHotelTypes();
            var model = new HotelsModel
            {
                Id = hotel.Id,
                HotelName = hotel.HotelName,
                HotelWebsite = hotel.HotelWebsite,
                HotelAddress = hotel.HotelAddress,
                HotelEmail = hotel.HotelEmail,
                HotelCountryId = hotel.HotelCountryId,
                ImageUrl = hotel.ImageUrl,
                HotelCityId = hotel.HotelCityId,
                HotelPhone = hotel.HotelPhone,
                Password = hotel.Password,
                Countries = countries.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToList(),
                Cities = cities.Select(x => new SelectListItem
                {
                    Value = x.Value,
                    Text = x.Text
                }).ToList()
                //HotelTypes = hotelTypes.Select(x => new SelectListItem
                //{
                //    Value = x.Id.ToString(),
                //    Text = x.Type
                //}).ToList()
            };
            return PartialView(model);
        }
        [HttpPost]
        public IActionResult EditHotel(HotelsModel model)
        {
            if (ModelState.IsValid)
            {
               
                var editedHotel = new Hotels()
                {
                    Id = model.Id,
                    HotelName = model.HotelName,
                    HotelWebsite = model.HotelWebsite,
                    HotelAddress = model.HotelAddress,
                    HotelPhone = model.HotelPhone,
                    HotelEmail = model.HotelEmail,
                    HotelCountryId = model.HotelCountryId,
                    HotelCityId = model.HotelCityId,
                    HotelTypeId = model.HotelTypeId,
                    Password = model.Password,
                };
                if (model.HotelImage != null)
                {
                    var uniqueFileName = ImageUpload(model.HotelImage);
                    editedHotel.ImageUrl = uniqueFileName;
                }
                else
                {
                    editedHotel.ImageUrl = model.ImageUrl;
                }
                _hotelsRepository.EditHotel(editedHotel);
            }
            return Json("");
        }
        public IActionResult DeleteHotel(Guid id)
        {
            if (id != null)
            {
                _hotelsRepository.DeleteHotel(id);
            }
            return Json("");
        }

        public IActionResult Countries()
        {
            var countries = _hotelsRepository.allCountries();
            List<CountriesModel> model = new List<CountriesModel>();
            foreach (var country in countries)
            {
                var item = new CountriesModel()
                {
                    Id = country.Id,
                    Name = country.Name
                };
                model.Add(item);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult addCountry()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult addCountry(CountriesModel model)
        {
            if (ModelState.IsValid)
            {
                var item = new Countries()
                {
                    Id = model.Id,
                    Name = model.Name
                };
                _hotelsRepository.AddCountry(item);
            }
            return Json("");
        }
        [HttpGet]
        public IActionResult EditCountry(Guid id)
        {
            var country = _hotelsRepository.FindCountryById(id);

            return PartialView(country);
        }
        [HttpPost]
        public IActionResult EditCountry(CountriesModel model)
        {
            if (ModelState.IsValid)
            {
                _hotelsRepository.EditCountry(model);
            }
            return Json("");
        }
        public IActionResult DeleteCountry(Guid id)
        {
            _hotelsRepository.DeleteCountry(id);
            return RedirectToAction("Countries");
        }

    }
}
