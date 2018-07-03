using System;
using Mogre;

namespace Game
{
    abstract class CharacterController
    {

        /// <summary>
        /// This abstract class allows to implement a character controller. 
        /// This allows to controll the camera either by keyboard and mouse or by AI
        /// </summary>
        /// 
        protected Character character;
        ///protected PlayerModel playerModel; 

        protected Vector3 angles;

        /// <summary>
        /// 
        /// </summary>
        public Character CharacterField
        {
            get { return character; }
        }

        /// <summary>
        /// Write only. This property allows to set the rotation angle
        /// </summary>
        public Vector3 Angles
        {
            set { angles = value; }
        }

        protected bool shoot;

        /// <summary>
        /// Write only. This property allows to set whether the character is to shoot
        /// </summary>
        public bool Shoot
        {
            set { shoot = value; }
        }

        protected bool forward;

        /// <summary>
        /// Write only. This property allows to set whether the character is to move forward
        /// </summary>
        public bool Forward
        {
            set { forward = value; }
        }

        protected bool backward;

        /// <summary>
        /// Write only. This property allows to set whether the character is to move backward
        /// </summary>
        public bool Backward
        {
            set { backward = value; }
        }

        protected bool left;

        /// <summary>
        /// Write only. This property allows to set whether the character is to move left
        /// </summary>
        public bool Left
        {
            set { left = value; }
        }

        protected bool right;

        /// <summary>
        /// Write only. This property allows to set whether the character is to move right
        /// </summary>
        public bool Right
        {
            set { right = value; }
        }

        protected bool up;

        /// <summary>
        /// Write only. This property allows to set whether the character is to move up
        /// </summary>
        public bool Up
        {
            set { up = value; }
        }

        public bool down;

        /// <summary>
        ///  Write only. This property allows to set whether the character is to move down
        /// </summary>
        public bool Down
        {
            set { down = value; }
        }

        protected bool accellerate;

        /// <summary>
        /// Write only. This property allows to set whether the character is to accellerate
        /// </summary>
        public bool Accellerate
        {
            set { accellerate = value; }
        }

        protected float speed;

        /// <summary>
        /// Write only. This property allows to set the speed of the character movement
        /// </summary>
        public float Speed
        {
            set { speed = value; }
        }

        /// <summary>
        /// This virtual method updates the state of the character
        /// </summary>
        /// <param name="evt"></param>
        /// <returns></returns>
        virtual public void Update(FrameEvent evt)
        {
          
        }


     
    } 
}
