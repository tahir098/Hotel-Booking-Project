using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FizzBook.HotelModels
{
    public partial class FizzHotleBookingContext : DbContext
    {
        public FizzHotleBookingContext()
        {
        }

        public FizzHotleBookingContext(DbContextOptions<FizzHotleBookingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Buildings> Buildings { get; set; }
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Companies> Companies { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<ExpenseTypes> ExpenseTypes { get; set; }
        public virtual DbSet<Expenses> Expenses { get; set; }
        public virtual DbSet<Facilities> Facilities { get; set; }
        public virtual DbSet<Floors> Floors { get; set; }
        public virtual DbSet<Hall> Hall { get; set; }
        public virtual DbSet<HallBookings> HallBookings { get; set; }
        public virtual DbSet<HallJoinService> HallJoinService { get; set; }
        public virtual DbSet<HallServiceBooking> HallServiceBooking { get; set; }
        public virtual DbSet<HotelBookings> HotelBookings { get; set; }
        public virtual DbSet<HotelExpenTypes> HotelExpenTypes { get; set; }
        public virtual DbSet<HotelExpense> HotelExpense { get; set; }
        public virtual DbSet<HotelOfficerRoles> HotelOfficerRoles { get; set; }
        public virtual DbSet<HotelOfficers> HotelOfficers { get; set; }
        public virtual DbSet<HotelTypes> HotelTypes { get; set; }
        public virtual DbSet<Hotels> Hotels { get; set; }
        public virtual DbSet<MenuRights> MenuRights { get; set; }
        public virtual DbSet<Menues> Menues { get; set; }
        public virtual DbSet<Officers> Officers { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<RoomBookings> RoomBookings { get; set; }
        public virtual DbSet<RoomJoinService> RoomJoinService { get; set; }
        public virtual DbSet<RoomServiceBooking> RoomServiceBooking { get; set; }
        public virtual DbSet<RoomServices> RoomServices { get; set; }
        public virtual DbSet<RoomTypes> RoomTypes { get; set; }
        public virtual DbSet<Rooms> Rooms { get; set; }
        public virtual DbSet<Route> Route { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<TableBookings> TableBookings { get; set; }
        public virtual DbSet<TableJoinService> TableJoinService { get; set; }
        public virtual DbSet<TableServiceBooking> TableServiceBooking { get; set; }
        public virtual DbSet<Tables> Tables { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=FizzHotleBooking;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Buildings>(entity =>
            {
                entity.ToTable("Buildings", "Hotel");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.ImageUrl).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Cities>(entity =>
            {
                entity.ToTable("Cities", "Setup");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CityName).HasMaxLength(200);

                entity.Property(e => e.Description).HasMaxLength(500);
            });

            modelBuilder.Entity<Companies>(entity =>
            {
                entity.ToTable("Companies", "Setup");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AddressOne).HasMaxLength(500);

                entity.Property(e => e.AddressTwo).HasMaxLength(500);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.CompanyName).HasMaxLength(50);

                entity.Property(e => e.CompanySite).HasMaxLength(50);

                entity.Property(e => e.ContactNo).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.PostCode).HasMaxLength(10);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.UserFirstName).HasMaxLength(50);

                entity.Property(e => e.UserLastName).HasMaxLength(50);
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.ToTable("Countries", "Hotel");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<ExpenseTypes>(entity =>
            {
                entity.ToTable("ExpenseTypes", "Hotel");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ExpenseType)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Expenses>(entity =>
            {
                entity.ToTable("Expenses", "Hotel");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.ExpenseDescription)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.ExpenseType)
                    .WithMany(p => p.Expenses)
                    .HasForeignKey(d => d.ExpenseTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Expenses_ExpenseTypes");
            });

            modelBuilder.Entity<Facilities>(entity =>
            {
                entity.ToTable("Facilities", "Hotel");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FacilityName).HasMaxLength(50);
            });

            modelBuilder.Entity<Floors>(entity =>
            {
                entity.ToTable("Floors", "Hotel");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FloorNo).HasMaxLength(50);

                entity.Property(e => e.ImageUrl).HasMaxLength(500);
            });

            modelBuilder.Entity<Hall>(entity =>
            {
                entity.ToTable("Hall", "Hotel");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Fare).HasColumnType("money");

                entity.Property(e => e.Height).HasMaxLength(50);

                entity.Property(e => e.ImageUrl).HasMaxLength(500);

                entity.Property(e => e.Length).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.RoomSize).HasMaxLength(50);

                entity.Property(e => e.Width)
                    .HasColumnName("width")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<HallBookings>(entity =>
            {
                entity.ToTable("HallBookings", "Bookings");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CheckInDate).HasColumnType("date");

                entity.Property(e => e.CheckOutDate).HasColumnType("date");

                entity.Property(e => e.ContactNo).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DiscountAmount).HasColumnType("money");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Fare).HasColumnType("money");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PaidAmount).HasColumnType("money");

                entity.Property(e => e.RemainingAmount).HasColumnType("money");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.TotalBill).HasColumnType("money");

                entity.Property(e => e.TotalFare).HasColumnType("money");
            });

            modelBuilder.Entity<HallJoinService>(entity =>
            {
                entity.HasKey(e => new { e.HallId, e.HallServiceBookingId });

                entity.ToTable("HallJoinService", "Bookings");
            });

            modelBuilder.Entity<HallServiceBooking>(entity =>
            {
                entity.ToTable("HallServiceBooking", "Bookings");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<HotelBookings>(entity =>
            {
                entity.ToTable("HotelBookings", "Bookings");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CheckInDate).HasColumnType("date");

                entity.Property(e => e.CheckOutDate).HasColumnType("date");

                entity.Property(e => e.ContactNo).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DiscountAmount).HasColumnType("money");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Fare).HasColumnType("money");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.TotalBill).HasColumnType("money");
            });

            modelBuilder.Entity<HotelExpenTypes>(entity =>
            {
                entity.ToTable("HotelExpenTypes", "Hotel");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ExpenseType)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<HotelExpense>(entity =>
            {
                entity.ToTable("HotelExpense", "Hotel");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.ExpenseDescription)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.ExpenseType)
                    .WithMany(p => p.HotelExpense)
                    .HasForeignKey(d => d.ExpenseTypeId)
                    .HasConstraintName("FK_HotelExpense_HotelExpenTypes");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.HotelExpense)
                    .HasForeignKey(d => d.HotelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HotelExpense_Hotels");
            });

            modelBuilder.Entity<HotelOfficerRoles>(entity =>
            {
                entity.ToTable("HotelOfficerRoles", "Hotel");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HotelOfficers>(entity =>
            {
                entity.ToTable("HotelOfficers", "Hotel");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.HotelOfficers)
                    .HasForeignKey(d => d.HotelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HotelOfficers_Hotels");

                entity.HasOne(d => d.HotelOfficerRole)
                    .WithMany(p => p.HotelOfficers)
                    .HasForeignKey(d => d.HotelOfficerRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HotelOfficers_HotelOfficerRoles");
            });

            modelBuilder.Entity<HotelTypes>(entity =>
            {
                entity.ToTable("HotelTypes", "Setup");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Hotels>(entity =>
            {
                entity.ToTable("Hotels", "Hotel");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.HotelAddress).HasMaxLength(1000);

                entity.Property(e => e.HotelEmail).HasMaxLength(100);

                entity.Property(e => e.HotelLogo).HasMaxLength(200);

                entity.Property(e => e.HotelMobile).HasMaxLength(50);

                entity.Property(e => e.HotelName)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.HotelPhone).HasMaxLength(50);

                entity.Property(e => e.HotelWebsite).HasMaxLength(50);

                entity.Property(e => e.ImageUrl).HasMaxLength(500);

                entity.HasOne(d => d.HotelCity)
                    .WithMany(p => p.Hotels)
                    .HasForeignKey(d => d.HotelCityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Hotels_Cities");
            });

            modelBuilder.Entity<MenuRights>(entity =>
            {
                entity.ToTable("MenuRights", "Setup");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Menues>(entity =>
            {
                entity.ToTable("Menues", "Setup");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Action).HasMaxLength(500);

                entity.Property(e => e.Area).HasMaxLength(500);

                entity.Property(e => e.Controller).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(500);
            });

            modelBuilder.Entity<Officers>(entity =>
            {
                entity.ToTable("Officers", "Hotel");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Mobile).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.UserName).HasMaxLength(100);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Officers)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Officers_Roles");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.ToTable("Roles", "Hotel");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<RoomBookings>(entity =>
            {
                entity.ToTable("RoomBookings", "Bookings");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CheckInDate).HasColumnType("date");

                entity.Property(e => e.CheckOutDate).HasColumnType("date");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DiscountAmount).HasColumnType("money");

                entity.Property(e => e.FarePerNight).HasColumnType("money");

                entity.Property(e => e.PaidAmount).HasColumnType("money");

                entity.Property(e => e.RemainingAmount).HasColumnType("money");

                entity.Property(e => e.TotalBill).HasColumnType("money");

                entity.Property(e => e.TotalFare).HasColumnType("money");
            });

            modelBuilder.Entity<RoomJoinService>(entity =>
            {
                entity.HasKey(e => new { e.RoomId, e.RoomServiceBookingId });

                entity.ToTable("RoomJoinService", "Bookings");
            });

            modelBuilder.Entity<RoomServiceBooking>(entity =>
            {
                entity.ToTable("RoomServiceBooking", "Bookings");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<RoomServices>(entity =>
            {
                entity.ToTable("RoomServices", "Hotel");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.RoomServices)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoomServices_Rooms");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.RoomServices)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoomServices_Services");
            });

            modelBuilder.Entity<RoomTypes>(entity =>
            {
                entity.ToTable("RoomTypes", "Setup");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<Rooms>(entity =>
            {
                entity.ToTable("Rooms", "Hotel");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.DiscountAmount).HasColumnType("money");

                entity.Property(e => e.FarePerNight).HasColumnType("money");

                entity.Property(e => e.ImageUrl).HasMaxLength(500);

                entity.Property(e => e.RoomNo).HasMaxLength(50);

                entity.Property(e => e.RoomView).HasMaxLength(200);
            });

            modelBuilder.Entity<Route>(entity =>
            {
                entity.ToTable("Route", "Travel");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FromCity).HasMaxLength(50);

                entity.Property(e => e.ToCity).HasMaxLength(50);
            });

            modelBuilder.Entity<Services>(entity =>
            {
                entity.ToTable("Services", "Hotel");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ServiceName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TableBookings>(entity =>
            {
                entity.ToTable("TableBookings", "Bookings");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CheckInDate).HasColumnType("date");

                entity.Property(e => e.CheckInTime).HasColumnType("time(0)");

                entity.Property(e => e.CheckOutDate).HasColumnType("date");

                entity.Property(e => e.CheckOutTime).HasColumnType("time(0)");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DiscountAmount).HasColumnType("money");

                entity.Property(e => e.FarePerHour).HasColumnType("money");

                entity.Property(e => e.IsPaid).HasColumnType("money");

                entity.Property(e => e.IsRemaining).HasColumnType("money");

                entity.Property(e => e.PaidAmount).HasColumnType("money");

                entity.Property(e => e.RemainingAmount).HasColumnType("money");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.TotalBill).HasColumnType("money");

                entity.Property(e => e.TotalFare).HasColumnType("money");
            });

            modelBuilder.Entity<TableJoinService>(entity =>
            {
                entity.HasKey(e => new { e.TableId, e.TableServiceBookingId });

                entity.ToTable("TableJoinService", "Bookings");
            });

            modelBuilder.Entity<TableServiceBooking>(entity =>
            {
                entity.ToTable("TableServiceBooking", "Bookings");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<Tables>(entity =>
            {
                entity.ToTable("Tables", "Hotel");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FarePerHour).HasColumnType("money");

                entity.Property(e => e.ImageUrl).HasMaxLength(500);

                entity.Property(e => e.TableNo).HasMaxLength(50);

                entity.Property(e => e.TableView).HasMaxLength(50);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("Users", "Bookings");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cnic)
                    .HasColumnName("CNIC")
                    .HasMaxLength(13);

                entity.Property(e => e.ContactNo).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
