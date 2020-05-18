using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Models
{
    public interface IGroupRepository
    {
        IQueryable<Group> Groups { get; set; }
    }
}
