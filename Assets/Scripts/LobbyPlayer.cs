using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LobbyPlayer : MonoBehaviour
{
    [SerializeField] private TextMeshPro _playerName;
    [SerializeField] private Renderer _isReadyRenderer;

    private MaterialPropertyBlock _propertyBlock;
    private LobbyPlayerData _data;

    private void Start()
    {
        _propertyBlock = new MaterialPropertyBlock();
    }

    public void SetData(LobbyPlayerData data)
    {
        _data = data;
        _playerName.text = _data.GamerTag;

        if (_data.IsReady)
        {
            if (_isReadyRenderer != null)
            {
                _isReadyRenderer.GetPropertyBlock(_propertyBlock);
                _propertyBlock.SetColor("_Color", Color.green);
                _isReadyRenderer.SetPropertyBlock(_propertyBlock);
            }
        }

        gameObject.SetActive(true);
    }
}
