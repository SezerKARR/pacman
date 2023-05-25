using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    public int points = 10;
    void Start()
    {
    }
    protected virtual void eated()
    {
        
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            eated();
            FindObjectOfType<GameManager>().PelletEated(points);
            this.gameObject.SetActive(false);
        }
        
    }
    
}
