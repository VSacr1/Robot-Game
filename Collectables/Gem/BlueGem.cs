using System;
using Mogre;

using PhysicsEng;

using System.Collections.Generic;

namespace Game
{
    class BlueGem : Gem
    {
        /// <summary>
        /// Inherits from the Gem class 
        /// </summary>

        Radian angle;
        Vector3 direction;
        float radius;

        protected ModelElement blueGemModel;

        /// <summary>
        /// Gets the return value of blueGemModel and sets the value. 
        /// </summary>
        public ModelElement BlueGemModel
        {
            get { return blueGemModel; }
            set { blueGemModel = value; }
        }

        /// <summary>
        /// Gives the BlueGem a increase value and a angle to rotate the model. Also contains the loads the model. 
        /// </summary>
        /// <param name="score"></param>
        /// <param name="mSceneMgr"></param>
        public BlueGem(Stat score, SceneManager mSceneMgr)
        {

            this.mSceneMgr = mSceneMgr;
            gameNode = mSceneMgr.CreateSceneNode();
            this.score = score;

            LoadModel();
   

            increase = 10;
            angle = 20;

        }

        /// <summary>
        /// Contains the parts of the model and gives it physics. 
        /// </summary>
        virtual protected void LoadModelElement()
        {
            removeMe = false;
            blueGemModel = new ModelElement(mSceneMgr, "Gem.mesh");

            gameNode.Scale(2, 2, 2);

            physObj = new PhysObj(15, "Gem", 0.1f, 0.01f, 0.3f);
            physObj.SceneNode = gameNode;


            physObj.AddForceToList(new WeightForce(physObj.InvMass));

            Physics.AddPhysObj(physObj);

        }

        /// <summary>
        /// Assembles the model together. 
        /// </summary>
        virtual protected void AssembleModel()
        {
            gameNode.AddChild(blueGemModel.GameNode);
            mSceneMgr.RootSceneNode.AddChild(this.gameNode);
        }

        /// <summary>
        /// Set the position of the gameNode and physObj. 
        /// </summary>
        /// <param name="position"></param>
        public override void SetPosition(Vector3 position)
        {
            gameNode.Position = position; 
            physObj.Position = position;

        }

        /// <summary>
        /// Loads the model. 
        /// </summary>
        public override void LoadModel()
        {
            base.LoadModel();

            LoadModelElement();
            AssembleModel();

        }

        bool isActive = true;


        /// <summary>
        /// Update method and sets the collision if isActive = true. 
        /// </summary>
        /// <param name="evt"></param>
        public override void Update(FrameEvent evt)
        {
            if (isActive == true)
            {
                Collision();
                
                
            }
        }

        /// <summary>
        /// Is called in the update method and disposes of the object if it is colliding with the player. 
        /// </summary>
        public void Collision()
        {
            removeMe = IsCollidingWith("Player");
            if(removeMe == true)
            {
                isActive = false;
                //score.Increase(increase); 
                //Dispose();
            }
        }

        /// <summary>
        /// If colliding with the player the score increases by the increase value set in the constructor. 
        /// </summary>
        /// <param name="objName"></param>
        /// <returns></returns>
         private bool IsCollidingWith(string objName)
          {
            bool isColliding = false;
            if (physObj != null)
            {
                foreach (Contacts c in physObj.CollisionList)
                {
                    if (c.colliderObj.ID == objName || c.collidingObj.ID == objName)
                    {
                        isColliding = true;
                        score.Increase(increase);
                        Dispose();

                        break;
                    }
                }
            }
            
            return isColliding;
          }

        /// <summary>
        /// Animates the model by spinning. 
        /// </summary>
        /// <param name="evt"></param>
        public override void Animate(FrameEvent evt)
        {
            angle += (Radian)evt.timeSinceLastFrame;
            direction = radius * new Vector3(Mogre.Math.Cos(angle), 0, Mogre.Math.Sin(angle));
            blueGemModel.GameNode.Yaw(-evt.timeSinceLastFrame);
        }
      

        /// <summary>
        /// Disposes of the physics and the model. 
        /// </summary>
        public override void Dispose()
        {
            Physics.RemovePhysObj(physObj);
            physObj = null;

            
            gameNode.Parent.RemoveChild(blueGemModel.GameNode);
            blueGemModel.GameNode.DetachAllObjects();
            blueGemModel.GameNode.Dispose();
            blueGemModel.Dispose();


        }

    }
}
