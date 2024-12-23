using UnityEngine;

public class BucketScript: MonoBehaviour
{
    [SerializeField] private GameObject fullBucketPrefab; // Ссылка на префаб FullBucket

    public void Start()
    {
        ReplaceBucket();
    }
    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, есть ли у другого объекта тег "barrel"
        if (other.CompareTag("barrel"))
        {
            ReplaceBucket();
        }
    }

    private void ReplaceBucket()
    {
        if (fullBucketPrefab != null)
        {
            // Сохраняем текущую позицию и поворот
            Vector3 currentPosition = transform.position;
            Quaternion currentRotation = transform.rotation;

            // Создаём новый FullBucket
            Instantiate(fullBucketPrefab, currentPosition, currentRotation);
            // Удаляем текущий EmptyBucket
            Destroy(gameObject);
        }
        else
        {
            Debug.LogError("FullBucketPrefab не назначен!");
        }
    }
}
