using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : MonoBehaviour
{    
    [Header("Ennemi settings")]
    [SerializeField] Transform m_SpawnPoint;
    [SerializeField] float m_TranslationSpeed;
    [SerializeField] int m_LifeNumber;

    [Header("Ball shot")]
    [SerializeField] GameObject m_BallPrefab;
    [SerializeField] Transform m_BallSpawnPoint;
    [SerializeField] float m_BallInitTranslationSpeed;
    [SerializeField] float m_BallShotCooldownDuration;
    float m_BallShotNextTime; // temps dans le futur auquel le tir est autorisé



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
