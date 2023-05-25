using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deneme : MonoBehaviour

{
    public Vector3[] targets;
    int i;
    public Ghost ghost;
    // Start is called before the first frame update
    public void Awake()
    {
        ghost = gameObject.GetComponent<Ghost>();


    }
    


    /*private void OnTriggerEnter2D(Collider2D collision)
    {

        if (ghost.CheckIt(collision) != null)
        {



            if (Vector3.Distance(transform.position, targets[i]) < 1f)
            {

                i = i == 1 ? 0 : 1;
            }
            ghost.MoveTowardsTarget(targets[i], ghost.CheckIt(collision));

        }

    }*/

}
