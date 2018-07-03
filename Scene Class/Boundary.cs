using System;
using System.Collections.Generic;
using Mogre;

using PhysicsEng;

namespace Game
{
    class Boundary
    {
        SceneManager mSceneMgr;
        MeshPtr borderMeshPtr;
        MeshPtr borderMeshPtr2;
        MeshPtr borderMeshPtr3;
        MeshPtr borderMeshPtr4; 

        Entity borderEntity;
        SceneNode borderNode;

        Entity borderEntity2;

        Entity borderEntity3;

        Entity borderEntity4;

        int borderHeight = 10;
        int borderWidth = 10;

        Plane plane1;
        Plane plane2;
        Plane plane3;
        Plane plane4;

        Physics physics;
        PhysObj physObj;

        /// <summary>
        /// returns planes used for boundaries
        /// </summary>
        protected Boundary boundary; 

        public Plane Plane1
        {
            get { return plane1; }
        }

        public Plane Plane2
        {
            get { return plane2; }
        }

        public Plane Plane3
        {
            get { return plane3;  }
        }

        public Plane Plane4
        {
            get { return plane4; }
        }

        /// <summary>
        /// Sets the boundary height and width and creates the boundary. 
        /// </summary>
        /// <param name="mSceneMgr"></param>
        public Boundary(SceneManager mSceneMgr)
        {
            this.mSceneMgr = mSceneMgr;
            borderHeight = 100;
            borderWidth = 2000;

            plane1 = new Plane(Vector3.UNIT_Z, -1000);
            borderMeshPtr = MeshManager.Singleton.CreatePlane("border", ResourceGroupManager.DEFAULT_RESOURCE_GROUP_NAME, plane1, borderWidth, borderHeight, 100,100, true, 0, 10, 10, Vector3.UNIT_Y);

            plane2 = new Plane(Vector3.UNIT_X, -1000);
            borderMeshPtr2 = MeshManager.Singleton.CreatePlane("border2", ResourceGroupManager.DEFAULT_RESOURCE_GROUP_NAME, plane2, borderWidth, borderHeight, 100, 100, true, 0, 10, 10, Vector3.UNIT_Y);

            plane3 = new Plane(Vector3.NEGATIVE_UNIT_Z, -1000);
            borderMeshPtr3 = MeshManager.Singleton.CreatePlane("border3", ResourceGroupManager.DEFAULT_RESOURCE_GROUP_NAME, plane3, borderWidth, borderHeight, 100, 100, true, 0, 10, 10, Vector3.UNIT_Y);

            plane4 = new Plane(Vector3.NEGATIVE_UNIT_X, -1000);
            borderMeshPtr4 = MeshManager.Singleton.CreatePlane("border4", ResourceGroupManager.DEFAULT_RESOURCE_GROUP_NAME, plane4, borderWidth, borderHeight, 100, 100, true, 0, 10, 10, Vector3.UNIT_Y);

            borderEntity = mSceneMgr.CreateEntity("border");
            borderEntity2 = mSceneMgr.CreateEntity("border2");
            borderEntity3 = mSceneMgr.CreateEntity("border3");
            borderEntity4 = mSceneMgr.CreateEntity("border4");

            borderNode = mSceneMgr.CreateSceneNode();
            borderNode.AttachObject(borderEntity);
            borderNode.AttachObject(borderEntity2);
            borderNode.AttachObject(borderEntity3);
            borderNode.AttachObject(borderEntity4);
            mSceneMgr.RootSceneNode.AddChild(borderNode);

            borderEntity.SetMaterialName("Wall.material");
            borderEntity2.SetMaterialName("Wall.material");
            borderEntity3.SetMaterialName("Wall.material");
            borderEntity4.SetMaterialName("Wall.material");


        }

        /// <summary>
        /// Dispose method to remove the borderNode. 
        /// </summary>
        public void Dispose()
        {
            borderNode.DetachAllObjects();
            borderNode.Parent.RemoveChild(borderNode);
            borderNode.Dispose();
            borderEntity.Dispose();

        }

        //static public AddBoundary(Plane boundary)
        //{
                
        //}

    }
}
