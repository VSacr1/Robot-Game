using System;
using Mogre;

namespace Game
{

    /// <summary>
    /// This class inherits from the MovableElement class and is to determine how the character model is described
    /// </summary>
    /// 
    abstract class CharacterModel : MoveableElement
    {
        Vector3 left;

        /// <summary>
        /// Read only. This property returns the left direction of the character model
        /// </summary>
        public Vector3 Left
        {
            get
            {
                left = gameNode.LocalAxes.GetColumn(0).NormalisedCopy;
                return left;
            }
        }

        Vector3 up;

        /// <summary>
        /// Read only. This property returns the up direction of the character model
        /// </summary>
        public Vector3 Up
        {
            get
            {
                up = gameNode.LocalAxes.GetColumn(1).NormalisedCopy;
                return up;
            }
        }

        Vector3 forward;

        /// <summary>
        /// Read only. This property returns the forward direction of the character model
        /// </summary>
        public Vector3 Forward
        {
            get
            {
                forward = gameNode.LocalAxes.GetColumn(2).NormalisedCopy;
                return forward;
            }
        }

        /// <summary>
        /// This method is to animate the characters. 
        /// </summary>
        /// <param name="evt"></param>
        public override void Animate(FrameEvent evt)
        {

        }

        /// <summary>
        /// This method is to move the characters. 
        /// </summary>
        /// <param name="direction"></param>
        public override void Move(Vector3 direction)
        {
            

        }

        /// <summary>
        /// This virtual method is to initialize the model elements
        /// </summary>
        virtual protected void LoadModelElements() { }

        /// <summary>
        /// This virtual method is to define how the model is assembled
        /// </summary>
        virtual protected void AssembleModel() { }

        /// <summary>
        /// This virtual method is for dispose all the components of the character model
        /// </summary>
        virtual public void DisposeModel() { }

        /// <summary>
        /// This method dispose of the character model
        /// </summary>
        public override void Dispose()
        {
            DisposeModel();
            base.Dispose(); 
        }
    }
}
