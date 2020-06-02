using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class pacman_movement : MonoBehaviour
{
    public float speed = 0.4f;


    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }


    bool CanMoveTo(UnityEngine.Vector2 dir)
    {
        UnityEngine.Vector2 pacmanPos = this.transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pacmanPos + dir, pacmanPos);
        Collider2D pacmanCollider = GetComponent<Collider2D>();
        Collider2D coll
        return hit.collider == GetComponent<Collider2D>();
    }
}
