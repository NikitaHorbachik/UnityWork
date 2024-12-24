using UnityEngine;

public class BarrelInteraction : MonoBehaviour
{
    // —сылки на объекты ведра
    public GameObject emptyBucket;
    public GameObject filledBucket;

    // ћетод срабатывает при столкновении
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
