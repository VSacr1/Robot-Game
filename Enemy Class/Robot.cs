using System;
using Mogre;

namespace Game
{
    /// <summary>
    /// This class implements a robot
    /// </summary>
    class Robot
    {
            Radian angle;
            Vector3 direction;
            float radius;



            #region Part2
            const float maxTime = 1000f; //changes it every one second
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
            #endregion

            SceneManager mSceneMgr;     // A reference to the scene manager
            Entity robotEntity;         // The entity which will contain the robot mesh
            SceneNode robotNode;        // The node of the scene graph for the robot

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="mSceneMgr">A reference to the scene manager</param>
            public Robot(SceneManager mSceneMgr)
            {
                this.mSceneMgr = mSceneMgr;
                Load();
                AnimationSetup();


            }

        public Vector3 Position
        {
            get { return robotNode.Position;  }
        }

        public void AddChild(SceneNode child)
        {
            robotNode.AddChild(child); 
        }

        public void Animate(FrameEvent evt)
        {
            CircularMotion(evt);

            #region Part2
            AnimationMesh(evt);
            #endregion
        }

            public void Shooting(FrameEvent evt)
            {
                    radius = 0.01f;
                    direction = Vector3.ZERO;
                    angle = 0f;

                    time = new Timer();
                    animationChanged = false;
                    animationName = "Shoot";
                    LoadAnimation();

                    AnimationMesh(evt);
            }

            private void AnimationSetup()
            {

                radius = 0.01f;
                direction = Vector3.ZERO;
                angle = 0f;

                time = new Timer();
                PrintAnimationNames();
                animationChanged = false;
                animationName = "Walk";
                LoadAnimation();

            }

            #region Part2
            private void CircularMotion(FrameEvent evt)
            {
                angle += (Radian)evt.timeSinceLastFrame;
                direction = radius * new Vector3(Mogre.Math.Cos(angle), 0, Mogre.Math.Sin(angle));
                robotNode.Translate(direction);
                robotNode.Yaw(-evt.timeSinceLastFrame);
            }

            private void HasAnimationChanged(string newName)
            {
                if (newName != animationName)
                    animationChanged = true;
            }

            private void PrintAnimationNames()
            {
                AnimationStateSet animStateSet = robotEntity.AllAnimationStates;
                AnimationStateIterator animIterator = animStateSet.GetAnimationStateIterator();

                while (animIterator.MoveNext())
                {
                    Console.WriteLine(animIterator.CurrentKey);
                }
            }

            private bool IsValidAnimationName(string newName)
            {
                bool nameFound = false;

                AnimationStateSet animStateSet = robotEntity.AllAnimationStates;
                AnimationStateIterator animIterator = animStateSet.GetAnimationStateIterator();

                while (animIterator.MoveNext() && nameFound)
                {
                    if (newName == animIterator.CurrentKey)
                    {
                        nameFound = true;
                    }
                }
                return nameFound;
            }



            private void changeAnimationName()
            {
                switch ((int)Mogre.Math.RangeRandom(0, 4.5f))
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
            /// This method loads the mesh and attaches it to a node and to the schenegraph
            /// </summary>

            private void LoadAnimation()
            {
                animationState = robotEntity.GetAnimationState(animationName);
                animationState.Loop = true;
                animationState.Enabled = true;

            }

            private void AnimationMesh(FrameEvent evt)
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
            #endregion
            public void Load()
            {
                robotEntity = mSceneMgr.CreateEntity("robot.mesh"); //make sure the mesh is in the Media/models folder 
                robotNode = mSceneMgr.CreateSceneNode();
                robotNode.AttachObject(robotEntity);
                mSceneMgr.RootSceneNode.AddChild(robotNode);
            }

            /// <summary>
            /// This method detaches the robot node from the scene graph and destroies it and the robot enetity
            /// </summary>
            public void Dispose()
            {
                robotNode.Parent.RemoveChild(robotNode);
                robotNode.DetachAllObjects();
                robotNode.Dispose();
                robotEntity.Dispose();
            }
        }
    }


