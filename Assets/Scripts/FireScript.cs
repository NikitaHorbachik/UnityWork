using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FirePitController : MonoBehaviour
{
    private ParticleSystem fireParticleSystem;

    private void Awake()
    {
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
        // Перебираем всех детей firepit
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            child.gameObject.SetActive(true); // включаем
        }

        Debug.Log("Все дочерние объекты firepit отключены.");
    }

    public void Extinguish()
    {
        // Выключаем партикл систему
        if (fireParticleSystem != null && fireParticleSystem.isPlaying)
        {
            fireParticleSystem.Stop();
            Debug.Log("Костёр потушен.");
        }
    }
}
