using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pemain_Kontrol : MonoBehaviour
{
    public CharacterController karakterKontroler;
    public float kecepatanGerak = 12f;
    public float gravitasi = -9.81f;
    public float tinggiLompatan = 3f;

    public Transform pengecekPlatform;
    public float jarakPlatform = 0.4f;
    public LayerMask maskPlatform;
    bool diPlatform;

    Vector3 velocity;
    void Update()
    {
       Pergerakan(); 
    }

    void Pergerakan()
    {
        diPlatform = Physics.CheckSphere(pengecekPlatform.position, jarakPlatform, maskPlatform);

        if(diPlatform && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 pergerakan = transform.right * x + transform.forward * z;
        karakterKontroler.Move(pergerakan * kecepatanGerak * Time.deltaTime);

        Lompat();
        TerapkanGravitasi();
    }

    void Lompat()
    {
        if(Input.GetButtonDown("Jump") && diPlatform)
        {
            velocity.y = Mathf.Sqrt(tinggiLompatan * -2f * gravitasi);
        }

    }

    void TerapkanGravitasi()
    {
        velocity.y += gravitasi * Time.deltaTime;
        karakterKontroler.Move(velocity * Time.deltaTime);
    }
}
