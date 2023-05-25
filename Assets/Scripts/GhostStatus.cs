using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ghostStatus
{
    chase,
    scatter,
    frightened,
    home
}
public class GhostStatus : MonoBehaviour
{
    public ghostStatus ghostStatus;
    public Ghost ghostChase;
    public GhostScatter ghostScatter;
    public GhostFrightened ghostFrightened;
    public float timeToScatter=5;
    public float timeToChase=20;
    public float timeToFrightened=8;
    private int level;
    public void Awake()
    {
        
        ghostChase = gameObject.GetComponent<Ghost>();
        ghostScatter = gameObject.GetComponent<GhostScatter>();
        ghostFrightened = gameObject.GetComponent<GhostFrightened>();
    }
    public  void newLevel()
    {
        
    }
    public void ChangeEnum(ghostStatus ghostStatus)
    {

        if (ghostStatus != ghostStatus.home) {
            this.ghostStatus = ghostStatus;
        }
        
        if (ghostStatus == ghostStatus.home)
        {
            ghostChase.enabled = false;
            ghostScatter.enabled = false;
            ghostFrightened.enabled = false;
        }
        if (ghostStatus == ghostStatus.chase)
        {
            ghostChase.enabled = true;
            ghostScatter.enabled = false;
            ghostFrightened.enabled = false;
            
            StartCoroutine(WaitSeconds(timeToChase,ghostStatus.scatter));
           

        }
        else if (ghostStatus == ghostStatus.scatter)
        {
            ghostScatter.enabled = true;
            ghostFrightened.enabled = false;
            ghostChase.enabled = false;
            
            StartCoroutine(WaitSeconds(timeToScatter, ghostStatus.chase));
            
        }
        else if (ghostStatus == ghostStatus.frightened)
        {
            Debug.Log("korktu");
            if (this.ghostStatus == ghostStatus.frightened)
            {
                ghostFrightened.enabled = false;
            }
            
            ghostFrightened.enabled = true;
            ghostScatter.enabled = false;
            ghostChase.enabled = false;
            StopAllCoroutines();
            StartCoroutine(WaitSeconds(timeToFrightened,ghostStatus.chase));
        }
        
    }
    IEnumerator WaitSeconds(float time,ghostStatus ghostStatus)
    {
        yield return new WaitForSeconds(time);
        
        ChangeEnum(ghostStatus);
        Debug.Log("burada");
    }
    
}

