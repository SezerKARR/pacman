using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostFrightened : Ghost
{
    public GameObject blueFrightened;
    public GameObject whiteFrightened;
    // Start is called before the first frame update
    public  override void Awake()
    {
        base.Awake();
        blueFrightened.SetActive(false);
        whiteFrightened.SetActive(false);
        
    }

    public override void OnEnable()
    {
        base.OnEnable();
        StartCoroutine(ChangeFrigtenedAnim());
    }
    public override void OnDisable()
    {
        base.OnDisable();
        StopCoroutine(ChangeFrigtenedAnim());
        Debug.Log("disable oldu");
        blueFrightened.SetActive(false);
        whiteFrightened.SetActive(false);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CheckIt(collision))
        {

            MoveAwayFromPacman(collision.GetComponent<Node>());
        }
        
    }
    public void MoveAwayFromPacman(Node node)
    {


        Vector2 direction = Vector2.zero;
        float minDistance = float.MinValue;
        foreach (Vector2 avaliableDirection in node.avaliableDirections)
        {
            Vector2 newPosition = new Vector2(transform.position.x, transform.position.y) + avaliableDirection;
            float distance = Vector2.Distance(newPosition, pacman.transform.position);
            if (distance > minDistance)
            {
                direction = avaliableDirection;
                minDistance = distance;
            }

        }
        movement.SetDirection(direction);
    }
    IEnumerator ChangeFrigtenedAnim()
    {
        Debug.Log("geldi2");
        blueFrightened.SetActive(true);
        yield return new WaitForSeconds(4f);
        Debug.Log("geldi3");
        blueFrightened.SetActive(false);
        whiteFrightened.SetActive(true);
        yield return new WaitForSeconds(4f);
        whiteFrightened.SetActive(false);
        yield return null;
    }
}
