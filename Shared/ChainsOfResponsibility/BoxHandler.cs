using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared.ChainsOfResponsibility
{
    public class BoxHandler : IStructureHandler
    {
        private IStructureHandler nextHandler;

        List<IStructure> structures = new List<IStructure>();
        public void SetNext(IStructureHandler handler)
        {
            nextHandler = handler;
        }

        public List<IStructure> HandleRequest(params object[] parameters)
        {
            int startX = (int)parameters[0];
            int startY = (int)parameters[1];
            int length = (int)parameters[2];
            int powerUp = (int)parameters[3];
            List<IStructure> structures = new List<IStructure>();
            // Check if this handler can handle the request for creating boxes
            if (length != 0)
            {
                var boxFactory = new BoxFactory();
                return new List<IStructure> { boxFactory.CreateStructure(startX, startY, length, powerUp)};
            }
            else if (nextHandler != null)
            {
                // Pass the request to the next handler in the chain
                return nextHandler.HandleRequest(parameters);
            }
            else
            {
                // No handler found to handle this request
                return new List<IStructure>(); // Or handle the case appropriately
            }
        }
    }
}
