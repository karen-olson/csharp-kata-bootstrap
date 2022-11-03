using System;
using System.Collections.Generic;

namespace DotnetStarter.Logic.BowlingKata
{
    public class Game
    {
        private readonly List<int> _rolls = new(); 
        
        public void Roll(int pins)
        {
            _rolls.Add(pins);
        }

        public int Score()
        {
            int score = 0;
            int rollCursor = 0;
            for (int frameCursor = 0; frameCursor < 10; frameCursor++)
            {
                if (Spare(rollCursor))
                {
                    score += SpareBonus(rollCursor);
                    rollCursor += 2;
                }
                else if (Strike(rollCursor))
                {
                    score += StrikeBonus(rollCursor);
                    rollCursor += 1;
                }
                else
                {
                    score += RegularBonus(rollCursor);
                    rollCursor += 2;
                }
            }

            return score;
        }

        private Boolean Spare(int rollCursor)
        {
            return _rolls[rollCursor] + _rolls[rollCursor + 1] == 10;
        }
        
        private Boolean Strike(int rollCursor)
        {
            return _rolls[rollCursor] == 10;
        }

        private int SpareBonus(int rollCursor)
        {
            return 10 + _rolls[rollCursor + 2];
        }

        private int StrikeBonus(int rollCursor)
        {
            return 10 + _rolls[rollCursor + 1] + _rolls[rollCursor + 2];
        }

        private int RegularBonus(int rollCursor)
        {
            return _rolls[rollCursor] + _rolls[rollCursor + 1];
        }
    }
}
