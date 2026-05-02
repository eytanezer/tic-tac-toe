using System;
using UnityEngine;

namespace TicTacToe
{
    public class GameManager : MonoBehaviour
    {
        private int _scoreX;
        private int _scoreO;
        private String _waitingWinner;

        private void OnEnable()
        {
            GameEvents.GameWon += OnGameWon;
            GameEvents.GameDrawn += OnGameDrawn;
            GameEvents.NewGame += OnNewGame;
        }
        
        private void OnDisable()
        {
            GameEvents.GameWon -= OnGameWon;
            GameEvents.GameDrawn -= OnGameDrawn;
            GameEvents.NewGame += OnNewGame;
        }

        private void Start()
        {
            GameEvents.ScoreChanged?.Invoke(_scoreX, _scoreO);
        }

        private void OnGameWon(string winner)
        {
            _waitingWinner = winner;
            
            GameEvents.ResultReady?.Invoke($"{winner} wins!");
        }

        private void OnGameDrawn()
        {
            GameEvents.ResultReady?.Invoke("Draw!");
        }
        
        private void OnNewGame()
        {
            if (_waitingWinner == "X")
            {
                _scoreX++;
            }
            else
            {
                _scoreO++;
            }

            GameEvents.ScoreChanged?.Invoke(_scoreX, _scoreO);
        }
    }
}
