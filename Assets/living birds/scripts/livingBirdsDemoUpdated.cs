using UnityEngine;
using System.Collections;

public class livingBirdsDemoUpdated : MonoBehaviour
{
    public lb_BirdController birdControl;
    public int birdsKilled=0;

    Camera currentCamera;
    bool cameraDirections = true;
    Ray ray;
    RaycastHit[] hits;

    void Start()
    {
        currentCamera = transform.GetComponentInChildren<Camera>();
        birdControl = GameObject.Find("_livingBirdsController").GetComponent<lb_BirdController>();
        SpawnSomeBirds();
    }

    // Update is called once per frame
    /*void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = currentCamera.ScreenPointToRay(Input.mousePosition);
            hits = Physics.RaycastAll(ray);
            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.tag == "lb_bird")
                {
                    hit.transform.SendMessage("KillBirdWithForce", ray.direction * 500);
                    birdsKilled++;
                    break;
                }
            }
        }
    }*/

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = currentCamera.ScreenPointToRay(Input.mousePosition);
            hits = Physics.RaycastAll(ray);
            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.tag == "lb_bird")
                {
                    hit.transform.SendMessage("KillBirdWithForce", ray.direction * 500);
                    birdsKilled++;
                    break;
                }
            }
        }
    }

    void OnGUI()
    {
        if (cameraDirections)
        {
            GUI.Label(new Rect(170, 10, 1014, 20), "Goal: Sleep!");
            GUI.Label(new Rect(170, 30, 1014, 20), "Objective: Make it quiet so that you can sleep.");
            GUI.Label(new Rect(170, 50, 1014, 20), "Birds killed: " + birdsKilled);
            
        }
    }

    IEnumerator SpawnSomeBirds()
    {
        yield return 2;
        birdControl.SendMessage("SpawnAmount", 10);
    }

    /*void ChangeCamera()
    {
        if (camera2.gameObject.activeSelf)
        {
            camera1.gameObject.SetActive(true);
            camera2.gameObject.SetActive(false);
            birdControl.SendMessage("ChangeCamera", camera1);
            cameraDirections = true;
            currentCamera = camera1;
        }
        else
        {
            camera1.gameObject.SetActive(false);
            birdControl.SendMessage("ChangeCamera", camera2);
            cameraDirections = false;
            currentCamera = camera2;
        }
    }*/
}
