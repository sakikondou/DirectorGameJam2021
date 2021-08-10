using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary>
    /// プレイヤーID
    /// </summary>
    [SerializeField] int m_playerID = -1;
    /// <summary>
    /// プレイヤーID
    /// </summary>
    public int PlayerID
    {
        set
        {
            //GameStartからしかIDを設定できないようにする
            System.Diagnostics.StackFrame caller = new System.Diagnostics.StackFrame(1);
            if (caller.GetMethod().ReflectedType.Name == typeof(GameStart).Name)
            {
                m_playerID = value;
            }
        }
        get { return m_playerID; }
    }
}
