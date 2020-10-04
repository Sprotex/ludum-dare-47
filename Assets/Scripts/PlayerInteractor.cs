using TMPro;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    public Camera mainCamera;
    public float interactingDistance;
    public TextMeshProUGUI noticeTextGUI;

    private TaskManager manager;
    private string currentNoticeText;
    private GameObject focusedGameObject;
    private GameObject lastFocusedGameObject;

    private void Start()
    {
        manager = TaskManager.instance;
        noticeTextGUI.text = "";
        lastFocusedGameObject = null;
        focusedGameObject = null;
    }

    private void FocusOnObject(GameObject gameObject, string accessText)
    {
        currentNoticeText = accessText;
        focusedGameObject = gameObject;
    }

    private void Update()
    {
        var maxDistance = interactingDistance;
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out var info, maxDistance))
        {
            var interactable = info.collider.GetComponent<Interactable>();
            if (interactable != null && interactable.enabled)
            {
                if (manager.CanBeRunAgain)
                {
                    if (!manager.isRunning)
                    {
                        FocusOnObject(interactable.gameObject, interactable.accessText);
                    }
                    else
                        FocusOnObject(gameObject, "Press TAB to leave PC");
                }
                var isMouseClicked = Input.GetMouseButtonDown(0);
                if (isMouseClicked)
                    interactable.AccessTask();
            }
            else
                FocusOnObject(null, "");
        }
        else
            FocusOnObject(null, "");
        if (lastFocusedGameObject != focusedGameObject)
        {
            lastFocusedGameObject = focusedGameObject;
            noticeTextGUI.text = currentNoticeText;
        }
    }
}
