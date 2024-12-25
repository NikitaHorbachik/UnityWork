using UnityEngine;

public class BucketScript : MonoBehaviour
{
    public GameObject emptyBucketPrefab;  // ������ ������� �����
    public GameObject fullBucketPrefab;   // ������ ������� �����
    public bool isFull = false;           // ��������� �����: ������ ��� ������
    private bool isProcessing = false;    // ���� ��� �������������� ������������� ������������

    private static int interactionCount = 0; // ������� �������������� � ���������
    public GameObject glassObject;           // ������ �������
    public GameObject filledGlassPrefab;     // ������ ������������ �������

    private void OnTriggerEnter(Collider other)
    {
        if (isProcessing) return;

        if (other.CompareTag("barrel") && !isFull)
        {
            Debug.Log("����� �����������...");
            ReplaceBucket(fullBucketPrefab, true);
        }
        else if (other.CompareTag("machine") && isFull)
        {
            if (FirePitController.isFireOn == true)
            {
                Debug.Log("����� ������������...");
                ReplaceBucket(emptyBucketPrefab, false);

                // ����������� ������� ��������������
                interactionCount++;
                Debug.Log($"�������������� � ���������: {interactionCount}");

                CheckGlassState(); // ��������� ��������� �������
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
            Debug.LogError("Prefab ����� �� ��������!");
        }

        isProcessing = false;
    }

    private void CheckGlassState()
    {
        // ���������, ��������� �� �������
        if (interactionCount >= 2 && FirePitController.isFireOn == true && GlassScript.isGlassPlaced == true)
        {
            Debug.Log("������ ������ �� �����������!");

            if (glassObject != null && filledGlassPrefab != null)
            {
                // ��������� ������� � ������� �������
                Vector3 glassPosition = glassObject.transform.position;
                Quaternion glassRotation = glassObject.transform.rotation;
                glassRotation.x = 0;

                // ������ ����������� ������
                Instantiate(filledGlassPrefab, glassPosition, glassRotation);

                // ������� ������ ������
                glassObject.SetActive(false);
            }
            else
            {
                Debug.LogError("������ ������� ��� ������ ������������ ������� �� ��������!");
            }
        }
    }
}
