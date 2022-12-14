using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GhostCounter : MonoBehaviour
{
    private int ghostNumber;
    public TextMeshProUGUI counterUI;

    public GameObject[] ghosts;

    // Start is called before the first frame update
    void Start()
    {
        //ghostNumber = 0;
        //CountGhost();
    }

    /*
    public void CountGhost()
    {
        ghosts = GameObject.FindGameObjectsWithTag("Ghost");
        SetGhosts(ghosts.Length);
    }
    */


    public void SetGhosts(int n)
    {
        ghostNumber = n;
        UpdateCounter();
    }

    /*
    public void SubGhost()
    {
        if(ghostNumber == 0)
        {
            Debug.Log("Trying to substract ghost when there is none.");
        }
        else
        {
            ghostNumber--;
            UpdateCounter();
        }
    }
    */

    /*
    public void AddGhost()
    {
        ghostNumber++;
        UpdateCounter();
    }
    */

    private void UpdateCounter()
    {
        string numeral = "";

        switch( ghostNumber )
        {
            case 0:
                numeral = "O";
                break;
            case 1:
                numeral = "I";
                break;
            case 2:
                numeral = "II";
                break;
            case 3:
                numeral = "III";
                break;
            case 4:
                numeral = "IV";
                break;
            case 5:
                numeral = "V";
                break;
            case 6:
                numeral = "VI";
                break;
            case 7:
                numeral = "VII";
                break;
            case 8:
                numeral = "VIII";
                break;
            case 9:
                numeral = "IX";
                break;
            case 10:
                numeral = "X";
                break;
            case 11:
                numeral = "XI";
                break;
            case 12:
                numeral = "XII";
                break;
            default:
                numeral = "!!!";
                break;
        }

        counterUI.text = numeral;
    }
}
