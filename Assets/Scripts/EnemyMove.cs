using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour
{
    //public Transform target;
    public GameObject player = null;
    public int moveSpeed;
    public int rotationSpeed;

    private Transform myTransform;

    void Awake()
    {
        myTransform = transform;
    }

    //Use this to initialize
    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");

        //target = go.transform;
    }

    //Remember that the Update() is called once per frame
    void Update()
    {

        //Debug.Drawline(target.position, myTransform.position, Color.yellow);

        //Look at target
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(player.transform.position - myTransform.position), rotationSpeed * Time.deltaTime);
        if (GetComponent<EnemySight>().seePlayer == true)
            //Move towards player
            myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
    }
}