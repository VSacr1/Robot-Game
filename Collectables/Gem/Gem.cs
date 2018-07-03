using System;
using Mogre;

using PhysicsEng;

namespace Game
{

    class Gem : Collectable
    {
        /// <summary>
        /// This inherits from the collectable class. 
        /// </summary>

        protected PhysObj physObj;

        public Stat score;


        /// <summary>
        /// Gets the return value of score. 
        /// </summary>
        public Stat ScoreField
        {
            get { return score; }
        }

        protected int increase;

        /// <summary>
        /// Sets the increase as a value. 
        /// </summary>
        public int Increase
        {
            set { increase = value; }
        }

        protected int decrease;

        /// <summary>
        /// Sets the decrease as a value. 
        /// </summary>
        public int Descrease
        {
            set { decrease = value; }
        }



        /// <summary>
        /// Loads the model 
        /// </summary>
        virtual public void LoadModel()
        {
           
        }

        /// <summary>
        /// Update method
        /// </summary>
        /// <param name="evt"></param>
        public override void Update(FrameEvent evt)
        {

        }
        /// <summary>
        /// Remove Method 
        /// </summary>
        public override void Remove()
        {
           
        }

        /// <summary>
        /// Dispose method. 
        /// </summary>
        public override void Dispose()
        {

        }


        /// <summary>
        /// This is the update method used for the code for the physics collision detection. 
        /// </summary>

    }
}
