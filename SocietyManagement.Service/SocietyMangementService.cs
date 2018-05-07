using System;
using System.Collections.Generic;
using System.Text;
using SocietyManagement.Domain.Entities;
using SocietyManagement.Interface.Repository;
using SocietyManagement.Interface.Service;

namespace SocietyManagement.Service
{
    public class SocietyMangementService: ISocietyMangementService
    {
        private readonly ISocietyMangementRepository _societyMangementRepository;

        public SocietyMangementService(ISocietyMangementRepository societyMangementRepository)
        {
            _societyMangementRepository = societyMangementRepository;
        }

        public List<Members> GetAllMembers()
        {
            return _societyMangementRepository.GetAllMembers();
        }

        public void AddMembers(Domain.Models.Member member)
        {
            _societyMangementRepository.AddFlatMember(member);
        }

        public IEnumerable<Domain.Models.Visitors> GetVisitors(int flatId)
        {
            return _societyMangementRepository.GetVisitors(flatId);
        }
        public IEnumerable<Domain.Models.Society> GetSocietyList()
        {
            return _societyMangementRepository.GetSocietyList();
        }
        public IEnumerable<Domain.Models.SocietyFlat> GetFlatsBySociety(int societyId)
        {
            return _societyMangementRepository.GetFlatsBySociety(societyId);
        }
        public Domain.Models.ProfileDetails GetProfileDetails(string userName, string password)
        {
            return _societyMangementRepository.GetProfileDetails(userName, password);
        }

        public void AddFamilyMember(Domain.Models.Member member)
        {
            _societyMangementRepository.AddFamilyMember(member);
        }
    }
}
