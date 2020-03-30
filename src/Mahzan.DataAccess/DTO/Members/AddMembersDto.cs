using System;
namespace Mahzan.DataAccess.DTO.Members
{
    public class AddMembersDto
    {
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public Guid AspNetUsersId { get; set; }

        public Guid? MembersPatternId { get; set; }
    }
}
