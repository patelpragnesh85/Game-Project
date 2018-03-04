using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float speed = 10f;

    //vars for the whole sheet
    public int colCount = 3;
    public int rowCount = 3;

    //vars for animation
    public int rowNumber = 0; //Zero Indexed
    public int colNumber = 0; //Zero Indexed
    public int totalCells = 8;
    public int fps = 24;

    private Renderer _renderer;
    private Vector2 offset;
    private bool canWalk;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        float horizontalSpeed = Input.GetAxis("Horizontal");
        float verticalSpeed = Input.GetAxis("Vertical");

        if (horizontalSpeed != 0 || verticalSpeed != 0) canWalk = true;
        else canWalk = false;

        if (horizontalSpeed > 0)
        {
            transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
            transform.Translate(Vector3.down * horizontalSpeed * Time.deltaTime * speed);
        }
        else if (horizontalSpeed < 0)
        {
            transform.rotation = Quaternion.AngleAxis(-90, Vector3.forward);
            transform.Translate(Vector3.up * horizontalSpeed * Time.deltaTime * speed);
        }
        else if (verticalSpeed > 0)
        {
            transform.rotation = Quaternion.AngleAxis(180, Vector3.forward);
            transform.Translate(Vector3.down * verticalSpeed * Time.deltaTime * speed);
        }
        else if (verticalSpeed < 0)
        {
            transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
            transform.Translate(Vector3.up * verticalSpeed * Time.deltaTime * speed);
        }

        SetSpriteAnimation(colCount, rowCount, rowNumber, colNumber, totalCells, fps);
    }

    //SetSpriteAnimation
    void SetSpriteAnimation(int colCount, int rowCount, int rowNumber, int colNumber, int totalCells, int fps)
    {
        // Calculate index
        int index = (int)(Time.time * fps);

        // Repeat when exhausting all cells
        index = index % totalCells;

        // Size of every cell
        float sizeX = 1.0f / colCount;
        float sizeY = 1.0f / rowCount;
        Vector2 size = new Vector2(sizeX, sizeY);

        // split into horizontal and vertical index
        var uIndex = index % colCount;
        var vIndex = index / colCount;

        // build offset
        // v coordinate is the bottom of the image in opengl so we need to invert.
        float offsetX = (uIndex + colNumber) * size.x;
        float offsetY = (1.0f - size.y) - (vIndex + rowNumber) * size.y;

        if (canWalk)
        {
            offset = new Vector2(offsetX, offsetY);
            _renderer.material.SetTextureOffset("_MainTex", offset);
        }
        _renderer.material.SetTextureScale("_MainTex", size);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.name);

        if (collision.gameObject.tag == "Enemy")
        {
        }
    }

}
