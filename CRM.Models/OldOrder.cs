using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Models
{
    /// <summary>
    /// Stores disabled orders prices to allow re opening
    /// </summary>
    public class OldOrder
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public decimal OldPrice { get; set; }
    }
}
