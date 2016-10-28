using UnityEngine;
using System.Collections;

public class CrossSpeed : MonoBehaviour {
    public float speed = 10f;

	Rigidbody rb;

    // Use this for initialization
    void Start()
    {
		rb = GetComponent<Rigidbody> ();
    }

    // Update is called once per frame
    void Update()
    {
		rb.AddForce(Vector3.forward * speed);
		//transform.Translate(Vector3.forward * Time.deltaTime * speed);
		Destroy(gameObject, 5);
    }


	void OnTriggerEnter(Collider other)
 {
		if (other.gameObject.name == "PlayerBody")
     {
        	print(other.gameObject.name + " please die");
			other.GetComponent<BodyController>().health.CurrentVal -= 2;
			Destroy(gameObject);
     }
 }
}

