using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Ghost : MonoBehaviour
{
    public GameObject pacman;
    [HideInInspector]
    public Node node;
    public Movement movement;
    private Vector3 initialPosition ;
    private Vector3 homePosition = new Vector3(16f, 16f, 0f);
    public virtual void Awake()
    {
        initialPosition = transform.position;
        movement = GetComponent<Movement>();
        pacman = GameObject.FindGameObjectWithTag("Player");
    }
    public virtual void OnEnable()
    {
        enabled = true;
        
    }
    public virtual void OnDisable()
    {
        enabled = false;
        CancelInvoke();
    }

    public void MoveTowardsTarget(Vector2 target,Node node)
    {

        Vector2 direction = Vector2.zero;
        float minDistance = float.MaxValue;
        foreach (Vector2 avaliableDirection in node.avaliableDirections)
        {
            
            Vector2 newPosition = new Vector2(transform.position.x, transform.position.y) + avaliableDirection;
            float distance = Vector2.Distance(newPosition, target);
            if (distance < minDistance)
            {
                
                direction = avaliableDirection;
                minDistance = distance;
            }

        }
        
        movement.SetDirection(direction);
    }
    public virtual bool CheckIt(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Node") && enabled)
        {

            node = collision.GetComponent<Node>();
            return true;
            

        }
        return false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            if (GetComponent<GhostStatus>().ghostStatus == ghostStatus.frightened)
            {
                this.transform.position = homePosition;
                GetComponent<GhostStatus>().ChangeEnum(ghostStatus.home);
            }
        }
    }
    
}
