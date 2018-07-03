using Mogre;
using Mogre.TutorialFramework;
using System;

using PhysicsEng;
using System.Collections.Generic;

namespace Game
{

  


    class Game : BaseApplication
    {
        GameInterface gameHMD;
        Timer timer;
        TimerPU timerPu;

        List<TimerPU> timerPUs;
        List<TimerPU> timerPUToRemove;

        List<BlueGem> blueGems;
        List<BlueGem> blueGemToRemove;

        List<RedGem> redGems;
        List<RedGem> redGemToRemove;

        List<LifePU> lifePus;
        List<LifePU> lifePuToRemove;

        List<ShieldPU> shieldPus;
        List<ShieldPU> shieldPuToRemove;

        List<HealthPU> healthPus;
        List<HealthPU> healthPuToRemove;
        ShieldPU shieldPu;

        List<Bomb> bombs;
        List<Bomb> bombToRemove;
        Bomb bomb;

        List<CannonBall> cannonBalls;
        List<CannonBall> cannonBallToRemove;
        CannonBall cannonBall;

        Cube cube;

        List <Enemy> enemys;
        List<Enemy> enemysToRemove;
        Enemy enemy;

        //Enemy enemy4;

        Player player;

        Environment environment;
        Ground ground;
        Boundary border;



        InputsManager inputManager = InputsManager.Instance;

        BlueGem blueGem;

        RedGem redGem;

        LifePU lifePu;
        HealthPU healthPu;

        SceneNode cameraNode;

        BombDropperGun bombDropperGun;

        Physics physics;

        /// <summary>
        ///
        /// </summary>
        public static void Main()
        {
            new Game().Go();            // This method starts the rendering loop
        }

        /// <summary>
        /// This method create the initial scene
        /// </summary>
        protected override void CreateScene()
        {

            physics = new Physics();

            player = new Player(this.mSceneMgr);

            timer = new Timer();

            gameHMD = new GameInterface(mSceneMgr, mWindow, player.Stats, timer);

            bombDropperGun = new BombDropperGun(mSceneMgr);
            ((PlayerModel)player.Model).AttachGun(bombDropperGun);
            ///CAMERA
            cameraNode = mSceneMgr.CreateSceneNode();
            cameraNode.AttachObject(mCamera);
            ///((PlayerModel)player.Model).Body.AddChild(cameraNode); //Tells it that you are expecting a player model instead of a character model. Called casting

            player.Model.GameNode.AddChild(cameraNode);
            player.Model.SetPosition(new Vector3(0, 20, 0));

            ///inputManager.PlayerModel = playerModel;
            inputManager.PlayerController = (PlayerController)player.Controller;

            //cannonBall = new CannonBall(mSceneMgr);
            //cube = new Cube(this.mSceneMgr);
            //cube.Load();
            ///cube.SetPosition(new Vector3(20f, 20f, 20f));

            /////ENEMY MODEL

            //enemy2 = new Enemy(this.mSceneMgr);

            //enemy3 = new Enemy(this.mSceneMgr);
            //enemy4 = new Enemy(this.mSceneMgr);

            /////ENEMY POSITION


            //enemy2.Model.SetPosition(new Vector3(400, 0, -200));

            //enemy3.Model.SetPosition(new Vector3(-300, 0, 300));
            //enemy4.Model.SetPosition(new Vector3(400, 0, 400));




            ///GEMS
            blueGems = new List<BlueGem>();
            blueGemToRemove = new List<BlueGem>();
            spawnBlueGems();

            redGems = new List<RedGem>();
            redGemToRemove = new List<RedGem>();
            spawnRedGems();


            timerPUs = new List<TimerPU>();
            timerPUToRemove = new List<TimerPU>();

            spawnTimePU();

            healthPus = new List<HealthPU>();
            healthPuToRemove = new List<HealthPU>();

            spawnHealthPU();


            Random rnd = new Random();
            float x;
            float z;

            ///POWER UPS
            lifePus = new List<LifePU>();
            lifePuToRemove = new List<LifePU>();

            spawnLifePU();

            shieldPus = new List<ShieldPU>();
            shieldPuToRemove = new List<ShieldPU>();

            spawnShieldPU();

            cannonBalls = new List<CannonBall>();
            cannonBallToRemove = new List<CannonBall>();


            ///ENEMIES
            enemys = new List<Enemy>();
            enemysToRemove = new List<Enemy>();
            for (var enemyCount = 0; enemyCount <4; enemyCount++)
            {
                x = rnd.Next(-400, 400);
                z = rnd.Next(-400, 400);

                enemy = new Enemy(mSceneMgr, (PlayerStats)player.Stats);
                enemy.SetPosition(new Vector3(x, 0, z));


                enemys.Add(enemy);
                enemy.Movement.Walking();

            }
            ///AddBomb();
            bombs = new List<Bomb>();
            bombToRemove = new List<Bomb>();
            spawnBombs();



            ///ENVIRONMENT
            environment = new Environment(mSceneMgr, mWindow);
            ground = new Ground(mSceneMgr);
            border = new Boundary(mSceneMgr);
            player.Model.GameNode.AttachObject(environment.Light);


            ///cube.Quad();

            physics.StartSimTimer();


        }

