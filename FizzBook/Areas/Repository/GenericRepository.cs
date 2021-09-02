using FizzBook.HotelModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBook.Areas.Repository
{
    public class GenericRepository : IGenericRepository
    {
        private FizzHotleBookingContext _Context;

        public GenericRepository(FizzHotleBookingContext Context)
        {
            _Context = Context;
        }
        public async Task<bool> Add(Object EntityType)
        {
            await _Context.AddAsync(EntityType);
            await _Context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Update(Object EntityType)
        {
            _Context.Update(EntityType);
            await _Context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Delete(Object EntityType)
        {
            _Context.Remove(EntityType);
            await _Context.SaveChangesAsync();
            return true;
        }

    }
}
