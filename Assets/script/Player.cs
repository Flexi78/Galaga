using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Ball shot")]
    [SerializeField] GameObject m_BallPrefab;
    [SerializeField] Transform m_BallSpawnPoint;
    [SerializeField] float m_BallInitTranslationSpeed;
    [SerializeField] float m_BallShotCooldownDuration;
    float m_BallShotNextTime; // temps dans le futur auquel le tir est autorisé

    [Header("Player settings")]
    [SerializeField] float m_TranslationSpeed;
    [SerializeField] int m_LifeNumber;



    [SerializeField] EasingFunction.Ease m_TranslateEasingFunction;

    Transform m_Transform;
    Rigidbody m_Rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        m_BallShotNextTime = Time.time;
        m_Transform = GetComponent<Transform>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");

        //cinématique
        Vector3 moveVect = hAxis * Vector3.right * m_TranslationSpeed * Time.deltaTime;
        m_Transform.Translate(moveVect, Space.Self);

        bool isFiring = Input.GetButton("Fire1");

        if (isFiring && Time.time > m_BallShotNextTime)
        {
            Shoot();
            m_BallShotNextTime = Time.fixedTime + m_BallShotCooldownDuration;
        }
    }

    public void Shoot()
    {
        GameObject newBallGO = Instantiate(m_BallPrefab);
        newBallGO.transform.position = m_BallSpawnPoint.position;
        Rigidbody newBallRB = newBallGO.GetComponent<Rigidbody>();
        newBallRB.AddForce(m_BallSpawnPoint.up  * m_BallInitTranslationSpeed, ForceMode.VelocityChange);
    }
}
