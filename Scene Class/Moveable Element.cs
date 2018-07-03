using System;
using Mogre;

namespace Game
{
    class MoveableElement : GameElement
    {
        /// <summary>
        /// This abstract class inherits form the GameElement class and contains methods and parameters necessary 
        /// to move and animate a movable element in the game
        /// </summary>
        /// 
        protected bool removeMe;

        /// <summary>
        /// Read only. This property returns whether this movable element is to be removed from the game
        /// </summary>
        public bool RemoveMe
        {
            get { return removeMe; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public MoveableElement()
        {
            isMovable = true;
        }

        /// <summary>
        /// This virtual method is to contain the translation of the movable element in the given direction
        /// </summary>
        /// <param name="direction">Direction along which move the movable element</param>
        virtual public void Move(Vector3 direction)
        {
            gameNode.Translate(direction);
           /// Console.WriteLine("moveable move");
        }

        /// <summary>
        /// This virtual method is to contain the rotation the movable element by the given quaternion in the specified transform space
        /// </summary>
        /// <param name="quaternion">Quaternion which describes axis and rotation angle</param>
        /// <param name="transformSpace">Space on which apply the rotation, local by default</param>
        virtual public void Rotate(Quaternion quaternion,
            Node.TransformSpace transformationSpace = Node.TransformSpace.TS_LOCAL)
        {
            gameNode.Yaw(quaternion.y);
        }

        /// <summary>
        /// This virtual method is to contain the animation description of the movable element
        /// </summary>
        /// <param name="evt">A frame event which can be used to tune the animation timings</param>
        virtual public void Animate(FrameEvent evt)
        {

        }
    }
}
