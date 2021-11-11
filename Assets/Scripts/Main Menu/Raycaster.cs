using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Raycaster : MonoBehaviour
{
    public Animator anim;
    private NavMeshAgent agente;
    public GameObject OptionsCanvas;
    public GameObject ExitCanvas;
    public GameObject  PlayCanvas;
    public bool isTouching = false;
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
            if (isTouching == false)

            {
                if(Physics.Raycast(ray, out hit) == true)
                {
                    var selection=hit.transform;
                    if(selection.CompareTag("Options") || selection.CompareTag("Play") || selection.CompareTag("Exit"))
                    {
                        agente.destination=hit.point;
                        Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
                        Debug.Log(hit.transform.gameObject.tag);
                        anim.SetBool("run",true);
                    } 
                }
            }
            
        }
    }

    public void Pause()
    {
        isTouching = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Options") || other.gameObject.CompareTag("Play") || other.gameObject.CompareTag("Exit"))
        {
            anim.SetBool("run", false);
        }

        if (other.gameObject.CompareTag("Options"))
        {
            OptionsCanvas.SetActive(true);
            isTouching = true;
        }

        if (other.gameObject.CompareTag("Exit"))
        {
            ExitCanvas.SetActive(true);
        }

        if (other.gameObject.CompareTag("Play"))
        {
            
            PlayCanvas.SetActive(true);
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("PSF");
    }

    public void Exit()
    {
        Application.Quit();
    }
}