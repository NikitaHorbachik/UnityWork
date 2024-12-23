using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FirePitController : MonoBehaviour
{
    private ParticleSystem fireParticleSystem;

    private void Awake()
    {
            // ���������� ���� ����� firepit
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                child.gameObject.SetActive(false); // ��������� ������
            }

            Debug.Log("��� �������� ������� firepit ���������.");
    }

    private void Start()
    {
        // ���������� ���� ����� firepit
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            child.gameObject.SetActive(false); // ��������� ������
        }

        Debug.Log("��� �������� ������� firepit ���������.");
    }

    public void Ignite()
    {
        // ���������� ���� ����� firepit
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            child.gameObject.SetActive(true); // ��������
        }

        Debug.Log("��� �������� ������� firepit ���������.");
    }

    public void Extinguish()
    {
        // ��������� ������� �������
        if (fireParticleSystem != null && fireParticleSystem.isPlaying)
        {
            fireParticleSystem.Stop();
            Debug.Log("����� �������.");
        }
    }
}
