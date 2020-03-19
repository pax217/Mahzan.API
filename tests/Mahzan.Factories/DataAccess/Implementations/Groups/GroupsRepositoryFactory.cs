using Mahzan.DataAccess.DTO.Groups;
using Mahzan.DataAccess.Interfaces;
using Mahzan.DataAccess.Paging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Factories.DataAccess.Implementations.Groups
{
    public static class GroupsRepositoryFactory
    {

        public static Mock<IGroupsRepository> CreateMockIGroupsRepository() 
        {
            Mock<IGroupsRepository> mock = new Mock<IGroupsRepository>();

            mock.Setup(p => p.Get(It.IsAny<GetGroupsDto>()))
                .ReturnsAsync(ReturnsGetGroups());

            return mock;
        }

        private static PagedList<Models.Entities.Groups> ReturnsGetGroups() 
        {
            return new PagedList<Models.Entities.Groups>(new List<Models.Entities.Groups>(),0,0,0);
        }
    }
}
