﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Models
{
    public class User
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public long GroupId { get; set; }
        public DateTime RecordDateTimeStamp { get; set; }
    }
}
