using SocietyManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocietyManagement.Domain.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CurrentCity { get; set; }
        public string HomeTown { get; set; }
        public string OccupationType { get; set; }
        public string CompanyName { get; set; }
        public string MobileNumber { get; set; }
        public FlatMemberType FlatMemberTypeId { get; set; }
        //public int Id { get; set; }
        public int SocietyFlatId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public bool IsLoogedinUser { get; set; }

        public static implicit operator Domain.Entities.Members(Domain.Models.Member member)
        {
            return new Domain.Entities.Members
            {
                CompanyName = member.CompanyName,
                CurrentCity = member.CurrentCity,
                FirstName = member.FirstName,
                FlatMemberTypeId = (int)member.FlatMemberTypeId,
                HomeTown = member.HomeTown,
                LastName = member.LastName,
                MobileNumber = member.MobileNumber,
                OccupationType = member.OccupationType,
                UserName = member.UserName,
                Password = member.Password,
                RoleId = (int)Role.Normal,
                SocietyFlatId = member.SocietyFlatId
            };
        }

    }

}
