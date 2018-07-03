using System;
using Mogre; 

namespace Game
{
    class Gun : MoveableElement
    {
        protected int maxAmmo;

        protected Projectile projectile; 

        /// <summary>
        /// Set the projectiles as a value; 
        /// </summary>
        public Projectile Projectile
        {
            set { projectile = value; }
        }

        protected Stat ammo;

        /// <summary>
        /// gets the return value of the ammo stat. 
        /// </summary>
        public Stat Ammo
        {
            get { return ammo; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Vector3 GunPostion()
        {
            SceneNode node = gameNode;
            try
            {
                while (node.ParentSceneNode.ParentSceneNode != null)
                {
                    node = node.ParentSceneNode;
                }
            }
            catch (System.AccessViolationException)
            { }
            return node.Position; 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Vector3 GunDirection()
        {
            SceneNode node = gameNode;
            try
            {
                while (node.ParentSceneNode.ParentSceneNode != null)
                {
                    node = node.ParentSceneNode;
                }
            }
            catch (System.AccessViolationException)
            { }
            Vector3 direction = node.LocalAxes * gameNode.LocalAxes.GetColumn(2); 
            return direction; 
        }

        /// <summary>
        /// Loads model and is inherited from its sub classes
        /// </summary>
        virtual protected void LoadModel()
        {

        }

        /// <summary>
        /// Reloads the ammo and is inherited from its sub classes
        /// </summary>
        virtual public void ReloadAmmo()
        { }

        /// <summary>
        ///  Fires the gun and is inherited from its sub classes
        /// </summary>
        virtual public void Fire() { }

    }
}
