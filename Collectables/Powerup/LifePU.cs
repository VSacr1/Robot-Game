using System;
using Mogre;

using PhysicsEng;

namespace Game
{
    class LifePU : Powerup
    {

        PhysObj physObj;

        protected ModelElement lifePuModel;

        /// <summary>
        /// Gets the return value of lifePuModel and sets the value. 
        /// </summary>
        public ModelElement LifePuModel
        {
            get { return lifePuModel; }
            set { lifePuModel = value; }
        }

        /// <summary>
        /// This constructor increases the stat life by the value specified and contains the load model.
        /// </summary>
        /// <param name="life"></param>
        /// <param name="mSceneMgr"></param>
        public LifePU(Stat life, SceneManager mSceneMgr)
        {
            this.mSceneMgr = mSceneMgr;
            gameNode = mSceneMgr.CreateSceneNode();
            this.stat = life; 

            LoadModel();
            increase = 1; 
        }



        /// <summary>
        /// Contains the parts of the model and gives the model physics. 
        /// </summary>
        protected void LoadModelElement()
        {
            removeMe = false;

            lifePuModel = new ModelElement(mSceneMgr, "Heart.mesh");
            lifePuModel.GameEntity.SetMaterialName("Red");

            gameNode.Scale(7, 7, 7);

            physObj = new PhysObj(15, "Life", 0.1f, 0.01f, 0.5f);
            physObj.SceneNode = gameNode;

            physObj.AddForceToList(new WeightForce(physObj.InvMass));

            Physics.AddPhysObj(physObj);
        }

        /// <summary>
        /// Assembles the model together.
        /// </summary>
        virtual protected void AssembleModel()
        {
            gameNode.AddChild(lifePuModel.GameNode);
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
        protected override void LoadModel()
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
            //removeMe = IsCollidingWith("Player");
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
            }
        }
        /// <summary>
        /// If colliding with the player the lives increases by the increase value set in the constructor. 
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
                    stat.Increase(increase);
                    Dispose();

                    break;
                }
            }
            return isColliding;
        }

        /// <summary>
        /// Disposes of the physics and the model. 
        /// </summary>
        public override void Dispose()
        {

            Physics.RemovePhysObj(physObj);
            physObj = null;

            gameNode.Parent.RemoveChild(lifePuModel.GameNode);
            lifePuModel.GameNode.DetachAllObjects();
            lifePuModel.GameNode.Dispose();
            lifePuModel.Dispose(); 

        }

    }
}
