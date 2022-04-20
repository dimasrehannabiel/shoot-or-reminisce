using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pemain_Kamera : MonoBehaviour
{
    public float sensitivitasMouse = 100f;
    public Transform pemain;
    float rotasiX = 0f;
    
    void Start()
    {
        //Mengunci cursor pemain agar selalu ditengah monitor
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        GerakKamera();
    }

    void GerakKamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivitasMouse * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivitasMouse * Time.deltaTime;

        //Melakukan Clamping agar pemain tidak melihat ke atas atau bawah 180 derajat
        rotasiX -= mouseY;
        rotasiX = Mathf.Clamp(rotasiX, -90f, 90f);

        //Menggerakkan kamera pemain
        transform.localRotation = Quaternion.Euler(rotasiX, 0f, 0f);
        pemain.Rotate(Vector3.up * mouseX);
    }
}
