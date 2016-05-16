using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVC6_App.Models
{
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }

    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int UserNumber { get; set; }
        public int CustomerId { get; set; }
        public virtual Customers Customers { get; set; }
    }
}
