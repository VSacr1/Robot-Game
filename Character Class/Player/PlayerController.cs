using System;
using Mogre;

using PhysicsEng;
using System.Collections.Generic;

namespace Game
{
    class PlayerController : CharacterController
    {
        Radian angle;
        Vector3 direction;
        float radius;

        List<CannonBall> cannonBalls;
        List<CannonBall> cannonBallToRemove;

        SceneManager mSceneMgr; 
       
        /// <summary>
        /// This is a constructer that takes the object type character and names it player. 
        /// It gives the character a speed and also calls the cannonballs as a list. 
        /// The cannonballs are related to the Fire method. 
        /// </summary>
        /// <param name="player"></param>
        public PlayerController(Character player, SceneManager mSceneMgr)
        {
            this.mSceneMgr = mSceneMgr; 
            speed = 0.7f; /// Speed = 100
            Left = false;
            Right = false;
            Forward = false;
            Backward = false;

            cannonBalls = new List<CannonBall>();
            cannonBallToRemove = new List<CannonBall>();


            character = player;
        }

        /// <summary>
        /// This updates the frame event for the characters control. 
        /// </summary>
        /// <param Update ="evt"></param>
        /// <returns></returns>
        public override void Update(FrameEvent evt)
        {
            MovementControl(evt);
            MouseControls(evt);
            ShootingControls();

            foreach (CannonBall cannonBall in cannonBalls)
            {
                cannonBall.Update(evt);
                if (cannonBall.RemoveMe)
                    cannonBallToRemove.Add(cannonBall);
            }

            foreach (CannonBall cannonBall in cannonBallToRemove)
            {
                cannonBalls.Remove(cannonBall);
                cannonBall.Dispose();
            }
            cannonBallToRemove.Clear();
            //CircularMotion(evt); 
        }
     

        /// <summary>
        /// Movement controls for the player model.
        /// Forwards Backwards left and right, there is also an accellerate button which can make the model go faster. 
        /// </summary>
        /// <param MovementControl ="evt"></param>
        private void MovementControl(FrameEvent evt)
        {
            Vector3 move = Vector3.ZERO;
            

            if (forward)                            /// If forward is true then the player model shall move forward.
                move -= character.Model.Forward;
               

            if (backward)                           /// If backward is true then the player model shall move backwards.
                move += character.Model.Forward;                /// This is a subtraction from the value forward.
               

            if (left)                               /// If left is true then the player model shall move left. 
                move -= character.Model.Left;
              

            if (right)                              /// If right is true then the player model shall move right. 
                move += character.Model.Left;                   /// This is a subtraction from the value Left. 

            move = move.NormalisedCopy * speed;

            if (accellerate)                        /// If accellerate is true then model shall accellerate
                move = move * speed * 2;                    /// This multiplies the speed of the character by 2 while the model is moving.  COME BACK TO IT!!!!!!!!!


         
            if (move != Vector3.ZERO)

                ///character.Move(move * evt.timeSinceLastEvent); ///CHARACTER.MODEL.MOVE
                character.Move(move);
                ///((PlayerModel)character.Model).Move(move); ///Getting whatever character model is getting the playermodel and telling it to move. Stating definatly that it is a player model. 
            
           
        }

        /// <summary>
        /// This is the mouse control which will rotate the character is looking. 
        /// </summary>
        private void MouseControls(FrameEvent evt)
        {

            character.Model.GameNode.Yaw(Mogre.Math.AngleUnitsToRadians(angles.y * speed));

        }

        /// <summary>
        /// This will be used to add animation to the character. 
        /// </summary>
        private void Animate()
        {
            
        }
        
        /// <summary>
        /// Was trying to animate the character model to move round in a circle. This was an experiment to see if i had made my connections right with the classes. 
        /// </summary>
        /// <param name="evt"></param>
        private void CircularMotion(FrameEvent evt)
        {
            //angle += (Radian)evt.timeSinceLastFrame;
            //direction = radius * new Vector3(Mogre.Math.Cos(angle), 0, Mogre.Math.Sin(angle));
            //character.Model.GameNode.Translate(direction);
            //character.Model.GameNode.Yaw(-evt.timeSinceLastFrame); 
        }

        protected bool changeGuns;

        /// <summary>
        /// Bool to change the guns on the model for attack power
        /// </summary>
        public bool ChangeGuns
        {
            get { return changeGuns; }
        }

        /// <summary>
        /// These are the controls for the shooting
        /// </summary>
        private void ShootingControls()
        {
            if(shoot == true)
            {
                CannonBall cannonBall = new CannonBall(mSceneMgr);
                cannonBall.SetPosition(character.Model.GameNode.Position);
                //cannonBall.SetPosition(cannonBall.GameNode.Position + cannonBall.physObj.Velocity * 100);
                /// cannonBall.Move(((Player)character).Model.GameNode.AutoTrackLocalDirection);
                ///cannonBall.InitialDirection = new Vector3(0, 0, 300);
                shoot = false;
            }
        }
        ///Bool change guns X
        ///Keyboard controls 
        ///Mouse Controls
        ///Shooting Controls
    
    }
}
