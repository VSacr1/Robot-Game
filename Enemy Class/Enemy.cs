using System;
using Mogre;

using PhysicsEng;


namespace Game
{
    class Enemy : Character
    {

        EnemyMovement movement;
        PlayerStats playerStats;
        SceneNode controlNode;

        /// <summary>
        /// Puts together the components of the enemy and gives it physics. 
        /// </summary>
        /// <param name="model"></param>
        public Enemy(SceneManager mSceneMgr, PlayerStats playerStats) ///EnemyMovement movement)
        {
            this.model = new EnemyModel(mSceneMgr);
            this.movement = new EnemyMovement(this,(EnemyModel)model);
            this.stats = new EnemyStat();

            //controlNode = mSceneMgr.CreateSceneNode();
            //controlNode.AddChild(model.GameNode);
            mSceneMgr.RootSceneNode.AddChild(model.GameNode);

            //model.GameNode.Position += 0 * Vector3.UNIT_Y;
            //model.GameNode.Position -= 20 * Vector3.UNIT_Y;

            physObj = new PhysObj(20, "Robot", 0.1f, 0.2f, 0.5f);
            physObj.SceneNode = model.GameNode;
            ///model.GameNode.AddChild(physObj.SceneNode);
            physObj.Position = model.GameNode.Position;
            physObj.AddForceToList(new WeightForce(physObj.InvMass));
            Physics.AddPhysObj(physObj);

            this.playerStats = playerStats;
        }

        /// <summary>
        /// returns the variable movement
        /// </summary>
        public EnemyMovement Movement
        {
            get{ return movement; }
        }

        /// <summary>
        /// Set the posiiton of the object. 
        /// </summary>
        /// <param name="position"></param>
        public  void SetPosition(Vector3 position)
        {

            physObj.Position = model.GameNode.Position;
            model.GameNode.Position = position;
            physObj.Position = position;

        }
        /// <summary>
        /// Uses the fire method the armoury to perform a shoot action
        /// </summary>
        public override void Shoot()
        {
            armoury.ActiveGun.Fire();
        }
        /// <summary>
        /// Updates the player model and checks if 
        /// </summary>
        /// <param name="evt"></param>
        public override void Update(FrameEvent evt)
        {
            ((EnemyModel)model).Update(evt);
            IsCollidingWith("Player");
            physObj.SceneNode.Position = model.GameNode.Position;
            physObj.Position = model.GameNode.Position;
        }

        /// <summary>
        /// Is called in the update method and disposes of the object if it is colliding with the player. 
        /// </summary>

        /// <summary>
        /// If colliding with the player the health increases by the increase value set in the constructor. 
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
                    {
                        playerStats.Shield.Decrease(1);
                    }

                    if (playerStats.Shield.Value <= 0)
                    {
                        playerStats.Health.Decrease(1);
                    }

                    if (playerStats.Health.Value <= 0)
                    {
                        playerStats.Lives.Decrease(1);
                    }

                    break;
                }
            }
            return isColliding;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objName"></param>
        /// <returns></returns>

        ///WHILE SIGNAL IS TRUE ANIMATE WHILE SIGNAL IS FALSE DONT ANIMATE.  BOOLEAN
    }
}
