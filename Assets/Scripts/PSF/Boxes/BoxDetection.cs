using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDetection : MonoBehaviour
{
    //public GameObject light;
    public float timeOff;
    public float timeOn;
    public float destructionTime;

    private float pauseTimeOff;
    private float nextTimeOff;
    private float pauseTimeOn;
    private float nextTimeOn;

    private void Start()
    {
        pauseTimeOff = timeOff;
        nextTimeOff = 0;

        pauseTimeOn = timeOn;
        nextTimeOn = 0;
    }

    private void Update()
    {
        if (Time.time > nextTimeOff)
        {
           nextTimeOff = Time.time + pauseTimeOff;
           //light.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "BoxDestroyer")
        {
            if (Time.time > nextTimeOn)
            {
                nextTimeOn = Time.time + pauseTimeOn;
                //light.SetActive(true);
                
                StartCoroutine("BoxDestruction");
            }
        }
    }

    private IEnumerator BoxDestruction()
    {
        yield return new WaitForSeconds(destructionTime);
        Destroy(gameObject);
    }
}

