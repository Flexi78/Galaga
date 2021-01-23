using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : MonoBehaviour
{    
    [Header("Ennemi settings")]
    //[SerializeField] Transform m_SpawnPoint;
    [SerializeField] float m_TranslationSpeed;
    [SerializeField] int m_LifeNumber;
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
        m_Rigidbody = GetComponent<Rigidbody>();
        spawn = GetComponent<Transform>();
        //Waypoint = new GameObject[transform.childCount];
        //Waypoint = GetComponent<WaypointScript>().Waypoint;
        Debug.Log("wayoints : "+Waypoint.Length);
        for (int i = 0; i < transform.childCount; i++)
        {
            Waypoint[i] = transform.GetChild(i).gameObject;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
       // Move();
        float rand = Random.Range(-20.0f, 20.0f);

        bool isPressed = Input.GetButton("Fire2"); //si le joueur appuie sur "alt"

        if (rand > 15.8f && CanShoot)
        {
            CanShoot = false;
            Shoot();
        }

        if (NoEnnemi < transform.childCount)
        {
            if (this.transform.position != Waypoint[NoEnnemi].transform.position)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, Waypoint[NoEnnemi].transform.position, speed * Time.deltaTime);
                NoEnnemi++;
            }
            else
            {
                NoEnnemi++;
            }
        }

        if (isPressed)
        {
            Debug.LogWarning("appuie sur alt");
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
        /*Vector3 vect = new Vector3(0,0,1);
        m_Rigidbody.AddForce(vect, ForceMode.VelocityChange);
        StartCoroutine(Pause());
        m_Rigidbody.AddForce(-vect, ForceMode.VelocityChange);*/

        //this.transform.Translate(0.5f * Vector3.up * m_TranslationSpeed * Time.deltaTime, Space.Self);
        //StartCoroutine(Pause());
        //this.transform.Translate(0.5f * Vector3.down * m_TranslationSpeed * Time.deltaTime, Space.Self);
        m_Rigidbody.AddForce(2*Vector3.up * m_TranslationSpeed * Time.deltaTime, ForceMode.Impulse);
        StartCoroutine(Pause());
        m_Rigidbody.AddForce(-2*Vector3.up * m_TranslationSpeed * Time.deltaTime, ForceMode.Impulse);


    }

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(2f);
    }
}


