using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    GameSession gameSession;

    Collider2D body;
    Collider2D feet;
    void Start()
    {
        body = GetComponent<CapsuleCollider2D>();
        feet = GetComponent<CircleCollider2D>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (feet.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            Destroy(other.gameObject);
        }
        else if (body.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            FindFirstObjectByType<GameSession>().ProcessPlayerDamage();
        }
        Debug.Log(body);
    }
}