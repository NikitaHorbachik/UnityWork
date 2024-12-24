using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FirePitController : MonoBehaviour
{
    private ParticleSystem fireParticleSystem;
    public static bool isFireOn = false;

    private void Awake()
    {
        isFireOn = false;
        // Перебираем всех детей firepit
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            child.gameObject.SetActive(false); // Отключаем объект
        }

        Debug.Log("Все дочерние объекты firepit отключены.");
    }

    private void Start()
    {
        isFireOn = false;
        // Перебираем всех детей firepit
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            child.gameObject.SetActive(false); // Отключаем объект
        }

        Debug.Log("Все дочерние объекты firepit отключены.");
    }

    public void Ignite()
    {
        isFireOn = !isFireOn;
        // Перебираем всех детей firepit
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if (isFireOn == true)
            {
                child.gameObject.SetActive(true); // включаем
            }
            else
            {
                child.gameObject.SetActive(false);
            }
        }

        Debug.Log("Все дочерние объекты firepit отключены.");
    }

    public void Extinguish()
    {
        isFireOn = false;
        // Выключаем партикл систему
        if (fireParticleSystem != null && fireParticleSystem.isPlaying)
        {
            fireParticleSystem.Stop();
            Debug.Log("Костёр потушен.");
        }
    }
}