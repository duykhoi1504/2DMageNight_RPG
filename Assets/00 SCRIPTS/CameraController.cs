using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : Singleton<CameraController>
{
    // Start is called before the first frame update
    [SerializeField] Transform _playerTransform;
    [SerializeField] float _speed;
     public Vector2 _maxPos;
     public Vector2 _minPos;
    Animator ani;
    void Start()
    {
        ani = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos=_playerTransform.position;
        pos.z = -10;
        //Bounding the Camera(min max of map for camera)
        pos.x=Mathf.Clamp(pos.x,_minPos.x,_maxPos.x);
        pos.y = Mathf.Clamp(pos.y, _minPos.y, _maxPos.y);

        this.transform.position = Vector3.MoveTowards(this.transform.position, pos, _speed);
    }
    public void BeginKick()
    {
        ani.SetBool("Kick_active", true);
        StartCoroutine(KickCo());
    }
    public IEnumerator KickCo()
    {
        yield return new WaitForSeconds(0.5f);
        ani.SetBool("Kick_active", false);

    }
}
