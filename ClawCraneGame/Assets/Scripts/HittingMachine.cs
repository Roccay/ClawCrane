using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittingMachine : MonoBehaviour
{
    [SerializeField] bool mouseHover = false;
    public GameObject machine;

    public Transform cam;
    public float shake;
    Vector3 camPos_original;
    Vector3 machinePos_original;

    private Transform machineXYZ;
    // Start is called before the first frame update
    void Start()
    {
        machineXYZ = machine.GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        DetectMouse();
    }


    IEnumerator MachineHitted()
    {
        machinePos_original = machineXYZ.position;
        machineXYZ.position = new Vector3(machineXYZ.position.x + Random.Range(-shake, shake), machineXYZ.position.y + Random.Range(-shake, shake), machineXYZ.position.z + Random.Range(-shake, shake));
        yield return new WaitForSecondsRealtime(0.05f);
        machineXYZ.position = new Vector3(machineXYZ.position.x + Random.Range(-shake, shake), machineXYZ.position.y + Random.Range(-shake, shake), machineXYZ.position.z + Random.Range(-shake, shake));
        yield return new WaitForSecondsRealtime(0.05f);

        machineXYZ.position = machinePos_original;
    }

    IEnumerator CamAction()
    {
        camPos_original = cam.position;
        cam.position = new Vector3(cam.position.x + Random.Range(-shake, shake), cam.position.y + Random.Range(-shake, shake), cam.position.z + Random.Range(-shake, shake));
        yield return new WaitForSecondsRealtime(0.05f);
        cam.position = new Vector3(cam.position.x + Random.Range(-shake, shake), cam.position.y + Random.Range(-shake, shake), cam.position.z + Random.Range(-shake, shake));
        yield return new WaitForSecondsRealtime(0.05f);

        cam.position = camPos_original;
    }

    void DetectMouse()
    {
        if (mouseHover)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("hit from L!");
                StartCoroutine(CamAction());
                StartCoroutine(MachineHitted());
            }
        }
    }
    private void OnMouseEnter()
    {
        mouseHover = true;
    }
    private void OnMouseExit()
    {
        mouseHover = false;
    }
}
