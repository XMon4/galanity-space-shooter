using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemygunController : MonoBehaviour
{
    [SerializeField] private projectileController _enemyprojectile;

    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(enemyShoot());

    }

    // Update is called once per frame
    void Update()
    {
    }

    private IEnumerator enemyShoot()
    {
        yield return new WaitForSeconds(1);
        _enemyprojectile.fireDOWN(transform.position.x,transform.position.y);
        yield return new WaitForSeconds(1);
        _enemyprojectile.fireUP(transform.position.x,transform.position.y);
        yield return new WaitForSeconds(1);
        StartCoroutine(enemyShoot());


    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(_enemyprojectile.gameObject);
    }
}
