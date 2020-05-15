using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using KModkit;

public class SpotTheDifference : MonoBehaviour {

    public KMBombInfo Bomb;
    public KMAudio Audio;
    public KMSelectable[] Spheres;
    public Material[] Colors;
    public GameObject[] WeedChungi;
    public GameObject[] BiggerChungus;

    static int moduleIdCounter = 1;
    int moduleId;
    private bool moduleSolved;
    private List<int> abcefgh = new List<int>{0,1,2,3,2,1,1,1,3,3,3,0,0,0,2,1,3,2,0,0,0,3,2,2,1,1,3,2,0,0,1,0,3,3,0,1,1,2,2,2,0,0,3,0,1,1,2,1,3,0,3,3,2,3,1,2,1,2,0,0};
    int hgnjmhgnjmgfnb = 0;
    int jon = -1000000;
    float TimeKeeper = 1f;
    private Vector3 a = new Vector3(0f, 0.02f, 0f);
    private Vector3 b = new Vector3(0f, 0.06f, 0f);
    private Vector3 c = new Vector3(0f, 0.1f, 0f);
    private Vector3 d = new Vector3(0f, 0.14f, 0f);
    int check = 0;
    Vector3[] idontknow = new Vector3[4];
    private List<string> logcolor = new List<string>{"Blue", "Green", "Orange", "Red"};

    void Awake () {
        moduleId = moduleIdCounter++;

        foreach (KMSelectable Sphere in Spheres) {
                    Sphere.OnInteract += delegate () { SpheresPress(Sphere); return false; };
          }
    }

    void Start () {
      hgnjmhgnjmgfnb = UnityEngine.Random.Range(0, WeedChungi.Count());
      jon = UnityEngine.Random.Range(0,4);
      while (abcefgh[hgnjmhgnjmgfnb] == jon){
        jon = UnityEngine.Random.Range(0,4);
      }
      Debug.LogFormat("[Spot The Difference #{0}] The faulty sphere is {1} (with the bottom row, bottom left according to the image and going in geometric order being 0). The color that it is is {2}.", moduleId, hgnjmhgnjmgfnb, logcolor[jon]);
      WeedChungi[hgnjmhgnjmgfnb].GetComponent<MeshRenderer>().material = Colors[jon];
      StartCoroutine(looper());
	}
	void SpheresPress (KMSelectable Sphere) {
    if (moduleSolved == true) {
      return;
    }
    for (int i = 0; i < WeedChungi.Count(); i++) {
      if (Sphere == Spheres[i]) {
        Debug.Log(i);
        if (i == hgnjmhgnjmgfnb) {
          GetComponent<KMBombModule>().HandlePass();
          moduleSolved = true;
          Audio.PlaySoundAtTransform("PenisBlaster", transform);
          Debug.LogFormat("[Spot The Difference #{0}] You pressed the right sphere. Module disarmed.", moduleId);
          for (int j = 0; j < WeedChungi.Count(); j++) {
            Spheres[j].GetComponent<MeshRenderer>().material = Colors[4];
          }
        }
        else {
          GetComponent<KMBombModule>().HandleStrike();
          Debug.LogFormat("[Spot The Difference #{0}] You pressed sphere {1}. This mod is tough so I won't berate you this time.", moduleId, i);
        }
      }
    }
	}
  private IEnumerator looper()
  {
      float time = 0f;
      float speed = 1f;
      idontknow = new Vector3[]{BiggerChungus[0].transform.localPosition, BiggerChungus[1].transform.localPosition, BiggerChungus[2].transform.localPosition, BiggerChungus[3].transform.localPosition};
      while (time < 2f)
      {
          for (int i = 0; i < 4; i++)
          {
               if (Math.Abs(idontknow[i].y - a.y) <= .001f){
                 BiggerChungus[i].transform.localPosition = Vector3.Lerp(BiggerChungus[i].transform.localPosition, b, time);
               }
               else if (Math.Abs(idontknow[i].y - b.y) <= .01f){
                 BiggerChungus[i].transform.localPosition = Vector3.Lerp(BiggerChungus[i].transform.localPosition, c, time);
               }

               else if (Math.Abs(idontknow[i].y - c.y) <= .01f){
                 BiggerChungus[i].transform.localPosition = Vector3.Lerp(BiggerChungus[i].transform.localPosition, d, time);
               }

               else if (Math.Abs(idontknow[i].y - d.y) <= .01f){
                 BiggerChungus[i].transform.localPosition = Vector3.Lerp(BiggerChungus[i].transform.localPosition, a, time);
               }
               time += Time.deltaTime * speed;
          }
          yield return null;
      }
      yield return new WaitForSeconds(0.2f);
      StartCoroutine(looper());
  }
}
