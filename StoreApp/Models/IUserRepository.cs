using System;
using System.Collections.Generic;
using System.Linq;


namespace StoreApp.Models
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }
    }
}
