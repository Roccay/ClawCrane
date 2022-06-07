using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StuffsID : MonoBehaviour
{
    public string id;
    public string description;
    public string type;

    private Text infoText;
    // Start is called before the first frame update
    void Start()
    {
        infoText = GameObject.Find("Line").GetComponent<Text>();
        if (description != "")
        {
            description = "(" + description + ")";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseEnter()
    {
        infoText.text = "里面好像是" + id + description;
    }

    private void OnMouseExit()
    {
        infoText.text = "";
    }

}
