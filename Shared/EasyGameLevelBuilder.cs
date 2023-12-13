using BomberGopnik.Shared.ChainsOfResponsibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public class EasyGameLevelBuilder : IGameLevelBuilder
    {
        private GameLevel level = new GameLevel();
        private StructureFactory factory = new StructureFactory();
        private IStructureHandler boxHandler;
        private IStructureHandler brickHandler;
        
        public EasyGameLevelBuilder()
        {
           
            boxHandler = new BoxHandler();
            brickHandler = new BrickHandler();

            
            boxHandler.SetNext(brickHandler);
        }
        public void BuildBoxes()
        {

            level.Boxes = boxHandler.HandleRequest(10, 10, 30, 1);
            level.Boxes.AddRange(boxHandler.HandleRequest(30, 30, 30, 0));
            level.Boxes.AddRange(boxHandler.HandleRequest(20, 40, 30, 0));
            level.Boxes.AddRange(boxHandler.HandleRequest(70, 50, 30, 0));
           
        }

        public void BuildBricks()
        {

            level.Bricks = brickHandler.HandleRequest("brickwall", 20, 20, 10);
            level.Bricks.AddRange(brickHandler.HandleRequest("brickwall", 40, 40, 30));
            level.Bricks.AddRange(brickHandler.HandleRequest("brickwall", 80, 80, 30));
            level.Bricks.AddRange(brickHandler.HandleRequest("brickwall", 60, 60, 30));
        }

        public GameLevel GetResult()
        {
            return level;
        }
    }
}
