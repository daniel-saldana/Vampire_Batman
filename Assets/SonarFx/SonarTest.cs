using UnityEngine;
using System.Collections;

public class SonarTest : MonoBehaviour {

    void Start()
    {
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
            GetComponent<SonarFxSwitcher>().Toggle();
    }
}
