using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPellet : Pellet
{
    public float frightenedTime;
    // Start is called before the first frame update
    protected override void eated()
    {
        FindObjectOfType<GameManager>().PowerPelletEated();
        base.eated();
    }



}
