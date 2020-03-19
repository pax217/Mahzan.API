using System;
using System.Threading.Tasks;
using Mahzan.Business.Implementations.Business.Groups;
using Mahzan.Business.Interfaces.Business.Groups;
using Mahzan.Business.Results.Groups;
using Mahzan.DataAccess.DTO.Groups;
using Mahzan.Factories.Business.Implementations.Groups;
using Mahzan.Factories.Business.Validations.Groups;
using Mahzan.Factories.DataAccess.DTO.Groups;
using Moq;
using Xunit;

namespace Mahzan.Business.UnitTest.Implementations.Business.Groups
{
    public class GroupsBusinessTests
    {
        public GroupsBusinessTests()
        {
        }

        [Fact]
        public async Task Add_New_Group_Successfull()
        {
            //AddGroupsDto
            AddGroupsDto addGroupsDto = AddGroupsDtoFactory.GetAddGroupsDtoValid();

            //Repositories
            Mock<IGroupsRepositories> mockIGroupsRepositories = AddNewGroupRepositoriesFactory
                                                                .CreateMockIGroupsRepositories(addGroupsDto);

            //Validations
            Mock<IGroupsValidations> mockIGroupsValidations = AddNewGroupValidationsFactory
                                                              .CreateMockIGroupsValidations(addGroupsDto);

            //Business
            GroupsBusiness groupsBusiness = new GroupsBusiness(mockIGroupsRepositories.Object,
                                                               mockIGroupsValidations.Object);

            //Method
            AddGroupsResult result = await groupsBusiness
                                           .Add(addGroupsDto);

            //Condiciónes de Prueba
            Assert.NotNull(result);
            Assert.True(result.IsValid);
            Assert.Equal(addGroupsDto.Name, result.Group.Name);
            Assert.Equal(addGroupsDto.MembersId, result.Group.MembersId);
        }
    }
}
