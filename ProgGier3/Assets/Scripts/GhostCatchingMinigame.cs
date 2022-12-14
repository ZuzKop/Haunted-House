using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostCatchingMinigame : MonoBehaviour
{
    public Slider ghostSlider;
    public Slider catchSlider;

    private float ghostSpeed;
    private int ghostDirection; //1 or -1;

    private float catchSpeed;

    private float progress;
    private int percents;
    public Text text;

    public GameObject panelGhosts;
    public GameObject panelCounter;

    private bool stop;

    void Start()
    {
        stop = true;
    }

    public void InitiateMinigame()
    {
        if(stop)
        {
            stop = false;

            panelCounter.SetActive(false);
            panelGhosts.SetActive(true);

            ghostSpeed = 0.005f;
            ghostDirection = 1;
            ghostSlider.value = 0f;

            catchSpeed = 0.01f;
            catchSlider.value = 0.5f;

            progress = 0f;
            percents = 0;

        }
    }

    public void StopMinigame()
    {
        if(!stop)
        {
            stop = true;
            StartCoroutine(EndMinigame());
        }

    }

    void FixedUpdate()
    {
        if (!stop)
        {
            if (ghostSlider.value >= ghostSlider.maxValue)
            {
                ghostDirection = -1;
            }

            if (ghostSlider.value <= ghostSlider.minValue)
            {
                ghostDirection = 1;
            }

            int randomSwitch = Random.Range(0, 61);
            if (randomSwitch == 30) ghostDirection = -ghostDirection;

            if (randomSwitch == 60)
            {

                if (ghostSpeed >= 0.009f)
                {
                    ghostSpeed -= 0.001f;
                }
                else if (ghostSpeed <= 0.004f)
                {
                    ghostSpeed += 0.001f;
                }
                else
                {
                    int rand = Random.Range(0, 2);
                    if (rand == 1)
                    {
                        ghostSpeed += 0.0005f;
                    }
                    else
                    {
                        ghostSpeed -= 0.0005f;
                    }

                }
            }

            float ghostVal = ghostSlider.value;
            ghostVal += ghostSpeed * ghostDirection;

            ghostSlider.value = ghostVal;

            //ghost catching slider

            if (Input.GetKey("space"))
            {
                catchSlider.value += catchSpeed;
            }
            else
            {
                catchSlider.value -= catchSpeed;
            }

            if (catchSlider.value > ghostSlider.value - 0.1f && catchSlider.value < ghostSlider.value + 0.1f)
            {
                if (progress <= 100f)
                {
                    progress += 0.8f;
                }
            }
            else
            {
                if (progress >= 0.2f)
                {
                    progress -= 0.2f;
                }
            }

            percents = (int)progress;
            if (percents == 100)
            {
                StartCoroutine(FinishMinigame());
            }

            text.text = percents + "%";

        }
    }

    IEnumerator EndMinigame()
    {
        text.text = "Lost Connection to the ghost";

        yield return new WaitForSeconds(1.3f);

        if(stop)
        {
            panelCounter.SetActive(true);
            panelGhosts.SetActive(false);
        }
    }

    IEnumerator FinishMinigame()
    {
        if (!stop)
        {
            stop = true;
            GetComponent<DetectingGhosts>().KillThisGhost();

            yield return new WaitForSeconds(0.05f);
            stop = true;
            text.text = "100 % Got'em!";
        
            for(int i = 0; i<3; i++)
            {
                yield return new WaitForSeconds(0.2f);
                text.text = "";
                yield return new WaitForSeconds(0.1f);
                text.text = "100 % Got'em!";
            }


            yield return new WaitForSeconds(1.3f);

            panelCounter.SetActive(true);
            panelGhosts.SetActive(false);
        }

    }

}
