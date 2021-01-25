using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ennemi : MonoBehaviour
{

    [SerializeField]
    Transform[] waypoints;

    [SerializeField]
    float moveSpeed = 2f;

    int waypointIndex = 0;

    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position,
                                                waypoints[waypointIndex].transform.position,
                                                moveSpeed * Time.deltaTime);
        Debug.Log(waypointIndex);

        if (transform.position == waypoints[waypointIndex].transform.position)
        {
            Debug.Log("ez");
            waypointIndex += 1;
        }

        if (waypointIndex == waypoints.Length)
            waypointIndex = 0;
    }

}
/*public class Ennemi : MonoBehaviour
{


    [SerializeField]
    Transform[] waypoints;

    [SerializeField]
    float moveSpeed = 2f;

    int waypointIndex = 0;

    public bool CanShoot = true;


    [Header("Ball shot")]
    [SerializeField] GameObject m_BallPrefab;
    //[SerializeField] Transform m_BallSpawnPoint;
    [SerializeField] float m_BallInitTranslationSpeed;

    Rigidbody m_Rigidbody;
    Transform spawn;

    [SerializeField]
    GameObject[] Waypoint;
    public float speed = 5;

    int NoEnnemi = 0;



    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
       Move();
        float rand = Random.Range(-20.0f, 20.0f);


        if (rand > 15.8f && CanShoot)
        {
            CanShoot = false;
            Shoot();
        }


    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Ball"))
        {
            Destroy(this);
        }
        
    }

    public void Shoot()
    {
        Debug.LogWarning("Ennemi shoot ! "+this.transform.position);
        GameObject newBallGO = Instantiate(m_BallPrefab, spawn);
    }

    public void Move()
    {

        transform.position = Vector2.MoveTowards(transform.position,
                                                waypoints[waypointIndex].transform.position,
                                                moveSpeed * Time.deltaTime);

        if (transform.position == waypoints[waypointIndex].transform.position)
        {
            waypointIndex += 1;
        }

        if (waypointIndex == waypoints.Length)
            waypointIndex = 0;

    }

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(2f);
    }
}


*/