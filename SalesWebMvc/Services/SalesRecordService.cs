using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
namespace SalesWebMvc.Services
{
    public class SalesRecordService
    {
        private readonly SalesWebMvcContext _context;

        public SalesRecordService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var salesRecords = from sales in _context.SalesRecord select sales;

            if (minDate.HasValue)
            {
                salesRecords = salesRecords.Where(salesRecords => salesRecords.Date >= minDate);
            }

            if (maxDate.HasValue)
            {
                salesRecords = salesRecords.Where(salesRecords => salesRecords.Date <= maxDate);
            }

            return await salesRecords
                            .Include(salesRecords => salesRecords.Seller)
                            .Include(salesRecords => salesRecords.Seller.Department)
                            .OrderByDescending(x => x.Date)
                            .ToListAsync();
        }
    }
}
