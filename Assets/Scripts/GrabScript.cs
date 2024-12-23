using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class GrabbableMessage : MonoBehaviour
{
    public string message = "Объект захвачен!"; // Сообщение для вывода

    private void OnEnable()
    {
        // Подписка на события взаимодействия
        var interactable = GetComponent<XRGrabInteractable>();
        if (interactable != null)
        {
            interactable.selectEntered.AddListener(OnGrab);
            interactable.selectExited.AddListener(OnRelease);
        }
    }

    private void OnDisable()
    {
        // Отписка от событий
        var interactable = GetComponent<XRGrabInteractable>();
        if (interactable != null)
        {
            interactable.selectEntered.RemoveListener(OnGrab);
            interactable.selectExited.RemoveListener(OnRelease);
        }
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        Debug.Log(message); // Вывод сообщения в консоль
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        Debug.Log("Объект отпущен."); // Вывод информации об отпускании объекта
    }
}
