using UnityEngine;
using System.Collections;

public class CrossSpeed : MonoBehaviour {
    public float speed = 10f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}

/* void OnTriggerEnter(Collider other)
 {
     if (other.gameObject.name == "Player" || other.gameObject.name == "Player2")
     {
         print(other.gameObject.name + " please die");
         other.GetComponent<PlayerController>().health -= 1;


         if (other.GetComponent<PlayerController>().health <= 0)
         {
             Destroy(other.gameObject);
         }
         Destroy(gameObject);
     }
 }
}*/
