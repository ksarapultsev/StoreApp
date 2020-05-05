using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Models
{
    public class EFUserRepository : IUserRepository
    {
        private StoreContext context;
        public EFUserRepository(StoreContext ctx)
        {
            context = ctx;
        }

        public IQueryable<User> Users => context.Users;
    }
}
