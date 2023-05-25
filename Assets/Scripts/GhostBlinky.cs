using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GhostBlinky : Ghost
{
    
    // Start is called before the first frame update
    public virtual void Awake()
    {
        base.Awake();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (base.CheckIt(collision))
        {
            
            MoveTowardsTarget(pacman.transform.position, node);
        }
        
    }
    

}
