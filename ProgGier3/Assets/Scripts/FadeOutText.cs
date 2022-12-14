using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutText : MonoBehaviour
{

    [SerializeField] private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeOut()
    {
        anim.Play("TextFadeOut", 0, 0.0f);
    }
}
