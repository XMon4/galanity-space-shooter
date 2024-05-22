using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _enemyRigidbody2D;
    private Vector2 _currentVector2;
    public AnimationCurve _AnimationCurveSwing;
    public AnimationCurve _AnimationCurveDive;
    [SerializeField] private hudController _hud;
    [SerializeField] private enemyheadController _head;
    [SerializeField] private boomController _boom;

    private bool enemyGo;
    private float currentTime;


    // Start is called before the first frame update
    void Start()
    {
        _currentVector2 = _enemyRigidbody2D.transform.position;
        enemyGo = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var boom = Instantiate(_boom, other.transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
        MovementLoop();

        }

    private void MovementLoop()
    {
        //gameObject.GetComponentInChildren<>()
        
        if (enemyGo)
        {
            currentTime += Time.deltaTime;
        }
        transform.position = new Vector2((_AnimationCurveSwing).Evaluate(currentTime), transform.position.y);
        transform.position = new Vector2(transform.position.x, (_AnimationCurveDive).Evaluate(currentTime));
    }

    public void enemyReset()
    {
        currentTime = 0;
        transform.position=new Vector2(0,4);
    }

    public IEnumerator countHeads()
    {
        print("print from counting");
        yield return new WaitForEndOfFrame();
        if(transform.GetComponentsInChildren<enemyheadController>().Length <= 0)
        {
            StartCoroutine(defeatedEnemy());
        }
    }


    private IEnumerator defeatedEnemy()
    {
        print("print from enemy");
        enemyGo = false;
        yield return new WaitForSecondsRealtime(1);
        _hud.lvlClear();
    }
}
