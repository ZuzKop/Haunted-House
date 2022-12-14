using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountGhostsInRoom : MonoBehaviour
{
    private int ghosts;
    [SerializeField] private int room;

    /*
    0 - room 0
    1 - room 1
    2 - kitchen
    3 - bedroom 2
    4 - bedroom 1
    5 - bathroom
    6 - living room     
    */

    private GameObject gameManager;

    /*
    public int GetGhostsInRoom(int r)
    {
        if (r == room)
        {
            return ghosts;
        }

        else return 0;
    }
    */

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        ghosts = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ghost"))
        {
            ghosts++;
            Debug.Log(ghosts);
        }
        else if(other.CompareTag("Player"))
        {
            gameManager.GetComponent<GhostCounter>().SetGhosts(ghosts);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ghost"))
        {
            ghosts--;
            Debug.Log(ghosts);
            gameManager.GetComponent<GhostCounter>().SetGhosts(ghosts);
        }
    }

}
