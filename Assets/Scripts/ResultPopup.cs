using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe
{
    public class ResultPopup : MonoBehaviour
    {
        [SerializeField] private GameObject _root;
        [SerializeField] private TMP_Text _resultText;
        [SerializeField] private Button _newGameButton;
        [SerializeField] private Button _undoButton;

        private void Awake()
        {
            _newGameButton.onClick.AddListener(Hide);
            _newGameButton.onClick.AddListener(() => GameEvents.NewGame?.Invoke());
            
            _undoButton.onClick.AddListener(() => GameEvents.UndoMove?.Invoke());
            
            _root.SetActive(false);
        }

        private void OnEnable()
        {
            GameEvents.ResultReady += OnResultReady;
            GameEvents.UndoMove += Hide;
        }

        private void OnDisable()
        {
            GameEvents.ResultReady -= OnResultReady;
            GameEvents.UndoMove -= Hide;
        }

        private void OnResultReady(string message)
        {
            _resultText.text = message;
            _root.SetActive(true);
        }

        private void Hide()
        {
            _root.SetActive(false);
        }
    }
}
