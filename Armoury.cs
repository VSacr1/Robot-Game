using System;
using System.Collections.Generic;
using Mogre;

namespace Game
{
    class Armoury
    {
        /// <summary>
        /// Constructor
        /// This creates a new List for the class Gun called collectedGuns. 
        /// </summary>
        public Armoury()
        {
            this.collectedGuns = new List<Gun>();
        }

        Gun gun; 

        protected bool gunChange;

        /// <summary>
        /// Boolean to change guns. 
        /// returns gunchange and sets value. 
        /// </summary>
        public bool GunChange
        {
            get { return gunChange; }
            set { gunChange = value; }
        }

        protected Gun activeGun;

        /// <summary>
        /// returns active gun and sets value
        /// </summary>
        public Gun ActiveGun
        {
            get { return activeGun; }
            set { activeGun = value; }
        }

        protected List<Gun> collectedGuns;

        /// <summary>
        /// This returns the value of the list created in the constructor. 
        /// </summary>
        public List<Gun> CollectedGuns
        {
            get { return collectedGuns; }
        }

        /// Need to add (new List<Gun>();) to the constructor. 

           
       ///<summary>
       /// Change gun method. 
       /// </summary>
      

        public void ChangeGun(Gun gun)
        {
            activeGun = new Gun(); 
            gunChange = true; 
        }

        /// <summary>
        /// Swaps the gun currently held for another gun picked up. 
        /// </summary>
        /// <param name="i"></param>
        public void SwapGun(int i)
        {
            if(collectedGuns != null)
            {
                ChangeGun(gun); 
            }

            if(activeGun != null)
            {
                ChangeGun(gun); 
            }
        }

        /// <summary>
        /// Add the gun to the collection and reloads the ammo to full.  
        /// </summary>
        /// <param name="gun"></param>
        /// <param name="add"></param>
        public void AddGun(Gun gun, bool add = true)
        {
            foreach (Gun g in collectedGuns)
            {
                if (add == true && (g.GetType() == gun.GetType()))
                {
                    g.ReloadAmmo();
                    ChangeGun(g);
                    add = false;
                }
            }
            if(add == true)
            {
                ChangeGun(gun);
                collectedGuns.Add(gun); 
            }

            else
            {
               gun.Dispose();
            }
                ///if both add == true && (g.GetType()==gun.GetType()) = true
                ///Call the change gun method passing g to it and then set add to false. 
            
        }

        /// <summary>
        /// Armoury dispose method. Gets rid of collectedGuns and activeGun. 
        /// </summary>
        protected void Dispose()
        {
            if(collectedGuns != null)
            {
                ///Dispose each gun in the collectedGuns list
            }

            if(activeGun != null)
            {
                ///Dispose each gun in the acitveGun list. 
            }
        }

    }
}
