using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class pacman_movement : MonoBehaviour
{
    public float speed = 0.4f;
    Vector2 destination = Vector2.zero;

    void Start()
    {
        destination = this.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Calculamos el nuevo punto donde hay que ir en base a la variable de destino
        Vector2 newPos = Vector2.MoveTowards(this.transform.position, destination, speed);
        //usamos el rigidbody para transportar a pacman hasta dicha posicion
        GetComponent<Rigidbody2D>().MovePosition(newPos);

        float distanceToDestination = Vector2.Distance((Vector2)this.transform.position, destination);

        if(distanceToDestination < 1f)
        {
            if (Input.GetKey(KeyCode.UpArrow) && CanMoveTo(Vector2.up))
            {
                destination = (Vector2)this.transform.position + Vector2.up;
            }

            if (Input.GetKey(KeyCode.RightArrow) && CanMoveTo(Vector2.right))
            {
                destination = (Vector2)this.transform.position + Vector2.right;
            }

            if (Input.GetKey(KeyCode.DownArrow) && CanMoveTo(Vector2.down))
            {
                destination = (Vector2)this.transform.position + Vector2.down;
            }

            if (Input.GetKey(KeyCode.LeftArrow) && CanMoveTo(Vector2.left))
            {
                destination = (Vector2)this.transform.position + Vector2.left;
            }
        }

        Vector2 dir = destination - (Vector2)this.transform.position;
        GetComponent<Animator>().SetFloat("X", dir.x);
        GetComponent<Animator>().SetFloat("Y", dir.y);


    }


    bool CanMoveTo(Vector2 dir)
    {
        Vector2 pacmanPos = this.transform.position;
        //se traza una linea desde el objetivo hacia pacman
        RaycastHit2D hit = Physics2D.Linecast(pacmanPos + dir*2, pacmanPos);
        Collider2D pacmanCollider = GetComponent<Collider2D>();
        Collider2D hitCollider = hit.collider;

        //se comprueba el primer objeto al que choca la linea imaginaria
        /*if (hitCollider == pacmanCollider)
        {
            //no tengo nada en medio por lo tanto puedo moverme para alla
            return true;
        }
        else
        {
            //tengo un collider delante que no es el de pacman -> no puedo moverme alli
            return false;
        }*/
        /*mas simple
        return hitCollider == pacmanCollider; */

        // aun mas simple
          return hit.collider == GetComponent<Collider2D>();
         

    }
}
