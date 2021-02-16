﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Core.Entities;


namespace Entities.Concrete
{
    public class Car:IEntity
    {
        public int Id { get; set; }
        public string CarName { get; set; }

        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int ModelYear { get; set; }
        public long DailyPrice { get; set; }
        public string Description { get; set; }
    }
}
