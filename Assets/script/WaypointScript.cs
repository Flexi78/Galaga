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
    public int subDivCount = 25;
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

   /* private void Update()
    {
       if (i < transform.childCount)
        {
            if (ObjectToMove.transform.position != Waypoint[i].transform.position)
            {
                /*for (int j=1; j < Waypoint.Length - 3; i += 2)
                {
                    Vector3 a, b, c, dest;
                    a = Waypoint[j].transform.position;
                    b = Waypoint[j+1].transform.position;
                    c = Waypoint[j+2].transform.position;

                    for (int n =0; n < subDivCount; n++)
                    {
                        dest = BezierPath(a, b, c, n / (float)subDivCount);
                        ObjectToMove.transform.position = Vector3.MoveTowards(ObjectToMove.transform.position, dest, speed * Time.deltaTime);

                    }
                }*/

          /*      ObjectToMove.transform.position = Vector3.MoveTowards(ObjectToMove.transform.position, Waypoint[i].transform.position, speed * Time.deltaTime);
            }
            else
            {
                i++;
            }
        }
    }*/

    Vector3 BezierPath(Vector3 p0, Vector3 p1, Vector3 p2, float progress)
    {
        Vector3 controlNodeA = LinearInterp(p0, p1, progress);
        Vector3 controlNodeB = LinearInterp(p1, p2, progress);

        return LinearInterp(controlNodeA, controlNodeB, progress);
    }

    Vector3 LinearInterp(Vector3 start, Vector3 end, float progress)
    {
        return new Vector3(LinearInterp(start.x, end.x, progress), LinearInterp(start.y, end.y, progress), LinearInterp(start.z, end.z, progress));
    }

    float LinearInterp(float start, float end, float progress)
    {
        return start + (end - start) * progress;
    }
}
