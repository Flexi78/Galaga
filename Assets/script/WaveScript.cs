using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveScript : MonoBehaviour
{
    public GameObject[] AlienType;
    public float SpaceColums = 1f, SpaceRow = 1f;
    public int TotalAliensInline = 3;
    public Transform SpawnPoint;

    private void Awake()
    {
        //Générteur de vague

        for (int i=0; i<AlienType.Length; i++)
        {
            float posY = transform.position.y - (SpaceRow * i);

            for (int j=0; j<TotalAliensInline; j++)
            {
                Vector2 position = new Vector2(this.transform.position.x + (SpaceColums * j), posY);
                GameObject Go = Instantiate(AlienType[i].gameObject, position, Quaternion.identity);
                Go.transform.SetParent(this.transform);
            }
        }

    }
}
