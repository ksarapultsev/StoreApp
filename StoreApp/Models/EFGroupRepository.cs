using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Models
{
    public class EFGroupRepository
    {
        private StoreContext context;
        public EFGroupRepository(StoreContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Group> Groups => context.Groups;
    }
}
