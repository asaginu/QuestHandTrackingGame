using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class huwahuwa : MonoBehaviour
{
    float intensity = .04f;
    Vector3 myposition;

    private void Start()
    {
        myposition = GetComponent<Transform>().position;
    }
    void Update()
    {
        transform.position = new Vector3(myposition.x
         , myposition.y + Mathf.Sin(Time.frameCount * intensity)/17, myposition.z);
    }
}
