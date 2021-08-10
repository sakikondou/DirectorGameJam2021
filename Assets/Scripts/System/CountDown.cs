using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    InputController m_input;
    BomGenerator m_generator;
    private void Start()
    {
        m_input = GetComponent<InputController>();
        m_generator = FindObjectOfType<BomGenerator>();
        m_input.AllStopInput();
    }

    /// <summary>
    /// ゲームプレイを開始する。
    /// カウントダウンのAnimationにこの関数を張り付ける。
    /// </summary>
    void PlayStart()
    {
        m_input.AllStartInput();
        m_generator.enabled = true;
    }
}
