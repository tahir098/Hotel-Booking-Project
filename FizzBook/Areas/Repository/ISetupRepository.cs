using FizzBook.Areas.Master.Models.Setup;
using FizzBook.HotelModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FizzBook.Areas.Repository
{
    public interface ISetupRepository
    {
        HotelTypesModel FindHotelTypeById(Guid id);
        void EditUser(Users user);
        IEnumerable<SelectListItem> GetCities(Guid id);
        void AddUser(Users user);
        Users FindUserById(Guid id);
        Users FindUserByCNIC(string CNIC);
        string GetHotelTypeName(Guid id);
        void AddHotelType(HotelTypes hotelType);
        IEnumerable<HotelTypes> GetHotelTypes();
        void DeleteHotelTypeById(Guid id);
        void EditHotelType(HotelTypesModel hotelType);
        IEnumerable<RoomTypes> GetRoomTypes();
        void AddRoomType(RoomTypes roomType);
        void EditRoomType(RoomTypesModel roomType);
        RoomTypesModel FindRoomTypeById(Guid id);
        void DeleteRoomTypeById(Guid id);
        IEnumerable<Cities> GetCities();
        void AddCity(Cities city);
        void EditCity(CitiesModel cityModel);
        CitiesModel FindCityById(Guid id);
        void DeleteCityById(Guid id);
        IEnumerable<Companies> Companies();
        void AddCompany(Companies company);
        void EditCompany(CompaniesModel companyModel);
        CompaniesModel FindCompanyById(Guid id);
        void DeleteCompanyById(Guid id);
        IEnumerable<RoomServiceBooking> GetRoomServiceBooking();
        void DeleteRoomServiceBookingById(int id);
        IEnumerable<TableServiceBooking> GetTableServiceBooking();
        void DeleteTableServiceBookingById(int id);
        IEnumerable<HallServiceBooking> GetHallServiceBooking();
        void DeleteHallServiceBookingById(int id);
    }
}