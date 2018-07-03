using System;
using Mogre;

using PhysicsEng;

namespace Game
{
    class EnemyModel : CharacterModel
    {
        /// <summary>
        /// PUT THE ENEMY MODEL ON TO A SEPERATE NODE FROM THE PLAYER MODEL. 
        /// </summary>
        PhysObj physObj;

        protected ModelElement enemy;
        ///Entity robotEntity;

        /// <summary>
        /// return variable of set the enemy as a value
        /// </summary>
        public ModelElement Robot
        {
            get { return enemy; }
            set { enemy = value; }
        }



        protected Gun gun;

        /// <summary>
        /// return variable of gun
        /// </summary>
        public Gun Gun
        {
            get { return gun; }
        }


        /// <summary>
        /// Contains part of the model and loads the model elements.
        /// </summary>
        virtual protected void LoadModelElement()
        {
            enemy = new ModelElement(mSceneMgr, "robot.mesh");
            gameNode = mSceneMgr.CreateSceneNode();
            gameNode.AddChild(enemy.GameNode);
            enemy.GameEntity.GetMesh().BuildEdgeList();
        }



        /// <summary>
        /// Enemy model constructor which contains a scene Manager
        /// </summary>
        /// <param name="mSceneMgr"></param>
        public EnemyModel(SceneManager mSceneMgr)
        {
            this.mSceneMgr = mSceneMgr;
            LoadModelElement();
            
        }



        /// <summary>
        /// Animate method to animate the enemy model
        /// </summary>
        /// <param name="evt"></param>
        virtual protected void Animate(FrameEvent evt)
        {


        }

        /// <summary>
        /// Update method which updates Animate. 
        /// </summary>
        /// <param name="evt"></param>
        virtual public void Update(FrameEvent evt)
        {
            Animate(evt);
        }
        
        /// <summary>
        /// Disposes of the enemy model. 
        /// </summary>
        virtual protected void Dispose()
        {
            if (enemy != null)
            {
                enemy.Dispose(); 
            }

        }

    }
}

