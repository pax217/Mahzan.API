using System;
using Mahzan.Business.Interfaces.Business.Groups;
using Mahzan.DataAccess.DTO.Groups;
using Moq;

namespace Mahzan.Factories.Business.Implementations.Groups
{
    public static class AddNewGroupRepositoriesFactory
    {

        public static Mock<IGroupsRepositories> CreateMockIGroupsRepositories(AddGroupsDto addGroupsDto)
        { 
            Mock<IGroupsRepositories> mock = new Mock<IGroupsRepositories>();

            //Agrega Grupo
            mock.Setup(p => p.AddGroup(addGroupsDto))
                .ReturnsAsync(ReturnsAddGroup(addGroupsDto));

            return mock;
        }

        /// <summary>
        /// Regresa un Grupo creado con base en AddGroupsDto
        /// </summary>
        /// <param name="addGroupsDto"></param>
        /// <returns></returns>
        private static Models.Entities.Groups ReturnsAddGroup(AddGroupsDto addGroupsDto) 
        {
            return new Models.Entities.Groups
            {
                GroupsId = Guid.NewGuid(),
                Name = addGroupsDto.Name,
                MembersId = addGroupsDto.MembersId
            };
        }
    }
}
