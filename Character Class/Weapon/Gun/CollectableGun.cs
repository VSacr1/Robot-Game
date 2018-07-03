using System;
using Mogre;
namespace Game
{
    class CollectableGun : Collectable
    {
        Gun gun;

        /// <summary>
        /// gets the return value of gun. 
        /// </summary>
        public Gun Gun
        {
            get { return gun; }
        }

        Armoury playerArmoury;

        /// <summary>
        /// sets playerArmoury as a value. 
        /// </summary>
        public Armoury PlayerAmoury
        {
            set { playerArmoury = value; }
        }

        /// <summary>
        /// sets the game node scale in the constructor
        /// </summary>
        /// <param name="mSceneMgr"></param>
        /// <param name="gun"></param>
        /// <param name="playerAmoury"></param>
        public CollectableGun(SceneManager mSceneMgr, Gun gun, Armoury playerAmoury)
        {

            this.mSceneMgr = mSceneMgr;
            GameNode.Scale(new Vector3(1.5f));

        }

        /// <summary>
        /// This updates the collectiable gun class by taking from the collectable class updates and removing a child from the gun.gameNode.parent. 
        /// </summary>
        /// <param name="evt"></param>
        public override void Update(FrameEvent evt)
        {
            ///Animate(evt);

            base.Update(evt);
                                                                    ///THIS IS WHERE COLLISION DETECTION WILL GO. 
            (gun.GameNode.Parent).RemoveChild(gun.GameNode.Name);

            playerArmoury.AddGun(gun);

            ///to detach the gun model from the current node and add it to the player sub scene graph call dispose before the break; 
        }


    }
}
