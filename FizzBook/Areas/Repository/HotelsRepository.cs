using FizzBook.Areas.Master.Models.Hotels;
using FizzBook.HotelModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBook.Areas.Repository
{
    public class HotelsRepository : IHotelsRepository
    {
        private readonly FizzHotleBookingContext _context;

        public HotelsRepository(FizzHotleBookingContext context)
        {
            _context = context;
        }

        public string GetHotelName(string id)
        {
            var hotel = _context.Hotels.Where(x => x.Id == Guid.Parse(id)).FirstOrDefault();

            if (hotel != null)
            {
                return hotel.HotelName;
            }
            return string.Empty;
        }
        public string GetBuildingName(string hotelId)
        {
            var building = _context.Buildings.Where(x => x.HotelId == Guid.Parse(hotelId)).FirstOrDefault();
            if (building != null)
            {
                return building.Name;

            }

            return string.Empty;
        }
        public string GetFloorNo(string hotelId)
        {
            var floor = _context.Floors.Where(x => x.HotelId == Guid.Parse(hotelId)).FirstOrDefault();
            return floor.FloorNo;
        }
        public string GetRoomNoByRoomId(string roomId)
        {
            var room = _context.Rooms.Where(x => x.Id == Guid.Parse(roomId)).FirstOrDefault();
            return room.RoomNo;
        }
        public string GetHallName(string id)
        {
            var hall = _context.Hall.Where(x => x.Id == Guid.Parse(id)).FirstOrDefault();

            if (hall != null)
            {
                return hall.Name;
            }
            return string.Empty;
        }

        public IEnumerable<Hotels> AllHotels()
        {
            var hotels = _context.Hotels.OrderBy(p => p.HotelName).Where(p => p.IsDeleted == null);
            return hotels;
        }

        public IEnumerable<Hotels> GetAllHotelsByHotelId(string hotelId)
        {
            var hotels = _context.Hotels.Where(x => x.Id == Guid.Parse(hotelId)).OrderBy(p => p.HotelName).Where(p => p.IsDeleted == null);
            return hotels;
        }

        public IEnumerable<SelectListItem> GetHotels(Guid id)
        {
            if (id != Guid.Empty)
            {
                IEnumerable<SelectListItem> hotels = _context.Hotels.AsNoTracking()
                    .OrderBy(n => n.HotelName)
                    .Where(n => n.HotelCityId == id)
                    .Select(n =>
                       new SelectListItem
                       {
                           Value = n.Id.ToString(),
                           Text = n.HotelName
                       }).ToList();
                return new SelectList(hotels, "Value", "Text");
            }
            return null;
        }

        //public ActionResult GetBuildings(Guid id)
        //{
        //    if (id != null)
        //    {
        //        IEnumerable<SelectListItem> buildings = _hotelsRepository.GetBuildings(id);
        //        return Json(buildings);
        //    }
        //    return null;
        //}

        public IEnumerable<SelectListItem> GetAvailableRoomsByHotelId(Guid id)
        {
            if (id != null)
            {
                IEnumerable<SelectListItem> rooms = _context.Rooms.AsNoTracking()
                    .OrderBy(n => n.RoomNo)
                    .Where(n => n.HotelId == id && n.IsBooked == null)
                    .Select(n =>
                       new SelectListItem
                       {
                           Value = n.Id.ToString(),
                           Text = n.RoomNo
                       }).ToList();
                return new SelectList(rooms, "Value", "Text");
            }
            return null;
        }

        public IEnumerable<SelectListItem> GetAvailableBuildingsByHotelId(string hotelId)
        {
            if (hotelId != null)
            {
                IEnumerable<SelectListItem> buildings = _context.Buildings.AsNoTracking()
                    .OrderBy(n => n.Id)
                    .Where(n => n.HotelId == Guid.Parse(hotelId) && n.IsDeleted != true)
                    .Select(n =>
                       new SelectListItem
                       {
                           Value = n.Id.ToString(),
                           Text = n.Name
                       }).ToList();
                return new SelectList(buildings, "Value", "Text");
            }
            return null;
        }

        public IEnumerable<SelectListItem> GetAvailableRoomsByHotelAndTypeId(Guid hotelId, Guid typeId)
        {
            if (hotelId != null && typeId != null)
            {
                IEnumerable<SelectListItem> rooms = _context.Rooms.AsNoTracking()
                    .OrderBy(n => n.RoomNo)
                    .Where(n => n.HotelId == hotelId && n.TypeId == typeId && n.IsBooked == null)
                    .Select(n =>
                       new SelectListItem
                       {
                           Value = n.Id.ToString(),
                           Text = n.RoomNo
                       }).ToList();
                return new SelectList(rooms, "Value", "Text");
            }
            return null;
        }
        public IEnumerable<SelectListItem> GetRoomTypes()
        {
            IEnumerable<SelectListItem> roomTypes = _context.RoomTypes.AsNoTracking()
                .OrderBy(n => n.Name)
                .Select(n =>
                   new SelectListItem
                   {
                       Value = n.Id.ToString(),
                       Text = n.Name
                   }).ToList();
            return new SelectList(roomTypes, "Value", "Text");
        }

        public IEnumerable<Rooms> GetAvailableRooms()
        {
            var rooms = _context.Rooms.OrderBy(s => s.RoomNo).Where(p => (p.IsBooked == null || p.IsBooked == false) && (p.IsBookedOnline == null || p.IsBookedOnline == false) && (p.IsDeleted == null || p.IsDeleted == false));
            return rooms;
        }

        public IEnumerable<Rooms> GetAvailableRoomsByHotelId(string hotelId)
        {
            var rooms = _context.Rooms.Where(p => p.HotelId == Guid.Parse(hotelId) && (p.IsBooked == null || p.IsBooked != true) && (p.IsDeleted != true) && (p.IsAvailable == null || p.IsAvailable == true)).OrderBy(s => s.RoomNo);
            return rooms;
        }

        public void MarkRoomBooked(Guid id)
        {
            if (id != null)
            {
                var room = _context.Rooms.SingleOrDefault(s => s.Id == id);
                room.IsBooked = true;
                room.IsBookedOnline = false;
                _context.Update(room);
                _context.SaveChanges();
            }
        }

        public void MarkHallBooked(Guid id)
        {
            if (id != null)
            {
                var hall = _context.Hall.SingleOrDefault(s => s.Id == id);
                hall.IsBooked = true;
                hall.IsBookedOnline = false;
                _context.Update(hall);
                _context.SaveChanges();
            }
        }

        public void MarkTableBooked(Guid id)
        {
            if (id != null)
            {
                var table = _context.Tables.SingleOrDefault(s => s.Id == id);
                table.IsBooked = true;
                table.IsBookedOnline = false;
                _context.Update(table);
                _context.SaveChanges();
            }
        }

        public IEnumerable<SelectListItem> GetFloors(Guid id)
        {
            if (id != null)
            {
                IEnumerable<SelectListItem> floors = _context.Floors.AsNoTracking()
                    .OrderBy(n => n.FloorNo)
                    .Where(n => n.BuildingId == id)
                    .Select(n =>
                       new SelectListItem
                       {
                           Value = n.Id.ToString(),
                           Text = n.FloorNo
                       }).ToList();
                return new SelectList(floors, "Value", "Text");
            }
            return null;
        }
        public IEnumerable<SelectListItem> GetRooms(Guid id)
        {
            if (id != null)
            {
                IEnumerable<SelectListItem> rooms = _context.Rooms.AsNoTracking()
                    .OrderBy(n => n.RoomNo)
                    .Where(n => n.HotelId == id)
                    .Select(n =>
                       new SelectListItem
                       {
                           Value = n.Id.ToString(),
                           Text = n.RoomNo
                       }).ToList();
                return new SelectList(rooms, "Value", "Text");
            }
            return null;
        }

        public IEnumerable<SelectListItem> GetHotelExpenseTypes()
        {
            IEnumerable<SelectListItem> rooms = _context.HotelExpenTypes.AsNoTracking()
               .OrderBy(n => n.ExpenseType)
              .Where(n => n.IsDeleted == false)
               .Select(n =>
                  new SelectListItem
                  {
                      Value = n.Id.ToString(),
                      Text = n.ExpenseType
                  }).ToList();

            return new SelectList(rooms, "Value", "Text");
        }

        public void addHotel(Hotels hotel)
        {
            hotel.Id = Guid.NewGuid();
            _context.Hotels.Add(hotel);
            _context.SaveChanges();
        }
        public HotelsModel FindHotelById(Guid id)
        {
            var hotel = _context.Hotels.SingleOrDefault(d => d.Id == id);
            var hotelModel = new HotelsModel()
            {
                Id = hotel.Id,
                HotelName = hotel.HotelName,
                HotelPhone = hotel.HotelPhone,
                HotelWebsite = hotel.HotelWebsite,
                HotelEmail = hotel.HotelEmail,
                HotelCountryId = hotel.HotelCountryId,
                HotelCityId = hotel.HotelCityId,
                ImageUrl = hotel.ImageUrl,
                HotelAddress = hotel.HotelAddress,
                HotelTypeId = hotel.HotelTypeId,
                Password = hotel.Password
            };
            return hotelModel;
        }
        public string HotelNameById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return "Not Found";
            }
            var hotel = _context.Hotels.SingleOrDefault(d => d.Id == id);
            var hotelName = hotel.HotelName;
            return hotelName;
        }
        public string buildingNameById(Guid id)
        {
            if (id == null)
            {
                return "Not Found";
            }
            var building = _context.Buildings.SingleOrDefault(d => d.Id == id);
            var buildingName = building.Name;
            return buildingName;
        }
        public string FloorNoById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return "Not Found";
            }
            var floor = _context.Floors.SingleOrDefault(d => d.Id == id);
            var name = floor.FloorNo;
            return name;
        }
        public void EditHotel(Hotels model)
        {
            _context.Update(model);
            _context.SaveChanges();
        }
        public void DeleteHotel(Guid id)
        {
            var hotel = _context.Hotels.FirstOrDefault(x => x.Id == id);
            if (hotel != null)
            {
                hotel.IsDeleted = true;
                _context.Update(hotel);
                _context.SaveChanges();
            }
        }
        public IEnumerable<Buildings> Buildings()
        {
            var buildings = _context.Buildings.OrderBy(p => p.Name).Where(p => p.IsDeleted == null);
            return buildings;
        }

        public IEnumerable<Buildings> GetBuildingsByHotelId(string hotelId)
        {
            var buildings = _context.Buildings.Where(x => x.HotelId == Guid.Parse(hotelId)).OrderBy(p => p.Name).Where(p => p.IsDeleted != true);
            return buildings;
        }

        public IEnumerable<SelectListItem> GetBuildings(Guid id)
        {
            if (id != null)
            {
                IEnumerable<SelectListItem> buildings = _context.Buildings.AsNoTracking()
                    .OrderBy(n => n.Name)
                    .Where(n => n.HotelId == id)
                    .Select(n =>
                       new SelectListItem
                       {
                           Value = n.Id.ToString(),
                           Text = n.Name
                       }).ToList();
                return new SelectList(buildings, "Value", "Text");
            }
            return null;
        }
        public void AddBuilding(Buildings building)
        {
            building.Id = Guid.NewGuid();
            _context.Buildings.Add(building);
            _context.SaveChanges();
        }
        public BuildingModel FindBuildingById(Guid id)
        {
            var building = _context.Buildings.SingleOrDefault(p => p.Id == id);
            var model = new BuildingModel()
            {
                Id = building.Id,
                Name = building.Name,
                HotelId = building.HotelId,
                ImageUrl = building.ImageUrl,
                IsDeleted = building.IsDeleted,
                Address = building.Address
            };
            return model;
        }
        public void EditBuildding(BuildingModel model)
        {
            var editedBuilding = new Buildings()
            {
                Id = model.Id,
                Name = model.Name,
                ImageUrl = model.ImageUrl,
                IsDeleted = model.IsDeleted,
                Address = model.Address,
                HotelId = model.HotelId
            };
            if (editedBuilding != null)
            {
                _context.Update(editedBuilding);
                _context.SaveChanges();
            }
        }
        public void EditBuildding(Hotel.Models.Hotels.BuildingModel model)
        {
            //var editedBuilding = new Buildings()
            //{
            //    Id = model.Id,
            //    Name = model.Name,
            //    ImageUrl = model.ImageUrl,
            //    IsDeleted = model.IsDeleted,
            //    Address = model.Address,
            //    HotelId = model.HotelId
            //};
            if (model != null)
            {
                Buildings buildings = new Buildings()
                {
                    Address = model.Address,
                    HotelId = model.HotelId,
                    Id = model.Id,
                    ImageUrl = model.ImageUrl,
                    IsDeleted = model.IsDeleted,
                    Name = model.Name
                };

                _context.Buildings.Update(buildings);
                _context.SaveChanges();
            }
        }


        public void DeleteBuilding(Guid id)
        {
            var building = _context.Buildings.FirstOrDefault(d => d.Id == id);
            if (building != null)
            {
                building.IsDeleted = true;
                _context.SaveChanges();
            }
        }
        public IEnumerable<Hall> Halls()
        {
            var halls = _context.Hall.OrderBy(p => p.Name).Where(p => p.IsDeleted == null);
            return halls;
        }

        public List<Hall> GetHallsByHotelId(string hotelId)
        {
            List<Hall> halls = _context.Hall.Where(x => x.HotelId == Guid.Parse(hotelId))
                .OrderBy(p => p.Name).Where(p => p.IsDeleted != true).ToList();
            return halls;
        }
        public void AddHall(Hall hall)
        {
            hall.Id = Guid.NewGuid();
            _context.Hall.Add(hall);
            _context.SaveChanges();
        }
        public HallModel FindHallById(Guid id)
        {
            var hall = _context.Hall.SingleOrDefault(p => p.Id == id);
            var model = new HallModel()
            {
                Id = hall.Id,
                Name = hall.Name,
                Description = hall.Description,
                RoomSize = hall.RoomSize,
                IsDeleted = hall.IsDeleted,
                Height = hall.Length,
                ImageUrl = hall.ImageUrl,
                Length = hall.Length,
                Width = hall.Width,
                HotelId = hall.HotelId,
                Fare = hall.Fare,
                BuildingId = hall.BuildingId.HasValue ? hall.BuildingId.Value : Guid.Empty,
                FloorId = hall.FloorId.HasValue ? hall.FloorId.Value : Guid.Empty,
                
            };
            return model;
        }
        public string HallNameById(Guid id)
        {
            if (id == null)
            {
                return "Not Found";
            }
            var hall = _context.Hall.SingleOrDefault(d => d.Id == id);
            var hallName = hall.Name;
            return hallName;
        }
        public void EditHall(Hall model)
        {
            _context.Update(model);
            _context.SaveChanges();
        }
        public void DeleteHall(Guid id)
        {
            var hall = _context.Hall.FirstOrDefault(p => p.Id == id);
            if (hall != null)
            {
                hall.IsDeleted = true;
                _context.Update(hall);
                _context.SaveChanges();
            }
        }
        public IEnumerable<Floors> Floors()
        {
            var floors = _context.Floors.OrderBy(p => p.FloorNo).Where(p => p.IsDeleted == null);
            return floors;
        }
        public List<Floors> GetFloorsByHotelId(string hotelId)
        {
            var floors = _context.Floors.Where(x => x.HotelId == Guid.Parse(hotelId) && x.IsDeleted != true)
                .OrderBy(p => p.FloorNo)
                .ToList();
            return floors;
        }

        public void AddFloor(Floors floor)
        {
            floor.Id = Guid.NewGuid();
            _context.Floors.Add(floor);
            _context.SaveChanges();
        }
        public FloorModel FindFloorById(Guid id)
        {
            var floor = _context.Floors.FirstOrDefault(p => p.Id == id);
            var model = new FloorModel()
            {
                Id = floor.Id,
                FloorNo = floor.FloorNo,
                ImageUrl = floor.ImageUrl,
                HotelId = floor.HotelId,
                BuildingId = floor.BuildingId
            };
            return model;
        }
        public void EditFloor(FloorModel model)
        {
            var editedfloor = new Floors()
            {
                Id = model.Id,
                FloorNo = model.FloorNo,
                HotelId = model.HotelId,
                ImageUrl = model.ImageUrl,
                BuildingId = model.BuildingId
            };
            if (editedfloor != null)
            {
                _context.Update(editedfloor);
                _context.SaveChanges();
            }
        }

        public void EditFloor(Hotel.Models.Hotels.FloorModel model)
        {
            var editedfloor = new Floors()
            {
                Id = model.Id,
                FloorNo = model.FloorNo,
                HotelId = model.HotelId,
                ImageUrl = model.ImageUrl,
                BuildingId = model.BuildingId
            };
            if (editedfloor != null)
            {
                _context.Update(editedfloor);
                _context.SaveChanges();
            }
        }

        public void DeleteFloor(Guid id)
        {
            var floor = _context.Floors.SingleOrDefault(p => p.Id == id);
            if (floor != null)
            {
                floor.IsDeleted = true;
                _context.SaveChanges();
            }
        }
        public IEnumerable<Rooms> Rooms()
        {
            var rooms = _context.Rooms.Where(p => p.IsDeleted == null);
            return rooms;
        }
        public IEnumerable<Rooms> GetRoomsByHotelId(string hotelId)
        {
            var rooms = _context.Rooms.Where(p => p.HotelId == Guid.Parse(hotelId) && p.IsDeleted != true).ToList();
            return rooms;
        }

        public void AddRoom(Rooms room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();
        }
        public RoomsModel FindRoomById(Guid id)
        {
            var room = _context.Rooms.SingleOrDefault(p => p.Id == id);
            var model = new RoomsModel()
            {
                Id = room.Id,
                Description = room.Description,
                ImageUrl = room.ImageUrl,
                BuildingId = room.BuildingId,
                FarePerNight = room.FarePerNight,
                FloorId = room.FloorId,
                HotelId = room.HotelId,
                RoomNo = room.RoomNo,
                IsDeleted = room.IsDeleted,
                MaxNoOfPersons = room.MaxNoOfPersons,
                NoOfBeds = room.NoOfBeds,
                RoomView = room.RoomView,
                TypeId = room.TypeId
            };
            return model;
        }
        public void EditRoom(Rooms room)
        {
            _context.Update(room);
            _context.SaveChanges();
        }
        public void DeleteRoom(Guid id)
        {
            var room = _context.Rooms.SingleOrDefault(p => p.Id == id);
            if (room != null)
            {
                room.IsDeleted = true;
                _context.SaveChanges();
            }
        }
        public IEnumerable<Tables> Tables()
        {
            var tables = _context.Tables.OrderBy(p => p.TableNo).Where(p => p.IsDeleted != true);
            return tables;
        }

        public IEnumerable<Tables> GetTablesByHotelId(string hotelId)
        {
            var tables = _context.Tables.Where(p => p.HotelId == Guid.Parse(hotelId) && p.IsDeleted != true).OrderBy(p => p.TableNo);
            return tables;
        }

        public void AddTable(Tables table)
        {
            table.Id = Guid.NewGuid();
            _context.Tables.Add(table);
            _context.SaveChanges();
        }
        public TableModel FindTableById(Guid id)
        {
            var table = _context.Tables.SingleOrDefault(p => p.Id == id);
            var model = new TableModel()
            {
                Id = table.Id,
                BuildingId = table.BuildingId,
                Description = table.Description,
                ImageUrl = table.ImageUrl,
                FarePerHour = table.FarePerHour,
                FloorId = table.FloorId,
                HotelId = table.HotelId,
                IsDeleted = table.IsDeleted,
                MaxNoOfPersons = table.MaxNoOfPersons,
                TableNo = table.TableNo,
                TableView = table.TableView
            };
            return model;
        }
        public void EditTable(Tables table)
        {
            _context.Update(table);
            _context.SaveChanges();
        }
        public void DeleteTable(Guid id)
        {
            var table = _context.Tables.SingleOrDefault(p => p.Id == id);
            if (table != null)
            {
                table.IsDeleted = true;
                _context.SaveChanges();
            }
        }
        public IEnumerable<Countries> allCountries()
        {
            var countries = _context.Countries.OrderBy(p => p.Name).Where(p => p.IsDeleted == null);
            return countries;
        }
        public void AddCountry(Countries country)
        {
            country.Id = Guid.NewGuid();
            _context.Countries.Add(country);
            _context.SaveChanges();
        }
        public void EditCountry(CountriesModel countryModel)
        {
            var editedCountry = new Countries()
            {
                Id = countryModel.Id,
                Name = countryModel.Name
            };

            if (editedCountry != null)
            {
                _context.Update(editedCountry);
                _context.SaveChanges();
            }
        }
        public CountriesModel FindCountryById(Guid id)
        {
            var country = _context.Countries.SingleOrDefault(d => d.Id == id);
            var countryModel = new CountriesModel()
            {
                Id = country.Id,
                Name = country.Name
            };
            return countryModel;
        }
        public void DeleteCountry(Guid id)
        {
            var country = _context.Countries.SingleOrDefault(d => d.Id == id);
            if (country != null)
            {
                country.IsDeleted = true;
                _context.SaveChanges();
            }
            else
            {

            }
        }
        public string CountryNameById(Guid? id)
        {
            if (id == null)
            {
                return "Not Found";
            }
            var country = _context.Countries.SingleOrDefault(d => d.Id == id);
            var countryName = country.Name;
            return countryName;
        }

    }
}
