using System;
using Mogre;

namespace Game
{
    abstract class CharacterStats
    {
        protected CharacterStats characterStats;
        public Score score;

        /// <summary>
        /// 
        /// </summary>
        public CharacterStats CharacterStatsField
        {
            get { return characterStats; }
        }

        /// <summary>
        /// 
        /// </summary>
        public CharacterStats()
        {
            InitStats();
        }

        public Stat health; 

        /// <summary>
        /// 
        /// </summary>
        public Stat Health
        {
            get { return health; }
        }

        public Stat shield;

        /// <summary>
        /// 
        /// </summary>
        public Stat Shield
        {
            get { return shield; }
            set { shield = value; }
        }

        public Stat lives; 

        /// <summary>
        /// 
        /// </summary>
        public Stat Lives
        {
            get { return lives; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Score Score
        {
            set { score = value; }
            get { return score; }
        }

        /// <summary>
        /// 
        /// </summary>
        virtual public void InitStats()
        {
            lives = new Stat();
            health = new Stat();
            shield = new Stat(); 
        }
    }


}
