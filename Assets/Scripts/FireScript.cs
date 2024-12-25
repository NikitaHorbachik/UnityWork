using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FirePitController : MonoBehaviour
{
    private ParticleSystem fireParticleSystem;
    public static bool isFireOn = false;

    private void Awake()
    {
        isFireOn = false;
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
        isFireOn = false;
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
        isFireOn = !isFireOn;
        // ���������� ���� ����� firepit
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if (isFireOn == true)
            {
                child.gameObject.SetActive(true); // ��������
            }
            else
            {
                child.gameObject.SetActive(false);
            }
        }

        Debug.Log("��� �������� ������� firepit ���������.");
    }

    public void Extinguish()
    {
        isFireOn = false;
        // ��������� ������� �������
        if (fireParticleSystem != null && fireParticleSystem.isPlaying)
        {
            fireParticleSystem.Stop();
            Debug.Log("����� �������.");
        }
    }
}