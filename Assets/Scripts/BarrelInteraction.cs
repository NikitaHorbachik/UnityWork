using UnityEngine;

public class BarrelInteraction : MonoBehaviour
{
    // ������ �� ������� �����
    public GameObject emptyBucket;
    public GameObject filledBucket;

    // ����� ����������� ��� ������������
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("on trigger enter");
        if (other.CompareTag("EmptyBucket"))
        {
            emptyBucket.SetActive(false);
            filledBucket.SetActive(true);
        }
    }

}
