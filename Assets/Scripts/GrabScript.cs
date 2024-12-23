using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class GrabbableMessage : MonoBehaviour
{
    public string message = "������ ��������!"; // ��������� ��� ������

    private void OnEnable()
    {
        // �������� �� ������� ��������������
        var interactable = GetComponent<XRGrabInteractable>();
        if (interactable != null)
        {
            interactable.selectEntered.AddListener(OnGrab);
            interactable.selectExited.AddListener(OnRelease);
        }
    }

    private void OnDisable()
    {
        // ������� �� �������
        var interactable = GetComponent<XRGrabInteractable>();
        if (interactable != null)
        {
            interactable.selectEntered.RemoveListener(OnGrab);
            interactable.selectExited.RemoveListener(OnRelease);
        }
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        Debug.Log(message); // ����� ��������� � �������
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        Debug.Log("������ �������."); // ����� ���������� �� ���������� �������
    }
}
