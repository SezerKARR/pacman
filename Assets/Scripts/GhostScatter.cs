using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScatter : Ghost

{
    public Vector3[] targets;
    int i;
    // Start is called before the first frame update
   

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (CheckIt(collision))
        {
            
            
           
            if(Vector3.Distance(transform.position, targets[i]) < 1f)
            {

                i = i == 1 ? 0 : 1;
            }
            MoveTowardsTarget(targets[i],node);

        }
        
    }
    
}
