using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CameraFollow : MonoBehaviour
{
    Camera _cam;
    public Vector3 screenSize;
    public GameObject _player;
    Transform _target;

    Vector3 viewPos;
    Vector3 targetPosition;

    public float smoothTime = 0.2f;

    private Vector3 _velocity = Vector3.zero;
    public float minBoundX, maxBoundX, minBoundY, maxBoundY = 0f;


    void Awake()
    {
        _cam = this.gameObject.GetComponent<Camera>();
        screenSize = _cam.ViewportToWorldPoint(new Vector3(1, 1, transform.position.z));
    }

    void Start()
    {
        _target = _player.transform;
        targetPosition = new Vector3(_target.position.x, _target.position.y, transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {

        viewPos = _cam.WorldToViewportPoint(_target.position);
        if (viewPos.x < 0.3f)
        {
            targetPosition = new Vector3(_target.position.x - screenSize.x / 2, _target.position.y, transform.position.z);
        }

        if (viewPos.x > 0.7f)
        {
            targetPosition = new Vector3(_target.position.x + screenSize.x / 2, _target.position.y, transform.position.z);
        }
        if (viewPos.y > 0.7f)
        {
            targetPosition = new Vector3(_target.position.x, _target.position.y + screenSize.y / 2, transform.position.z);
        }
        if (viewPos.y < 0.3f)
        {
            targetPosition = new Vector3(_target.position.x, _target.position.y - screenSize.y / 2, transform.position.z);
        }
    }

    void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, smoothTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minBoundX, maxBoundX),
                                        Mathf.Clamp(transform.position.y, minBoundY, maxBoundY), transform.position.z);
    }


    public void SetBoundries(float minX, float maxX, float minY, float maxY)
    {
        minBoundX = minX + screenSize.x;
        maxBoundX = maxX - screenSize.x;
        minBoundY = minY + screenSize.y;
        maxBoundY = maxY - screenSize.y;
    }

    public void Center()
    {
        _player.transform.position = new Vector3(transform.position.x, transform.position.y, _player.transform.position.z);
    }

   /*  void OnDrawGizmos()
     {
         Handles.Label(new Vector3(0,0,0), viewPos.ToString());
     }*/
}