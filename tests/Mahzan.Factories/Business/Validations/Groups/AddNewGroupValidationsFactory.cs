using System;
using System.Threading.Tasks;
using Mahzan.Business.Interfaces.Business.Groups;
using Mahzan.Business.Results.Groups;
using Mahzan.DataAccess.DTO.Groups;
using Moq;

namespace Mahzan.Factories.Business.Validations.Groups
{
    public static class AddNewGroupValidationsFactory
    {
        public static Mock<IGroupsValidations> CreateMockIGroupsValidations(AddGroupsDto addGroupsDto)
        {
            Mock<IGroupsValidations> mock = new Mock<IGroupsValidations>();

            //Validacioón al agregar
            mock.Setup(p => p.AddGroupsValid(addGroupsDto))
                .ReturnsAsync(ReturnsAddGroupsValid());


            return mock;
        }

        private static AddGroupsResult ReturnsAddGroupsValid()
        {
            return new AddGroupsResult
            {
                IsValid = true
            };
        }
    }
}
