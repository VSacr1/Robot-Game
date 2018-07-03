using System;
using Mogre;

using PhysicsEng;
namespace Game
{
    class Cube 
    {

        private SceneManager mSceneMgr;

        private ManualObject cube;
        private Entity cubeEntity;
        private SceneNode cubeNode;

        private Physics physics;
        private PhysObj physObj;


        public Cube(SceneManager mSceneMgr)
        {
            this.mSceneMgr = mSceneMgr;

           //NEED TO APPLY PHYSICS TO THE CUBES. 
            
        }

        ///private MeshPtr Quad()
        public MeshPtr Quad()
        {
            cube = mSceneMgr.CreateManualObject("fieldQuad");
            cube.Begin("void", RenderOperation.OperationTypes.OT_TRIANGLE_LIST);

            cube.Position(new Vector3(20f, 20f, 20f)); // Vector 0
            cube.TextureCoord(new Vector2(0, 0));

            cube.Position(new Vector3(20f, -20f, 20f)); // Vector 1
            cube.TextureCoord(new Vector2(1, 0));

            cube.Position(new Vector3(20f, 20f, -20f)); // Vector 2
            cube.TextureCoord(new Vector2(0, 1));

            cube.Position(new Vector3(20f, -20f, -20f)); // Vector 3
            cube.TextureCoord(new Vector2(1, 1));

            cube.Position(new Vector3(-20f, 20f, 20f)); // Vector 4
            cube.TextureCoord(new Vector2(0, 0));

            cube.Position(new Vector3(-20f, -20f, 20f)); // Vector 5
            cube.TextureCoord(new Vector2(0, 1));

            cube.Position(new Vector3(-20f, 20f, -20f)); // Vector 6
            cube.TextureCoord(new Vector2(1, 0));

            cube.Position(new Vector3(-20f, -20f, -20f)); // Vector 7
            cube.TextureCoord(new Vector2(1, 1));

            // Index Buffer

            // Triangle 0
            cube.Index(0);
            cube.Index(1);
            cube.Index(2);

            // Triangle 1
            cube.Index(2);
            cube.Index(1);
            cube.Index(3);

            // Triangle 2
            cube.Index(4);
            cube.Index(6);
            cube.Index(5);

            // Triangle 3
            cube.Index(6);
            cube.Index(7);
            cube.Index(5);

            // Triangle 4
            cube.Index(0);
            cube.Index(4);
            cube.Index(1);

            // Triangle 5
            cube.Index(1);
            cube.Index(4);
            cube.Index(5);

            // Triangle 6
            cube.Index(0);
            cube.Index(6);
            cube.Index(4);

            // Triangle 7
            cube.Index(0);
            cube.Index(2);
            cube.Index(6);

            // Triangle 8
            cube.Index(6);
            cube.Index(2);
            cube.Index(3);

            // Triangle 9
            cube.Index(6);
            cube.Index(3);
            cube.Index(7);

            // Triangle 9
            cube.Index(3);
            cube.Index(1);
            cube.Index(7);

            cube.Index(1);
            cube.Index(5);
            cube.Index(7);

            cube.End();

            return cube.ConvertToMesh("Quad");


        }



        public void Load()
        {
            CubeMaterial();

            Quad();

            cubeEntity = mSceneMgr.CreateEntity( "Quad");
            cubeNode = mSceneMgr.CreateSceneNode("Quad_Node");
            cubeNode.AttachObject(cubeEntity);
            cubeNode.AttachObject(cube); 
            mSceneMgr.RootSceneNode.AddChild(cubeNode);

            cubeEntity.SetMaterialName("Cube");
        }

        //public void SetPosition(Vector3 position)
        //{
        //    //cubeNode.Position = position;
        //    //physObj.Position = position; 
        //}
        private void CubeMaterial()
        {
            using (MaterialPtr cubeMat = MaterialManager.Singleton.Create("Cube",
                    ResourceGroupManager.DEFAULT_RESOURCE_GROUP_NAME))
            {
                using (TextureUnitState fieldTexture =
                    cubeMat.GetTechnique(0).GetPass(0).CreateTextureUnitState("Dirt.jpg"))
                {
                    ///cube.SetMaterialName("Quad", "Cube");
                }
            }
        }

        public void Dispose()
        {
            if (cubeNode != null)
            {
                cubeNode.Parent.RemoveChild(cubeNode);
                cubeNode.DetachAllObjects();
                cubeNode.Dispose();
                cubeNode = null;
            }

            if (cubeEntity != null)
            {
                cubeEntity.Dispose();
                cubeEntity = null; 
            }
         
        }

        public void NonStaticGeometry()
        {
            Quad();
            
            for (int i = 0; i < 100; i++)
                for (int j = 0; j < 100; j++)
                {
                    cubeEntity = mSceneMgr.CreateEntity("Quad");
                    cubeNode = mSceneMgr.RootSceneNode.CreateChildSceneNode(new Vector3(i * 5, j * 5, 0));
                    cubeNode.AttachObject(cubeEntity);
                }
        }

        private StaticGeometry staticGeometry;
        public void StaticGeometry()
        {
            Quad();

            staticGeometry = mSceneMgr.CreateStaticGeometry("staticQuads");
            for(int i=0; i<200; i++)
                for(int j = 0;  j < 200; j++)
                {
                    cubeEntity = mSceneMgr.CreateEntity("Quad");
                    staticGeometry.AddEntity(cubeEntity, new Vector3(i * 5, j * 5, 0));
                }
            staticGeometry.Build();
        }

        
    }
}
