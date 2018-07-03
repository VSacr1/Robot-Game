using System;
using Mogre;

using PhysicsEng;

namespace Game
{
    class CannonBall : Projectile
    {
        SceneManager mSceneMgr;
        Enemy enemy; 

        /// <summary>
        /// This constructor calls a max time for when it gets disposed causes a health damage and shield damage to th enemy model. 
        /// </summary>
        /// <param name="mSceneMgr"></param>
        public CannonBall(SceneManager mSceneMgr)
        {
            this.mSceneMgr = mSceneMgr;
            maxTime = 100;
            healthDamage = 30;
            shieldDamage = 100;

            speed = 100;
            LoadModel();
            Console.WriteLine("Bomb Created");
            Console.WriteLine(GameNode.Position);

           
        }

        protected ModelElement cannonBall;

        /// <summary>
        /// get the return value of ModelElement cannonBall and sets the value. 
        /// </summary>
        public ModelElement CannonBallModel
        {
            get { return cannonBall; }
            set { cannonBall = value; }
        }

        /// <summary>
        /// The Load model element holds the physics of the object and the parts used to make the bombs. 
        /// removeMe method is set to false until it is colliding with something. 
        /// </summary>
        virtual protected void LoadModelElement()
        {
            removeMe = false; 

            cannonBall = new ModelElement(mSceneMgr, "Sphere.mesh");
            cannonBall.GameEntity.SetMaterialName("black");
            gameNode = mSceneMgr.CreateSceneNode();

            gameNode.Scale(0.5f, 0.5f, 0.5f);

            physObj = new PhysObj(20, "CannonBall", 0.1f, 0.01f, 0.5f);
            physObj.SceneNode = gameNode;

            physObj.AddForceToList(new WeightForce(physObj.InvMass));

            Physics.AddPhysObj(physObj);
        }

        /// <summary>
        /// Assembles the parts of the model and puts them together. 
        /// </summary>
        virtual protected void AssembleModel()
        {
            gameNode.AddChild(cannonBall.GameNode);
            mSceneMgr.RootSceneNode.AddChild(gameNode);
        }

        /// <summary>
        /// Sets the position of the gameNode and physObj. 
        /// </summary>
        /// <param name="position"></param>
        public override void SetPosition(Vector3 position)
        {
            gameNode.Position = position;
            physObj.Position = position;
        }

        /// <summary>
        /// Loads the model by calling the LoadModelElement and AssembleModel methods. 
        /// </summary>
        protected override void LoadModel()
        {
            base.LoadModel();
            LoadModelElement();
            AssembleModel(); 
        }

        bool isActive = true; 

        /// <summary>
        /// 
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
            removeMe = IsCollidingWith("Robot");
            if (removeMe == true)
            {
                isActive = false;

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
                        enemy.Model.Dispose(); 
                        Dispose();

                        break;
                    }
                }
            }

            return isColliding;
        }
        /// <summary>
        /// Disposes the model, physics and gameNode. 
        /// </summary>
        virtual protected void Dispose()
        {
            if(cannonBall != null)
            {
                cannonBall.Dispose(); 
            }
            
            if(gameNode != null)
            {
                gameNode.Dispose(); 
            }

            Physics.RemovePhysObj(physObj);
            physObj = null;
        }
    }
}
