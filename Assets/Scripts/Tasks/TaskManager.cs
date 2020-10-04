using System.Collections;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public static TaskManager instance;
    public GameObject screenIntroText;
    public GameObject successImage;
    public GameObject failureImage;
    public GeneralTask[] tasks;
    public float delayAfterSuccess = 0.5f;
    [HideInInspector]
    public bool isRunning;
    private int taskIndex;
    private GeneralTask currentTask;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        currentTask = null;
        taskIndex = 0;
    }

    private IEnumerator StartTask()
    {
        yield return new WaitForSeconds(1f);
        screenIntroText.SetActive(false);
        if (currentTask == null)
        {
            if (taskIndex >= tasks.Length)
                taskIndex = 0;
            currentTask = tasks[taskIndex];
            currentTask.Setup();
            taskIndex = taskIndex + 1;
        }
    }

    public void StartTasks()
    {
        isRunning = true;
        screenIntroText.SetActive(true);
        StartCoroutine(StartTask());
    }

    public void StopTasks() => isRunning = false;

    private IEnumerator TaskEndImage(GameObject imageObject)
    {
        yield return new WaitForSeconds(1f);
        imageObject.SetActive(false);
        screenIntroText.SetActive(true);
        StartCoroutine(StartTask());
    }

    public void Failure()
    {
        failureImage.SetActive(true);
        currentTask.gameObject.SetActive(false);
        currentTask.Teardown();
        currentTask = null;
        StartCoroutine(TaskEndImage(failureImage));
    }

    public void TaskState(bool isCompleted)
    {
        if (isCompleted)
            Success();
        else
            Failure();
    }

    public void Success() => StartCoroutine(DelayedSuccess());

    private IEnumerator DelayedSuccess()
    {
        var cachedTask = currentTask;
        var waitInstruction = new WaitForSeconds(delayAfterSuccess);
        yield return waitInstruction;
        if (cachedTask.hasSucceeded)
        {
            successImage.SetActive(true);
            currentTask.gameObject.SetActive(false);
            currentTask.Teardown();
            currentTask = null;
            StartCoroutine(TaskEndImage(successImage));
        }
    }
}
