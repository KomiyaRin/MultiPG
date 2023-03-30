using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbySpawner : MonoBehaviour
{
    [SerializeField] private List<LobbyPlayer> _players;

    private void OnEnable()
    {
        LobbyEvent.OnLobbyUpdated += OnLobbyUpdated;
    }

    private void OnDisable()
    {
        LobbyEvent.OnLobbyUpdated -= OnLobbyUpdated;
    }

    private void OnLobbyUpdated()
    {
        List<LobbyPlayerData> playerDatas = GameLobbyManager.Instance.GetPlayers();

        for (int i = 0; i < playerDatas.Count; i++)
        {
            LobbyPlayerData data = playerDatas[i];
            _players[i].SetData(data);
        }
    }
}
