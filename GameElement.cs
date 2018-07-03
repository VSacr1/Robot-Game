using System;
using Mogre;

namespace Game
{
    class GameElement
    {

        /// <summary>
        /// This abstract class is the basis of each element in the game. It contains the SceneNode, Enitity 
        /// and PhysObj necessary to build the game elements. It implements the Dispose method necessary to 
        /// destroy a GameElement at the end of its life in the game, and a method to position the GameElement 
        /// in the reference system of the game node's parent.
        /// The Enitity, the SceneNode and the PhysObj are to be initialized in the classes derived from this one.
        /// </summary>

        protected SceneManager mSceneMgr;

        protected Entity gameEntity;

        /// <summary>
        /// Read/Write. This property allows to read and write the game entity
        /// </summary>
        public Entity GameEntity
        {
            get { return gameEntity; }
            set { gameEntity = value; }
        }

        protected SceneNode gameNode;

        /// <summary>
        /// Read/Write. This property allows to read and write the game node
        /// </summary>
        public SceneNode GameNode
        {
            get { return gameNode; }
            set { gameNode = value; }
        }

        protected bool isMovable;

        /// <summary>
        /// Read/Write. This property allows to read and write whether this game element is movable
        /// </summary>
        public bool IsMovable
        {
            get { return isMovable; }
            set { IsMovable = value; }
        }

        /// <summary>
        /// This method is detaches from the scene graph and derstroies the game node and the game entity
        /// </summary>

        public virtual void Dispose()
        {
           if(gameNode.Parent != null)
            {
                gameNode.DetachAllObjects();
                gameNode.RemoveAndDestroyAllChildren();
                gameNode.Parent.RemoveChild(gameNode.Name);
            }
            gameNode.Dispose();

            if (gameEntity != null)
            {
                gameEntity.Dispose(); 
            }
        }

        /// <summary>
        /// This virtual method allows to set the game element in the reference system of game node's parent
        /// </summary>
        /// <param name="position">The position in which to put the game element</param>
        virtual public void SetPosition(Vector3 position)
        {
            gameNode.Position = position; 
            
        }
    }
}
