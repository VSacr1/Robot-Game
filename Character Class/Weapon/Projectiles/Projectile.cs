using System;
using Mogre;

using PhysicsEng;
using System.Collections.Generic;

namespace Game
{
    class Projectile : MoveableElement
    {

        public PhysObj physObj;

        protected Stat stat; 

        Timer time;
        protected int maxTime;
        protected Vector3 initialVelocity;
        protected float speed;
        protected Vector3 initialDirection; 

        /// <summary>
        /// The initial direction of the projectile. 
        /// </summary>
        public Vector3 InitialDirection
        {
            set {
                initialDirection = value;
                physObj.Velocity = speed * initialDirection;
            }

        }

        /// <summary>
        /// Sets the stas as a value. 
        /// </summary>
        protected Stat Statfield
        {
            set { stat = value;  }
        }

        protected int healthDamage;

        /// <summary>
        /// gets the return integer of health damager
        /// </summary>
        public int HealthDamage
        {
            get { return healthDamage; }
        }

        protected int shieldDamage;
        
        /// <summary>
        /// gets the return integer of shield damager
        /// </summary>
        public int ShieldDamage
        {
            get { return shieldDamage; }
        }

        /// <summary>
        /// Loads the model 
        /// </summary>
        virtual protected void LoadModel() {}

        /// <summary>
        /// Sets a new timer. 
        /// </summary>
        protected Projectile()
        {
            time = new Timer();

        }

        /// <summary>
        /// This class the removeMe method as true. 
        /// </summary>
        public override void Dispose()
        {
            base.Dispose();
            this.removeMe = true; 
        }

        /// <summary>
        /// This calls the update method for the projectile class.
        /// </summary>
        /// <param name="evt"></param>
        virtual public void Update(FrameEvent evt)
        {

            if (!removeMe && time.Milliseconds > maxTime)
            {
                removeMe = true;
                Dispose();
                return;  
            }

            this.SetPosition(this.GameNode.Position + physObj.Velocity);
        }

    }
}
