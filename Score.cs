using System;
using Mogre;
namespace Game
{
    class Score : Stat
    {

       /// <summary>
       /// Method to increase the value using an integer called val. 
       /// </summary>
       /// <param name="val"></param>
        public override void Increase(int val)
        {
            value = val + value; 
        }

    }
}
