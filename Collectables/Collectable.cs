using System;
using Mogre;

namespace Game
{
    class Collectable : MoveableElement
    {
        /// <summary>
        /// A remove method which sets the variable remove me to false
        /// </summary>
        virtual public void Remove()
        {
            removeMe = false; 
        }
        /// <summary>
        /// An update method for the child classes to override. 
        /// </summary>
        /// <param name="evt"></param>
        virtual public void Update(FrameEvent evt)
        {

        }
    }
}
