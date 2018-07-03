using System;
using System.Collections.Generic;
using Mogre; 

namespace Game
{
    class Ground
    {
        Plane plane;
        MeshPtr groundMeshPtr; 

        SceneManager mSceneMgr;

        SceneNode groundNode;
        Entity groundEntity;

        int groundWidth = 10;
        int groundHeight = 10;
        int groundXSegs = 1;
        int groundZSegs = 1;
        int uTiles = 10;
        int vTiles = 10; 

        protected Ground ground; 

        /// <summary>
        /// returns plane value.
        /// </summary>
        public Plane Plane
        {
            get { return plane; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mSceneMgr">A reference of the scene manager</param>
        public Ground(SceneManager mSceneMgr)
        {

            this.mSceneMgr = mSceneMgr;
            groundWidth = 2000;
            groundHeight = 2000;


            plane = new Plane(Vector3.UNIT_Y, -10);
            groundMeshPtr = MeshManager.Singleton.CreatePlane("floor", ResourceGroupManager.DEFAULT_RESOURCE_GROUP_NAME, plane, groundWidth, groundHeight, 100, 100, true, 0, 10, 10, Vector3.UNIT_Z);
            //Console.WriteLine(groundMeshPtr.)


            GroundMaterial();
            groundEntity = mSceneMgr.CreateEntity("floor");

            groundNode = mSceneMgr.CreateSceneNode();
            groundNode.AttachObject(groundEntity);
            mSceneMgr.RootSceneNode.AddChild(groundNode);

            groundEntity.SetMaterialName("Ground");
           
            //this.plane = new Plane(Vector3.UNIT_Y, 0);

        }

        /// <summary>
        /// Assigns materials and textures for the ground. 
        /// </summary>
        private void GroundMaterial()
        {
            using (MaterialPtr groundMat = MaterialManager.Singleton.Create("Cube",
                    ResourceGroupManager.DEFAULT_RESOURCE_GROUP_NAME))
            {
                using (TextureUnitState fieldTexture =
                    groundMat.GetTechnique(0).GetPass(0).CreateTextureUnitState("Floor.jpg"))
                {
                    ///cube.SetMaterialName("Quad", "Cube");
                }
            }
        }


        /// <summary>
        /// This method disposes of the scene node and enitity
        /// </summary>
        public void Dispose()
        {
            groundNode.DetachAllObjects();
            groundNode.Parent.RemoveChild(groundNode);
            groundNode.Dispose();
            groundEntity.Dispose(); 
        }
    }
}
