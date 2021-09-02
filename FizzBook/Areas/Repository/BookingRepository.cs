using FizzBook.Areas.Hotel.Models.Bookings;
using FizzBook.HotelModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBook.Areas.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private FizzHotleBookingContext _Context;
        public BookingRepository(FizzHotleBookingContext Context)
        {
            _Context = Context;
        }

        public IEnumerable<TableBookings> OrderedTabels()
        {
            var orderedTabels = _Context.TableBookings.OrderBy(p => p.CreateDate).Where(p => p.IsDeleted != true);
            return orderedTabels;
        }
        public IEnumerable<TableBookings> GetOrderedTablesByHotelId(string hotelId)
        {
            var orderedTabels = _Context.TableBookings.Where(p => p.HotelId == Guid.Parse(hotelId) && p.IsDeleted != true).OrderBy(p => p.CreateDate);
            return orderedTabels;
        }
        public string GetTableNoByTableId(string tableId)
        {
            var table = _Context.Tables.Where(p => p.Id == Guid.Parse(tableId) && p.IsDeleted != true).OrderBy(p => p.TableNo).FirstOrDefault();

            if (table != null)
            {
                return table.TableNo;
            }
            return string.Empty;
        }

        public IEnumerable<RoomBookings> OrderedRooms()
        {
            var orderedRooms = _Context.RoomBookings.OrderBy(p => p.CreateDate).Where(p => p.IsDeleted == null || (p.IsDeleted != true) && (p.IsLeave == false || p.IsLeave == null) && (p.IsBooked == true || p.IsBooked == null) && (p.IsBookedOnline == true || p.IsBookedOnline == null)).OrderBy(p => p.CreateDate);

            return orderedRooms;
        }

        public IEnumerable<RoomBookings> GetOrderedRoomsByHotelId(string hotelId)
        {
            var orderedRooms = _Context.RoomBookings.Where(p => p.HotelId == Guid.Parse(hotelId) && (p.IsDeleted != true) && (p.IsLeave == false || p.IsLeave == null) && (p.IsBooked == true || p.IsBooked == null) && (p.IsBookedOnline == true || p.IsBookedOnline == null)).OrderBy(p => p.CreateDate);
            return orderedRooms;
        }

        public IEnumerable<HallBookings> OrderedHalls()
        {
            var orderedHalls = _Context.HallBookings.OrderBy(p => p.CreateDate).Where(p => p.IsDeleted == null);
            return orderedHalls;
        }

        public IEnumerable<HallBookings> GetOrderedHallsByHotelId(string hotelId)
        {
            var orderedHalls = _Context.HallBookings.OrderBy(p => p.CreateDate).Where(p => p.HotelId == Guid.Parse(hotelId) && (p.IsDeleted == null || p.IsDeleted != true) && (p.IsLeave == null || p.IsLeave == false) && (p.IsBooked == true)).ToList();// && (p.IsBookedOnline == true || p.IsBookedOnline == null));
            return orderedHalls;
        }
        //public IEnumerable<HotelBookings> GetOrderedHotelsByHotelId(string hotelId)
        //{
        //    //var orderedHoltes = _Context.HotelBookings.OrderBy(p => p.CreateDate).Where(p => p.HotelId == Guid.Parse(hotelId) &&
        //    //p.IsDeleted != true &&
        //    //p.IsDeleted == null);

        //    var orderedHoltes = _Context.Hotels.Where(p => p.Id == Guid.Parse(hotelId) &&
        //    p.IsDeleted != true &&
        //    p.IsDeleted == null);

        //    return orderedHoltes;
        //}
        public void BookTable(TableBookings tableBooking)
        {
            tableBooking.Id = Guid.NewGuid();
            _Context.TableBookings.Add(tableBooking);
            _Context.SaveChanges();
        }

        public RoomBookings GetRoomBookingById(Guid id)
        {
            var roomOrder = _Context.RoomBookings.SingleOrDefault(p => p.Id == id);
            return roomOrder;
        }

        public HallBookings GetHallBookingById(Guid id)
        {
            var hallOrder = _Context.HallBookings.SingleOrDefault(p => p.Id == id);
            return hallOrder;
        }

        public TableBookings GetTableBookingById(Guid id)
        {
            var tableOrder = _Context.TableBookings.SingleOrDefault(p => p.Id == id);
            return tableOrder;
        }

        public void BookRoom(RoomBookings roomBooking)
        {
            roomBooking.Id = Guid.NewGuid();
            _Context.RoomBookings.Add(roomBooking);
            _Context.SaveChanges();
        }
        public void EditRoomOrder(RoomBookings model)
        {
            _Context.Update(model);
            _Context.SaveChanges();
        }

        public void EditHallOrder(HallBookings model)
        {
            HallBookings hallBooking = _Context.HallBookings.Where(x => x.Id == model.Id).FirstOrDefault();

            if (hallBooking != null)
            {
                hallBooking.Id = model.Id;
                hallBooking.UserId = model.UserId;
                hallBooking.ContactNo = model.ContactNo;
                hallBooking.Email = model.Email;
                hallBooking.HallId = model.HallId;
                hallBooking.Name = model.Name;

                _Context.Update(hallBooking);
                _Context.SaveChanges();
            }
        }


        public void CheckOutHallOrder(HallBookings model)
        {
            HallBookings hallBooking = _Context.HallBookings.Where(x => x.Id == model.Id).FirstOrDefault();

            if (hallBooking != null)
            {
                //CheckOutHall
                hallBooking.CheckInDate = model.CheckInDate;
                hallBooking.CheckInTime = model.CheckInTime;
                hallBooking.CheckOutDate = model.CheckOutDate;
                hallBooking.UserId = model.UserId;
                hallBooking.CheckOutTime = model.CheckOutTime;

                hallBooking.HotelId = model.HotelId;
                hallBooking.BuildingId = model.BuildingId;
                hallBooking.FloorId = model.FloorId;
                hallBooking.HallId = model.HallId;

                hallBooking.CreateDate = model.CreateDate.HasValue ? model.CreateDate.Value : DateTime.Now;

                hallBooking.Fare = model.Fare;
                hallBooking.IsPaid = model.IsPaid;
                hallBooking.RemainingAmount = model.RemainingAmount;
                hallBooking.TotalBill = model.TotalBill;
                hallBooking.DiscountAmount = model.DiscountAmount;
                hallBooking.IsLeave = model.IsLeave;
                hallBooking.Id = model.Id;
                hallBooking.PaidAmount = model.PaidAmount;
                hallBooking.DaysCount = model.DaysCount;
                hallBooking.TotalFare = model.TotalFare;

                _Context.Update(hallBooking);
                _Context.SaveChanges();
            }
        }
        public void BookHall(HallBookings hallBooking)
        {
            // hallBooking.Id = Guid.NewGuid();
            // hallBooking.CreateDate = DateTime.UtcNow.AddHours(5);
            _Context.HallBookings.Add(hallBooking);
            _Context.SaveChanges();
        }
        public void BookHotel(HotelBookings hotelBooking)
        {
            hotelBooking.Id = Guid.NewGuid();
            hotelBooking.CreateDate = DateTime.UtcNow.AddHours(5);
            _Context.HotelBookings.Add(hotelBooking);
            _Context.SaveChanges();
        }

        IEnumerable<HotelBookings> IBookingRepository.OrderedHotels()
        {
            throw new NotImplementedException();
        }

        public void DeleteRoomJoinServices(Guid roomId)
        {
            var roomJoinServices = _Context.RoomJoinService.Where(x => x.RoomId == roomId);

            if (roomJoinServices != null && roomJoinServices.Count() > 0)
            {
                _Context.RoomJoinService.RemoveRange(roomJoinServices);
                _Context.SaveChanges();
            }
        }

        public void DeleteHallJoinServices(Guid hallId)
        {
            var hallJoinServices = _Context.HallJoinService.Where(x => x.HallId == hallId);

            if (hallJoinServices != null && hallJoinServices.Count() > 0)
            {
                _Context.HallJoinService.RemoveRange(hallJoinServices);
                _Context.SaveChanges();
            }
        }

        public void DeleteTableJoinServices(Guid table)
        {
            var tableJoinServices = _Context.TableJoinService.Where(x => x.TableId == table);

            if (tableJoinServices != null && tableJoinServices.Count() > 0)
            {
                _Context.TableJoinService.RemoveRange(tableJoinServices);
                _Context.SaveChanges();
            }
        }
    }
}
