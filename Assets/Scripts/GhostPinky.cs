using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPinky : Ghost
{
    public override void Awake()
    {
        base.Awake();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        
        if (base.CheckIt(collision))
        {
            if (Vector2.Distance(transform.position, pacman.transform.position) >= 6f)
            {
                Vector2 pacmanDirection = pacman.GetComponent<Movement>().direction;

                int maxDistance = 6;
                for (int i = 6; i >= 0; i--)
                {
                    RaycastHit2D hit = Physics2D.BoxCast(pacman.transform.position, Vector2.one * 0.5f, 0, pacmanDirection, i, pacman.GetComponent<Movement>().obstacleLayer);
                    
                    if (hit.collider == null)
                    {
                        
                        maxDistance = i;
                        break;
                        

                    }

                }
               
                MoveTowardsTarget(pacman.transform.position + new Vector3(pacmanDirection.x * maxDistance, pacmanDirection.y * maxDistance, 0), node);
            }
            else
            {
                MoveTowardsTarget(pacman.transform.position, node);
            }



        }

    }
}
