using System;
using System.Collections.Generic;

namespace BaltaDataAccess.Models
{
    public class Career
    {
        public Career()
        {
            CareerItems = new List<CareerItem>();
        }

        public Guid id { get; set; }
        public string? Title { get; set; }
        public IList<CareerItem> CareerItems { get; set; }
    }
}