using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{

    public ghostStatus ghostStatusEnum;
    public float frightened;
    public Transform Pellets;
    private int howManyPellet;
    private int score;
    public static int level;
    // Start is called before the first frame update
    void Start()
    {

        foreach (Transform pellet in Pellets)
        {
            pellet.gameObject.SetActive(true);
            howManyPellet++;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PelletEated(int score)
    {
        this.score += score;
        howManyPellet--;
        if (howManyPellet == 0)
        {
            //bölüm bitti yeni bölüm açýlcak level arttýrýlacak
        }

    }
    public void PowerPelletEated()
    {
        foreach (GhostStatus ghostStatusScript in FindObjectsOfType<GhostStatus>())
        {
            ghostStatusScript.ChangeEnum(ghostStatus.frightened);
            
        }
        
    }



    IEnumerator WaitSeconds(float Time)
    {
        yield return new WaitForSeconds(Time);
    }
}
