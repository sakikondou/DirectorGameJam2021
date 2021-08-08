using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bound : MonoBehaviour
{
    Vector2 reflectDir;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "TombBullet")
        {

        }
    }
}
