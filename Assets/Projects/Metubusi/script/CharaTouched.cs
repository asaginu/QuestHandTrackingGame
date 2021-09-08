using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaTouched : MonoBehaviour
{

    public static int defeatedNum=0;//倒した数
    public AudioClip endsound;
    public AudioSource audiosource;
    public GameObject ps;

    private static float passedTime;//生成からの経過時間
    public float survivalTime;//生存時間


    // Start is called before the first frame update
    void Start()
    {
        passedTime = 0f;
        audiosource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        passedTime += Time.deltaTime;
        if (passedTime >= survivalTime)
        {
            AppearChara.appearinglist.Remove(gameObject.name);
            Destroy(gameObject);
        }

        if (Mytime.totalTime <= 0f) Destroy(this);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Hand_Index3_CapsuleCollider")
        {
            AppearChara.appearinglist.Remove(gameObject.name);//出現中位置のリストから削除

            audiosource.PlayOneShot(endsound);

            defeatedNum++;
            
            ChangeTexture tex = GetComponent<ChangeTexture>();
            tex.EndAppear();

            Instantiate(ps, this.transform.position,this.transform.rotation);
            ps.GetComponent<ParticleSystem>().trigger.SetCollider(1,GameObject.Find("delitecollider").GetComponent<BoxCollider>());

            this.GetComponent<MeshCollider>().enabled=false;
            Destroy(gameObject, 0.4f);
        }
    }
}
