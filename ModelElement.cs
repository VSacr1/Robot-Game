using System;
using Mogre;
namespace Game
{
    class ModelElement : MoveableElement
    {


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mSceneMgr">A reference to the scene manager</param>
        /// <param name="modelName">The name of the .mesh file which contains the geometry of the model</param>
        public ModelElement(SceneManager mSceneMgr, string modelName = "")
        {

            this.mSceneMgr = mSceneMgr;

            this.gameNode = mSceneMgr.CreateSceneNode(); 

            if (modelName != "")
            {
                this.gameEntity = mSceneMgr.CreateEntity(modelName);
                this.gameNode.AttachObject(gameEntity);
            }

            //CODE FOR INITIALIZE AND ATTATCH GAMEENTITY TO THE NODE GOES HERE

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mSceneMgr">A reference to the scene manager</param>
        /// <param name="modelName">The name of the .mesh file which contains the geometry of the model</param>
        public override void Move(Vector3 direction)
        {
            base.Move(direction); 
        }

        /// <summary>
        /// This modeto rotate the model element as described by the quaternion given as parameter in the
        /// specified transformation space
        /// </summary>
        /// <param name="quaternion">The quaternion which describes the rotation axis and angle</param>
        /// <param name="transformSpace">The space in which to perfrom the rotation, local by default</param>
        public override void Rotate(Quaternion quaternion,
            Node.TransformSpace transformSpace = Node.TransformSpace.TS_LOCAL)
        {

        }

        /// <summary>
        /// This method adds a child to the node of this model element
        /// </summary>
        /// <param name="childNode"></param>
        public void AddChild(SceneNode childNode)
        {

            gameNode.AddChild(childNode);
            //YOUR NODE FOR ATTATCHING CHILD NODE GOES HERE. 
            mSceneMgr.RootSceneNode.AddChild(childNode);
            ///gameNode.AddChild(childNode);

        }



    }
}

    
