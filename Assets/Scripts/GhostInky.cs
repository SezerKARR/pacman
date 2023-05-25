using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostInky : Ghost
{
    
    public GameObject ghostBlinky;
    // Start is called before the first frame update
    public override void Awake()
    {
        base.Awake();
        ghostBlinky = GameObject.Find("GhostBlinky");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (base.CheckIt(collision))
        {
            MoveTowardsTarget(pacman.transform.position - (ghostBlinky.transform.position - pacman.transform.position),node);
        }

    }
}
