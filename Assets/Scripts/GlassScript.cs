using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassScript : MonoBehaviour
{
    public static bool isGlassPlaced = false;
    private void OnTriggerEnter(Collider other)
    {
        if (isGlassPlaced == false)
        {
            if (other.CompareTag("glass"))
            {
                Debug.Log("Стакан установлен в нужном месте...");
                isGlassPlaced = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isGlassPlaced == true)
        {
            if (other.CompareTag("glass"))
            {
                Debug.Log("Стакан не установлен в нужном месте...");
                isGlassPlaced = false;
            }
        }
    }
}
