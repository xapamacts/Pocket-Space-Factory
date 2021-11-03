using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Raycaster : MonoBehaviour
{
     public Animator anim;
     private NavMeshAgent agente;
    public string sceneDestinationName;

    void Start()
    {
        
        anim.SetBool("run",false);
        agente=GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin,ray.direction*100, Color.cyan);

        RaycastHit hit;

        if(Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(ray, out hit)== true)
            {
                var selection=hit.transform;
                if(selection.CompareTag("Interactable")){
                    agente.destination=hit.point;
                    Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
                    Debug.Log(hit.transform.gameObject.tag);
                    anim.SetBool("run",true);
                } 
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            anim.SetBool("run",false);
            StartCoroutine(Wait());
            
        }
    }

    private IEnumerator Wait()
    {
        if (sceneDestinationName != "")
        {
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene(sceneDestinationName);
        }
    }

   
}
