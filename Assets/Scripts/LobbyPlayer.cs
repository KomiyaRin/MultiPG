using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LobbyPlayer : MonoBehaviour
{
    [SerializeField] private TextMeshPro _playerName;

    private LobbyPlayerData _data;

    public void SetData(LobbyPlayerData data)
    {
        _data = data;
        _playerName.text = _data.GamerTag;
        gameObject.SetActive(true);
    }
}
