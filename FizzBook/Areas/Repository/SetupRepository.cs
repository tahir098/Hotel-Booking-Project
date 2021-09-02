using FizzBook.Areas.Master.Models.Setup;
using FizzBook.HotelModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBook.Areas.Repository
{
    public class SetupRepository : ISetupRepository
    {
        private FizzHotleBookingContext _Context;

        public SetupRepository(FizzHotleBookingContext Context)
        {
            _Context = Context;
        }
        public IEnumerable<HotelTypes> GetHotelTypes()
        {
            var list = _Context.HotelTypes.OrderBy(e => e.Type).Where(p => p.IsDeleted == null);
            return list;
        }
        public void AddHotelType(HotelTypes hotelType)
        {
            hotelType.Id = Guid.NewGuid();
            _Context.HotelTypes.Add(hotelType);
            _Context.SaveChanges();
        }

        public void EditHotelType(HotelTypesModel hotelType)
        {
            var editedHotelType = new HotelTypes()
            {
                Id = hotelType.Id,
                Type = hotelType.Type,
                Description = hotelType.Description
            };

            if (editedHotelType != null)
            {
                _Context.Update(editedHotelType);
                _Context.SaveChanges();
            }
        }
        public HotelTypesModel FindHotelTypeById(Guid id)
        {
            var hotelType = _Context.HotelTypes.SingleOrDefault(d => d.Id == id);
            var type = new HotelTypesModel()
            {
                Id = hotelType.Id,
                Type = hotelType.Type,
                Description = hotelType.Description
            };
            return type;
        }
        public string GetHotelTypeName(Guid id)
        {
            if (id == null)
            {
                return "Not Found";
            }
            var type = _Context.HotelTypes.SingleOrDefault(d => d.Id == id);
            var typeName = type.Type;
            return typeName;

        }
        public void DeleteHotelTypeById(Guid id)
        {
            var hotelType = _Context.HotelTypes.SingleOrDefault(d => d.Id == id);
            if (hotelType != null)
            {
                hotelType.IsDeleted = true;
                _Context.SaveChanges();
            }
            else
            {

            }
        }
        public void AddUser(Users user)
        {
            _Context.Users.Add(user);
            _Context.SaveChanges();
        }
        public void EditUser(Users user)
        {
            _Context.Update(user);
            _Context.SaveChanges();
        }
        public Users FindUserByCNIC(string CNIC)
        {
            var user = _Context.Users.SingleOrDefault(p => p.Cnic == CNIC);
            return user;
        }
        public Users FindUserById(Guid id)
        {
            var user = _Context.Users.SingleOrDefault(p => p.Id == id);
            return user;
        }
        public IEnumerable<RoomTypes> GetRoomTypes()
        {
            var roomTypes = _Context.RoomTypes.OrderBy(e => e.Name).Where(e => e.IsDeleted == null);
            return roomTypes;
        }
        public void AddRoomType(RoomTypes roomType)
        {
            roomType.Id = Guid.NewGuid();
            _Context.RoomTypes.Add(roomType);
            _Context.SaveChanges();
        }
        public void EditRoomType(RoomTypesModel roomType)
        {
            var editedRoomType = new RoomTypes()
            {
                Id = roomType.Id,
                Name = roomType.Name,
                Description = roomType.Description
            };

            if (editedRoomType != null)
            {
                _Context.Update(editedRoomType);
                _Context.SaveChanges();
            }
        }
        public RoomTypesModel FindRoomTypeById(Guid id)
        {
            var roomType = _Context.RoomTypes.SingleOrDefault(d => d.Id == id);
            var type = new RoomTypesModel()
            {
                Id = roomType.Id,
                Name = roomType.Name,
                Description = roomType.Description
            };
            return type;
        }
        public void DeleteRoomTypeById(Guid id)
        {
            var roomType = _Context.RoomTypes.SingleOrDefault(d => d.Id == id);
            if (roomType != null)
            {
                roomType.IsDeleted = true;
                _Context.SaveChanges();
            }
            else
            {

            }
        }
        public IEnumerable<Cities> GetCities()
        {
            var cities = _Context.Cities.OrderBy(c => c.CityName).Where(p => p.IsDeleted == null);
            return cities;
        }
        public IEnumerable<SelectListItem> GetCities(Guid id)
        {
            if (id != null)
            {
                IEnumerable<SelectListItem> cities = _Context.Cities.AsNoTracking()
                    .OrderBy(n => n.CityName)
                    .Where(n => n.CountryId == id)
                    .Select(n =>
                       new SelectListItem
                       {
                           Value = n.Id.ToString(),
                           Text = n.CityName
                       }).ToList();
                return new SelectList(cities, "Value", "Text");
            }
            return null;
        }
        public void AddCity(Cities city)
        {
            city.Id = Guid.NewGuid();
            _Context.Cities.Add(city);
            _Context.SaveChanges();
        }
        public void EditCity(CitiesModel cityModel)
        {
            var editedCity = new Cities()
            {
                Id = cityModel.Id,
                CityName = cityModel.CityName,
                CountryId = cityModel.CountryId,
                Description = cityModel.Description
            };

            if (editedCity != null)
            {
                _Context.Update(editedCity);
                _Context.SaveChanges();
            }
        }
        public CitiesModel FindCityById(Guid id)
        {
            var city = _Context.Cities.SingleOrDefault(d => d.Id == id);
            var cityModel = new CitiesModel()
            {
                Id = city.Id,
                CityName = city.CityName,
                Description = city.Description,
                CountryId = city.CountryId
            };
            return cityModel;
        }
        public void DeleteCityById(Guid id)
        {
            var city = _Context.Cities.SingleOrDefault(d => d.Id == id);
            if (city != null)
            {
                city.IsDeleted = true;
                _Context.SaveChanges();
            }
            else
            {

            }
        }
        public IEnumerable<Companies> Companies()
        {
            var companies = _Context.Companies.OrderBy(p => p.CompanyName).Where(p => p.IsDeleted == null);
            return companies;
        }
        public void AddCompany(Companies company)
        {
            company.Id = Guid.NewGuid();
            _Context.Companies.Add(company);
            _Context.SaveChanges();
        }
        public void EditCompany(CompaniesModel companyModel)
        {
            var editedCompany = new Companies()
            {
                Id = companyModel.Id,
                CompanyName = companyModel.CompanyName,
                UserFirstName = companyModel.UserFirstName,
                UserLastName = companyModel.UserLastName,
                ContactNo = companyModel.ContactNo,
                Email = companyModel.Email,
                CompanySite = companyModel.CompanySite,
                AddressOne = companyModel.AddressOne,
                AddressTwo = companyModel.AddressTwo,
                PostCode = companyModel.PostCode,
                City = companyModel.City,
                State = companyModel.State,
                Country = companyModel.Country,
                IsDeleted = companyModel.IsDeleted,
                CreateDate = companyModel.CreateDate
            };

            if (editedCompany != null)
            {
                _Context.Update(editedCompany);
                _Context.SaveChanges();
            }
        }
        public CompaniesModel FindCompanyById(Guid id)
        {
            var company = _Context.Companies.FirstOrDefault(d => d.Id == id);
            var companyModel = new CompaniesModel()
            {
                Id = company.Id,
                CompanyName = company.CompanyName,
                UserFirstName = company.UserFirstName,
                UserLastName = company.UserLastName,
                ContactNo = company.ContactNo,
                Email = company.Email,
                CompanySite = company.CompanySite,
                AddressOne = company.AddressOne,
                AddressTwo = company.AddressTwo,
                PostCode = company.PostCode,
                City = company.City,
                State = company.State,
                Country = company.Country,
                IsDeleted = company.IsDeleted,
                CreateDate = company.CreateDate
            };
            return companyModel;
        }
        public void DeleteCompanyById(Guid id)
        {
            var company = _Context.Companies.SingleOrDefault(d => d.Id == id);
            if (company != null)
            {
                company.IsDeleted = true;
                _Context.SaveChanges();
            }
            else
            {

            }
        }


        public IEnumerable<RoomServiceBooking> GetRoomServiceBooking()
        {
            var roomServiceBooking = _Context.RoomServiceBooking.OrderBy(e => e.Name).Where(e => e.IsDeleted == null);
            return roomServiceBooking;
        }
        public void DeleteRoomServiceBookingById(int id)
        {
            var roomServiceBooking = _Context.RoomServiceBooking.FirstOrDefault(d => d.Id == id);
            if (roomServiceBooking != null)
            {
                roomServiceBooking.IsDeleted = true;
                _Context.Update(roomServiceBooking);
                _Context.SaveChanges();
            }
        }

        public void DeleteTableServiceBookingById(int id)
        {
            var tableServiceBooking = _Context.TableServiceBooking.FirstOrDefault(d => d.Id == id);
            if (tableServiceBooking != null)
            {
                tableServiceBooking.IsDeleted = true;
                _Context.Update(tableServiceBooking);
                _Context.SaveChanges();
            }
        }



        public IEnumerable<TableServiceBooking> GetTableServiceBooking()
        {
            var tableServiceBooking = _Context.TableServiceBooking.OrderBy(e => e.Name).Where(e => e.IsDeleted == null);
            return tableServiceBooking;
        }



        public IEnumerable<HallServiceBooking> GetHallServiceBooking()
        {
            var hallServiceBooking = _Context.HallServiceBooking.OrderBy(e => e.Name).Where(e => e.IsDeleted == null);
            return hallServiceBooking;
        }

        public void DeleteHallServiceBookingById(int id)
        {
            var hallServiceBooking = _Context.HallServiceBooking.FirstOrDefault(d => d.Id == id);
            if (hallServiceBooking != null)
            {
                hallServiceBooking.IsDeleted = true;
                _Context.Update(hallServiceBooking);
                _Context.SaveChanges();
            }
        }
    }
}
