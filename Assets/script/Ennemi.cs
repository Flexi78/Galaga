using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : MonoBehaviour
{    
    [Header("Ennemi settings")]
    [SerializeField] Transform m_SpawnPoint;
    [SerializeField] float m_TranslationSpeed;
    [SerializeField] int m_LifeNumber;
    public bool CanShoot = true;


    [Header("Ball shot")]
    [SerializeField] GameObject m_BallPrefab;
    [SerializeField] Transform m_BallSpawnPoint;
    [SerializeField] float m_BallInitTranslationSpeed;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Ball"))
        {
            Destroy(this);
        }
        
    }
}


