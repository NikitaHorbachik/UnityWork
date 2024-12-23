using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class GOYDA : MonoBehaviour
{
    private MeshCollider MeshCollider;
    // Start is called before the first frame update
    void Start()
    {
        MeshCollider = GetComponent<MeshCollider>();
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MeshCollider.enabled = false;

            Debug.Log("√ŒŒŒŒŒ…ƒ¿¿¿¿¿¿¿¿¿¿!!!!!!¿ ¿!¿!¿!¿!¿!¿");

            yield return new WaitForSeconds(1);
            MeshCollider.enabled = true;
        }
    }
}
