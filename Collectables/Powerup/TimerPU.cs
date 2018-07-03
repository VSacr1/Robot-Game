using System;
using Mogre;

using PhysicsEng;

namespace Game
{
    class TimerPU : Powerup
    {
        SceneManager mSceneMgr;
        GameInterface gameInterface; 

        PhysObj physObj;
        Physics physics;

        PlayerStats time;


        protected ModelElement timerPuModel;

        /// <summary>
        /// Gets the return value of timePuModel and sets the value. 
        /// </summary>
        public ModelElement TimerPuModel
        {
            get { return timerPuModel; }
            set { timerPuModel = value; }
        }
        /// 
        /// </summary>
        /// <param name="life"></param>
        /// <param name="mSceneMgr"></param>


        /// <summary>
        /// This constructor increases the stat shield by the value specified and contains the load model.
        /// </summary>
        /// <param name="gameInterface"></param>
        /// <param name="mSceneMgr"></param>
        public TimerPU(SceneManager mSceneMgr, GameInterface gameInterface)
        {
            this.mSceneMgr = mSceneMgr;
            this.gameInterface = gameInterface;

            gameNode = mSceneMgr.CreateSceneNode();


            LoadModel();
            increase = 12000; 
        }



        /// <summary>
        /// Contains the parts of the model and gives the model physics. 
        /// </summary>
        protected void LoadModelElement()
        {
            removeMe = false;

            timerPuModel = new ModelElement(mSceneMgr, "knot.mesh");
            timerPuModel.GameEntity.SetMaterialName("Red");

            gameNode.Scale(0.1f, 0.1f, 0.1f);

            physObj = new PhysObj(15, "Time", 0.1f, 0.01f, 0.5f);
            physObj.SceneNode = gameNode;

            physObj.AddForceToList(new WeightForce(physObj.InvMass));

            Physics.AddPhysObj(physObj);
        }

        /// <summary>
        /// Assembles the model together.
        /// </summary>
        virtual protected void AssembleModel()
        {
            gameNode.AddChild(timerPuModel.GameNode);
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
        /// Update method and sets the collision if isActive = true. 
        /// </summary>
        /// <param name="evt"></param>
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
        /// If colliding with the player the time increases by the increase value set in the constructor. 
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
                    gameInterface.TimeExtra = gameInterface.TimeExtra + increase;
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

            gameNode.Parent.RemoveChild(timerPuModel.GameNode);
            timerPuModel.GameNode.DetachAllObjects();
            timerPuModel.GameNode.Dispose();
            timerPuModel.Dispose(); 

        }

    }
}
