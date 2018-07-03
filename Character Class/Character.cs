using System;
using Mogre;

using PhysicsEng;

namespace Game
{

    /// <summary>
    /// This abstract class describes the logic and the components of a character in the game
    /// </summary>
  
    abstract class Character
    {

        protected PhysObj physObj;


        ///protected CharacterController controller;

        protected CharacterController controller;

        /// <summary>
        /// Read/Write. This property allows to set and read the character controller.
        /// </summary>
        public CharacterController Controller
        {
            get { return controller; }
            set { controller = value; }
        }

        protected CharacterStats stats;

        /// <summary>
        /// Read/Write. This property allows to set and read the character statistics.
        /// </summary>
        public CharacterStats Stats
        {
            get { return stats; }
            set { stats = value; }
        }

        protected CharacterModel model;

        /// <summary>
        /// Read/Write. This property allows to set and read the character model.
        /// </summary>
        public CharacterModel Model
        {
            set { model = value; }
            get { return model; }
        }

        protected bool isDead = false;

        /// <summary>
        /// Read/Write. This property allows to set and read whether the character is dead.
        /// </summary>
        public bool IsDead
        {
            get { return isDead; }
            set { isDead = value; }
        }

        /// CHARACTER ARMOURY SO THAT ENEMIES CAN PICK UP WEAPONS AS WELL AS THE PLAYERS IF DESIRED
        protected Armoury armoury;

        protected Armoury Armoury
        {
            get { return armoury; }
        }


        /// <summary>
        /// Read/Write. This property allows to set and read the position of the character in the scene.
        /// </summary>
        public Vector3 Position
        {
           set { model.SetPosition(value); }
           get { return model.GameNode.Position; }
        }

        /// <summary>
        /// This virtual method allows to move the character in the scene.
        /// </summary>
        /// <param name="direction"></param>
        virtual public void Move(Vector3 direction)
        {
            //model.Move(direction);
            physObj.Velocity = 100 * direction; 
        }

        /// <summary>
        /// This virtual method allows to rotate the character in the specified transform space.
        /// </summary>
        /// <param name="quarternion"></param>
        /// <param name="transformSpace"></param>
        virtual public void Rotate(Quaternion quarternion,
               Node.TransformSpace transformSpace = Node.TransformSpace.TS_LOCAL)
        {
        
            model.Rotate(quarternion, transformSpace);
        }


        /// <summary>
        /// This virtual method is to implement the logic for shooting of the character
        /// </summary>
        virtual public void Shoot() { }

        /// <summary>
        /// This method is to update the character state
        /// </summary>
        /// <param name="evt"></param>
        virtual public void Update(FrameEvent evt) { }

        /// <summary>
        /// This method disposes od the character when it dies
        /// </summary>
        virtual protected void Die()
        {
            model.Dispose();
        }

        protected bool removeMe;

        public bool RemoveMe
        {
            get { return removeMe; }
        }
    }
}
