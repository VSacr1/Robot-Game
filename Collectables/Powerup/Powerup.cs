using System;
using Mogre;

using PhysicsEng;

namespace Game
{
    class Powerup : Collectable
    {

        /// <summary>
        /// Inherits from the Collectable class. 
        /// </summary>
        PhysObj physObj;
        protected Stat stat;

        LifePU lifePu;
        ShieldPU shieldPu;
        HealthPU healthPu; 

        /// <summary>
        /// Sets the stat as a value. 
        /// </summary>
        protected Stat Statfield
        {
            set { stat = value; }
        }

        protected int increase;

        /// <summary>
        /// Sets the integer increase as a value. 
        /// </summary>
        public int Increase
        {
            set { increase = value; }
        }

        protected int decrease;

        /// <summary>
        /// Sets the integer decrease as a value. 
        /// </summary>
        public int Descrease
        {
            set { decrease = value; }
        }
        /// <summary>
        /// Loads the model.
        /// </summary>
        virtual protected void LoadModel()
        {

            
        }

    
        /// <summary>
        /// Update Method. 
        /// </summary>
        /// <param name="evt"></param>
        public override void Update(FrameEvent evt)
        {
            //removeMe = IsCollidingWith("Player");
        }
    }
}
