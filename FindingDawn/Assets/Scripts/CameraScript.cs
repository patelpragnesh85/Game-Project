using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{
    public float cameraWidth;
    public Transform player;

    private Camera _camera;
    private float startXPos;
    private Vector3 offset;

    void Start()
    {
        _camera = GetComponent<Camera>();
        offset = player.position - transform.position;
    }

    void Update()
    {
        offset = player.position - transform.position;
        Vector3 pos = offset + transform.position;
        pos =  new Vector3(Mathf.Clamp(pos.x, 0f, 17.7f), 
                           Mathf.Clamp(pos.y, -8.01f, 0f),
                           -10f);
        transform.position = pos;
    }
}