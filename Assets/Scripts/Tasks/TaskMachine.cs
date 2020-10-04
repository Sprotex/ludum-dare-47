using UnityEngine;

public class TaskMachine : MonoBehaviour
{
    private TaskManager manager;

    public GameObject playerCinemachineCamera;
    public CursorLocker cursorLocker;
    public string accessText;

    private void Start() => manager = TaskManager.instance;

    private void Update()
    {
        if (manager.isRunning)
            if (Input.GetButtonDown("Access PC"))
                StopAccessingTask();
    }

    public void AccessTask()
    {
        if (!manager.isRunning)
        {
            playerCinemachineCamera.SetActive(false);
            cursorLocker.Unlock();
            manager.StartTasks();
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
    }

    public void TaskSuccess() => manager.Success();
    public void TaskFailure() => manager.Failure();
}
