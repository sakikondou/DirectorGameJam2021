using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    InputController m_input;
    [SerializeField] TombGenerator m_generator;
    private void Start()
    {
        m_input = GetComponent<InputController>();
        Debug.Log($"m_input != null : {m_input != null}");
        m_input.AllStopInput();

    }


    void StartGame()
    {
        m_input.AllStartInput();
        m_generator.enabled = true;
    }
}
