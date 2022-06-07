using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawControl : MonoBehaviour
{
    [SerializeField] float time;
    public float downTime;
    [SerializeField] bool autoControl = false;
    [SerializeField] bool clawsOpen = true;
    [SerializeField] bool touchingStuff = false;
    Rigidbody2D Rclaw, Lclaw;

    public GameObject machine;
    Vector3 machinePos_original;
    private Transform machineXYZ;
    // Start is called before the first frame update
    void Start()
    {
        machineXYZ = machine.GetComponent<Transform>();

        Rclaw = GameObject.Find("Claws_R").GetComponent<Rigidbody2D>();
        Lclaw = GameObject.Find("Claws_L").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (!autoControl)
        {
            if (Input.GetKey(KeyCode.A))
            {

                gameObject.transform.Translate(-0.01f, 0, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                gameObject.transform.Translate(0.01f, 0, 0);
            }
            if (gameObject.transform.position.x >= 2)
            {
                gameObject.transform.position = new Vector2(2,gameObject.transform.position.y);
            }
            else if (gameObject.transform.position.x <= -2)
            {
                gameObject.transform.position = new Vector2(-2, gameObject.transform.position.y);

            }
        }



    }

    IEnumerator GrabWaitTime()
    {
        autoControl = true;
        time = 0;

        //putting down
        while (time < downTime)
        {
            gameObject.transform.Translate(0, -0.1f, 0);
            Debug.Log("going down");
            yield return new WaitForSeconds(0.05f);
            if (touchingStuff)
            {
                for(int i = 0; i < Random.Range(2, 5); i++)
                {
                    gameObject.transform.Translate(0, -0.1f, 0);
                    yield return new WaitForSeconds(0.05f);
                }

                break;
            }
        }


        yield return new WaitForSeconds(0.05f);


        //grabbing
        if (clawsOpen && touchingStuff)
        {
            Debug.Log("claw catch!");
            while (Lclaw.transform.eulerAngles.z < Random.Range(347,356) && Rclaw.transform.eulerAngles.z > Random.Range(5, 15))
            {

                Lclaw.transform.Rotate(0, 0, 1f);
                Rclaw.transform.Rotate(0, 0, -1f);
                yield return new WaitForSeconds(0.01f);
            }
        }
        clawsOpen = false;
            yield return new WaitForSeconds(0.5f);


        //going back to original height
            time = 0;
        while (gameObject.transform.position.y < 8.5f)
        {
            Debug.Log("going up");
            gameObject.transform.Translate(0, 0.1f, 0);

            yield return new WaitForSeconds(0.05f);
        }
        touchingStuff = false;
        //SHAKE HERE!!!!!!!!!!!!
        StartCoroutine(MachineHitted());


        //moving to the endPoint
        yield return new WaitForSeconds(0.8f);
        while (gameObject.transform.position.x > -2)
        {
            gameObject.transform.Translate(-0.08f, 0, 0);
            Debug.Log("going left");
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.05f);

        Debug.Log("releasing");
        //opening the claw again
        if (!clawsOpen)
        {
            Debug.Log("claw releasing!");
            while (Lclaw.transform.eulerAngles.z > 285 && Rclaw.transform.eulerAngles.z < 75)
            {

                Lclaw.transform.Rotate(0, 0, -1f);
                Rclaw.transform.Rotate(0, 0, 1f);
                yield return new WaitForSeconds(0.01f);
            }
        }
        clawsOpen = true;
        yield return new WaitForSeconds(0.5f);



        yield return new WaitForSeconds(0.05f);
        autoControl = false;


    }

    public void Grab()
    {
        Debug.Log("start grabing");
        StartCoroutine(GrabWaitTime());

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            Debug.Log("hit!");
            touchingStuff = true;
        }

    }

    IEnumerator MachineHitted()
    {
        machinePos_original = machineXYZ.position;
        machineXYZ.position = new Vector3(machineXYZ.position.x + Random.Range(-0.5f, 0.5f), machineXYZ.position.y + Random.Range(-0.5f, 0.5f), machineXYZ.position.z + Random.Range(-0.5f, 0.5f));
        yield return new WaitForSecondsRealtime(0.05f);
        machineXYZ.position = new Vector3(machineXYZ.position.x + Random.Range(-0.5f, 0.5f), machineXYZ.position.y + Random.Range(-0.5f, 0.5f), machineXYZ.position.z + Random.Range(-0.5f, 0.5f));
        yield return new WaitForSecondsRealtime(0.05f);

        machineXYZ.position = machinePos_original;
    }

}
