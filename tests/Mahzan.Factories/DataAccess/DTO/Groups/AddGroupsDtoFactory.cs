using System;
using Mahzan.DataAccess.DTO.Groups;

namespace Mahzan.Factories.DataAccess.DTO.Groups
{
    public static class AddGroupsDtoFactory
    {
        public static AddGroupsDto GetAddGroupsDtoValid()
        {
            return new AddGroupsDto
            {
                Name = "Grupo Mahzan",
                MembersId = Guid.NewGuid()
            };
        }
    }
}
