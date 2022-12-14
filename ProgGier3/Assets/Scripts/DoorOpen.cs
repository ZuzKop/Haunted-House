using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] private bool unlocked;
    [SerializeField] private Animator anim;


    [SerializeField] private bool doubleDoor;
    [SerializeField] private Animator anim_;

    [SerializeField] private bool opened;
    [SerializeField] private bool firstUnlocking;

    public AudioSource unlockingSound;
    public GameObject keyImage;

    public Collider coll;


    void Start()
    {
        opened = false;
    }

    public void UnlockDoors()
    {
        unlocked = true;
        firstUnlocking = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && unlocked && !opened)
        {
            if(firstUnlocking)
            {
                firstUnlocking = false;
                unlockingSound.Play();
                keyImage.SetActive(false);

            }

            opened = true;
            coll.enabled = false;
            anim.Play("DoorOpening", 0, 0.0f);

            if(doubleDoor)
            {
                anim_.Play("DoubleDoorOpening", 0, 0.0f);
            }
        }
    }
}
