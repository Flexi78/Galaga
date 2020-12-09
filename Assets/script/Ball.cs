using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float m_LifeDuration;


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
}
