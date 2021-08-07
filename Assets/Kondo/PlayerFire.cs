using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] InputController m_inputController = null;
    [SerializeField] GameObject m_bullet = null;
    [SerializeField] Transform[] m_muzzles = null;

    private void Start()
    {
        m_inputController.Init();
        m_inputController.InputActions.Player.Fire.started += context => Fire();
    }

    void Fire()
    {
        for (int i = 0; i < m_muzzles.Length; i++)
        {
            Instantiate(m_bullet, m_muzzles[i]);
        }
    }
}
