﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModels
{
   public class ShoppingCartViewModel
    {
        public IEnumerable<ShoppingCart> ListCart { get; set; }
        public OrderHeader OrderHeader { get; set; }
    }
}
