using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStuffs : MonoBehaviour
{
    public int TopAmount;
    public int ShoesAmount;
    public int BottomAmount;
    public int AccessAmount;
    float time;
    public float shootTime;
    private GameObject top;
    private GameObject shoes;
    private GameObject bottom;
    private GameObject acces;

    private Transform randomPlace;
    // Start is called before the first frame update
    void Start()
    {

        generateStuffs();


    }

    void generateStuffs()
    {
        for (int i = 0; i < TopAmount; i++)
        {
            gameObject.transform.position = new Vector2(Random.Range(-0.7f, 2.2f), Random.Range(-2, -0.5f));
            top = Instantiate(Resources.Load("Top" + Random.Range(0, 6))) as GameObject;
            top.transform.position = gameObject.transform.position;
            top.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 50));

        }
        for (int i = 0; i < ShoesAmount; i++)
        {
            gameObject.transform.position = new Vector2(Random.Range(-0.7f, 2.2f), Random.Range(-2, -0.5f));
            shoes = Instantiate(Resources.Load("Shoes" + Random.Range(0, 6))) as GameObject;
            shoes.transform.position = gameObject.transform.position;
            shoes.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 50));

        }
        for (int i = 0; i < BottomAmount; i++)
        {
            gameObject.transform.position = new Vector2(Random.Range(-0.7f, 2.2f), Random.Range(-2, -0.5f));
            bottom = Instantiate(Resources.Load("Bottom" + Random.Range(0, 6))) as GameObject;
            bottom.transform.position = gameObject.transform.position;
            bottom.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 50));

        }
        for (int i = 0; i < AccessAmount; i++)
        {
            gameObject.transform.position = new Vector2(Random.Range(-0.7f, 2.2f), Random.Range(-2, -0.5f));
            acces = Instantiate(Resources.Load("Acces" + Random.Range(0, 6))) as GameObject;
            acces.transform.position = gameObject.transform.position;
            acces.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 50));

        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time < shootTime)
        {

        }
    }
}
