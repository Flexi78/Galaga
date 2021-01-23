using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{   
    [Header("Ball shot")]
    [SerializeField] float m_LifeDuration; //temps de vie de la balle

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, m_LifeDuration);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().CanShoot = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ennemi"))
        {
            Destroy(collision.gameObject);
            Debug.Log("BOUM");
            Destroy(this.gameObject);
        }
    }
}