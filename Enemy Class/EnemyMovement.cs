using System;
using System.Collections.Generic;
using Mogre;

namespace Game
{
    class EnemyMovement : CharacterController
    {

        EnemyModel enemyModel;


        Radian angle;
        Vector3 direction;
        float radius = 10f;


        const float maxTime = 2000f;
        Timer time;
        AnimationState animationState;
        bool animationChanged;

        string animationName;


        public string AnimationName
        {
            set
            {
                HasAnimationChanged(value);
                if (IsValidAnimationName(value))
                    animationName = value;
                else
                    animationName = "Idle";
            }
        }

        public EnemyMovement(Character enemy, EnemyModel model)
        {
            this.character = enemy;
            ///this.character = enemy2;
            this.enemyModel = model;
            this.speed = 0.01f;

        }

        /// <summary>
        /// Animate method which calls CircularMotion(evt) and AnimateMesh(evt)
        /// </summary>
        /// <param name="evt"></param>
        public void Animate(FrameEvent evt)
        {
            CircularMotion(evt);
            AnimateMesh(evt); 
            
           
        }

        /// <summary>
        /// Causes a walking animation to occur. 
        /// </summary>
        public void Walking()
        {

            radius = 0.1f;
            direction = Vector3.ZERO;
            angle = 0f;

            time = new Timer();
            ///PrintAnimationName();
            animationChanged = false;
            animationName = "Walk";
            LoadAnimation();
            Console.WriteLine("Walking Animation!");

        }

        /// <summary>
        /// Causes a shooting animation to occur. 
        /// </summary>
        private void Shooting()
        {
            radius = 0.01f;
            direction = Vector3.ZERO;
            angle = 0f;

            time = new Timer();
            animationChanged = false;
            animationName = "Shoot";
            LoadAnimation();


        }

        /// <summary>
        /// Causes a death animation to occur. 
        /// </summary>
        public void Death()
        {
            radius = 0.01f;
            direction = Vector3.ZERO;
            angle = 0f;

            time = new Timer();
            animationChanged = false;
            animationName = "Die";
            ///LoadAnimation();

            //AnimationMesh(evt);
        }

        /// <summary>
        /// Causes a slump animation to occur. 
        /// </summary>
        private void Slump()
        {
            radius = 0.1f;
            direction = Vector3.ZERO;
            angle = 0f;

            time = new Timer();
            animationChanged = false;
            animationName = "Slump";
        }

        /// <summary>
        /// This method this method makes the mesh move in circle
        /// </summary>
        /// <param name="evt">A frame event which can be used to tune the animation timings</param>
        public void CircularMotion(FrameEvent evt)
        {
           /// Console.WriteLine("CircularMotion walking");
            angle += (Radian)evt.timeSinceLastFrame;
            direction = radius * new Vector3(Mogre.Math.Cos(angle), 0, Mogre.Math.Sin(angle));
            enemyModel.Robot.GameNode.Translate(direction);
            enemyModel.Robot.GameNode.Yaw(-evt.timeSinceLastFrame);
        }

        /// <summary>
        /// This method sets the animationChanged field to true whenever the animation name changes
        /// </summary>
        /// <param name="newName"> The new animation name </param>
        private void HasAnimationChanged(string newName)
        {
            if (newName != animationName)
                animationChanged = true; 
        }


        /// <summary>
        /// This method deternimes whether the name inserted is in the list of valid animation names
        /// </summary>
        /// <param name="newName">An animation name</param>
        /// <returns></returns>
        private bool IsValidAnimationName(string newName)
        {
            bool nameFound = false;

            AnimationStateSet animStateSet = enemyModel.Robot.GameEntity.AllAnimationStates;

            AnimationStateIterator animIterator = animStateSet.GetAnimationStateIterator();     ///Iterator.currentkey its like indexing a list and has methods that do it for you. 
           

            while (animIterator.MoveNext())
            {
                Console.WriteLine(animIterator.CurrentKey);
            }
            return nameFound;

            //while (animaIterator.MoveNext())
            //{
            //    Console.WriteLine(animaIterator.CurrentKey);
            //}
            //return nameFound; 
        }

        /// <summary>
        /// This method changes the animation name randomly
        /// </summary>
        private void changeAnimationName()
        {
            switch((int)Mogre.Math.RangeRandom(0, 4.5f))
            {
                case 0:
                    {
                        animationName = "Walk";
                        break;
                    }
                case 1:
                    {
                        animationName = "Shoot";
                        break; 
                    }
                case 2:
                    {
                        animationName = "Idle";
                        break; 
                    }
                case 3:
                    {
                        animationName = "Slump";
                        break;
                    }
                case 4:
                    {
                        animationName = "Die";
                        break; 
                    }
            }
        }

        /// <summary>
        /// This method loads the animation from the animation name
        /// </summary>
        private void LoadAnimation()
        {
            animationState = enemyModel.Robot.GameEntity.GetAnimationState(animationName);
         
            animationState.Loop = true;
            animationState.Enabled = true; 
        }

        /// <summary>
        /// This method puts the mesh in motion
        /// </summary>
        /// <param name="evt">A frame event which can be used to tune the animation timings</param>
        public void AnimateMesh(FrameEvent evt)
        {
            if (time.Milliseconds > maxTime)
            {
                changeAnimationName();
                time.Reset();
            }

            if (animationChanged)
            {
                LoadAnimation();
                animationChanged = false;
            }

            animationState.AddTime(evt.timeSinceLastFrame);

        }
    }
}