using UnityEngine;

public class TaskMachine : MonoBehaviour
{
    private TaskManager manager;

    private void Start() => manager = TaskManager.instance;

    public void AccessTask()
    {
        print("Access");
    }

    public void StopAccessingTask()
    {
        // TODO(Andy): Unlock cursor and hide overlay UI canvas!
    }

    public void TaskSuccess() => manager.Success();
    public void TaskFailure() => manager.Failure();
}
