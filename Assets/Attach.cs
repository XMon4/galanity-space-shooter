using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attach : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _MANrigidbody2D;

    public bool MANfollow=false;
    // Start is called before the first frame update
    void Start()
    {
        _MANrigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MANfollow && Vector2.Distance(PlayerController._rigidbody2D.transform.position,
                _MANrigidbody2D.transform.position) > 1.2)
        {
            MANfollow = false;
        }
        if (MANfollow)
        {
            _MANrigidbody2D.velocity=PlayerController._rigidbody2D.velocity;
        }
        else
        {
            _MANrigidbody2D.velocity = Vector2.zero;
        }
        
    }
    
}
