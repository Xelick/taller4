
using UnityEngine;
using System;
using System.IO.Ports;



public class MoveArduinoPotencimeters : MonoBehaviour
{


    SerialPort puerto = new SerialPort("COM4", 9600);
    // Use this for initialization
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
                mover(puerto.ReadLine());
                print(puerto.ReadLine());

            }
            catch (System.Exception)
            {

            }
        }
    }

    
    void mover(string datoArduino)
    {
        //Convert.ToInt32(datoArduino);
       
        if (datoArduino.Contains("1"))
        {
            
           
            GetComponent<Animator>().SetBool("MoverPared", true);

        }
        else
        {
            
            GetComponent<Animator>().SetBool("MoverPared", false);
        }

        

    
    }

}
