using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Ball shot")]
    [SerializeField] GameObject m_BallPrefab;
    [SerializeField] Transform m_BallSpawnPoint;
    [SerializeField] float m_BallInitTranslationSpeed;


    [Header("Player settings")]
    [SerializeField] float m_TranslationSpeed;
    [SerializeField] int m_HealtPoints = 3;
    public bool CanShoot = true;

    /*[Header("Ennemi bullet settings")]
    public GameObject AllienBullet;
    [SerializeField] float m_BulletInitTranslationSpeed;
    bool AlienCanShoot = true;
    public float AlienTimeToFire = 2f;*/

    public int LayerDefault;


    [SerializeField] EasingFunction.Ease m_TranslateEasingFunction;

    Transform m_Transform;
    Rigidbody m_Rigidbody;
    Rigidbody m_BulletRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        m_Transform = GetComponent<Transform>();
        m_Rigidbody = GetComponent<Rigidbody>();
        LayerDefault = LayerMask.GetMask("Default");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");

        //cinématique
        if (m_Transform.transform.position.x >= 8.300f && m_Transform.transform.position.x <= 21.600f)
        {
            Vector3 moveVect = hAxis * Vector3.right * m_TranslationSpeed * Time.deltaTime;
            Vector3 roteVect = hAxis * Vector3.down * m_TranslationSpeed  * Time.deltaTime;
            m_Transform.Translate(moveVect, Space.Self);
            m_Transform.Rotate(roteVect, Space.Self);
        }
        if(m_Transform.transform.position.x > 21.600f)
        {
            m_Transform.Translate(0.1f * Vector3.left * m_TranslationSpeed * Time.deltaTime, Space.Self);
        }
        if (m_Transform.transform.position.x < 8.300f)
        {
            m_Transform.Translate(0.1f * Vector3.right * m_TranslationSpeed * Time.deltaTime, Space.Self);
        }



        bool isFiring = Input.GetButton("Fire1");

        if (isFiring && CanShoot)
        {
            CanShoot = false;
            Shoot();
        }

       /* if (AlienCanShoot)
        {
            AlienShoot();
        }*/
    }

    public void Shoot()
    {
        GameObject newBallGO = Instantiate(m_BallPrefab);
        newBallGO.transform.position = m_BallSpawnPoint.position;
        Rigidbody newBallRB = newBallGO.GetComponent<Rigidbody>();
        newBallRB.AddForce(m_BallSpawnPoint.up  * m_BallInitTranslationSpeed, ForceMode.VelocityChange);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Debug.Log("m_HealtPoints--");
        }

    }

    /*void AlienShoot()
    {
        Debug.DrawRay(transform.position, Vector3.up * 7);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, Mathf.Infinity, LayerDefault))
        {
            if (hit.collider.CompareTag("Ennemi") && AlienCanShoot)
            {
                StartCoroutine(Pause());
                GameObject Bullet = Instantiate(AllienBullet, hit.point, Quaternion.identity);
                Rigidbody newBullet = Bullet.GetComponent<Rigidbody>();
                newBullet.AddForce(-hit.point * m_BulletInitTranslationSpeed, ForceMode.VelocityChange);

            }
        }

    }

    IEnumerator Pause()
    {
        AlienCanShoot = false;
        yield return new WaitForSeconds(AlienTimeToFire);
        AlienCanShoot = true;
    }*/
}
