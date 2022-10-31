using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // kill player on collision
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameBehavior game = GameObject.Find("GameManager").GetComponent<GameBehavior>();
            game.Lose();
        }
    }

}
