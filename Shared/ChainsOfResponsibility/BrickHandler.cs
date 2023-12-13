using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared.ChainsOfResponsibility
{
    public class BrickHandler : IStructureHandler
    {
        private IStructureHandler nextHandler;

        public void SetNext(IStructureHandler handler)
        {
            nextHandler = handler;

        }

        public List<IStructure> HandleRequest(params object[] parameters)
        {
            string structureType = (string)parameters[0];
            int x = (int)parameters[1];
            int y = (int)parameters[2];
            int size = (int)parameters[3];

            // Check if this handler can handle the request for creating bricks
            if (structureType.Equals("brickwall"))
            {
                var factory = new StructureFactory();
                return new List<IStructure> { factory.CreateStructure("brickwall", x, y, size) };
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
