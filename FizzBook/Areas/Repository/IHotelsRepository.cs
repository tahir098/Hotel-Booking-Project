using FizzBook.Areas.Master.Models.Hotels;
using FizzBook.HotelModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace FizzBook.Areas.Repository
{
    public interface IHotelsRepository
    {
        IEnumerable<Hotels> AllHotels();
        IEnumerable<SelectListItem> GetRooms(Guid id);
        IEnumerable<SelectListItem> GetAvailableRoomsByHotelId(Guid id);
        IEnumerable<SelectListItem> GetAvailableRoomsByHotelAndTypeId(Guid hotelId, Guid typeId);
        IEnumerable<SelectListItem> GetBuildings(Guid id);
        IEnumerable<SelectListItem> GetRoomTypes();
        void MarkRoomBooked(Guid id);
        IEnumerable<Rooms> GetAvailableRooms();
        IEnumerable<SelectListItem> GetFloors(Guid id);
        void addHotel(Hotels hotel);
        void DeleteHotel(Guid id);
        void AddFloor(Floors floor);
        void EditFloor(FloorModel model);
        void DeleteFloor(Guid id);
        void EditHotel(Hotels model);
        FloorModel FindFloorById(Guid id);
        string buildingNameById(Guid id);
        IEnumerable<Floors> Floors();
        string FloorNoById(Guid id);
        HotelsModel FindHotelById(Guid id);
        IEnumerable<Buildings> Buildings();
        string HallNameById(Guid id);
        string HotelNameById(Guid id);
        void AddBuilding(Buildings building);
        BuildingModel FindBuildingById(Guid id);
        void EditBuildding(BuildingModel model);

        void EditBuildding(Hotel.Models.Hotels.BuildingModel model);

        void DeleteBuilding(Guid id);
        IEnumerable<Hall> Halls();
        void AddHall(Hall hall);
        HallModel FindHallById(Guid id);
        void EditHall(Hall model);
        void DeleteHall(Guid id);
        IEnumerable<Rooms> Rooms();
        void AddRoom(Rooms room);
        RoomsModel FindRoomById(Guid id);
        void EditRoom(Rooms room);
        void DeleteRoom(Guid id);
        IEnumerable<Tables> Tables();
        void AddTable(Tables table);
        TableModel FindTableById(Guid id);
        void EditTable(Tables table);
        void DeleteTable(Guid id);
        IEnumerable<Countries> allCountries();
        void AddCountry(Countries country);
        void EditCountry(CountriesModel countryModel);
        CountriesModel FindCountryById(Guid id);
        void DeleteCountry(Guid id);
        string CountryNameById(Guid? id);
        IEnumerable<SelectListItem> GetHotels(Guid id);

        string GetHotelName(string id);
        List<Hall> GetHallsByHotelId(string hotelId);
        List<Floors> GetFloorsByHotelId(string hotelId);
        IEnumerable<Hotels> GetAllHotelsByHotelId(string hotelId);
        IEnumerable<Buildings> GetBuildingsByHotelId(string hotelId);
        void EditFloor(Hotel.Models.Hotels.FloorModel model);
        IEnumerable<Rooms> GetRoomsByHotelId(string hotelId);
        IEnumerable<SelectListItem> GetAvailableBuildingsByHotelId(string hotelId);
        IEnumerable<Tables> GetTablesByHotelId(string hotelId);
        string GetBuildingName(string hotelId);
        string GetFloorNo(string hotelId);
        string GetRoomNoByRoomId(string roomId);
        IEnumerable<Rooms> GetAvailableRoomsByHotelId(string hotelId);
        IEnumerable<SelectListItem> GetHotelExpenseTypes();
        string GetHallName(string id);
        void MarkHallBooked(Guid id);
        void MarkTableBooked(Guid id);
    }
}