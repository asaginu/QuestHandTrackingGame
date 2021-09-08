using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTexture : MonoBehaviour
{

    public Texture[] texture;
    public Material TargetMaterial;
    public float frametime = 0.7f;
    int probability;

    void Start()
    {
        TargetMaterial = GetComponent<Renderer > ().material;
        TargetMaterial.SetTexture("_MainTex", texture[0]);
    }

    void Update()
    {
        probability = Random.Range(1, 100);

        if (probability == 1)
        {
            StartCoroutine("Changing");
        }
    }
    IEnumerator Changing()
    {
        TargetMaterial.SetTexture("_MainTex", texture[1]);
            yield return new WaitForSeconds(frametime);
        TargetMaterial.SetTexture("_MainTex", texture[0]);
    }
    public void EndAppear()
    {
        StopCoroutine("Changing");
        TargetMaterial.SetTexture("_MainTex", texture[2]);
        
    }

}