        /// <summary>
        /// Spawns blue gems in random places.
        /// </summary>
        public void spawnBlueGems()
        {
            Random rnd = new Random();
            float x;
            float z;

            for (var gemCount = 0; gemCount < 30; gemCount++) //rename variable to gem count
            {

                x = rnd.Next(-900, 900);
                z = rnd.Next(-900, 900);

                blueGem = new BlueGem(((PlayerStats)player.Stats).score, mSceneMgr);
                blueGem.SetPosition(new Vector3(x, 0, z));


                blueGems.Add(blueGem);
            }
        }

        /// <summary>
        /// Spawns red gems in random places.
        /// </summary>
        public void spawnRedGems()
        {

            Random rnd = new Random();
            float x;
            float z;

            for (var redCount = 0; redCount < 30; redCount++)
            {

                x = rnd.Next(-900, 900);
                z = rnd.Next(-900, 900);

                redGem = new RedGem(((PlayerStats)player.Stats).Score, mSceneMgr);
                redGem.SetPosition(new Vector3(x, 0, z));

                redGems.Add(redGem);


            }
        }

        /// <summary>
        /// Spawns time powerups in random places.
        /// </summary>
        public void spawnTimePU()
        {
            Random rnd = new Random();
            float x;
            float z;

            for (var timerPUCount = 0; timerPUCount < 1; timerPUCount++) //rename variable to gem count
            {

                x = rnd.Next(-900, 900);
                z = rnd.Next(-900, 900);

                timerPu = new TimerPU(mSceneMgr, gameHMD);
                timerPu.SetPosition(new Vector3(x, 0, z));

                timerPUs.Add(timerPu);

            }
        }

        /// <summary>
        /// Spawns life powerups in random places.
        /// </summary>
        public void spawnLifePU()
        {
            if (((PlayerStats)player.Stats).Lives.Value <= 2)
            {
                Random rnd = new Random();
                float x;
                float z;

                for (var lifeCount = 0; lifeCount < 1; lifeCount++)
                {
                    x = rnd.Next(-900, 900);
                    z = rnd.Next(-900, 900);

                    lifePu = new LifePU(player.Stats.Lives, mSceneMgr);
                    lifePu.SetPosition(new Vector3(x, 0, z));

                    lifePus.Add(lifePu);
                }
            }

        }

        /// <summary>
        /// Spawns health powerups in random places.
        /// </summary>
        public void spawnHealthPU()
        {
            if (((PlayerStats)player.Stats).Health.Value <= 10)
            {
                Random rnd = new Random();
                float x;
                float z;

                for (var healthCount = 0; healthCount < 2; healthCount++)
                {
                    x = rnd.Next(-900, 900);
                    z = rnd.Next(-900, 900);

                    healthPu = new HealthPU(player.Stats.Health, mSceneMgr);
                    healthPu.SetPosition(new Vector3(x, 0, z));

                    healthPus.Add(healthPu);
                }
            }
        }

        /// <summary>
        /// Spawns shield powerups in random places.
        /// </summary>
        public void spawnShieldPU()
        {

            if (((PlayerStats)player.Stats).Shield.Value == 0)
            {
                Random rnd = new Random();
                float x;
                float z;

                for (var shieldCount = 0; shieldCount < 2; shieldCount++)
                {
                    x = rnd.Next(-900, 900);
                    z = rnd.Next(-900, 900);

                    shieldPu = new ShieldPU(player.Stats.Shield, mSceneMgr);
                    shieldPu.SetPosition(new Vector3(x, 0, z));

                    shieldPus.Add(shieldPu);
                }
            }

        }

        /// <summary>
        /// Spawns bombs powerups in random places.
        /// </summary>
        public void spawnBombs()
        {
            Random rnd = new Random();
            float x;
            float z;

            for (var bombCount = 0; bombCount < 10; bombCount++)
            {
                x = rnd.Next(-900, 900);
                z = rnd.Next(-900, 900);

                bomb = new Bomb(mSceneMgr, (PlayerStats)player.Stats);
                    bomb.SetPosition(new Vector3(x, 0, z));



                bombs.Add(bomb);
            }
        }
        /// <summary>
        /// This method destrois the scene
        /// </summary>

