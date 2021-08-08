using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    float m_timer = 0f;
    InputController m_input;
    bool m_stoped;
    Animator m_animator;

    private void Start()
    {
        m_input = GetComponent<InputController>();
        Debug.Log($"m_input != null : {m_input != null}");
        m_input.AllStopInput();
        m_animator = GetComponent<Animator>();
        m_animator.Play("CountDown");
    }
    void Update()
    {
        //m_timer += Time.deltaTime;
        //if (m_timer < 6.0f && m_stoped == false)
        //{
        //    m_input.AllStopInput();
        //    m_stoped = true;
        //}
        //else if (m_timer >= 6.0f && m_stoped == true)
        //{
        //    m_input.AllStartInput();
        //    m_stoped = false;
        //}
    }

    void StartGame()
    {
        m_input.AllStartInput();
    }
}
