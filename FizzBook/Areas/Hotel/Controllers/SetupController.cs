using FizzBook.Areas.Hotel.Models.Hotels;
using FizzBook.Areas.Repository;
using FizzBook.HotelModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBook.Areas.Hotel.Controllers
{
    [Area("Hotel")]
    public class SetupController : BaseController
    {
        private readonly FizzHotleBookingContext _context;
        private readonly IHotelsRepository _hotelsRepository;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ISetupRepository _setupRepository;

        public SetupController(FizzHotleBookingContext context,
            IHotelsRepository hotelsRepository,
            IWebHostEnvironment hostEnvironment,
            ISetupRepository setupRepository)
        {
            _context = context;
            _hotelsRepository = hotelsRepository;
            _hostEnvironment = hostEnvironment;
            _setupRepository = setupRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Buildings

        public ActionResult GetBuildings(Guid id)
        {
            if (id != null)
            {
                IEnumerable<SelectListItem> buildings = _hotelsRepository.GetBuildings(id);
                return Json(buildings);
            }
            return null;
        }

        public IActionResult Buildings()
        {
            var tmep = _context.Buildings.Where(p => p.HotelId == Guid.Parse(TheUser) && (p.IsDeleted.Value != true)).ToList();
            List<BuildingModel> model = new List<BuildingModel>();
            foreach (var building in tmep)
            {
                //var hotelName = _hotelsRepository.HotelNameById(building.HotelId);
                var item = new BuildingModel()
                {
                    Id = building.Id,
                    Name = building.Name,
                    Address = building.Address,
                    HotelId = building.HotelId,
                    HotelName = _hotelsRepository.GetHotelName(TheUser),
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
                //Hotels = hotels.Select(x => new SelectListItem()
                //{
                //    Value = x.Id.ToString(),
                //    Text = x.HotelName
                //}).ToList()

                HotelId = Guid.Parse(TheUser),
                HotelName = _hotelsRepository.GetHotelName(TheUser)
            };
            return PartialView(model);
        }
        [HttpPost]
        public IActionResult AddBuilding(BuildingModel model)
        {

            if (ModelState.IsValid)
            {
                //if (model.Id == Guid.Empty)
                //{
                var building = new Buildings()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Address = model.Address,
                    //HotelId = model.HotelId,
                    HotelId = Guid.Parse(TheUser),
                    IsDeleted = model.IsDeleted,
                };
                if (model.BuildingImage != null)
                {
                    var uniqueFileName = ImageUpload(model.BuildingImage);
                    building.ImageUrl = uniqueFileName;
                }
                _hotelsRepository.AddBuilding(building);
                //}
                //else
                //{
                //    var building = new Buildings()
                //    {
                //        Id = model.Id,
                //        Name = model.Name,
                //        Address = model.Address,
                //        //HotelId = model.HotelId,
                //        HotelId = Guid.Parse(TheUser),
                //        IsDeleted = model.IsDeleted,
                //    };
                //    if (model.BuildingImage != null)
                //    {
                //        var uniqueFileName = ImageUpload(model.BuildingImage);
                //        building.ImageUrl = uniqueFileName;
                //    }

                //    _hotelsRepository.EditBuildding(building);
                //}


            }
            return Json("");
        }

        [HttpGet]
        public IActionResult EditBuilding(string id)
        {
            if (id != null)
            {
                var building = _hotelsRepository.FindBuildingById(Guid.Parse(id));
                //var hotels = _hotelsRepository.AllHotels();
                var model = new BuildingModel()
                {
                    Id = building.Id,
                    Name = building.Name,
                    Address = building.Address,
                    ImageUrl = building.ImageUrl,
                    HotelName = _hotelsRepository.GetHotelName(TheUser),
                    IsDeleted = building.IsDeleted
                    //HotelId = building.HotelId,
                    //Hotels = hotels.Select(x => new SelectListItem()
                    //{
                    //    Value = x.Id.ToString(),
                    //    Text = x.HotelName
                    //}).ToList(),
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
                if (model.BuildingImage != null)
                {
                    var uniqueFileName = ImageUpload(model.BuildingImage);
                    model.ImageUrl = uniqueFileName;
                }
                model.HotelName = _hotelsRepository.GetHotelName(TheUser);
                model.HotelId = Guid.Parse(TheUser);

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

        #endregion

        #region Floor
        public IActionResult Floors()
        {
            // var floors = _hotelsRepository.Floors();

            List<Floors> floors = _hotelsRepository.GetFloorsByHotelId(TheUser);
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
            var hotels = _hotelsRepository.GetAllHotelsByHotelId(TheUser);
            var buildings = _hotelsRepository.GetBuildingsByHotelId(TheUser);
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
                },

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
                    // Id = floor.Id,
                    FloorNo = floor.FloorNo,
                    IsDeleted = floor.IsDeleted,
                    BuildingId = floor.BuildingId,
                    HotelId = Guid.Parse(TheUser),
                };
                if (floor.FloorImage != null)
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
                var hotels = _hotelsRepository.GetAllHotelsByHotelId(TheUser);
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
                if (model.FloorImage != null)
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
                _hotelsRepository.DeleteFloor(id);
            }
            return Json("");
        }

        #endregion

        #region Halls

        public IActionResult Halls()
        {
            // var halls = _hotelsRepository.Halls().ToList();

            var userHalls = _hotelsRepository.GetHallsByHotelId(TheUser);

            List<HallModel> model = new List<HallModel>();
            foreach (var hall in userHalls)
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
            return View(model);
        }

        [HttpGet]
        public IActionResult AddHall()
        {
            var hotels = _hotelsRepository.AllHotels();
            var buildings = _hotelsRepository.Buildings();
            var model = new HallModel
            {
                HotelId = Guid.Parse(TheUser),
                HotelName = _hotelsRepository.GetHotelName(TheUser),
                Hotels = hotels.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.HotelName
                }).ToList(),

                Buildings = _hotelsRepository.GetAvailableBuildingsByHotelId(TheUser).ToList(),
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

                    HotelId = Guid.Parse(TheUser),
                    BuildingId = hall.BuildingId,
                    FloorId = hall.FloorId,

                    Height = hall.Height,
                    RoomSize = hall.RoomSize,
                    Description = hall.Description,
                    Fare = hall.Fare
                };
                if (hall.HallImage != null)
                {
                    var ufn = ImageUpload(hall.HallImage);
                    model.ImageUrl = ufn;
                }
                _hotelsRepository.AddHall(model);

                //foreach (var item in hall.ServiceIds)
                //{
                //    var roomService = new RoomService()
                //    {
                //        Id = Guid.NewGuid(),
                //        RoomId = model.Id,
                //        ServiceId = item
                //    };
                //    _context.RoomServices.Add(roomService);
                //    _context.SaveChanges();
                //}
            }
            return Json("");
        }

        [HttpGet]
        public IActionResult EditHall(Guid id)
        {
            if (id != null)
            {
                var hall = _hotelsRepository.FindHallById(id);

                var buildings = _hotelsRepository.GetBuildingsByHotelId(TheUser);
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

                    HotelName = _hotelsRepository.GetHotelName(TheUser),
                    Fare = hall.Fare.HasValue ? Decimal.Round(hall.Fare.Value) : 0,
                    Buildings = buildings.Select(x => new SelectListItem()
                    {
                        Value = x.Id.ToString(),
                        Text = x.Name
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

                    HotelId = Guid.Parse(TheUser),
                    BuildingId = model.BuildingId,
                    FloorId = model.FloorId,
                    
                    IsDeleted = model.IsDeleted,
                    ImageUrl = model.ImageUrl,
                    RoomSize = model.RoomSize,
                    Fare = model.Fare
                };
                if (model.HallImage != null)
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

        #endregion

        #region Rooms

        public IActionResult Rooms()
        {
            var rooms = _hotelsRepository.GetRoomsByHotelId(TheUser);
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
            //var hotels = _hotelsRepository.AllHotels();
            var roomTypes = _setupRepository.GetRoomTypes();
            var services = _context.Services.Where(p => p.IsDeleted == null).ToList();//didnt get services using hotelId
            var buildings = _hotelsRepository.GetBuildingsByHotelId(TheUser);
            var floors = _hotelsRepository.GetFloorsByHotelId(TheUser);
            var model = new RoomsModel
            {
                //Hotels = hotels.Select(x => new SelectListItem()
                //{
                //    Value = x.Id.ToString(),
                //    Text = x.HotelName
                //}).ToList(),
                HotelName = _hotelsRepository.GetHotelName(TheUser),

                Services = services.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.ServiceName
                }).ToList(),
                //Buildings = new List<SelectListItem>()
                //{
                //   new SelectListItem
                //   {
                //       Value = null,
                //       Text = " "
                //   }
                //},
                Buildings = _hotelsRepository.GetAvailableBuildingsByHotelId(TheUser).ToList(),

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
        public ActionResult GetFloors(string buildingId)
        {
            if (buildingId != null)
            {
                IEnumerable<SelectListItem> floors = _hotelsRepository.GetFloors(Guid.Parse(buildingId));
                return Json(floors);
            }
            return null;
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
                    HotelId = Guid.Parse(TheUser),
                    IsBooked = room.IsBooked,
                    IsDeleted = room.IsDeleted,
                    IsAvailable = true,
                    NoOfBeds = room.NoOfBeds,
                    RoomView = room.RoomView
                };
                if (room.RoomImage != null)
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
                    _context.RoomServices.Add(roomService);
                    _context.SaveChanges();
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
                var roomServices = _context.RoomServices.Where(p => p.RoomId == room.Id).ToList();
                var services = _context.Services.Where(p => p.IsDeleted == null).ToList();
                var hotels = _hotelsRepository.AllHotels();
                var roomTypes = _setupRepository.GetRoomTypes();
                var buildings = _hotelsRepository.GetBuildingsByHotelId(TheUser);
                var floors = _hotelsRepository.GetFloors(room.BuildingId);
                var model = new RoomsModel
                {
                    Id = room.Id,
                    BuildingId = room.BuildingId,
                    FarePerNight = room.FarePerNight,
                    FloorId = room.FloorId,
                    HotelId = Guid.Parse(TheUser),
                    IsDeleted = room.IsDeleted,
                    MaxNoOfPersons = room.MaxNoOfPersons,
                    NoOfBeds = room.NoOfBeds,
                    RoomNo = room.RoomNo,
                    ImageUrl = room.ImageUrl,
                    RoomView = room.RoomView,
                    TypeId = room.TypeId,
                    Description = room.Description,
                    HotelName = _hotelsRepository.GetHotelName(TheUser),
                    Buildings = buildings.Select(x => new SelectListItem()
                    {
                        Value = x.Id.ToString(),
                        Text = x.Name
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
                    //Hotels = hotels.Select(x => new SelectListItem()
                    //{
                    //    Value = x.Id.ToString(),
                    //    Text = x.HotelName
                    //}).ToList()
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
                    HotelId = Guid.Parse(TheUser),
                    IsBooked = model.IsBooked,
                    IsDeleted = model.IsDeleted,
                    IsAvailable = true,
                    NoOfBeds = model.NoOfBeds,
                    RoomView = model.RoomView
                };
                if (model.RoomImage != null)
                {
                    string uniqueFileName = ImageUpload(model.RoomImage);
                    editedRoom.ImageUrl = uniqueFileName;
                }
                else
                {
                    editedRoom.ImageUrl = model.ImageUrl;
                }
                _hotelsRepository.EditRoom(editedRoom);
                var roomServices = _context.RoomServices.Where(p => p.RoomId == model.Id);
                _context.RemoveRange(roomServices);
                _context.SaveChanges();
                foreach (var item in model.ServiceIds)
                {
                    var roomService = new RoomServices()
                    {
                        Id = Guid.NewGuid(),
                        RoomId = model.Id,
                        ServiceId = item
                    };
                    _context.RoomServices.Add(roomService);
                    _context.SaveChanges();
                }
            }
            return Json("");
        }


        public IActionResult DeleteRoom(Guid id)
        {
            if (id != null)
            {
                _hotelsRepository.DeleteRoom(id);
            }
            return Json("");
        }


        #endregion

        #region Tables

        public IActionResult Tables()
        {
            var tables = _hotelsRepository.GetTablesByHotelId(TheUser);
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
                    HotelId = Guid.Parse(TheUser),
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
            // var hotels = _hotelsRepository.AllHotels();
            var model = new TableModel
            {
                //Hotels = hotels.Select(x => new SelectListItem()
                //{
                //    Value = x.Id.ToString(),
                //    Text = x.HotelName
                //}).ToList(),
                //Buildings = new List<SelectListItem>()
                //{
                //   new SelectListItem
                //   {
                //       Value = null,
                //       Text = " "
                //   }
                //},
                Buildings = _hotelsRepository.GetAvailableBuildingsByHotelId(TheUser).ToList(),
                HotelName = _hotelsRepository.GetHotelName(TheUser),
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
                    HotelId = Guid.Parse(TheUser),
                    FloorId = table.FloorId,
                    IsAvailable = true,
                    FarePerHour = table.FarePerHour ?? 0,
                    Description = table.Description
                };
                if (table.TableImage != null)
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
            if (id != Guid.Empty)
            {
                var table = _hotelsRepository.FindTableById(id);
                //var hotels = _hotelsRepository.AllHotels();
                var buildings = _hotelsRepository.GetBuildingsByHotelId(TheUser);
                var floors = _hotelsRepository.GetFloors(table.BuildingId);
                var model = new TableModel()
                {
                    Id = table.Id,
                    TableNo = table.TableNo,
                    ImageUrl = table.ImageUrl,
                    Description = table.Description,
                    FarePerHour = table.FarePerHour ?? 0,
                    MaxNoOfPersons = table.MaxNoOfPersons,
                    TableView = table.TableView,
                    IsDeleted = table.IsDeleted,
                    HotelId = Guid.Parse(TheUser),
                    IsAvailable = table.IsAvailable,
                    BuildingId = table.BuildingId,
                    FloorId = table.FloorId,
                    HotelName = _hotelsRepository.GetHotelName(TheUser),
                    //Hotels = hotels.Select(x => new SelectListItem()
                    //{
                    //    Value = x.Id.ToString(),
                    //    Text = x.HotelName
                    //}).ToList(),
                    Buildings = buildings.Select(x => new SelectListItem()
                    {
                        Value = x.Id.ToString(),
                        Text = x.Name
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
                    HotelId = Guid.Parse(TheUser),
                    TableNo = model.TableNo,
                    IsDeleted = model.IsDeleted,
                    MaxNoOfPersons = model.MaxNoOfPersons,
                    TableView = model.TableView
                };
                if (model.TableImage != null)
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
            if (id != Guid.Empty)
            {
                _hotelsRepository.DeleteTable(id);
            }
            return Json("");
        }

        #endregion


        private string ImageUpload(IFormFile Image)
        {
            string uniqueFileName = null;

            if (Image != null)
            {
                string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Image.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
