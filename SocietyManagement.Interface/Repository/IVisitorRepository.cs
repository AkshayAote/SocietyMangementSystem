using SocietyManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocietyManagement.Interface.Repository
{
    public interface IVisitorRepository
    {
        bool RecordVisitor(Domain.Entities.Visitors visitor);
        int AddImageOfIdProof(Domain.Entities.Image image);

    }
}
