using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostClyde : Ghost
{
    public override void Awake()
    {
        base.Awake();
    }
    public override void OnDisable()
    {
        base.OnDisable();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (base.CheckIt(collision))
        {
            
           
            if (Vector2.Distance(transform.position, pacman.transform.position) >= 8f)
            {
                
                MoveTowardsTarget(pacman.transform.position, node);
                
            }
            else
            {

                gameObject.GetComponent<GhostStatus>().ChangeEnum(ghostStatus.scatter);
                
            }



        }



    }
}