        /// <summary>
        /// This method update the scene after a frame has finished rendering. This holds the updates for the Gems, the powerups, the player and the player's controller and the enemy updates.
        /// </summary>
        /// <param name="evt"></param>
        protected override void UpdateScene(FrameEvent evt)
        {


            base.UpdateScene(evt);

            gameHMD.Update(evt);

            physics.UpdatePhysics(0.01f);

            ///TIMER
            if (timerPUs.Count == 0)
            {
                spawnTimePU();
            }


            foreach (TimerPU timerPu in timerPUs)
            {
                timerPu.Update(evt);
                if (timerPu.RemoveMe)
                    timerPUToRemove.Add(timerPu);
            }

            foreach (TimerPU timerPu in timerPUToRemove)
            {
                timerPUs.Remove(timerPu);
                timerPu.Dispose();
            }
            timerPUToRemove.Clear();

            if(bombs.Count == 0)
            {
                spawnBombs();

            }

            foreach (Bomb bomb in bombs)
            {
                bomb.Update(evt);
                if (bomb.RemoveMe)
                    bombToRemove.Add(bomb);
            }

            foreach (Bomb bomb in bombToRemove)
            {
                bombs.Remove(bomb);
                bomb.Dispose();
            }
            bombToRemove.Clear();


            //GEMS
            if (blueGems.Count == 0)
            {
                spawnBlueGems();
            }


            foreach (BlueGem blueGem in blueGems)
            {
                blueGem.Update(evt);
                blueGem.Animate(evt);
                if (blueGem.RemoveMe)
                    blueGemToRemove.Add(blueGem);
            }

            foreach (BlueGem blueGem in blueGemToRemove)
            {
                blueGems.Remove(blueGem);
                blueGem.Dispose();
            }
            blueGemToRemove.Clear();




            if(redGems.Count == 0)
            {
                spawnRedGems();
            }
            foreach (RedGem redGem in redGems)
            {
                redGem.Update(evt);
                redGem.Animate(evt);
                if (redGem.RemoveMe)
                    redGemToRemove.Add(redGem);
            }

            foreach (RedGem redGem in redGemToRemove)
            {
                redGems.Remove(redGem);
                redGem.Dispose();

            }
            redGemToRemove.Clear();

            ///HEALTH
            if (healthPus.Count == 0)
            {
                spawnHealthPU();
            }
            foreach (HealthPU healthPu in healthPus)
            {
                healthPu.Update(evt);
                if (healthPu.RemoveMe)
                    healthPuToRemove.Add(healthPu);
            }

            foreach (HealthPU healthPu in healthPuToRemove)
            {
                healthPus.Remove(healthPu);
                healthPu.Dispose();

            }
            healthPuToRemove.Clear();

            ///LIFE
            if (lifePus.Count == 0)
            {
                spawnLifePU();
            }

            foreach (LifePU lifePu in lifePus)
            {
               lifePu.Update(evt);
                if (lifePu.RemoveMe)
                    lifePuToRemove.Add(lifePu);
            }

            foreach (LifePU lifePu in lifePuToRemove)
            {
                lifePus.Remove(lifePu);
                lifePu.Dispose();

            }
            lifePuToRemove.Clear();


            //SHIELDPU
            if (shieldPus.Count == 0)
            {
                spawnShieldPU();
            }


            foreach (ShieldPU shieldPu in shieldPus)
            {
                shieldPu.Update(evt);
                if (shieldPu.RemoveMe)
                    shieldPuToRemove.Add(shieldPu);
            }

            foreach (ShieldPU shieldPu in shieldPuToRemove)
            {
                shieldPus.Remove(shieldPu);
                shieldPu.Dispose();
            }
            shieldPuToRemove.Clear();


            //ENEMIES
            foreach (Enemy enemy in enemys)
                {
                    enemy.Update(evt);
                    enemy.Movement.Animate(evt);
                }

                inputManager.ProcessInput(evt);


                player.Update(evt);



        }






        /// <summary>
        /// This method create a new camera
        /// </summary>
        protected override void CreateCamera()
        {
            ///base.CreateCamera();
            mCamera = mSceneMgr.CreateCamera("PlayerCam");
            mCamera.Position = new Vector3(0, 20, -100);

            mCamera.LookAt(new Vector3(0, 0, 0));
            mCamera.NearClipDistance = 5;
            mCamera.FarClipDistance = 1000;
            mCamera.FOVy = new Degree(70);

            mCameraMan = new CameraMan(mCamera);
            mCameraMan.Freeze = true;

        }

        /// <summary>
        /// This method create a new viewport
        /// </summary>
        protected override void CreateViewports()
        {
            ///base.CreateViewports();
            Viewport viewport = mWindow.AddViewport(mCamera);
            viewport.BackgroundColour = ColourValue.Black;
            mCamera.AspectRatio = viewport.ActualWidth / viewport.ActualHeight;
        }

        /// <summary>
        /// This method set create a frame listener to handle events before, during or after the frame rendering
        /// </summary>
        protected override void CreateFrameListeners()
        {
            base.CreateFrameListeners();
            mRoot.FrameRenderingQueued +=
                 new FrameListener.FrameRenderingQueuedHandler(inputManager.ProcessInput);
            /*mRoot.FrameRenderingQueued +=
                 new FrameListener.FrameRenderingQueuedHandler(inputManager.PlayerController.Update);
                 */
        }

        /// <summary>
        /// This method initilize the inputs reading from keyboard adn mouse
        /// </summary>
        protected override void InitializeInput()
        {
            base.InitializeInput();
            int windowHandle;
            mWindow.GetCustomAttribute("WINDOW", out windowHandle);
            inputManager.InitInput(ref windowHandle);
        }

        protected override void DestroyScene()
        {
            base.DestroyScene();
            gameHMD.Dispose();
            environment.Dispose();

            //foreach (BlueGem blueGem in blueGems)
            //{
            //    blueGem.Dispose();
            //}

            physics.Dispose();


        }
    }
}
