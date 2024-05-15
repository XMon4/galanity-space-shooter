using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class projectileController : MonoBehaviour
{
    [SerializeField] public Rigidbody2D _prj_bd;
    public projectileController _ProjectileController;
    [SerializeField] private float _prj_speed;
    // Start is called before the first frame update
    void Start()
    {
        _prj_bd = GetComponent<Rigidbody2D>();
        Destroy(_ProjectileController.gameObject,1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fireUP(float _transX,float _transY)
    {
        var newProjectile = Instantiate(_ProjectileController, new Vector2(_transX,_transY+1), Quaternion.identity);
        newProjectile._prj_bd.AddForce(Vector2.up*_prj_speed);
    }
    public void fireDOWN(float _transX,float _transY)
    {
        var newProjectile = Instantiate(_ProjectileController, new Vector2(_transX,_transY-1), Quaternion.identity);
        newProjectile._prj_bd.AddForce(Vector2.down*_prj_speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(_ProjectileController.gameObject);
        
    }
}
