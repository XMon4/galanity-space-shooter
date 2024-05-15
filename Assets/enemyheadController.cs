using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemyheadController : MonoBehaviour
{
    [SerializeField] private EnemyController _enemyParent;
    [SerializeField] private enemyheadController _enemyhead;
    

    
    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(_enemyhead.gameObject);
        _enemyParent.StartCoroutine(_enemyParent.countHeads());

    }
}
