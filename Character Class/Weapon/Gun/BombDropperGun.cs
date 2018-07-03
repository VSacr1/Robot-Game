using System;
using Mogre; 

namespace Game
{
    class BombDropperGun : Gun
    {

        /// <summary>
        /// This constructor loads the model and sets the maximum ammo at 10. 
        /// </summary>
        /// <param name="mSceneMgr"></param>
       public BombDropperGun(SceneManager mSceneMgr)
        {
            this.mSceneMgr = mSceneMgr;
            maxAmmo = 10;
            ammo = new Stat();

            LoadModel(); 

            ammo.InitValue(maxAmmo);
        }



        protected ModelElement bombGun; 

        /// <summary>
        /// Gets the return value of the Model Element bombGun and sets it as a value. 
        /// </summary>
        public ModelElement BombGunModel
        {
            get { return bombGun; }
            set { bombGun = value; }
        }

        /// <summary>
        /// This loads the components of the gun. 
        /// </summary>
        virtual protected void LoadModelElement()
        {
            bombGun = new ModelElement(mSceneMgr, "BombDropperGun.mesh");
            gameNode = mSceneMgr.CreateSceneNode(); 
        }

        /// <summary>
        /// This puts the the parts in the LoadModelElements together. 
        /// </summary>
        virtual protected void AssembleModel()
        {
            gameNode.AddChild(bombGun.GameNode);
            //mSceneMgr.RootSceneNode.AddChild(gameNode);
        }

        /// <summary>
        /// This Loads the model and is meantioned in the constructor. 
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
        /// 
        /// This reloads the ammo when the ammo value is less than the max ammo. It increases it back to it maximum value. 
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
        /// This disposes the components of the bomb gun. 
        /// </summary>
        public override void Dispose()
        {
            if(bombGun != null)
            {
                bombGun.Dispose(); 
            }

            if(gameNode != null)
            {
                gameNode.Dispose(); 
            }
        }

    }
}
