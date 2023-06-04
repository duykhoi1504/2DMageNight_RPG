using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform _playerTransform;
    [SerializeField] float _speed = 3;
    [SerializeField] Vector3 _maxPos;
    [SerializeField] Vector3 _minPos;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos=_playerTransform.position;
        pos.z = -10;
        //Bounding the Camera(min max of map for camera)
        pos.x=Mathf.Clamp(pos.x,_minPos.x,_maxPos.x);
        pos.y = Mathf.Clamp(pos.y, _minPos.y, _maxPos.y);

        this.transform.position = Vector3.Lerp(this.transform.position, pos, _speed*Time.deltaTime);
    }
}
