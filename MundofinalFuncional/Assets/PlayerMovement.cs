using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float forwardForce = 4000f; // Esta es la velocidad de arranque se puede cambiar aconsejo dejarla en 100 todo depende del nivel de Serial.begin
    public float sidewaysForce = 100f;// Esta la de avance, si no la bajan arranca a la mierda
    public int CMD; // Esto nos indica 

    public SerialPort sp = new SerialPort("COM4", 9600);

    // Start is called before the first frame update
    void Start()
    {
        sp.Open();
        sp.ReadTimeout = 1;
    }

    void FixedUpdate()
    {
        if (sp.IsOpen)
        {
            try
            {
                ReadCom();
                Move();
            }
            catch (System.Exception)
            {

            }
        }
        else
        {
            Move();
        }
    }

    // Update is called once per frame
    void Move()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("d") || CMD == 6) 
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a") || CMD == 4)
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("w") || CMD == 8)
        {
            rb.AddForce(0, 0, sidewaysForce * Time.deltaTime, ForceMode.VelocityChange);
        }

        if (Input.GetKey("s") || CMD == 2)
        {
            rb.AddForce(0, 0, -sidewaysForce * Time.deltaTime, ForceMode.VelocityChange);
        }

        /*if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();   
        }*/
    }

    void ReadCom()
    {
        CMD = sp.ReadByte();
    }

    public void CloseCom()
    {
        sp.Close();
    }
}
