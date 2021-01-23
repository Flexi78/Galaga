using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveScript : MonoBehaviour
{
    public GameObject[] NbRaws;
    public float SpaceColums = 1f, SpaceRow = 1f;
    public int TotalAliensInline = 3;
    public Transform SpawnPoint;

    [SerializeField]
    public GameObject[] Waypoint;

    public WaveScript(GameObject[] waypoint)
    {
        Waypoint = waypoint;
    }

    private int count = 0;

    private void Awake()
    {
        //Générteur de vague //TEST
        //Waypoint = GetComponent<WaveScript>().Waypoint;
        Waypoint = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            Waypoint[i] = transform.GetChild(i).gameObject;
        }
    }

    private void Update()
    {
        if (count==0)
        {
            StartCoroutine( Generator());
            count++;
        }

    }

    IEnumerator Pause()
    {
        Debug.Log("pendant"+Time.time);
        yield return new WaitForSeconds(2);
        Debug.Log("pendant" + Time.time);

    }

    IEnumerator Generator()
    {
        for (int i = 0; i < NbRaws.Length; i++) //nombre de lignes
        {
            float posY = this.transform.position.y - (SpaceRow * i);

            for (int j = 0; j < TotalAliensInline; j++) //nombre de colonnes
            {
                //Vector3 position = new Vector3(this.transform.position.x + (SpaceColums * j), posY, SpawnPoint.transform.position.z);
                Vector3 position = new Vector3(this.transform.position.x, posY, this.transform.position.z);
                GameObject Go = Instantiate(NbRaws[i].gameObject, position, Quaternion.identity);
                Go.transform.SetParent(this.transform);
                Debug.Log("AVANT");
                //StartCoroutine(Pause());
                yield return new WaitForSeconds(2);

                Debug.Log("APRES");
            }
        }
    }

}
