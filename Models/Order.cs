using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homework_51_1.Models
{
    public class Order

    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string ContactPhone { get; set; }



        public int PhoneId { get; set; }

        public Phone Phone { get; set; }

    }
}
