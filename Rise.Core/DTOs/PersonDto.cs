﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rise.Core.DTOs
{
    public class PersonDto :BaseDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FirmName { get; set; }
    }
}
