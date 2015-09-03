using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashcardsProgram
{
    public class Card
    {
        //Creates the Card Class, to store the data for each Card in memory.
        public string Q;
        public string A;
        public string N;
        public int score;
        public int index;
        
        public void New(string Qu, string An, string No, int i) //creates a new card based upon info.
        {
            Q = Qu;
            A = An;
            N = No;
            score = 0;
            index = i;
            
        }
    }
}
