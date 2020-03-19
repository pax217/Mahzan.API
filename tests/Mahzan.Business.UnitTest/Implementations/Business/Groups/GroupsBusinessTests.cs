using System;
using System.Threading.Tasks;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Implementations.Business.Groups;
using Mahzan.Business.Interfaces.Business.Groups;
using Mahzan.Business.Resources.Validations.Groups;
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

        /// <summary>
        /// Agrega un Grupo de froma exitosa.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Intenta crear un grupo con el mismo nombre
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Add_New_Group_Same_Name()
        {
            //AddGroupsDto
            AddGroupsDto addGroupsDto = AddGroupsDtoFactory.GetAddGroupsDtoValid();

            //Repositories
            Mock<IGroupsRepositories> mockIGroupsRepositories = AddNewGroupRepositoriesFactory
                                                                .CreateMockIGroupsRepositories(addGroupsDto);
            //Validations
            Mock<IGroupsValidations> mockIGroupsValidations = AddNewGroupValidationsFactory
                                                              .CreateMockIGroupsValidationsNameExist(addGroupsDto);
            //Business
            GroupsBusiness groupsBusiness = new GroupsBusiness(mockIGroupsRepositories.Object,
                                                               mockIGroupsValidations.Object);

            //Method
            AddGroupsResult result = await groupsBusiness
                                           .Add(addGroupsDto);

            //Condiciónes de Prueba
            Assert.NotNull(result);
            Assert.False(result.IsValid);
            Assert.Equal(ResultTypeEnum.WARNING, result.ResultTypeEnum);
            Assert.Equal(AddGroupsValidationsResources.AddMembersValid_500_WARNING_Message, result.Message);

        }

    }
}
