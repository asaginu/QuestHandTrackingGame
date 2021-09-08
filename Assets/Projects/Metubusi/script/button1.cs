using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button1 : MonoBehaviour
{
    float Ypos, newYpos;
    Vector3 velocity;

    public AudioClip sound;
    AudioSource audiosource;

    public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        Ypos= GetComponent<Transform>().localPosition.y;
        velocity = GetComponent<Rigidbody>().velocity;
        audiosource = GetComponent<AudioSource>();
        audiosource.clip = sound;
    }
    // Update is called once per frame
    void Update()
    {

        newYpos = GetComponent<Transform>().localPosition.y;
        if (newYpos > Ypos) GetComponent<Transform>().localPosition = new Vector3(0f, 0.1f, 0f);
        if (newYpos < Ypos-0.005f && this.tag!="Finish")
        {
            velocity = new Vector3(0f, 0f, 0f);
            GetComponent<Rigidbody>().isKinematic = true;
            scinechange();
            return;
        }else if(newYpos < Ypos - 0.005f)
        {
            Application.Quit();
        }

    }

    void scinechange()
    {
        GetComponent<Renderer>().material.color = Color.yellow;
        Vector3 vec = GetComponent<Transform>().localPosition + new Vector3(0f, 1.2f, 1f);
        
        audiosource.Play();
        SceneManager.LoadScene("metubusi");
    }
}
