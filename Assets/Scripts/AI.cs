using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    [Header("AI settings")]
    [SerializeField] Transform player;
    [SerializeField] Transform enemy;
    [SerializeField] GameObject eyeSight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemy.LookAt(player);
    }
}
