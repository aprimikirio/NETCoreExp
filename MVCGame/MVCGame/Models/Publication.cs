﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCGame.Models
{
    public class Publication
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImageName { get; set; }
    }
}
