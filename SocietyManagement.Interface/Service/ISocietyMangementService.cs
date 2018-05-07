using System;
using System.Collections.Generic;
using System.Text;
using SocietyManagement.Domain.Entities;

namespace SocietyManagement.Interface.Service
{
    public interface ISocietyMangementService
    {
        List<Members> GetAllMembers();
        void AddMembers(Domain.Models.Member member);

        IEnumerable<Domain.Models.Visitors> GetVisitors(int flatId);
        IEnumerable<Domain.Models.Society> GetSocietyList();
        IEnumerable<Domain.Models.SocietyFlat> GetFlatsBySociety(int societyId);
        Domain.Models.ProfileDetails GetProfileDetails(string userName, string password);
        void AddFamilyMember(Domain.Models.Member member);
    }
}
