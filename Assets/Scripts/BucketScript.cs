using UnityEngine;

public class BucketScript: MonoBehaviour
{
    [SerializeField] private GameObject fullBucketPrefab; // ������ �� ������ FullBucket

    public void Start()
    {
        ReplaceBucket();
    }
    private void OnTriggerEnter(Collider other)
    {
        // ���������, ���� �� � ������� ������� ��� "barrel"
        if (other.CompareTag("barrel"))
        {
            ReplaceBucket();
        }
    }

    private void ReplaceBucket()
    {
        if (fullBucketPrefab != null)
        {
            // ��������� ������� ������� � �������
            Vector3 currentPosition = transform.position;
            Quaternion currentRotation = transform.rotation;

            // ������ ����� FullBucket
            Instantiate(fullBucketPrefab, currentPosition, currentRotation);
            // ������� ������� EmptyBucket
            Destroy(gameObject);
        }
        else
        {
            Debug.LogError("FullBucketPrefab �� ��������!");
        }
    }
}
