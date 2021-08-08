using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JoinPlayer : MonoBehaviour
{
    PlayerInputManager m_playerInputManager = null;
    int m_playerId = 0;

    private void Start()
    {
        m_playerInputManager = GetComponent<PlayerInputManager>();
    }

    public void Join()
    {
        m_playerId = m_playerInputManager.playerCount;
    }
}
