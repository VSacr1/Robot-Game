using System;
using Mogre;

namespace Game
{
    class CannonGun : Gun
    {

        SceneManager mSceneMgr;

        /// <summary>
        /// The cannon gun takes the mSceneMgr as parameteres and the constructor holds a new ammo stat and the maxAmmo value of 10
        /// </summary>
        /// <param name="mSceneMgr"></param>
        public CannonGun(SceneManager mSceneMgr)
        {
            this.mSceneMgr = mSceneMgr;
            maxAmmo = 10; 
            ammo = new Stat();

            ammo.InitValue(maxAmmo);
        }

        protected ModelElement cannonGun; 

        /// <summary>
        /// This gets a return value of the cannonGun and sets the cannonGun as a value. 
        /// </summary>
        public ModelElement CannonGunModel
        {
            get { return cannonGun; }
            set { cannonGun = value; }
        }

        /// <summary>
        /// This holds the model element cannonGun and the gameNode in which the gun is created
        /// </summary>
        virtual protected void LoadModelElement()
        {
            cannonGun = new ModelElement(mSceneMgr, "CannonGun.mesh");
            gameNode = mSceneMgr.CreateSceneNode(); 
        }

        /// <summary>
        /// The assemble model combines the parts from the Load model Element
        /// </summary>
        virtual protected void AssembleModel()
        {
            gameNode.AddChild(cannonGun.GameNode);
            mSceneMgr.RootSceneNode.AddChild(gameNode);
        }

        /// <summary>
        /// This load the loadmodelelement and the assemblemodel. 
        /// </summary>
        protected override void LoadModel()
        {
            base.LoadModel();
            LoadModelElement();
            AssembleModel(); 
        }

        /// <summary>
        /// This checks whether the ammo value is equal to 0 and if there is still ammo
        /// then the gun will fire a distance of 10 from the gun position.
        /// </summary>
        public override void Fire()
        {
            base.Fire();
            if(ammo.Value == 0)
            {

            }

            else
            {
                projectile.SetPosition(GunPostion() + 10 * GunDirection());

                ammo.Decrease(1); 
            }

        }


        /// <summary>
        /// Reloads the ammo of the gun. 
        /// </summary>
        public override void ReloadAmmo()
        {
            base.ReloadAmmo();
            if(ammo.Value < maxAmmo)
            {
                ammo.Increase(10); 
            }
        }
        /// <summary>
        /// Disposes of the model and the game node. 
        /// </summary>
        virtual protected void Dispose()
        {
            if(cannonGun != null)
            {
                cannonGun.Dispose(); 
            }

            if (gameNode != null)
            {
                gameNode.Dispose();
            }
        }



    }
}
