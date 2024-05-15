using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class clickButton : MonoBehaviour
{
    [SerializeField] private Transform _block;
    [SerializeField] private Transform _change;

    private bool clickagain=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void click()
    {
        if (clickagain)
        {
            _change.rotation=quaternion.RotateZ(-90);
            _block.position = Vector3.zero;
            clickagain=!clickagain;
        }
        else
        {
            clickagain=!clickagain;
            _change.rotation = quaternion.RotateZ(90);
            _block.position = Vector3.left*5;
        }
    }
}
