using UnityEngine;
using System.Collections;

public class BatMovement : MonoBehaviour
{

    public float horizontalSpeed;
    public float verticalSpeed;
    public float amplitude;

    public Vector3 pos;

    public float speed;

	// Use this for initialization
	void Start ()
    {
        
	}
	
    void FixedUpdate()
    {
        pos = transform.position;
        pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        transform.position += transform.forward * Time.deltaTime * speed;

        if(pos.y >= 30.0f)
        {
            pos.y= 30.0f;
        }

        if(Input.GetKey(KeyCode.W))
        {
            transform.Rotate(Vector3.right);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(Vector3.left);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.down);
        }
    }
}
