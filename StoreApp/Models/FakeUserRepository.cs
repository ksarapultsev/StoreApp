using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Models
{
    public class FakeUserRepository : IUserRepository
    {
        public IQueryable<User> Users => new List<User>
        {
            new User {UserName = "Kos", UserId = 1, UserLogin="kos", UserPassword = "kos", RecordDateTimeStamp=DateTime.Now},
            new User {UserName = "Kos2", UserId = 2, UserLogin="kos2", UserPassword = "kos2", RecordDateTimeStamp=DateTime.Now}
        }.AsQueryable<User>();
    }
}
