using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class EnnemiBullet : MonoBehaviour
{
    [Header("Ball shot")]
    //[SerializeField] GameObject m_BallPrefab;
    //[SerializeField] Transform m_BallSpawnPoint;
    [SerializeField] float m_BallInitTranslationSpeed;
    [SerializeField] float m_LifeDuration; //temps de vie de la balle


    // Start is called before the first frame update
    void Start()
    {
        //Transform m_BallSpawnPoint = GetComponentInParent<Transform>();
        Destroy(this.gameObject, m_LifeDuration);
        //this.transform.position = m_BallSpawnPoint.position;
        Rigidbody newBallRB = this.GetComponent<Rigidbody>();
        newBallRB.AddForce(-Vector3.up * m_BallInitTranslationSpeed, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(this.transform.position);
    }

    /*private void OnDestroy()
    {
        GameObject.FindGameObjectWithTag("Ennemi").GetComponent<Ennemi>().CanShoot = true;
    }

}*/
