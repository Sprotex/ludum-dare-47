using UnityEngine;
using UnityEngine.Events;

public class GeneralTask : MonoBehaviour
{
    public UnityEvent setupEvent;
    public UnityEvent teardownEvent;
    public bool hasSucceeded;

    public void Setup()
    {
        hasSucceeded = true;
        setupEvent.Invoke();
    }
    public void Teardown()
    {
        hasSucceeded = false;
        teardownEvent.Invoke();
    }
}
