using System;
using System.Threading.Tasks;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Interfaces.Business.Groups;
using Mahzan.Business.Resources.Validations.Groups;
using Mahzan.Business.Results.Groups;
using Mahzan.DataAccess.DTO.Groups;
using Moq;

namespace Mahzan.Factories.Business.Validations.Groups
{
    public static class AddNewGroupValidationsFactory
    {
        #region Public Methods

        /// <summary>
        /// Mock, pasa todas las validaciones al intentar crear un Grupo.
        /// </summary>
        /// <param name="addGroupsDto"></param>
        /// <returns></returns>
        public static Mock<IGroupsValidations> CreateMockIGroupsValidations(AddGroupsDto addGroupsDto)
        {
            Mock<IGroupsValidations> mock = new Mock<IGroupsValidations>();

            //Validacioón al agregar
            mock.Setup(p => p.AddGroupsValid(addGroupsDto))
                .ReturnsAsync(ReturnsAddGroupsValid());


            return mock;
        }
        /// <summary>
        /// Mock, el nombre que se esta intentando crear ya existe.
        /// </summary>
        /// <param name="addGroupsDto"></param>
        /// <returns></returns>
        public static Mock<IGroupsValidations> CreateMockIGroupsValidationsNameExist(AddGroupsDto addGroupsDto)
        {
            Mock<IGroupsValidations> mock = new Mock<IGroupsValidations>();

            //Validacioón al agregar
            mock.Setup(p => p.AddGroupsValid(addGroupsDto))
                .ReturnsAsync(ReturnsAddGroupsValidNameExist());


            return mock;
        }

        #endregion

        #region Private Methods

        private static AddGroupsResult ReturnsAddGroupsValid()
        {
            return new AddGroupsResult
            {
                IsValid = true
            };
        }

        private static AddGroupsResult ReturnsAddGroupsValidNameExist()
        {
            return new AddGroupsResult
            {
                IsValid = false,
                ResultTypeEnum = ResultTypeEnum.WARNING,
                Message = AddGroupsValidationsResources.AddMembersValid_500_WARNING_Message
            };
        }

        #endregion
    }
}
