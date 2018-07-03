using System;
using System.Collections.Generic;
using Mogre;

namespace Game
{
    class EnemyStat : CharacterStats
    {
        protected EnemyStat enemyStat; 

        /// <summary>
        /// returns the enemystats
        /// </summary>
        public EnemyStat EnemyStatField
        {
            get { return enemyStat; }
        }

        ///<summary>
        ///Sets the maximum value for the enemy stats. 
        /// </summary>
        public override void InitStats()
        {
            base.InitStats();

            health.InitValue(50);

            shield.InitValue(10);

            lives.InitValue(1); 
        }
        

    }
}
