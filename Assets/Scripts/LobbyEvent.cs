using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyEvent : MonoBehaviour
{
    public delegate void LobbyUpdated();
    public static LobbyUpdated OnLobbyUpdated;

    public delegate void LobbyReady();
    public static LobbyReady OnLobbyReady;
}
