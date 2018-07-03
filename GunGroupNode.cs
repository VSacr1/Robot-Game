using System;
using System.Collections.Generic;
using Mogre; 
namespace Game
{
    class GunGroupNode
    {
        protected SceneNode gameNode;
        /// <summary>
        /// Advangtage of doing this is to make everything do only that one thing and to avoid coupling. 
        /// Had a piece of text in the instruction which was decided to take literally and create this class. 
        /// This class only purpose is to fufill the gun game node method specified in the tutorial in lab 5.coursework section Collectible gun and Armoury class. 
        /// COME BACK TO THIS INCASE OF EMERGENCY IF HAVE TIME. 
        /// </summary>
        public SceneNode GameNode
        {
            get { return gameNode; }
        }

        public GunGroupNode(SceneManager mSceneMgr)
        {
            this.gameNode = mSceneMgr.CreateSceneNode();
        }
    }
}
