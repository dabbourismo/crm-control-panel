using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models
{
    /// <summary>
    /// Represents Main App Clients
    /// </summary>
    public class Client
    {
        public int Id { get; set; }

        [StringLength(120)]
        public string Name { get; set; }

        public string Speciality { get; set; }

        public string Company { get; set; }

        [StringLength(15)]
        public string Phone1 { get; set; }

        [StringLength(15)]
        public string Phone2 { get; set; }

        [StringLength(25)]
        public string City { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        public List<Order> Orders { get; set; }

        public int Rating { get; set; }
    }
}