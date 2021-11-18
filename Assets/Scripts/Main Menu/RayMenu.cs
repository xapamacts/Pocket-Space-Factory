using UnityEngine;
using UnityEngine.AI;

public class RayMenu : MonoBehaviour
{
    public MenuManager menuManager;
    public Animator anim;

    private NavMeshAgent agente;
    private Vector3 initialPoint;
    private bool isReturningInitialPoint;

    void Start()
    {
        anim.SetBool("run",false);
        agente = GetComponent<NavMeshAgent>();
        initialPoint = transform.position;
        isReturningInitialPoint = false;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin,ray.direction*100, Color.cyan);
        RaycastHit hit;
        
        if(Input.GetMouseButtonDown(0))
        {
                if(Physics.Raycast(ray, out hit) == true)
                {
                    var selection = hit.transform;
                    if(selection.CompareTag("Options") || selection.CompareTag("Play") || selection.CompareTag("Exit"))
                    {
                        agente.destination = hit.point;
                        Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
                        Debug.Log(hit.transform.gameObject.tag);
                        anim.SetBool("run",true);
                    } 
                }     
        }

        if (isReturningInitialPoint == true)
        {
            float dist = Vector3.Distance(initialPoint, transform.position);
            Debug.Log("return distance: " + dist);
            if (dist < 0.5f)
            {
                anim.SetBool("run", false);
                isReturningInitialPoint = false;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Options") || other.gameObject.CompareTag("Play") || other.gameObject.CompareTag("Exit"))
        {
            anim.SetBool("run", false);
        }

        if (other.gameObject.CompareTag("Options"))
        {
            menuManager.ShowOptionsMenu();
        }

        if (other.gameObject.CompareTag("Exit"))
        {
            menuManager.ShowExitMenu();
        }

        if (other.gameObject.CompareTag("Play"))
        {
            menuManager.ShowPlayMenu();
        }
    }

    public void ReturnToStartPoint()
    {
        agente.destination = initialPoint;
        anim.SetBool("run", true);
        isReturningInitialPoint = true;
    }
}