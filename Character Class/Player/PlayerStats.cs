using System;
using Mogre; 
namespace Game
{
    class PlayerStats : CharacterStats
    {
        public Score score;
        ///protected Stat health;
        ////protected Stat shield;
        ///protected Stat lives; 
        protected PlayerStats playerStat;

        /// <summary>
        /// This gets the return value of the player stats. 
        /// </summary>
        public PlayerStats PlayerStatsField
        {
            get { return playerStat; }
        }


        /// <summary>
        /// Sets the score as a value and gets the return value of score. 
        /// </summary>
        public Score Score
        {
            set { score = value; }
            get { return score; }
        }

        /// <summary>
        /// This sets up a new score for the player and gives the stats a maximum value
        /// Health = 100, shield = 100, lives = 4, 
        /// </summary>
        public override void InitStats()
        {
            base.InitStats();

            score = new Score();
            score.InitValue(0);

            ///health = new Stats();
            health.InitValue(100);

            ///shield = new Stats();
            shield.InitValue(100);

            ///lives = new Stats();
            lives.InitValue(4);

           

        }


    }
}
