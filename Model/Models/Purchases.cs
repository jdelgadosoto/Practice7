﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Purchases
    {
        [Key]
        public int PurchaseId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
