using UnityEngine;

public class TaskMachine : Interactable
{
    private TaskManager manager;

    public GameObject playerCinemachineCamera;
    public CursorLocker cursorLocker;
    public PlayerMovement playerMovement;

    private void Start() => manager = TaskManager.instance;

    private void Update()
    {
        if (manager.isRunning)
            if (Input.GetButtonDown("Access PC"))
                StopAccessingTask();
    }

    public override void AccessTask()
    {
        if (!manager.isRunning && manager.CanBeRunAgain)
        {
            playerCinemachineCamera.SetActive(false);
            cursorLocker.Unlock();
            manager.StartTasks();
            playerMovement.enabled = false;
        }
    }

    public void StopAccessingTask()
    {
        if (manager.isRunning)
        {
            playerCinemachineCamera.SetActive(true);
            manager.StopTasks();
            cursorLocker.Lock();
        }
        playerMovement.enabled = true;
    }

    public void TaskSuccess() => manager.Success();
    public void TaskFailure() => manager.Failure();
}
