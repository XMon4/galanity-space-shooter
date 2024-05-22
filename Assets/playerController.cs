using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;

public class PlayerController: MonoBehaviour
{
    [SerializeField] private string _horzintalAxisName;
    [SerializeField] private string _vertialAxisName;
    [SerializeField] private string _fire1;

    [SerializeField] private float _speed=1f;
    [SerializeField] public static Rigidbody2D _rigidbody2D;
    private Attach _attach = null;
    private clickButton _button = null;
    [SerializeField] private EnemyController _enemyP;
    private hitboxControl _hitboxP;
    [SerializeField] private hudController _hudController;
    public PlayerController _player;

    [SerializeField] public projectileController _ProjectileController;

    [SerializeField] private boomController _boom;

    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

    }

    [SerializeField] private float baseCooldown = .3f;
    [SerializeField] private float fireCooldown = .3f;
    // Update is called once per frame
    void Update()
    {

        float xAxis = Input.GetAxis(_horzintalAxisName);
        float yAxis = Input.GetAxis(_vertialAxisName);
        _rigidbody2D.velocity = new Vector2(xAxis, yAxis) * _speed;
        if (Input.GetKeyUp(KeyCode.F))
        {
            playerInteract();
        }

        fireCooldown -= Time.deltaTime;

        if (Input.GetKeyUp(KeyCode.LeftShift) && fireCooldown <= 0f)
        {
            fireCooldown = baseCooldown;
            //var newObject = Instantiate(_ProjectileController, new Vector2(_rigidbody2D.transform.position.x,_rigidbody2D.transform.position.y+1), Quaternion.identity);
                            _ProjectileController.fireUP(_rigidbody2D.transform.position.x,_rigidbody2D.transform.position.y);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl)&& fireCooldown <= 0f)
        {
            fireCooldown = baseCooldown;
            _ProjectileController.fireDOWN(_rigidbody2D.transform.position.x, _rigidbody2D.transform.position.y);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        playerBoom();

        if (_hudController.hp != 0)
        {
            StartCoroutine(playerRespawn());
        }

        _hudController.losHP();
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if(_attach != null && other.gameObject == _attach.gameObject)
            _attach = null;
        
        if (_button!= null && other.gameObject == _button.gameObject)
            _button = null;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
    }

    private void playerInteract()
    {
        if(_attach is not null)
            _attach.MANfollow=!_attach.MANfollow;
        
        if(_button is not null)
            _button.click();
        
    }

    private IEnumerator playerRespawn()
    {
        //this.gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
        _rigidbody2D.position = new Vector2(0, -4);
        yield return new WaitForSecondsRealtime(1);
        _enemyP.enemyReset();
        GetComponent<Renderer>().enabled = true;
    }

    private void playerBoom()
    {
        GetComponent<Renderer>().enabled = false;
        var boom = Instantiate(_boom, _rigidbody2D.transform.position, Quaternion.identity);
    }
}