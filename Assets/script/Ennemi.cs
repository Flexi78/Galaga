using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class Ennemi : MonoBehaviour
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

    /*private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Ball"))
        {
            Destroy(this);
        }
        
    }*/
//}

public class Ennemi : MonoBehaviour
{
    [SerializeField]
    public int enemyRows = 3;
    public int enemyColumns = 10;
    public int direction = 1;
    public float speed = 1;
    public GameObject enemyPref;
    public GameObject[] enemies;
    private GameObject attackForce;

    int GetEnemyCount()
    {
        int total = 0;
        foreach (GameObject enemy in enemies)
        {
            if (enemy != null)
            {
                total += 1;
            }
        }
        return total;
    }

    void Start()
    {
        enemies = new GameObject[enemyRows * enemyColumns];

        Spawn();
    }

    void Spawn()
    {
        Vector2 center = gameObject.transform.position;
        for (int i = 0; i < enemyRows; i++)
        {
            for (int j = 0; j < enemyColumns; j++)
            {
                if (!enemies[i * enemyColumns + j])
                {
                    Vector2 pos = new Vector2(j - enemyColumns / 2 + 0.5f, i);
                    enemies[i * enemyColumns + j] = (GameObject)Instantiate(enemyPref, pos, Quaternion.identity);
                    enemies[i * enemyColumns + j].transform.SetParent(this.transform);
                }
            }
        }
    }

    void Move()
    {
        var pos = transform.position;
        pos.x = pos.x + direction * Time.deltaTime * speed;
        pos.x = Mathf.Clamp(pos.x, -1, 1);

        transform.position = pos;

        if (pos.x == -1 || pos.x == 1)
        {
            direction = -1 * direction;
        }
    }

    bool isAttacking()
    {
        return (bool)attackForce;
    }

}



