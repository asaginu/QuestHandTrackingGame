using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppearChara : MonoBehaviour
{
    public GameObject chara;//出現キャラ

    [SerializeField] private GameObject parentObject;
    GameObject[] children=new GameObject[15];//子オブジェクトのposition
    int posIndex = 0;//children用


    public static List<string> appearinglist = new List<string>();//今キャラが出ている位置の和紙


    public static int maxAppearNumber=1;//同時出現数（片方の障子のみ）

    float f;
    // Use this for initialization
    private void Start()
    {
        f = 0;
        while (posIndex < parentObject.gameObject.transform.childCount)
        {

            children[posIndex] = parentObject.gameObject.transform.GetChild(posIndex).gameObject;
            posIndex++;

        }
        StartCoroutine(Appear());
    }

    private void Update()
    {
        //f += Time.deltaTime;
        //maxAppearNumber += (int)f;
    }

    // Update is called once per frame
    IEnumerator Appear()
    {
        while (true)
        {
            if (Mytime.totalTime <= 0f) break;
            yield return new WaitForSeconds(2.0f);
            for (int i = 0; i < maxAppearNumber; i++)
            {
                int rand1 = Random.Range(0, posIndex);

                Vector3 newPosVector = children[rand1].transform.position;

            
                if (appearinglist.IndexOf(children[rand1].name) < 0)
                {
                    appearinglist.Add("M" + children[rand1].name);
                    GameObject tmpobj = Instantiate(chara, new Vector3(newPosVector.x, newPosVector.y, newPosVector.z - 0.005f), chara.transform.rotation);
                    tmpobj.name = ("M"+children[rand1].name);
                }
            }
        }

        foreach(string v in appearinglist)
        {
            Destroy(GameObject.Find(v));
        }
        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene("matubusiEnding");
    }
}
