using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Data.Models
{
    public class Group
    {
        public long GroupId { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }
        public DateTime RecordDateTimeStamp { get; set; }

        public ICollection<User> Users { get; set; }

        
    }
}
