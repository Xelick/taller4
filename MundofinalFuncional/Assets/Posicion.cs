using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Diagnostics;

public class Posicion : MonoBehaviour
{
    public Transform target;
    public Transform target2;

    public int posi;

    public float speed;

    SerialPort puerto = new SerialPort("COM3", 9600);
    // Start is called before the first frame update
    void Start()
    {
        puerto.Open();
        puerto.ReadTimeout = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (puerto.IsOpen)
        {
            try
            {
                Cambio(puerto.ReadByte());
            }
            catch (System.Exception)
            {

            }
        }
    }

    void Cambio(int position)
    {
        posi = position;
        UnityEngine.Debug.Log(position);

        if (posi==0)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
        else
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target2.position, step);
        }
       
    }
    void LateUpdate()
    {
        posi = 1;
    }
}
