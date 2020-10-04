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

    private GeneralTask currentTask;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start() => currentTask = null;

    private IEnumerator StartTask()
    {
        yield return new WaitForSeconds(1f);
        screenIntroText.SetActive(false);
        if (currentTask == null)
        {
            var index = Random.Range(0, tasks.Length);
            //var index = tasks.Length - 1;
            currentTask = tasks[index];
            currentTask.Setup();
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
        var waitInstruction = new WaitForSeconds(delayAfterSuccess);
        yield return waitInstruction;
        if (currentTask.hasSucceeded)
        {
            successImage.SetActive(true);
            currentTask.gameObject.SetActive(false);
            currentTask.Teardown();
            currentTask = null;
            StartCoroutine(TaskEndImage(successImage));
        }
    }
}
