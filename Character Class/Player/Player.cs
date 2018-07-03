using System;
using Mogre;
using PhysicsEng;
using System.Collections.Generic;

namespace Game
{
    class Player : Character
    {

        //SceneNode controlNode;

        /// <summary>
        /// This applies the physic engine to the player model. 
        /// It calls a new model, controller, stats and armoury in its constructor taken from the player classes. 
        /// </summary>
        /// <param CharacterModel="model"></param>
        /// <param CharacterController="controller"></param>
        /// <param CharacterStats="stats"></param>

        public Player(/*CharacterModel model, */ /*CharacterController controller,*/ /*CharacterStats stats,*/ SceneManager mSceneMgr)
        {
            model = new PlayerModel(mSceneMgr);
            controller = new PlayerController(this, mSceneMgr);
            stats = new PlayerStats();
            armoury = new Armoury();


            float radius = 15;

            model.GameNode.Position += radius * Vector3.UNIT_Y;
            model.GameNode.Position -= radius * Vector3.UNIT_Y;

            physObj = new PhysObj(radius, "Player", 0.1f, 0.02f, 0.3f);
            physObj.SceneNode = model.GameNode;
            physObj.Position = model.GameNode.Position;
            physObj.AddForceToList(new WeightForce(physObj.InvMass));
            Physics.AddPhysObj(physObj);

            physObj.SceneNode = model.GameNode;
            
        }

        /// <summary>
        /// This is a collision method. 
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
                }
            }
            return isColliding;
        }

        /// <summary>
        /// The update method calls the updates from the controller and the models animation. 
        /// </summary>
        /// <param name="evt"></param>
        public override void Update(FrameEvent evt) 
        {
            controller.Update(evt);
            model.Animate(evt);

            if (stats.Lives.Value == 0)
            {
                model.Dispose();
                model.GameNode.Dispose();
                
            }


            //if (stats.shield.InitValue(0))
            //{
            //    stats.health.Decrease(10);
            //}

            //if (stats.health.InitValue(0))
            //{
            //    stats.lives.Decrease(0);
            //    stats.health.Increase(100);
            //    stats.shield.Increase(100);
            //}


            if (armoury.GunChange)
            {
                ((PlayerModel)model).AttachGun(armoury.ActiveGun);
                armoury.GunChange = false; 
            }

         
        }

        public override void Shoot()
        {
            armoury.ActiveGun.Fire();
            

        }

        public void Dispose()
        {

        }

        /// <summary>
        /// This is the Update method which Updates the Animate events. 
        /// </summary>
        /// <param Update="evt"></param>
       
    }


}
