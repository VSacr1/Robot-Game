using System;
using Mogre;


using PhysicsEng;

using System.Collections.Generic;

namespace Game
{
    class RedGem : Gem
    {
        /// <summary>
        /// Inherits from the Gem class 
        /// </summary>

        Radian angle;
        Vector3 direction;
        float radius;


        protected ModelElement redGemModel;

        /// <summary>
        ///  Gets the return value of blueGemModel and sets the value. 
        /// </summary>
        public ModelElement RedGemModel
        {
            get { return redGemModel; }
            set { redGemModel = value; }
        }

        /// <summary>
        /// Gives the RedGem a decrease value and a angle to rotate the model. Also contains the loads the model. 
        /// </summary>
        /// <param name="score"></param>
        /// <param name="mSceneMgr"></param>
        public RedGem(Stat score, SceneManager mSceneMgr)
        {

            this.mSceneMgr = mSceneMgr;
            gameNode = mSceneMgr.CreateSceneNode();
            this.score = score;

            LoadModel();

            decrease = 20;
            angle = 20;
        }

        /// <summary>
        /// Contains the parts of the model and gives it physics. 
        /// </summary>
        virtual protected void LoadModelElement()
        {

            removeMe = false;
            
            redGemModel = new ModelElement(mSceneMgr, "Gem.mesh");
            redGemModel.GameEntity.SetMaterialName("Red");

            gameNode.Scale(2, 2, 2);

            physObj = new PhysObj(15, "RedGem", 0.1f, 0.01f, 0.3f);
            physObj.SceneNode = gameNode;

            physObj.AddForceToList(new WeightForce(physObj.InvMass));

            Physics.AddPhysObj(physObj);
        }

        /// <summary>
        /// Assembles the model together. 
        /// </summary>
        virtual protected void AssembleModel()
        {
            gameNode.AddChild(redGemModel.GameNode);
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

            if(isActive == true)
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
            if (removeMe == true)
            {
                isActive = false;

                //score.Increase(increase); 
                //Dispose();

            }
        }

        /// <summary>
        /// If colliding with the player the score decrease by the decrease value set in the constructor. 
        /// </summary>
        /// <param name="objName"></param>
        /// <returns></returns>
        private bool IsCollidingWith(string objName)
        {
            bool isColliding = false;
            foreach (Contacts c in physObj.CollisionList)
            {
                if (c.colliderObj.ID == objName || c.colliderObj.ID == objName)
                {
                    isColliding = true;
                    score.Decrease(decrease);
                    Console.WriteLine(score.Value);
                    Dispose();

                    break;
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
            redGemModel.GameNode.Yaw(-evt.timeSinceLastFrame);
        }

        /// <summary>
        /// Disposes of the physics and the model. 
        /// </summary>
        public override void Dispose()
        {
          

            Physics.RemovePhysObj(physObj);
            physObj = null;

            gameNode.Parent.RemoveChild(redGemModel.GameNode);
            redGemModel.GameNode.DetachAllObjects();
            redGemModel.GameNode.Dispose();
            redGemModel.Dispose();
        }

    }
}
