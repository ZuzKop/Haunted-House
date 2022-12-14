using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectingGhosts : MonoBehaviour
{
    private int hearable;
    private float turn;
    private float vol = 0f;

    public GameObject minigame;

    public Camera fpsCam;

    private GameObject currentGhost;
    public GameObject emptyGhost;

    void Start()
    {
        currentGhost = emptyGhost;
    }

    public void KillThisGhost()
    {
        currentGhost.GetComponent<KillGhost>().KillThisGhost();
        currentGhost = emptyGhost;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
        {
            if (hit.transform.tag == "Ghost")
            {
                hearable = 1;
                vol = (10 / hit.distance);
                currentGhost = hit.transform.gameObject;
                currentGhost.GetComponent<GhostMoan>().SetVolume(vol);
            }
            else
            {
                hearable = 0;
            }
        }
        else
        {
            hearable = 0;
        }

        currentGhost.GetComponent<GhostMoan>().MoanVolume(hearable);

        if(hearable == 1 && Input.GetMouseButtonDown(0))
        {
            minigame.SetActive(true);
            GetComponent<GhostCatchingMinigame>().InitiateMinigame();
        }
        if(hearable == 0)
        {
            GetComponent<GhostCatchingMinigame>().StopMinigame();

        }

        

    }

    public int IsGhostDetected()
    {
        return hearable;
    }
}

