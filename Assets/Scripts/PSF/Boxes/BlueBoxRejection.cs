using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBoxRejection : MonoBehaviour
{
    public float maxForce;
    public float minForce;
    public Vector3 forceDirectionVector;  
    
    private GameObject rejectionZone;

    private void Awake()
    {
        rejectionZone = GameObject.Find("BoxRejection");
    }

    private void OnCollisionEnter(Collision box)
    {
        if (box.gameObject.tag == "BoxRejection")
        {
            if (GameManager.actualLevel == 1)
            {
                Incorrect();
            }
        }
    }

    private void Incorrect()
    {
        Debug.Log("INCORRECT");
        float forceMagnitude = Random.Range(minForce, maxForce);
        Vector3 force = Vector3.Normalize(forceDirectionVector) * forceMagnitude;

        gameObject.GetComponent<Rigidbody>().AddForce(force);
    }

    private void Correct()
    {
        rejectionZone.GetComponent<BoxHoleAcces>().Correct();
    }
}
