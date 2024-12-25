using UnityEngine;

public class BucketScript : MonoBehaviour
{
    public GameObject emptyBucketPrefab;  // Префаб пустого ведра
    public GameObject fullBucketPrefab;   // Префаб полного ведра
    public bool isFull = false;           // Состояние ведра: полное или пустое
    private bool isProcessing = false;    // Флаг для предотвращения многократного срабатывания

    private static int interactionCount = 0; // Счетчик взаимодействий с аппаратом
    public GameObject glassObject;           // Объект стакана
    public GameObject filledGlassPrefab;     // Префаб заполненного стакана

    private void OnTriggerEnter(Collider other)
    {
        if (isProcessing) return;

        if (other.CompareTag("barrel") && !isFull)
        {
            Debug.Log("Ведро наполняется...");
            ReplaceBucket(fullBucketPrefab, true);
        }
        else if (other.CompareTag("machine") && isFull)
        {
            if (FirePitController.isFireOn == true)
            {
                Debug.Log("Ведро опустошается...");
                ReplaceBucket(emptyBucketPrefab, false);

                // Увеличиваем счетчик взаимодействий
                interactionCount++;
                Debug.Log($"Взаимодействий с аппаратом: {interactionCount}");

                CheckGlassState(); // Проверяем состояние стакана
            }
        }
    }

    private void ReplaceBucket(GameObject newBucketPrefab, bool newState)
    {
        isProcessing = true;

        if (newBucketPrefab != null)
        {
            Vector3 currentPosition = transform.position;
            Quaternion currentRotation = transform.rotation;

            GameObject newBucket = Instantiate(newBucketPrefab, currentPosition, currentRotation);

            BucketScript newBucketScript = newBucket.GetComponent<BucketScript>();
            if (newBucketScript != null)
            {
                newBucketScript.isFull = newState;
                newBucketScript.glassObject = glassObject;
                newBucketScript.filledGlassPrefab = filledGlassPrefab;
            }

            Destroy(gameObject);
        }
        else
        {
            Debug.LogError("Prefab ведра не назначен!");
        }

        isProcessing = false;
    }

    private void CheckGlassState()
    {
        // Проверяем, выполнены ли условия
        if (interactionCount >= 2 && FirePitController.isFireOn == true && GlassScript.isGlassPlaced == true)
        {
            Debug.Log("Меняем стакан на заполненный!");

            if (glassObject != null && filledGlassPrefab != null)
            {
                // Сохраняем позицию и поворот стакана
                Vector3 glassPosition = glassObject.transform.position;
                Quaternion glassRotation = glassObject.transform.rotation;
                glassRotation.x = 0;

                // Создаём заполненный стакан
                Instantiate(filledGlassPrefab, glassPosition, glassRotation);

                // Удаляем старый стакан
                glassObject.SetActive(false);
            }
            else
            {
                Debug.LogError("Объект стакана или префаб заполненного стакана не назначен!");
            }
        }
    }
}
