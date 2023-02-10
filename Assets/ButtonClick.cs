using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{

    public GameObject girl;

    public void OnButtonClick()
    {
        ExecuteTrigger("Speak");
    }

    public void OnStopClick()
    {
        StopTrigger("Speak");
    }

    private void ExecuteTrigger(string trigger)
    {
        if (girl != null)
        {
            var animator = girl.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetTrigger(trigger);
            }
        }
    }

    private void StopTrigger(string trigger)
    {
        if (girl != null)
        {
            var animator = girl.GetComponent<Animator>();
            if (animator != null)
            {
                animator.ResetTrigger(trigger);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
