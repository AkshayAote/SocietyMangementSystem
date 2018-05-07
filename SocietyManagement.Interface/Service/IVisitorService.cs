using SocietyManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocietyManagement.Interface.Service
{
    public interface IVisitorService
    {
        bool RecordVisitor(Visitors visitor);
        int AddImage(string imageData);
    }
}
