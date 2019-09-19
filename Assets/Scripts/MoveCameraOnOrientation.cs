using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraOnOrientation : MonoBehaviour
{
    private DeviceOrientation deviceOrientation;

    // Start is called before the first frame update
    void Start()
    {
        deviceOrientation = Input.deviceOrientation;
        changeOrientation();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.deviceOrientation != deviceOrientation) Start();
    }

    private void changeOrientation()
    {
        if (deviceOrientation == DeviceOrientation.LandscapeLeft || deviceOrientation == DeviceOrientation.LandscapeRight)
        {
            transform.position = new Vector3(0, 0, -1);
        }

        if (deviceOrientation == DeviceOrientation.Portrait || deviceOrientation == DeviceOrientation.PortraitUpsideDown || deviceOrientation == DeviceOrientation.FaceUp )
        {
            transform.position = new Vector3(0, 0, -2);
        }
    }
}
