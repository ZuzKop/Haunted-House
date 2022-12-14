using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillGhost : MonoBehaviour
{
    public bool emptyGhost;
    public GameObject gameManager;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    public void KillThisGhost()
    {
        //gameManager.GetComponent<GhostCounter>().SubGhost();

        if(!emptyGhost)
        {
            GetComponent<GhostMoan>().SetVolume(0);
            gameObject.SetActive(false);
        }
    }
}
