using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;


public class Move : MonoBehaviour
{
    SerialPort puerto = new SerialPort("COM4", 9600);

    public float distanciaMov = 50;
   
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
                mover(puerto.ReadByte());
            }
            catch (System.Exception)
            {

            }
        }
    }

    void mover(int direccion)
    {


        if (direccion == 1)
        {
            transform.Translate(Vector3.left * distanciaMov, Space.World);
        }



        //Space.World: se mueve en las coordenadas del espacio local donde esta el GameObject
        //Space.Self: se utiliza para rotación sobre si mismo, con los ejes que el objeto tiene
        //Camera.main.transform: se mueve relativo a las coordenadas de la camara

        
    }
}