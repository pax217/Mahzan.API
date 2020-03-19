using Mahzan.Business.Implementations.Validations.Groups;
using Mahzan.Business.Interfaces.Business.Groups;
using Mahzan.Business.Results.Groups;
using Mahzan.DataAccess.DTO.Groups;
using Mahzan.DataAccess.Interfaces;
using Mahzan.Factories.Business.Validations.Groups;
using Mahzan.Factories.DataAccess.DTO.Groups;
using Mahzan.Factories.DataAccess.Implementations.Groups;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Mahzan.Business.UnitTest.Implementations.Validations.Groups
{
    public class AddGroupsValidationsTests
    {
        public AddGroupsValidationsTests() 
        {
        
        }

        [Fact]
        public async Task Add_Group_Valid_Succesfull() 
        {
            //AddGroupsDto
            AddGroupsDto addGroupsDto = AddGroupsDtoFactory.GetAddGroupsDtoValid();

            //IGroupsRepository
            Mock<IGroupsRepository> mock = GroupsRepositoryFactory
                                           .CreateMockIGroupsRepository();

            //Validation
            AddGroupsValidations addGroupsValidations = new AddGroupsValidations(mock.Object);

            //Method
            AddGroupsResult result = await addGroupsValidations.AddGroupsValid(addGroupsDto);

            //Asserts Test
            Assert.NotNull(result);
            Assert.True(result.IsValid);
        }

    }
}
