using FizzBook.Areas.Hotel.Models.Bookings;
using FizzBook.Areas.Hotel.Models.Hotels;
using FizzBook.Areas.Repository;
using FizzBook.HotelModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBook.Areas.Hotel.Controllers
{
    [Area("Hotel")]
    public class BookingController : BaseController
    {
        private readonly IBookingRepository _bookingRepostery;
        private readonly IHotelsRepository _hotelsRepository;
        private readonly ISetupRepository _setupRepository;
        private readonly FizzHotleBookingContext _context;

        public BookingController(ISetupRepository setupRepository,
            FizzHotleBookingContext context,
            IHotelsRepository hotelsRepository,
            IBookingRepository bookingRepositery)
        {
            _bookingRepostery = bookingRepositery;
            _hotelsRepository = hotelsRepository;
            _setupRepository = setupRepository;
            _context = context;
        }

        [HttpGet]
        public ActionResult SearchUserByCnic(string cnic)
        {
            if (!string.IsNullOrEmpty(cnic))
            {
                Users user = _setupRepository.FindUserByCNIC(cnic);
                //return Json(user);
                return new JsonResult(new { Name = user.Name, Email = user.Email, ContactNo = user.ContactNo });
            }
            return null;

        }

        #region Tables

        public IActionResult OrderedTables()
        {
            var orderedTabels = _bookingRepostery.GetOrderedTablesByHotelId(TheUser);
            var model = new List<TableBookingsModel>();
            if (orderedTabels.Any())
            {
                foreach (var item in orderedTabels)
                {
                    var user = _setupRepository.FindUserById(item.UserId);

                    var table = _context.Tables.Where(x => x.Id == item.TableId).FirstOrDefault();


                    if (table != null)
                    {
                        var order = new TableBookingsModel()
                        {
                            CheckInDate = item.CheckInDate,
                            CheckInTime = item.CheckInTime,

                            CheckOutDate = item.CheckOutDate,
                            CheckOutTime = item.CheckOutTime,
                            Name = user.Name,
                            ContactNo = user.ContactNo,
                            CreateDate = item.CreateDate,
                            Email = user.Email,
                            UserId = item.UserId,
                            NoOfPersons = item.NoOfPersons,
                            Id = item.Id,
                            IsDeleted = item.IsDeleted,
                            HotelName = _hotelsRepository.GetHotelName(TheUser),
                            BuildingName = _hotelsRepository.GetBuildingName(TheUser),
                            FloorNo = _hotelsRepository.GetFloorNo(TheUser),
                            TableNo = _bookingRepostery.GetTableNoByTableId(item.TableId.ToString()),


                            FarePerHour = item.FarePerHour ?? 0,
                            TableView = table.TableView ?? "NIL",
                            Description = table.Description ?? "NIL",
                            MaxNoOfPersons = table.MaxNoOfPersons ?? 0,
                            ImageUrl = table.ImageUrl,

                            TotalBill = item.TotalBill,
                            DiscountAmount = item.DiscountAmount


                            //HotelName = _hotelsRepository.GetHotelName(item.HotelId.ToString()),
                            // BuildingName = _hotelsRepository.GetBuildingName(item.HotelId.ToString()),
                            // FloorNo = _hotelsRepository.GetFloorNo(item.HotelId.ToString()),
                            // TableNo = _bookingRepostery.GetTableNoByTableId(item.TableId.ToString())
                        };
                        model.Add(order);
                    }
                }
            }
            return View(model);

        }

        public IActionResult AvailableTables()
        {
            //var availableTabels = _context.Tables.Where(c => c.IsBooked == null && c.IsBookedOnline == null && c.IsDeleted != true);
            var availableTabels = _context.Tables.Where(c =>
            c.HotelId == Guid.Parse(TheUser) &&
            c.IsBooked != true &&
            c.IsBookedOnline != true
            && c.IsDeleted != true);
            var model = new List<TableModel>();

            if (availableTabels.Any())
            {
                foreach (var item in availableTabels)
                {
                    var table = _hotelsRepository.FindTableById(item.Id);
                    var buildingName = _hotelsRepository.buildingNameById(item.BuildingId);
                    var hotelName = _hotelsRepository.HotelNameById(item.HotelId);
                    var floorNo = _hotelsRepository.FloorNoById(item.FloorId);
                    var room = new TableModel()
                    {
                        Id = item.Id,
                        BuildingId = item.BuildingId,
                        Description = item.Description,
                        FarePerHour = item.FarePerHour,
                        FloorId = item.FloorId,
                        HotelId = item.HotelId,

                        //HotelId = _hotelsRepository.GetHotelName(TheUser),
                        IsDeleted = item.IsDeleted,
                        MaxNoOfPersons = item.MaxNoOfPersons,
                        ImageUrl = item.ImageUrl,
                        TableNo = item.TableNo,
                        HotelName = hotelName,
                        BuildingName = buildingName,
                        FloorNo = floorNo,
                        TableView = item.TableView
                    };
                    model.Add(room);
                }
                return View(model);
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult BookTable(Guid id)
        {
            if (id != Guid.Empty)
            {
                var table = _hotelsRepository.FindTableById(id);
                //var countries = _hotelsRepository.allCountries();
                //var cities = _setupRepository.GetCities();
                //var hotels = _hotelsRepository.AllHotels();
                //var buildings = _hotelsRepository.Buildings();
                var hotel = _hotelsRepository.FindHotelById(table.HotelId);
                //var floors = _hotelsRepository.Floors();

                var tableservices = _context.TableServiceBooking.Where(p => p.IsDeleted == null).ToList();


                var model = new TableBookingsModel
                {
                    TableId = table.Id,
                    BuildingId = table.BuildingId,
                    HotelId = table.HotelId,
                    CityId = hotel.HotelCityId,
                    CountryId = hotel.HotelCountryId,
                    FarePerHour = table.FarePerHour,
                    FloorId = table.FloorId,
                    NoOfPersons = table.MaxNoOfPersons,
                    Services = tableservices.Select(x => new SelectListItem()
                    {
                        Value = x.Id.ToString(),
                        Text = $"{x.Name} : {Decimal.Round(x.Price)} Rs"
                    }).ToList(),
                    TableNo = table.TableNo
                };
                return PartialView(model);
            }
            else
            {
                return Json("");
            }
        }

        [HttpPost]
        public IActionResult BookTable(TableBookingsModel model)
        {
            if (ModelState.IsValid)
            {
                var userid = model.UserId;
                var user = _setupRepository.FindUserByCNIC(model.CNIC);
                if (user != null)
                {
                    userid = user.Id;
                }
                else
                {
                    var Newuser = new Users()
                    {
                        Id = Guid.NewGuid(),
                        Name = model.Name,
                        Cnic = model.CNIC,
                        ContactNo = model.ContactNo,
                        IsDeleted = model.IsDeleted,
                        Email = model.Email
                    };
                    _setupRepository.AddUser(Newuser);
                    var createdUser = _setupRepository.FindUserByCNIC(model.CNIC);
                    userid = createdUser.Id;
                }
                if (userid != Guid.Empty)
                {
                    var order = new TableBookings()
                    {
                        DiscountAmount = model.DiscountAmount,
                        CheckInDate = model.CheckInDate,
                        CheckInTime = model.CheckInTime,
                        CheckOutDate = model.CheckOutDate,
                        UserId = userid,
                        FarePerHour = model.FarePerHour,
                        TotalFare = model.TotalFare,
                        NoOfPersons = model.NoOfPersons,
                        BuildingId = model.BuildingId,
                        FloorId = model.FloorId,
                        CountryId = model.CountryId,
                        CheckOutTime = model.CheckOutTime,
                        HotelId = Guid.Parse(TheUser),
                        CreateDate = DateTime.UtcNow.AddHours(5),
                        IsBooked = true,
                        IsBookedOnline = false,
                        IsPaid = model.IsPaid,
                        TableId = model.TableId,
                        IsRemaining = model.IsRemaining,
                        CityId = model.CityId
                    };

                    if (model.ServiceIds != null)
                    {
                        if (model.ServiceIds.Count > 0)
                        {
                            foreach (var item in model.ServiceIds)
                            {
                                var tableServices = new TableJoinService()
                                {
                                    // Id = Guid.NewGuid(),
                                    TableId = model.TableId,
                                    TableServiceBookingId = item
                                };
                                _context.TableJoinService.Add(tableServices);
                                _context.SaveChanges();
                            }
                        }
                    }

                    _bookingRepostery.BookTable(order);
                    var table = _context.Tables.FirstOrDefault(c => c.Id == model.TableId);
                    table.IsBooked = true;
                    _context.Update(table);
                    _context.SaveChanges();

                }
            }
            return Json("");
        }

        [HttpGet]
        public IActionResult EditTableOrder(Guid id)
        {
            var order = _context.TableBookings.FirstOrDefault(c => c.Id == id);
            //var tableId = order.TableId;
            //var buildingId = order.BuildingId;
            //var roomTypes = _setupRepository.GetRoomTypes();
            //var hotelId = order.HotelId;
            var user = _setupRepository.FindUserById(order.UserId);

            var tableservices = _context.TableServiceBooking.Where(p => p.IsDeleted == null).ToList();
            var tableServicesBooked = _context.TableJoinService.Where(p => p.TableId == order.TableId).ToList();

            var tableOrder = new TableBookingsModel()
            {
                Id = order.Id,
                Name = user.Name,
                Email = user.Email,
                ContactNo = user.ContactNo,
                CNIC = user.Cnic,
                BuildingId = order.BuildingId,
                CheckInDate = order.CheckInDate,
                CheckInTime = order.CheckInTime,
                CheckOutDate = order.CheckOutDate,
                CheckOutTime = order.CheckOutTime,
                CityId = order.CityId,
                CountryId = order.CountryId,
                DiscountAmount = order.DiscountAmount,
                TotalFare = order.TotalFare,
                FarePerHour = order.FarePerHour,
                FloorId = order.FloorId,
                CreateDate = order.CreateDate,
                TableId = order.TableId,
                NoOfPersons = order.NoOfPersons,
                IsBooked = order.IsBooked,
                IsBookedOnline = order.IsBookedOnline,
                HotelId = order.HotelId,
                IsPaid = order.IsPaid,
                IsRemaining = order.IsRemaining,
                UserId = order.UserId,

                TotalBill = order.TotalBill,
                RemainingAmount = order.RemainingAmount,
                PaidAmount = order.PaidAmount,
                TotalHours = order.TotalHours,
                Services = tableservices.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = $"{x.Name} : {Decimal.Round(x.Price)} Rs"
                }).ToList(),
            };

            tableOrder.ServiceIds = new List<int>();
            foreach (var service in tableServicesBooked)
            {
                var serviceId = service.TableServiceBookingId;
                tableOrder.ServiceIds.Add(serviceId);
            };
            tableOrder.ServiceIdsString = string.Join(",", tableOrder.ServiceIds);

            return PartialView(tableOrder);
        }
        [HttpPost]
        public IActionResult EditTableOrder(TableBookingsModel model)
        {
            var userid = model.UserId;
            var user = _setupRepository.FindUserByCNIC(model.CNIC);
            if (user != null)
            {
                userid = user.Id;
            }
            else
            {
                var Newuser = new Users()
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    Cnic = model.CNIC,
                    ContactNo = model.ContactNo,
                    IsDeleted = model.IsDeleted,
                    Email = model.Email
                };
                _setupRepository.AddUser(Newuser);
                var createdUser = _setupRepository.FindUserByCNIC(model.CNIC);
                userid = createdUser.Id;
            }
            if (userid != null)
            {
                //var order = new TableBookings()
                //{
                //    DiscountAmount = model.DiscountAmount,

                //    CheckInDate = model.CheckInDate,
                //    CheckInTime = model.CheckInTime,

                //    CheckOutTime = model.CheckOutTime,
                //    CheckOutDate = model.CheckOutDate,

                //    UserId = userid,
                //    FarePerHour = model.FarePerHour,
                //    TotalFare = model.TotalFare,
                //    NoOfPersons = model.NoOfPersons,
                //    BuildingId = model.BuildingId,
                //    FloorId = model.FloorId,
                //    CountryId = model.CountryId,
                //    HotelId = model.HotelId,
                //    CreateDate = model.CreateDate,
                //    IsBooked = true,
                //    IsBookedOnline = false,
                //    IsPaid = model.IsPaid,
                //    TableId = model.TableId,
                //    IsRemaining = model.IsRemaining,
                //    CityId = model.CityId,
                //    Id = model.Id,

                //    PaidAmount = model.PaidAmount,
                //    RemainingAmount = model.RemainingAmount,
                //    TotalHours = model.TotalHours,
                //    TotalBill = model.TotalBill,
                //    IsDeleted = model.IsDeleted,
                //    Status = model.Status
                //};

                var order = new TableBookings()
                {
                    DiscountAmount = model.DiscountAmount,
                    CheckInDate = model.CheckInDate,
                    CheckInTime = model.CheckInTime,
                    CheckOutDate = model.CheckOutDate,
                    UserId = userid,
                    FarePerHour = model.FarePerHour,
                    TotalFare = model.TotalFare,
                    NoOfPersons = model.NoOfPersons,
                    BuildingId = model.BuildingId,
                    FloorId = model.FloorId,
                    CountryId = model.CountryId,
                    CheckOutTime = model.CheckOutTime,
                    HotelId = model.HotelId,
                    CreateDate = model.CreateDate,
                    IsBooked = true,
                    IsBookedOnline = false,
                    IsPaid = model.IsPaid,
                    TableId = model.TableId,
                    IsRemaining = model.IsRemaining,
                    CityId = model.CityId,
                    Id = model.Id,

                    TotalBill = model.TotalBill,
                    PaidAmount = model.PaidAmount,
                    RemainingAmount = model.RemainingAmount,
                    TotalHours = model.TotalHours
                };

                _context.TableBookings.Update(order);
                _context.SaveChanges();

                _hotelsRepository.MarkTableBooked(model.TableId);

                _bookingRepostery.DeleteTableJoinServices(model.TableId);

                if (model.ServiceIds != null)
                {
                    if (model.ServiceIds.Count > 0)
                    {
                        foreach (var item in model.ServiceIds)
                        {
                            var tableServices = new TableJoinService()
                            {
                                // Id = Guid.NewGuid(),
                                TableId = model.TableId,
                                TableServiceBookingId = item
                            };
                            _context.TableJoinService.Add(tableServices);
                            _context.SaveChanges();
                        }
                    }
                }
            }
            return Json("");
        }

        public IActionResult DeleteOrder(Guid id)
        {
            var temp = _context.TableBookings.Where(p => p.Id == id).FirstOrDefault();
            if (temp != null)
            {
                temp.IsDeleted = true;
                temp.IsBooked = false;
                temp.IsBookedOnline = false;
                _context.TableBookings.Update(temp);

                Tables table = _context.Tables.FirstOrDefault(x => x.Id == temp.TableId);
                table.IsBooked = false;
                table.IsBookedOnline = false;
                table.IsAvailable = true;
                _context.Tables.Update(table);

                _context.SaveChanges();
            }
            return Json("");
        }

        [HttpGet]
        public IActionResult CheckOutTable(Guid id)
        {
            var order = _bookingRepostery.GetTableBookingById(id);
            var user = _setupRepository.FindUserById(order.UserId);

            var table = _context.Tables.FirstOrDefault(x => x.Id == order.TableId);

            var tableOrder = new CheckOutTableModel();

            var tableServices = _context.TableServiceBooking.Where(p => p.IsDeleted == null).ToList();
            var tableServicesBooked = _context.TableJoinService.Where(p => p.TableId == order.TableId).ToList();
            // var hallOrder = new CheckOutModel();

            try
            {
                tableOrder.Id = order.Id;
                tableOrder.FarePerHour = order.FarePerHour;

                //tableOrder.HallName = order.Name;

                tableOrder.CheckInDate = order.CheckInDate.Value;
                tableOrder.CheckInTime = order.CheckInTime.Value;
                tableOrder.CheckOutDate = order.CheckOutDate;
                tableOrder.CheckOutTime = order.CheckOutTime;

                tableOrder.DiscountAmount = order.DiscountAmount;
                tableOrder.TotalBill = order.TotalBill.HasValue ? order.TotalBill : 0;
                tableOrder.IsPaid = order.IsPaid.HasValue ? Convert.ToBoolean(order.IsPaid.Value) : false;
                tableOrder.RemainingAmount = order.RemainingAmount.HasValue ? order.RemainingAmount : 0;

                tableOrder.CreateDate = order.CreateDate.Value;
                tableOrder.IsDeleted = order.IsDeleted;
                tableOrder.IsBookedOnline = order.IsBookedOnline;
                //tableOrder.IsLeave = order.IsLeave;
                tableOrder.Status = order.Status;
                tableOrder.PaidAmount = order.PaidAmount.HasValue ? order.PaidAmount.Value : 0;
                tableOrder.IsBooked = order.IsBooked.Value;

                tableOrder.TotalHours = order.TotalHours;
                tableOrder.TotalFare = order.TotalFare;
                tableOrder.BuildingId = order.BuildingId.Value;
                tableOrder.CityId = order.CityId.HasValue ? order.CityId.Value : Guid.Empty;
                tableOrder.CountryId = order.CountryId.HasValue ? order.CountryId.Value : Guid.Empty;

                tableOrder.UserId = order.UserId;
                tableOrder.FloorId = order.FloorId.Value;
                //tableOrder.HallId = order.HallId;
                tableOrder.HotelId = order.HotelId.Value;

                tableOrder.TableId = order.TableId;
                tableOrder.TableNo = table.TableNo;

                tableOrder.Services = tableServices.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = $"{x.Name} : {Decimal.Round(x.Price)} Rs"
                }).ToList();


                tableOrder.ServiceIds = new List<int>();
                foreach (var service in tableServicesBooked)
                {
                    var serviceId = service.TableServiceBookingId;
                    tableOrder.ServiceIds.Add(serviceId);
                };
                tableOrder.ServiceIdsString = string.Join(",", tableOrder.ServiceIds);

                //Add HallService price to Total Bill

                var tableservices = _context.TableServiceBooking.Where(x => tableOrder.ServiceIds.Contains(x.Id)).ToList();

                if (tableservices != null)
                {
                    foreach (var item in tableservices)
                    {
                        // hallOrder.HallServicePrice = item.Price;
                        tableOrder.TableServicePrice += item.Price;
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return PartialView(tableOrder);
        }

        [HttpPost]
        public IActionResult CheckOutTable(CheckOutTableModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.UserId != null)
                {
                    var order = new TableBookings()
                    {

                        CheckInDate = model.CheckInDate,
                        CheckInTime = model.CheckInTime,
                        UserId = model.UserId,
                        CheckOutDate = model.CheckOutDate,
                        CheckOutTime = model.CheckOutTime,
                        //CreateDate = model.CreateDate,
                        IsBooked = true,

                        FarePerHour = model.FarePerHour,
                        IsPaid = Convert.ToDecimal(model.IsPaid),
                        RemainingAmount = model.RemainingAmount,
                        TotalBill = model.TotalBill,
                        DiscountAmount = model.DiscountAmount,
                        //IsLeave = model.IsLeave,
                        Id = model.Id,
                        PaidAmount = model.PaidAmount,
                        //HallId = model.HallId,
                        TotalHours = model.TotalHours,
                        TotalFare = model.TotalFare,

                        HotelId = model.HotelId,
                        BuildingId = model.BuildingId,
                        FloorId = model.FloorId,
                        TableId = model.TableId,
                        CityId = model.CityId,
                        CountryId = model.CountryId,
                        Status = model.Status,
                        NoOfPersons = model.NoOfPersons,
                        IsRemaining = model.IsRemaining,
                        IsDeleted = model.IsDeleted,
                        IsBookedOnline = model.IsBookedOnline,



                        CreateDate = model.CreateDate.HasValue ? model.CreateDate.Value : DateTime.Now
                    };
                    _context.TableBookings.Update(order);
                    _context.SaveChanges();
                    //_bookingRepostery.CheckOutHallOrder(order);
                    _hotelsRepository.MarkTableBooked(order.TableId);
                }
            }
            return Json("");
        }

        #endregion

        #region Rooms


        public IActionResult OrderedRooms()
        {
            var orderedRooms = _bookingRepostery.GetOrderedRoomsByHotelId(TheUser);
            var model = new List<RoomBookingsModel>();
            foreach (var order in orderedRooms)
            {
                var user = _setupRepository.FindUserById(order.UserId);
                var item = new RoomBookingsModel()
                {
                    Id = order.Id,
                    Adults = order.Adults,
                    HotelId = order.HotelId,
                    BuildingId = order.BuildingId,
                    FloorId = order.FloorId,
                    CheckInDate = order.CheckInDate,
                    CheckInTime = order.CheckInTime,
                    CheckOutDate = order.CheckOutDate,
                    Name = user.Name,
                    Email = user.Email,
                    ContactNo = user.ContactNo,
                    CheckOutTime = order.CheckOutTime,
                    Childrens = order.Childrens,
                    TotalBill = order.TotalBill,
                    DiscountAmount = order.DiscountAmount,

                    HotelName = _hotelsRepository.GetHotelName(TheUser),
                    BuildingName = _hotelsRepository.GetBuildingName(TheUser),
                    FloorNo = _hotelsRepository.GetFloorNo(TheUser),
                    RoomNo = _hotelsRepository.GetRoomNoByRoomId(order.RoomId.ToString()),

                    FarePerNight = order.FarePerNight.HasValue ? order.FarePerNight : 0,
                    NightsCount = order.NightsCount.HasValue ? order.NightsCount.Value : 0,
                    RoomImageUrl = _context.Rooms.Where(x => x.Id == order.RoomId).Select(x => x.ImageUrl).FirstOrDefault(),
                };
                model.Add(item);
            }
            return View(model);
        }

        public IActionResult AvailableRooms()
        {
            var availableRooms = _hotelsRepository.GetAvailableRoomsByHotelId(TheUser);
            var model = new List<RoomsModel>();
            if (availableRooms.Any())
            {

                foreach (var item in availableRooms)
                {
                    var roomTpe = _setupRepository.FindRoomTypeById(item.TypeId);
                    var typeName = roomTpe.Name;
                    var buildingName = _hotelsRepository.buildingNameById(item.BuildingId);
                    var hotelName = _hotelsRepository.HotelNameById(item.HotelId);
                    var floorNo = _hotelsRepository.FloorNoById(item.FloorId);
                    var officers = _context.Officers.Where(r => r.IsDeleted == null).Include(r => r.Role).ToList();
                    var roomServices = _context.RoomServices.Where(c => c.RoomId == item.Id).Include(r => r.Service).ToList();
                    var room = new RoomsModel()
                    {
                        Id = item.Id,
                        BuildingId = item.BuildingId,
                        Description = item.Description,
                        FarePerNight = item.FarePerNight,
                        FloorId = item.FloorId,
                        HotelId = item.HotelId,
                        IsDeleted = item.IsDeleted,
                        MaxNoOfPersons = item.MaxNoOfPersons,
                        ImageUrl = item.ImageUrl,
                        RoomNo = item.RoomNo,
                        HotelName = hotelName,
                        BuildingName = buildingName,
                        TypeName = typeName,
                        FloorNo = floorNo,
                        NoOfBeds = item.NoOfBeds,
                        TypeId = item.TypeId,
                        RoomView = item.RoomView,
                        Services = roomServices.Select(x => new SelectListItem
                        {
                            Value = x.Id.ToString(),
                            Text = x.Service.ServiceName
                        }).ToList()
                    };
                    model.Add(room);
                }
                return View(model);
            }
            else
            {
                //return Json("Sorry No Room available at this time. Try Again!");
                return View(model);

            }
        }

        [HttpGet]
        public IActionResult BookRoom(Guid id)
        {
            if (id != null)
            {
                var room = _hotelsRepository.FindRoomById(id);
                var countries = _hotelsRepository.allCountries();
                var cities = _setupRepository.GetCities();
                var hotels = _hotelsRepository.AllHotels();
                var buildings = _hotelsRepository.Buildings();
                var hotel = _hotelsRepository.FindHotelById(room.HotelId);
                var roomTypes = _setupRepository.GetRoomTypes();
                var floors = _hotelsRepository.Floors();

                var roomservices = _context.RoomServiceBooking.Where(p => p.IsDeleted == null).ToList();


                var model = new RoomBookingsModel
                {
                    Cities = cities.Select(x => new SelectListItem()
                    {
                        Value = x.Id.ToString(),
                        Text = x.CityName
                    }).ToList(),
                    // Hotels = new List<SelectListItem>()
                    //{
                    //    new SelectListItem
                    //    {
                    //         Value = null,
                    //         Text = " "
                    //     }
                    // },
                    Rooms = new List<SelectListItem>()
                    {
                    new SelectListItem
                    {
                           Value = null,
                            Text = " "
                     }
                    },
                    RoomTypes = new List<SelectListItem>()
                    {
                         new SelectListItem
                        {
                           Value = null,
                            Text = " "
                         }
                    },
                    Services = roomservices.Select(x => new SelectListItem()
                    {
                        Value = x.Id.ToString(),
                        Text = $"{x.Name} : {Decimal.Round(x.Price)} Rs"
                    }).ToList(),
                    BuildingId = room.BuildingId,
                    TypeId = room.TypeId,
                    HotelId = room.HotelId,
                    CityId = hotel.HotelCityId,
                    CountryId = hotel.HotelCountryId,
                    FarePerNight = room.FarePerNight,
                    FloorId = room.FloorId,
                    DiscountAmount = room.DiscountAmount,
                    RoomId = room.Id,
                    RoomNo = room.RoomNo
                };
                return PartialView(model);
            }
            else
            {
                return Json("");
            }
        }
        [HttpPost]
        public IActionResult BookRoom(RoomBookingsModel model)
        {
            if (ModelState.IsValid)
            {
                var userid = model.UserId;
                var user = _setupRepository.FindUserByCNIC(model.CNIC);
                if (user != null)
                {
                    userid = user.Id;
                }
                else
                {
                    var Newuser = new Users()
                    {
                        Id = Guid.NewGuid(),
                        Name = model.Name,
                        Cnic = model.CNIC,
                        ContactNo = model.ContactNo,
                        IsDeleted = model.IsDeleted,
                        Email = model.Email
                    };
                    _setupRepository.AddUser(Newuser);
                    var createdUser = _setupRepository.FindUserByCNIC(model.CNIC);
                    userid = createdUser.Id;
                }
                if (userid != null)
                {
                    var order = new RoomBookings()
                    {
                        DiscountAmount = model.DiscountAmount,
                        CheckInDate = model.CheckInDate,
                        CheckInTime = model.CheckInTime,
                        RoomId = model.RoomId,
                        CheckOutDate = model.CheckOutDate,
                        TotalBill = (model.FarePerNight - model.DiscountAmount),
                        UserId = userid,
                        BuildingId = model.BuildingId,
                        FloorId = model.FloorId,
                        CountryId = model.CountryId,
                        FarePerNight = model.FarePerNight,
                        CheckOutTime = model.CheckOutTime,
                        HotelId = Guid.Parse(TheUser),
                        CreateDate = DateTime.UtcNow.AddHours(5),
                        IsBooked = true,
                        IsPaid = model.IsPaid,
                        TypeId = model.TypeId,
                        CityId = model.CityId,
                        Adults = model.Adults,
                        Childrens = model.Childrens,
                        NightsCount = model.TotalNights
                    };

                    if (model.ServiceIds != null)
                    {
                        if (model.ServiceIds.Count > 0)
                        {
                            foreach (var item in model.ServiceIds)
                            {
                                var roomServices = new RoomJoinService()
                                {
                                    // Id = Guid.NewGuid(),
                                    RoomId = model.RoomId,
                                    RoomServiceBookingId = item
                                };
                                _context.RoomJoinService.Add(roomServices);
                                _context.SaveChanges();
                            }
                        }
                    }

                    _bookingRepostery.BookRoom(order);
                    _hotelsRepository.MarkRoomBooked(model.RoomId);
                }
            }
            return Json("");
        }

        [HttpGet]
        public IActionResult EditRoomOrder(Guid id)
        {
            var order = _bookingRepostery.GetRoomBookingById(id);
            var roomId = order.RoomId;
            var buildingId = order.BuildingId;
            var roomType = _setupRepository.FindRoomTypeById(order.TypeId);
            var roomTypeName = roomType.Name;
            //var roomTypes = _setupRepository.GetRoomTypes();
            //var hotelId = order.HotelId;
            var building = _hotelsRepository.FindBuildingById(buildingId);
            var room = _hotelsRepository.FindRoomById(roomId);
            var user = _setupRepository.FindUserById(order.UserId);

            var roomservices = _context.RoomServiceBooking.Where(p => p.IsDeleted == null).ToList();
            var roomServicesBooked = _context.RoomJoinService.Where(p => p.RoomId == room.Id).ToList();

            RoomBookingsModel roomOrder = new RoomBookingsModel();
            roomOrder = new RoomBookingsModel()
            {
                Id = order.Id,
                Adults = order.Adults,
                Name = user.Name,
                Email = user.Email,
                ContactNo = user.ContactNo,
                CNIC = user.Cnic,
                BuildingName = building.Name,
                RoomTypeName = roomTypeName,
                RoomNo = room.RoomNo,
                BuildingId = order.BuildingId,
                CheckInDate = order.CheckInDate,
                CheckInTime = order.CheckInTime,
                CheckOutDate = order.CheckOutDate,//
                CheckOutTime = order.CheckOutTime,//
                CityId = order.CityId,
                CountryId = order.CountryId,
                DiscountAmount = order.DiscountAmount.HasValue ? order.DiscountAmount.Value : 0,//
                //TotalBill = order.TotalBill.HasValue ? order.TotalBill.Value : 0,//
                RoomId = order.RoomId,
                TypeId = order.TypeId,
                FloorId = order.FloorId,
                HotelId = Guid.Parse(TheUser),
                //IsPaid = order.IsPaid.Value,//
                //IsRemaining = order.IsRemaining,
                // IsRemaining = order.IsRemaining,
                NightsCount = order.NightsCount ?? 0,
                TotalFare = order.TotalFare ?? 0,
                PaidAmount = order.PaidAmount,
                RemainingAmount = order.RemainingAmount,
                FarePerNight = order.FarePerNight,
                TotalBill = order.TotalBill ?? 0,
                UserId = order.UserId,

                Services = roomservices.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = $"{x.Name} : {Decimal.Round(x.Price)} Rs"
                }).ToList(),
            };

            roomOrder.ServiceIds = new List<int>();
            foreach (var service in roomServicesBooked)
            {
                var serviceId = service.RoomServiceBookingId;
                roomOrder.ServiceIds.Add(serviceId);
            };
            roomOrder.ServiceIdsString = string.Join(",", roomOrder.ServiceIds);

            return PartialView(roomOrder);
        }
        [HttpPost]
        public IActionResult EditRoomOrder(RoomBookingsModel model)
        {
            if (ModelState.IsValid)
            {
                var userid = model.UserId;
                var user = _setupRepository.FindUserByCNIC(model.CNIC);
                if (user != null)
                {
                    userid = user.Id;
                }
                else
                {
                    var Newuser = new Users()
                    {
                        Id = Guid.NewGuid(),
                        Name = model.Name,
                        Cnic = model.CNIC,
                        ContactNo = model.ContactNo,
                        IsDeleted = model.IsDeleted,
                        Email = model.Email
                    };
                    _setupRepository.AddUser(Newuser);
                    var createdUser = _setupRepository.FindUserByCNIC(model.CNIC);
                    userid = createdUser.Id;
                }
                if (userid != null)
                {
                    var order = new RoomBookings()
                    {
                        TotalBill = model.TotalBill,
                        DiscountAmount = model.DiscountAmount,
                        CheckInDate = model.CheckInDate,
                        CheckInTime = model.CheckInTime,
                        RoomId = model.RoomId,
                        UserId = userid,
                        BuildingId = model.BuildingId,
                        FloorId = model.FloorId,
                        CountryId = model.CountryId,
                        CheckOutTime = model.CheckOutTime,
                        CheckOutDate = model.CheckOutDate,

                        HotelId = Guid.Parse(TheUser),
                        CreateDate = model.CreateDate,
                        IsBooked = true,
                        IsPaid = model.IsPaid,
                        //IsRemaining = model.IsRemaining,
                        TypeId = model.TypeId,
                        CityId = model.CityId,
                        Adults = model.Adults,
                        Childrens = model.Childrens,
                        Id = model.Id,
                        FarePerNight = model.FarePerNight,

                        TotalFare = model.TotalFare,
                        NightsCount = model.NightsCount,
                        PaidAmount = model.PaidAmount,
                        RemainingAmount = model.RemainingAmount,

                    };
                    _bookingRepostery.EditRoomOrder(order);
                    _hotelsRepository.MarkRoomBooked(model.RoomId);

                    _bookingRepostery.DeleteRoomJoinServices(model.RoomId);

                    if (model.ServiceIds != null)
                    {
                        if (model.ServiceIds.Count > 0)
                        {
                            foreach (var item in model.ServiceIds)
                            {
                                var roomServices = new RoomJoinService()
                                {
                                    // Id = Guid.NewGuid(),
                                    RoomId = model.RoomId,
                                    RoomServiceBookingId = item
                                };
                                _context.RoomJoinService.Add(roomServices);
                                _context.SaveChanges();
                            }
                        }
                    }
                }
            }

            return Json("");
        }


        //Work on
        [HttpGet]
        public IActionResult CheckOutRoom(Guid id)
        {
            var order = _bookingRepostery.GetRoomBookingById(id);
            var roomId = order.RoomId;
            var buildingId = order.BuildingId;
            var roomType = _setupRepository.FindRoomTypeById(order.TypeId);
            var roomTypeName = roomType.Name;
            //var roomTypes = _setupRepository.GetRoomTypes();
            //var hotelId = order.HotelId;
            var building = _hotelsRepository.FindBuildingById(buildingId);
            var room = _hotelsRepository.FindRoomById(roomId);
            var user = _setupRepository.FindUserById(order.UserId);


            var roomServices = _context.RoomServiceBooking.Where(p => p.IsDeleted == null).ToList();
            var roomServicesBooked = _context.RoomJoinService.Where(p => p.RoomId == order.RoomId).ToList();


            var roomOrder = new CheckOutModel();

            roomOrder = new CheckOutModel()
            {
                Id = order.Id,
                Adults = order.Adults,
                //Name = user.Name,
                //Email = user.Email,
                //ContactNo = user.ContactNo,
                //CNIC = user.Cnic,
                BuildingName = building.Name,
                RoomTypeName = roomTypeName,
                RoomNo = room.RoomNo,
                BuildingId = order.BuildingId,
                CheckInDate = order.CheckInDate,
                CheckInTime = order.CheckInTime,
                CheckOutDate = order.CheckOutDate,
                FarePerNight = order.FarePerNight,
                CheckOutTime = order.CheckOutTime,
                CityId = order.CityId,
                CountryId = order.CountryId,
                DiscountAmount = order.DiscountAmount,
                TotalBill = order.TotalBill.HasValue ? order.TotalBill : 0,
                RoomId = order.RoomId,
                TypeId = order.TypeId,
                FloorId = order.FloorId,
                HotelId = order.HotelId,
                IsPaid = order.IsPaid.HasValue ? order.IsPaid.Value : false,
                RemainingAmount = order.RemainingAmount.HasValue ? order.RemainingAmount : 0,
                UserId = order.UserId,
                TotalNights = order.NightsCount.HasValue ? order.NightsCount : 0,
                TotalFare = order.TotalFare.HasValue ? order.TotalFare : 0,
                CreateDate = order.CreateDate,
                IsDeleted = order.IsDeleted,
                PaidAmount = order.PaidAmount.HasValue ? order.PaidAmount.Value : 0,

            };

            roomOrder.Services = roomServices.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = $"{x.Name} : {Decimal.Round(x.Price)} Rs"
            }).ToList();


            roomOrder.ServiceIds = new List<int>();
            foreach (var service in roomServicesBooked)
            {
                var serviceId = service.RoomServiceBookingId;
                roomOrder.ServiceIds.Add(serviceId);
            };
            roomOrder.ServiceIdsString = string.Join(",", roomOrder.ServiceIds);

            //Add RoomService price to Total Bill

            var roomservices = _context.RoomServiceBooking.Where(x => roomOrder.ServiceIds.Contains(x.Id)).ToList();

            if (roomservices != null)
            {
                foreach (var item in roomservices)
                {
                    roomOrder.RoomServicePrice += item.Price;
                }
            }
            return PartialView(roomOrder);
        }

        [HttpPost]
        public IActionResult CheckOutRoom(CheckOutModel model)
        {
            if (ModelState.IsValid)
            {
                // var userid = model.UserId;
                //var user = _setupRepository.FindUserByCNIC(model.CNIC);
                //if (user != null)
                //{
                //    userid = user.Id;
                //}
                if (model.UserId != null)
                {
                    var order = new RoomBookings()
                    {

                        CheckInDate = model.CheckInDate,
                        CheckInTime = model.CheckInTime,
                        RoomId = model.RoomId,
                        CheckOutDate = model.CheckOutDate,
                        UserId = model.UserId,
                        BuildingId = model.BuildingId,
                        FloorId = model.FloorId,
                        CountryId = model.CountryId,
                        CheckOutTime = model.CheckOutTime,
                        HotelId = model.HotelId,
                        CreateDate = model.CreateDate,
                        IsBooked = true,



                        TypeId = model.TypeId,
                        CityId = model.CityId,
                        Adults = model.Adults,
                        Childrens = model.Childrens,


                        FarePerNight = model.FarePerNight,
                        NightsCount = model.TotalNights,
                        TotalFare = model.TotalFare,
                        IsPaid = model.IsPaid,
                        RemainingAmount = model.RemainingAmount,
                        TotalBill = model.TotalBill,
                        DiscountAmount = model.DiscountAmount,

                        // DiscountAmount  = model.DiscountAmount,
                        IsLeave = model.IsLeave,
                        Id = model.Id,
                        PaidAmount = model.PaidAmount,

                        IsBookedOnline = model.IsBookedOnline,
                        IsDeleted = model.IsDeleted
                    };

                    //if (model.IsPaid == model.DiscountAmount)
                    //{
                    //    model.IsRemaining = 0;
                    //}
                    //else
                    //{
                    //    model.IsRemaining = 1;
                    //}

                    // model.IsRemaining = model.IsPaid == model.DiscountAmount ? 0 : 1;

                    _bookingRepostery.EditRoomOrder(order);

                    //  _bookingRepostery.BookRoom(order);

                    _hotelsRepository.MarkRoomBooked(model.RoomId);
                }
            }

            return Json("");
        }


        public IActionResult LeaveRoom(Guid id)
        {
            var temp = _context.RoomBookings.Where(p => p.Id == id).FirstOrDefault();

            Rooms room = _context.Rooms.Where(x => x.Id == temp.RoomId).FirstOrDefault();
            if (temp != null)
            {
                //RoomBookings
                temp.IsBooked = false;
                temp.IsLeave = true;
                _context.RoomBookings.Update(temp);

                //Room
                room.IsBooked = false;
                room.IsAvailable = true;
                _context.Rooms.Update(room);

                _context.SaveChanges();
            }
            return Json("");
        }

        public IActionResult DeleteRoom(Guid id)
        {
            var temp = _context.RoomBookings.Where(p => p.Id == id).FirstOrDefault();

            Rooms room = _context.Rooms.Where(x => x.Id == temp.RoomId).FirstOrDefault();
            if (temp != null)
            {
                //RoomBookings
                temp.IsDeleted = true;
                temp.IsBooked = false;
                temp.IsBookedOnline = false;

                _context.RoomBookings.Update(temp);

                //Room
                room.IsBooked = false;
                room.IsBookedOnline = false;
                room.IsAvailable = true;

                _context.Rooms.Update(room);

                _context.SaveChanges();
            }
            return Json("");
        }

        #endregion


        #region Hotels

        //public IActionResult BookedHotels()
        //{
        //    var orderedHotels = _bookingRepostery.GetOrderedHotelsByHotelId(TheUser);
        //    return View(orderedHotels);
        //}

        #endregion


        #region Halls

        public IActionResult BookedHalls()
        {
            var orderedHalls = _bookingRepostery.GetOrderedHallsByHotelId(TheUser);

            var model = new List<HallBookingModel>();
            foreach (var order in orderedHalls)
            {
                var user = _setupRepository.FindUserById(order.UserId);
                var item = new HallBookingModel()
                {
                    Id = order.Id,
                    //Adults = order.Adults,
                    //HotelId = order.HotelId,
                    //BuildingId = order.BuildingId,
                    //FloorId = order.FloorId,
                    HallName = _hotelsRepository.GetHallName(order.HallId.ToString()),

                    CheckInDate = order.CheckInDate,
                    CheckInTime = order.CheckInTime,
                    CheckOutDate = order.CheckOutDate.HasValue ? order.CheckOutDate : null,
                    CheckOutTime = order.CheckOutTime.HasValue ? order.CheckOutTime : null,
                    CreateDate = order.CreateDate.HasValue ? order.CreateDate : null,

                    Name = order.Name,
                    Email = order.Email,
                    ContactNo = order.ContactNo,

                    Fare = order.Fare.HasValue ? order.Fare.Value : 0,
                    CNIC = user.Cnic,

                    DaysCount = order.DaysCount,

                    //Childrens = order.Childrens,
                    TotalBill = order.TotalBill,
                    DiscountAmount = order.DiscountAmount,
                    HotelName = _hotelsRepository.GetHotelName(TheUser),
                    BuildingName = _hotelsRepository.buildingNameById(order.BuildingId.Value),
                    FloorNo = _hotelsRepository.FloorNoById(order.FloorId.Value)
                };
                model.Add(item);
            }
            return View(model);
        }

        public IActionResult AvailableHalls()
        {
            //var availableTabels = _context.Tables.Where(c => c.IsBooked == null && c.IsBookedOnline == null && c.IsDeleted != true);
            var availableHalls = _context.Hall.Where(c =>
            c.HotelId == Guid.Parse(TheUser) &&
            c.IsBooked != true &&
            c.IsBookedOnline != true
            && c.IsDeleted != true);
            var model = new List<HallModel>();

            if (availableHalls.Any())
            {
                foreach (var item in availableHalls)
                {
                    //var table = _hotelsRepository.FindTableById(item.Id);
                    var buildingName = _hotelsRepository.buildingNameById(item.BuildingId.Value);
                    var hotelName = _hotelsRepository.HotelNameById(item.HotelId);
                    var floorNo = _hotelsRepository.FloorNoById(item.FloorId.Value);
                    var hall = new HallModel()
                    {
                        Id = item.Id,
                        //BuildingId = item.BuildingId,
                        Description = item.Description,
                        Fare = item.Fare,
                        //FloorId = item.FloorId,
                        HotelId = item.HotelId,
                        //HotelName = _hotelsRepository.GetHotelName(TheUser),
                        //HotelId = _hotelsRepository.GetHotelName(TheUser),
                        IsDeleted = item.IsDeleted,
                        //MaxNoOfPersons = item.MaxNoOfPersons,
                        ImageUrl = item.ImageUrl,
                        //TableNo = item.TableNo,
                        HotelName = hotelName,
                        RoomSize = item.RoomSize,
                        Length = item.Length,
                        Width = item.Width,
                        Height = item.Height,
                        Name = item.Name,
                        BuildingName = buildingName,
                        FloorNo = floorNo,
                        //TableView = item.TableView
                    };
                    model.Add(hall);
                }
                return View(model);
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult BookHall(Guid id)
        {
            if (id != Guid.Empty)
            {
                var hall = _hotelsRepository.FindHallById(id);
                //var countries = _hotelsRepository.allCountries();
                //var cities = _setupRepository.GetCities();
                //var hotels = _hotelsRepository.AllHotels();
                //var buildings = _hotelsRepository.Buildings();
                //var hotel = _hotelsRepository.FindHotelById(table.HotelId);
                //var floors = _hotelsRepository.Floors();

                var hallServices = _context.HallServiceBooking.Where(p => p.IsDeleted == null).ToList();


                var model = new HallBookingModel
                {
                    BuildingId = hall.BuildingId,
                    HotelId = Guid.Parse(TheUser),
                    HallId = hall.Id,
                    Fare = hall.Fare,
                    //ContactNo = hall.
                    Services = hallServices.Select(x => new SelectListItem()
                    {
                        Value = x.Id.ToString(),
                        Text = $"{x.Name} : {Decimal.Round(x.Price)} Rs"
                    }).ToList(),
                    HallName = hall.Name,
                    // = hotel.HotelCityId,
                    //CountryId = hotel.HotelCountryId,
                    //FarePerHour = table.FarePerHour,
                    FloorId = hall.FloorId,
                    //NoOfPersons = table.MaxNoOfPersons,
                };
                return PartialView(model);
            }
            else
            {
                return Json("");
            }
        }

        [HttpPost]
        public IActionResult BookHall(HallBookingModel model)
        {
            if (ModelState.IsValid)
            {
                var userid = model.UserId;
                var user = _setupRepository.FindUserByCNIC(model.CNIC);
                if (user != null)
                {
                    userid = user.Id;
                }
                else
                {
                    var Newuser = new Users()
                    {
                        Id = Guid.NewGuid(),
                        Name = model.Name,
                        Cnic = model.CNIC,
                        ContactNo = model.ContactNo,
                        IsDeleted = model.IsDeleted,
                        Email = model.Email
                    };
                    _setupRepository.AddUser(Newuser);
                    var createdUser = _setupRepository.FindUserByCNIC(model.CNIC);
                    userid = createdUser.Id;
                }
                if (userid != Guid.Empty)
                {
                    var order = new HallBookings()
                    {
                        CheckInDate = model.CheckInDate.Value,
                        CheckInTime = model.CheckInTime.Value,
                        CheckOutDate = model.CheckOutDate,
                        UserId = userid,
                        CheckOutTime = model.CheckOutTime,
                        HotelId = Guid.Parse(TheUser),
                        CreateDate = DateTime.UtcNow.AddHours(5),
                        IsBooked = true,
                        IsBookedOnline = false,
                        Email = model.Email,
                        ContactNo = model.ContactNo,
                        Id = Guid.NewGuid(),
                        Name = model.Name,
                        HallId = model.HallId,
                        Fare = model.Fare,

                        BuildingId = model.BuildingId,
                        FloorId = model.FloorId

                    };

                    if (model.ServiceIds != null)
                    {
                        if (model.ServiceIds.Count > 0)
                        {
                            foreach (var item in model.ServiceIds)
                            {
                                var hallServices = new HallJoinService()
                                {
                                    // Id = Guid.NewGuid(),
                                    HallId = model.HallId,
                                    HallServiceBookingId = item
                                };
                                _context.HallJoinService.Add(hallServices);
                                _context.SaveChanges();
                            }
                        }
                    }

                    _bookingRepostery.BookHall(order);
                    var hall = _context.Hall.FirstOrDefault(c => c.Id == model.HallId);
                    hall.IsBooked = true;
                    _context.Update(hall);
                    _context.SaveChanges();
                }
            }
            return Json("");
        }

        [HttpGet]
        public IActionResult EditHallOrder(Guid id)
        {
            var order = _bookingRepostery.GetHallBookingById(id);
            var user = _setupRepository.FindUserById(order.UserId);

            var hallservices = _context.HallServiceBooking.Where(p => p.IsDeleted == null).ToList();
            var hallServicesBooked = _context.HallJoinService.Where(p => p.HallId == order.HallId).ToList();


            HallBookingModel hallOrder = new HallBookingModel();
            hallOrder = new HallBookingModel()
            {
                Id = order.Id,
                Name = order.Name,
                HallName = _hotelsRepository.GetHallName(order.HallId.ToString()),

                //User
                Email = order.Email,
                ContactNo = order.ContactNo,

                CNIC = user.Cnic,
                UserId = order.UserId,

                CheckInDate = order.CheckInDate,
                CheckInTime = order.CheckInTime,
                CheckOutDate = order.CheckOutDate,
                CheckOutTime = order.CheckOutTime,
                HallId = order.HallId,

                Services = hallservices.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = $"{x.Name} : {Decimal.Round(x.Price)} Rs"
                }).ToList(),

            };

            hallOrder.ServiceIds = new List<int>();
            foreach (var service in hallServicesBooked)
            {
                var serviceId = service.HallServiceBookingId;
                hallOrder.ServiceIds.Add(serviceId);
            };
            hallOrder.ServiceIdsString = string.Join(",", hallOrder.ServiceIds);

            return PartialView(hallOrder);
        }
        [HttpPost]
        public IActionResult EditHallOrder(HallBookingModel model)
        {
            if (ModelState.IsValid)
            {
                var userid = model.UserId;
                var user = _setupRepository.FindUserByCNIC(model.CNIC);
                if (user != null)
                {
                    userid = user.Id;
                }
                else
                {
                    var Newuser = new Users()
                    {
                        Id = Guid.NewGuid(),
                        Name = model.Name,
                        Cnic = model.CNIC,
                        ContactNo = model.ContactNo,
                        IsDeleted = model.IsDeleted,
                        Email = model.Email
                    };
                    _setupRepository.AddUser(Newuser);
                    var createdUser = _setupRepository.FindUserByCNIC(model.CNIC);
                    userid = createdUser.Id;
                }
                if (userid != null)
                {
                    var order = new HallBookings()
                    {
                        UserId = userid,
                        ContactNo = model.ContactNo,
                        Email = model.Email,
                        HallId = model.HallId,
                        PaidAmount = model.PaidAmount,
                        Id = model.Id,
                        Name = model.Name,
                        HotelId = model.HotelId
                    };
                    _bookingRepostery.EditHallOrder(order);
                    _hotelsRepository.MarkHallBooked(model.HallId);

                    _bookingRepostery.DeleteHallJoinServices(model.HallId);

                    if (model.ServiceIds != null)
                    {
                        if (model.ServiceIds.Count > 0)
                        {
                            foreach (var item in model.ServiceIds)
                            {
                                var hallServices = new HallJoinService()
                                {
                                    // Id = Guid.NewGuid(),
                                    HallId = model.HallId,
                                    HallServiceBookingId = item
                                };
                                _context.HallJoinService.Add(hallServices);
                                _context.SaveChanges();
                            }
                        }
                    }
                }
            }

            return Json("");
        }

        [HttpGet]
        public IActionResult CheckOutHall(Guid id)
        {
            var order = _bookingRepostery.GetHallBookingById(id);
            var user = _setupRepository.FindUserById(order.UserId);

            var hallServices = _context.HallServiceBooking.Where(p => p.IsDeleted == null).ToList();
            var hallServicesBooked = _context.HallJoinService.Where(p => p.HallId == order.HallId).ToList();

            var hallOrder = new CheckOutModel();

            hallOrder = new CheckOutModel()
            {
                Id = order.Id,
                Fare = order.Fare,
                CheckInDate = order.CheckInDate,
                CheckInTime = order.CheckInTime,
                CheckOutDate = order.CheckOutDate,
                CheckOutTime = order.CheckOutTime,
                DiscountAmount = order.DiscountAmount,
                TotalBill = order.TotalBill.HasValue ? order.TotalBill : 0,
                IsPaid = order.IsPaid.HasValue ? order.IsPaid.Value : false,
                RemainingAmount = order.RemainingAmount.HasValue ? order.RemainingAmount : 0,
                UserId = order.UserId,
                CreateDate = order.CreateDate.Value,
                IsDeleted = order.IsDeleted,
                PaidAmount = order.PaidAmount.HasValue ? order.PaidAmount.Value : 0,
                IsBooked = order.IsBooked.Value,
                HallId = order.HallId,
                DaysCount = order.DaysCount,
                TotalFare = order.TotalFare,
                HallName = order.Name,


                HotelId = order.HotelId ?? Guid.Empty,
                BuildingId = order.BuildingId ?? Guid.Empty,
                FloorId = order.FloorId ?? Guid.Empty,

            };

            hallOrder.Services = hallServices.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = $"{x.Name} : {Decimal.Round(x.Price)} Rs"
            }).ToList();


            hallOrder.ServiceIds = new List<int>();
            foreach (var service in hallServicesBooked)
            {
                var serviceId = service.HallServiceBookingId;
                hallOrder.ServiceIds.Add(serviceId);
            };
            hallOrder.ServiceIdsString = string.Join(",", hallOrder.ServiceIds);

            var hallservices = _context.HallServiceBooking.Where(x => hallOrder.ServiceIds.Contains(x.Id)).ToList();

            if (hallservices != null)
            {
                foreach (var item in hallservices)
                {
                    // hallOrder.HallServicePrice = item.Price;
                    hallOrder.HallServicePrice += item.Price;
                }
            }


            return PartialView(hallOrder);
        }

        [HttpPost]
        public IActionResult CheckOutHall(CheckOutModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.UserId != null)
                {
                    var order = new HallBookings()
                    {

                        CheckInDate = model.CheckInDate.Value,
                        CheckInTime = model.CheckInTime.Value,
                        UserId = model.UserId,
                        CheckOutDate = model.CheckOutDate,
                        CheckOutTime = model.CheckOutTime,

                        CreateDate = model.CreateDate,
                        IsBooked = false,

                        //
                        Fare = model.Fare,
                        IsPaid = model.IsPaid,
                        RemainingAmount = model.RemainingAmount,
                        TotalBill = model.TotalBill,
                        DiscountAmount = model.DiscountAmount,
                        IsLeave = model.IsLeave,
                        Id = model.Id,
                        PaidAmount = model.PaidAmount,

                        DaysCount = model.DaysCount,
                        TotalFare = model.TotalFare,

                        HotelId = Guid.Parse(TheUser),
                        BuildingId = model.BuildingId,
                        FloorId = model.FloorId,
                        HallId = model.HallId,

                    };
                    _bookingRepostery.CheckOutHallOrder(order);
                    _hotelsRepository.MarkHallBooked(order.HallId);
                }
            }
            return Json("");
        }

        public IActionResult DeleteHall(Guid id)
        {
            var temp = _context.HallBookings.Where(p => p.Id == id).FirstOrDefault();
            if (temp != null)
            {
                temp.IsDeleted = true;
                temp.IsBooked = false;
                _context.HallBookings.Update(temp);

                var hall = _context.Hall.FirstOrDefault(x => x.Id == temp.HallId);

                hall.IsBooked = false;
                hall.IsBookedOnline = false;
                hall.IsAvailable = true;
                _context.Hall.Update(hall);

                _context.SaveChanges();
            }
            return Json("");
        }

        public IActionResult LeaveHall(Guid id)
        {
            HallBookings temp = _context.HallBookings.Where(p => p.Id == id).FirstOrDefault();

            Hall hall = _context.Hall.Where(x => x.Id == temp.HallId).FirstOrDefault();
            if (temp != null)
            {
                //HallBookings
                temp.IsBooked = false;
                temp.IsBookedOnline = false;
                temp.IsLeave = true;

                _context.HallBookings.Update(temp);

                //Hall
                hall.IsBooked = false;
                hall.IsBookedOnline = false;
                hall.IsAvailable = true;

                _context.Hall.Update(hall);

                _context.SaveChanges();
            }
            //return Json("");
            return RedirectToAction("BookedHalls");
        }

        #endregion
    }
}
