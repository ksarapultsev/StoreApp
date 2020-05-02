using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Models
{
    public class Users
    {
        public long userId { get; set; }
        public string userName { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public long groupId { get; set; }
        public DateTime RecordDateTimeStamp { get; set; }
    }
}
