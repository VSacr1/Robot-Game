using System;
using System.Collections.Generic;
using Mogre;

using PhysicsEng;

namespace Game
{
    class PlayerModel : CharacterModel
    {
        PhysObj physObj;
        Physics physics;


        protected ModelElement sphere; 
        /// <summary>
        /// Returns the Model Element known sphere and sets it as a value
        /// </summary>
        public ModelElement Sphere
        {
            get { return sphere; }
            set { sphere = value; }
        }

        /// <summary>
        /// Returns the Model Element known as body and sets it as a value
        /// </summary>
        protected ModelElement  body;
        public ModelElement Body
        {
            get { return body; }
            set { body = value; }
        }

        protected ModelElement powerCells;

        /// <summary>
        /// Returns the Model Element known as powerCells and sets it as a value; 
        /// </summary>
        public ModelElement PowerCells
        {
           get { return powerCells; }
           set { powerCells = value; }
        }


        protected GunGroupNode gunGroupNode; 

        /// <summary>
        /// This gets the return value of the gunGroupNode. 
        /// </summary>
        public GunGroupNode GunGroupNode
        {
            get { return gunGroupNode; }
        }

        //SceneNode playerNode;

        
            /// <summary>
            /// The constructor holds LoadModelElement and Assembles model and contains a mSceneMgr in its parameters. 
            /// This is used to load the model in to the player class. 
            /// </summary>
            /// <param name="mSceneMgr"></param>
        public PlayerModel(SceneManager mSceneMgr)
        {
            this.mSceneMgr = mSceneMgr;
            gameNode = mSceneMgr.CreateSceneNode();
            LoadModelElements();
            AssembleModel();
        }
        /// <summary>
        /// This loads the model elements which is a sphere mesh and a body mesh for the player. 
        /// </summary>
        protected override void LoadModelElements() {
            sphere = new ModelElement(mSceneMgr, "Sphere.mesh");
            body = new ModelElement(mSceneMgr, "Main.mesh");
            powerCells = new ModelElement(mSceneMgr, "PowerCells.mesh");

            body.GameEntity.GetMesh().BuildEdgeList();
            sphere.GameEntity.GetMesh().BuildEdgeList();
            //body.GetMesh().BuildEdgeList();
            //gunGroupNode = new ModelElement(mSceneMgr);
            ///EMPTY NODE WITH NO NAME. PlayerNode. 
            ///gameNode = mSceneMgr.CreateSceneNode(); 


        }

        /// <summary>
        /// Allows me to set the position of the gameNode. 
        /// </summary>
        /// <param name="position"></param>
        public override void SetPosition(Vector3 position)
        {
            gameNode.Translate(position);
        }

        /// <summary>
        /// This assembles the model by attaching the sphere, powercells and body to the game node. 
        /// </summary>
         protected override void AssembleModel() {

            gameNode.AddChild(body.GameNode);
            gameNode.AddChild(sphere.GameNode);
            gameNode.AddChild(powerCells.GameNode);

            mSceneMgr.RootSceneNode.AddChild(this.gameNode);

            this.gunGroupNode = new GunGroupNode(mSceneMgr);
            gameNode.AddChild(gunGroupNode.GameNode);

            //Physics.AddPhysObj(physObj);
            
        }
        
        /// <summary>
        /// Allows me to move the gameNodes position which is attached to the player. 
        /// </summary>
        /// <param name="move"></param>
        public override void Move(Vector3 move)
        {
            this.gameNode.Position += move;
            //Console.WriteLine("Move in playerModel Class");
        }

        /// <summary>
        /// Attaches a gun to the player and contains a try and catch method to see if it successfully attaches the gun. 
        /// </summary>
        /// <param name="gun"></param>
        public void AttachGun(Gun gun)
        {
            if (gunGroupNode.GameNode.NumChildren() != 0)
            {
                gunGroupNode.GameNode.RemoveAllChildren();
            }
            try
            {
                gunGroupNode.GameNode.AddChild(gun.GameNode);
            }
            catch (System.AccessViolationException)
            { }
        }

        /// <summary>
        /// This code Disposes the sphere, body and gameNode of the playerModel object. 
        /// </summary>
        public override void Dispose()
        {

            if (sphere != null)
            {
                sphere.Dispose();
            }

            if (body != null)
            {
                body.Dispose();
            }

            if (gameNode != null)
            {
                gameNode.Dispose();
            }

            if(powerCells != null)
            {
                powerCells.Dispose(); 
            }

            Physics.RemovePhysObj(physObj);
            physObj = null;
        }

    }
}
