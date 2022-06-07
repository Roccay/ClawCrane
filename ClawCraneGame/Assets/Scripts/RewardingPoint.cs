using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardingPoint : MonoBehaviour
{
    public Text rewardingText;
    [SerializeField] string rewardName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //take collider's ID here and connect to the text
        rewardName = collision.gameObject.GetComponent<StuffsID>().id;

        StartCoroutine(textTime());
        Debug.Log(collision.gameObject.name);
        Destroy(collision.gameObject);
        //also add reward here
    }

    IEnumerator textTime()
    {
        rewardingText.text = "……抓到了" + rewardName + "……";
        yield return new WaitForSeconds(3f);
        rewardingText.text = "";
    }
}
