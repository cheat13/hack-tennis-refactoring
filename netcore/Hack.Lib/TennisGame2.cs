using System;

namespace Hack.Lib
{
    public class TennisGame2 : ITennisGame
    {
        private int p1point;
        private int p2point;

        private string p1result = "";
        private string p2result = "";
        private string player1Name;
        private string player2Name;

        public TennisGame2(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public string GetScore()
        {
            var score = "";
            #region equal      
            if (p1point == p2point)
            {
                score = GetScoreEqualResult();
            }
            #endregion equal
            #region winner
            else if (p1point >= 4 && p2point >= 0 && (p1point - p2point) >= 2)
            {
                score = "Win for player1";
            }
            else if (p2point >= 4 && p1point >= 0 && (p2point - p1point) >= 2)
            {
                score = "Win for player2";
            }
            #endregion winner
            #region adventage

            else if (p1point > p2point && p2point >= 3)
            {
                score = "Advantage player1";
            }

            else if (p2point > p1point && p1point >= 3)
            {
                score = "Advantage player2";
            }
            #endregion adventage
            #region Not equal, Not Adventage and Not win
            else score = string.Format("{0}-{1}", GetResult(p1point), GetResult(p2point));
            #endregion
            return score;

        }

        private string GetScoreEqualResult()
        {
            var score = "";
            if (p1point < 3)
            {
                score = string.Format("{0}-All", GetResult(p1point));
            }
            else
            {
                score = "Deuce";
            }
            return score;
        }

        private string GetResult(int point)
        {
            if (point == 0) return "Love";
            if (point == 1) return "Fifteen";
            if (point == 2) return "Thirty";
            return "Forty";
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                p1point++;
            else
                p2point++;
        }


    }
}

