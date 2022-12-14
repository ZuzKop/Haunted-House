using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMoan : MonoBehaviour
{
    public AudioSource moan;
    private float turn;
    private float volume;

    void Start()
    {
        volume = 0f;
        turn = 0f;
    }

    void FixedUpdate()
    {
        //Debug.Log(vol);
    }

    public void MoanVolume(float hearable)
    {
        volume = moan.volume;

        if (hearable == 0)
        {
            if (turn > 0)
                turn -= 0.06f;
            else turn = 0;
        }
        else if (hearable == 1)
        {
            if (turn < 1)
                turn += 0.06f;
            else turn = 1;
        }

        volume *= turn;
        moan.volume = volume;
    }

    public void SetVolume(float v)
    {
        moan.volume = v;
    }

}
