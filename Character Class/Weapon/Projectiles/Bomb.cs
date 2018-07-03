using System;
using Mogre;

using PhysicsEng;
using System.Collections.Generic;


namespace Game

  
{
    class Bomb : Projectile
    {

        PhysObj physObj;
        PlayerStats playerStats;

        protected ModelElement bomb;

        /// <summary>
        /// Gets the return value of bomb and sets the bomb as a value 
        /// </summary>
        public ModelElement BombModel
        {
            get { return bomb; }
            set { bomb = value; }
        }

        /// <summary>
        /// Calls the player stats gameNode and load model in the constructor. 
        /// </summary>
        /// <param name="mSceneMgr"></param>
        /// <param name="playerStats"></param>
        public Bomb(SceneManager mSceneMgr, PlayerStats playerStats)
        {
            this.mSceneMgr = mSceneMgr;
            gameNode = mSceneMgr.CreateSceneNode();
            this.playerStats = playerStats;


            LoadModel();
        }

        /// <summary>
        /// The Load model element holds the physics of the object and the parts used to make the bombs. 
        /// removeMe method is set to false until it is colliding with something. 
        /// </summary>
        protected void LoadModelElement()
        {
            removeMe = false;

            bomb = new ModelElement(mSceneMgr, "Bomb.mesh");
        

            gameNode.Scale(2, 2, 2);

            physObj = new PhysObj(15, "Bomb", 0.1f, 0.01f, 0.5f);
            physObj.SceneNode = gameNode;

            physObj.AddForceToList(new WeightForce(physObj.InvMass));

            Physics.AddPhysObj(physObj);
        }

        /// <summary>
        /// Assembles the parts of the model and puts them together. 
        /// </summary>
        virtual protected void AssembleModel()
        {
            gameNode.AddChild(bomb.GameNode);
            mSceneMgr.RootSceneNode.AddChild(this.gameNode);
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
        /// If isActive is true it calls Collision method. 
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
        /// The model gets removed if it is colliding with the player. 
        /// </summary>
        public void Collision()
        {
            removeMe = IsCollidingWith("Player");
            if (removeMe == true)
            {
                isActive = false;

            }
        }
        /// <summary>
        /// This affects the player stats on collision by destroying the shield first, then the health and lives. 
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

                    if (playerStats.Shield.Value > 0)
                        playerStats.Shield.Decrease(20);
                    Console.WriteLine(playerStats.Shield.Value);

                    if (playerStats.Shield.Value <= 0)
                     ((PlayerStats)playerStats).Health.Decrease(30);
                    Console.WriteLine(playerStats.Health.Value);

                    if (playerStats.Health.Value <= 0)
                    {
                        ((PlayerStats)playerStats).Lives.Decrease(1);
                        ((PlayerStats)playerStats).Health.Increase(100);
                        Console.WriteLine(playerStats.Lives.Value);
                    }
                    Dispose();

                    break;
                }
            }
            return isColliding;
        }

        /// <summary>
        /// This disposes the model once it collides with the player. 
        /// </summary>
        public override void Dispose()
        {

            Physics.RemovePhysObj(physObj);
            physObj = null;

            gameNode.Parent.RemoveChild(bomb.GameNode);
            bomb.GameNode.DetachAllObjects();
            bomb.GameNode.Dispose();
            bomb.Dispose();

        }
    }
}
