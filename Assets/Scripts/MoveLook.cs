using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLook : MonoBehaviour
{
    public float sensitivity;
    public Transform player;
    private float rot;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        float x = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float y = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        rot -= y;
        rot = Mathf.Clamp(rot,-70f, 90f);
        transform.localRotation = Quaternion.Euler(rot, 0f, 0f);
        player.Rotate(player.up*x);
        

    }
}
