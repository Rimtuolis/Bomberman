using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared.ChainsOfResponsibility
{
    public interface IStructureHandler
    {
        List<IStructure> HandleRequest(params object[] parameters);
        void SetNext(IStructureHandler handler);
    }
}
