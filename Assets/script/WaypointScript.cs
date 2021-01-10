using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum WayPointState { WAIT, PASSTHROUGH };

[System.Serializable]
public class WaypointScript : MonoBehaviour
{
    public GameObject[] Waypoint;
    public GameObject ObjectToMove;
    public float speed = 5;
    [SerializeField]
    private int i = 0;


    private void Start()
    {
        Waypoint = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            Waypoint[i] = transform.GetChild(i).gameObject;
        }
    }

    private void Update()
    {
        if (i < transform.childCount)
        {
            if (ObjectToMove.transform.position != Waypoint[i].transform.position)
            {
                ObjectToMove.transform.position = Vector3.MoveTowards(ObjectToMove.transform.position, Waypoint[i].transform.position, speed * Time.deltaTime);
            }
            else
            {
                i++;
            }
        }
    }
}


