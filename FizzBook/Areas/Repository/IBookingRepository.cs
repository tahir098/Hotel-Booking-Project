using FizzBook.HotelModels;
using System;
using System.Collections.Generic;

namespace FizzBook.Areas.Repository
{
    public interface IBookingRepository
    {
        IEnumerable<TableBookings> OrderedTabels();
        RoomBookings GetRoomBookingById(Guid id);
        IEnumerable<RoomBookings> OrderedRooms();
        void EditRoomOrder(RoomBookings model);
        IEnumerable<HallBookings> OrderedHalls();
        IEnumerable<HotelBookings> OrderedHotels();
        void BookTable(TableBookings tableBooking);
        void BookRoom(RoomBookings roomBooking);
        void BookHall(HallBookings hallBooking);
        void BookHotel(HotelBookings hotelBooking);
        IEnumerable<TableBookings> GetOrderedTablesByHotelId(string hotelId);
        string GetTableNoByTableId(string tableId);
        IEnumerable<RoomBookings> GetOrderedRoomsByHotelId(string hotelId);
        IEnumerable<HallBookings> GetOrderedHallsByHotelId(string hotelId);
        HallBookings GetHallBookingById(Guid id);
        void EditHallOrder(HallBookings model);
        void CheckOutHallOrder(HallBookings model);
        void DeleteRoomJoinServices(Guid roomId);
        void DeleteHallJoinServices(Guid hallId);
        void DeleteTableJoinServices(Guid table);
        TableBookings GetTableBookingById(Guid id);
        //IEnumerable<HotelBookings> GetOrderedHotelsByHotelId(string hotelId);
    }
}