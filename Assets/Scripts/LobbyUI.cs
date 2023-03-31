using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LobbyUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _lobbyCodeText;
    [SerializeField] private Button _readyButton;
    [SerializeField] private Button _startButton;

    private void OnEnable()
    {
        _readyButton.onClick.AddListener(OnReadyPressed);
        if (GameLobbyManager.Instance.IsHost)
        {
            _startButton.onClick.AddListener(OnStartButtonClicked);
            LobbyEvent.OnLobbyReady += OnLobbyReady;
        }
    }

    private void OnDisable()
    {
        _readyButton.onClick.RemoveAllListeners();
        _startButton.onClick.RemoveAllListeners();
        LobbyEvent.OnLobbyReady -= OnLobbyReady;
    }

    private void Start()
    {
        _lobbyCodeText.text = $"Lobby code: {GameLobbyManager.Instance.GetLobbyCode()}";
    }

    private async void OnReadyPressed()
    {
        bool succeed = await GameLobbyManager.Instance.SetPlayerReady();
        if (succeed)
        {
            _readyButton.gameObject.SetActive(false);
        }
    }

    private void OnLobbyReady()
    {
        _startButton.gameObject.SetActive(true);
    }

    private void OnStartButtonClicked()
    {
        GameLobbyManager.Instance.StartGame();
    }
}
