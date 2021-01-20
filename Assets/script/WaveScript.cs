using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveScript : MonoBehaviour
{
    public GameObject[] NbRaws;
    public float SpaceColums = 1f, SpaceRow = 1f;
    public int TotalAliensInline = 3;
    public Transform SpawnPoint;



    private void Awake()
    {
        //Générteur de vague //TEST

        for (int i=0; i<NbRaws.Length; i++)
        {
            float posY = this.transform.position.y - (SpaceRow * i);

            for (int j=0; j<TotalAliensInline; j++)
            {
                Vector3 position = new Vector3(this.transform.position.x + (SpaceColums * j), posY, SpawnPoint.transform.position.z);
                GameObject Go = Instantiate(NbRaws[i].gameObject, position, Quaternion.identity);
                Go.transform.SetParent(this.transform);
            }
        }

    }

}
