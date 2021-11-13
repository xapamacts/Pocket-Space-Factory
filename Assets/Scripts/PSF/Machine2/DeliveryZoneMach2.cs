using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryZoneMach2 : MonoBehaviour
{
     private GameManager gameManager;

    // Start is called before the first frame update
    private void Awake() 
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Box2")
        {
            if(gameManager.actualBoxType==2)
            {
                Debug.Log("CajaAmarilla");
                gameManager.UpdateBox();
            }
            
        }
    }


}
