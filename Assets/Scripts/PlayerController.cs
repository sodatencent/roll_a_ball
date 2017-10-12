using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float speed;
    public GUIText countTxt;
    private int count;
    private Rigidbody body;

    // Use this for initialization
    void Start () {
        count = 0;
        countTxt.text = "";
        body = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        body.AddForce(movement * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        //Destroy(other.gameObject);
        if (other.gameObject.tag == "PickUp")
        {
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            count++;
            countTxt.text = "Count: " + count.ToString();
        }
    }
}
