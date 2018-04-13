using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScriptUnclamped : MonoBehaviour
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
        transform.position = new Vector3(player.position.x, player.position.y, -10f);
    }
}