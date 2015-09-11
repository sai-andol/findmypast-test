using System;
using System.Linq;
using TicTacToeGame.Rules;

namespace TicTacToeGame.Services
{
    public class ResultsCheckingService : IResultsCheckingService
    {
        private readonly IGameRule[] _gameRules;

        public ResultsCheckingService(params IGameRule[] gameRules)
        {
            _gameRules = gameRules;
        }

        public bool CheckForAnyResult()
        {
            return _gameRules.Any(rule => rule.Apply());
        }

        public bool CheckForAWin()
        {
            return _gameRules.Where(rule => !IsADrawRule(rule)).Any(winRule => winRule.Apply());
        }

        public bool CheckForDraw()
        {
            return _gameRules.First(IsADrawRule).Apply();
        }

        private static bool IsADrawRule(IGameRule rule)
        {
            try
            {
                ((GameIsADrawRule)rule).GetType();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}