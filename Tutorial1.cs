using Mogre;
using Mogre.TutorialFramework;
using System;

namespace Tutorial
{
    class Tutorial : BaseApplication
    {
        ManualObjExample manObjExample;
        SceneNode cameraNode;
        ModelElement modelE; 
        //Cube cube; 


        #region Part 2
        Robot robot, robot2;
        // Field which will contain an instance of the robot class
        #endregion

        #region Part 3
        ///CharacterModel model;
        InputsManager inputsManager = InputsManager.Instance;
        #endregion
        
        public static void Main()
        {
            new Tutorial().Go();
            // This method starts the rendering loop
        }
        
        protected override void CreateCamera()
        {

            //(Something, up, something)
            ///base.CreateViewports();
            mCamera = mSceneMgr.CreateCamera("PlayerCam");
            mCamera.Position = new Vector3(0, 60, -100);
            mCamera.LookAt(new Vector3(0, 0, 0));
            mCamera.NearClipDistance = 5;
            mCamera.FarClipDistance = 1000;
            mCamera.FOVy = new Degree(70);

            mCameraMan = new CameraMan(mCamera);
            mCameraMan.Freeze = true; 
        }

        protected override void CreateViewports()
        {
            ////base.CreateViewports();
            Viewport viewport = mWindow.AddViewport(mCamera);
            viewport.BackgroundColour = ColourValue.Black; 
            mCamera.AspectRatio = viewport.ActualWidth / viewport.ActualHeight;
        }

        /// <summary>
        /// This method create the initial scene
        /// </summary>
        protected override void CreateScene()
        {
            manObjExample = new ManualObjExample(mSceneMgr);
            manObjExample.Load();

            modelE = new ModelElement(mSceneMgr);
            modelE.Load(); 

            //manObjExample.NonStaticGeometry();
            //manObjExample.StaticGeometry();

            #region Part 2
            robot = new Robot(mSceneMgr);
            robot2 = new Robot(mSceneMgr);

            #endregion

            #region Part 3
            ///model = new CharacterModel(mSceneMgr);
            ///
            ///inputsManager.Model(model);
            ///
            #endregion
            #region Part 4
            cameraNode = mSceneMgr.CreateSceneNode();
            cameraNode.AttachObject(mCamera);
            modelE.AddChild(cameraNode);
        }

        protected override void UpdateScene(FrameEvent evt)
        {
            base.UpdateScene(evt);
            robot.Animate(evt);
            robot2.Shooting(evt);
            mCamera.LookAt(modelE.Position);
            modelE.Animate(evt); 
            //gameItems.Animate(evt);
        }
        /// <summary>
        /// This method destrois the scene
        /// </summary>
        protected override void DestroyScene()
        {
            //manObjExample.Dispose();

            if (modelE != null)
                modelE.Dispose();
            #region Part 2
            if (robot != null)
                robot.Dispose();
            #endregion

            if (robot2 != null)
                robot2.Dispose(); 

            #region Part 3
            if (modelE != null)
                modelE.Dispose();
            #endregion

        }


        #region Framework methods not used in this demo

        /// <summary>
        /// This method set create a frame listener to handle events before, during or after the frame rendering
        /// </summary>
        protected override void CreateFrameListeners()
        {
            base.CreateFrameListeners();
            mRoot.FrameRenderingQueued +=
                new FrameListener.FrameRenderingQueuedHandler(inputsManager.ProcessInput);
        }

        /// <summary>
        /// This method initilize the inputs reading from keyboard adn mouse
        /// </summary>
        protected override void InitializeInput()
        {
            base.InitializeInput();

            int windowHandle;
            mWindow.GetCustomAttribute("WINDOW", out windowHandle);
            inputsManager.InitInput(ref windowHandle);
        }
        #endregion
    }
 }
        #endregion
