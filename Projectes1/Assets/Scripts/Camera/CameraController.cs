using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Camera cam;
    public float threshold;

    Vector3 mousePos;

    Vector3 targetPos;
    private void Awake()
    {
        
    }
    void Start()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(References.player != null)
        {
            CameraPositionHandeler();
        }
        
    }

    private void FixedUpdate()
    {
        CameraPosition();
    }

    private void CameraPosition()
    {
        transform.position = new Vector3(targetPos.x, targetPos.y , transform.position.z);
    }

    private void CameraPositionHandeler()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        targetPos = (player.position + mousePos) / 2f;

        targetPos.x = Mathf.Clamp(targetPos.x, -threshold + player.position.x, threshold + player.position.x);
        targetPos.y = Mathf.Clamp(targetPos.y, -threshold + player.position.y, threshold + player.position.y);
    }
}
