using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UnlockDoors : MonoBehaviour
{
    public GameObject doors;
    public GameObject key;

    public GameObject text;

    public GameObject keyImage;
    [SerializeField] private int keyNo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            doors.GetComponent<DoorOpen>().UnlockDoors();
            key.SetActive(false);
            keyImage.SetActive(true);

            if(keyNo == 0)
            {
                text.GetComponent<TextMeshProUGUI>().SetText("You got bathroom key.");
            }
            else
            {
                text.GetComponent<TextMeshProUGUI>().SetText("You got living room key.");
            }
            text.GetComponent<FadeOutText>().FadeOut();
            
            gameObject.SetActive(false);

        }
    }
}
