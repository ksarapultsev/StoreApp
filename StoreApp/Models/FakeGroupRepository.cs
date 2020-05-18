using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Models
{
    public class FakeGroupRepository : IGroupRepository
    {
        public IQueryable<Group> Groups => new List<Group>
        {
            new Group { GroupId = 1, Description = "Administrator", GroupName ="admin", RecordDateTimeStamp=DateTime.Now},
            new Group { GroupId = 2, Description = "User", GroupName ="user", RecordDateTimeStamp=DateTime.Now}
           
        }.AsQueryable<Group>();

        IQueryable<Group> IGroupRepository.Groups { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
