using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject _mainScreen;
    [SerializeField] private GameObject _joinScreen;
    [SerializeField] private Button _hostButton;
    [SerializeField] private Button _joinButton;

    [SerializeField] private Button _summitCodeButton;
    [SerializeField] private TextMeshProUGUI _codeText;

    void OnEnable()
    {
        _hostButton.onClick.AddListener(OnHostClicked);
        _joinButton.onClick.AddListener(OnJoinClicked);
        _summitCodeButton.onClick.AddListener(OnSummitCodeClicked);
    }

    void OnDisable()
    {
        _hostButton.onClick.RemoveListener(OnHostClicked);
        _joinButton.onClick.RemoveListener(OnJoinClicked);
        _summitCodeButton.onClick.RemoveListener(OnSummitCodeClicked);
    }

    private async void OnHostClicked()
    {
        bool succeeded = await GameLobbyManager.Instance.CreateLobby();
        if (succeeded)
        {
            SceneManager.LoadSceneAsync("Lobby");
        }
    }

    private void OnJoinClicked()
    {
        _mainScreen.SetActive(false);
        _joinScreen.SetActive(true);
    }

    private async void OnSummitCodeClicked()
    {
        string code = _codeText.text;
        code = code.Substring(0, code.Length - 1);

        bool succeeded = await GameLobbyManager.Instance.JoinLobby(code);
        if (succeeded)
        {
            SceneManager.LoadSceneAsync("Lobby");
        }
    }
}
