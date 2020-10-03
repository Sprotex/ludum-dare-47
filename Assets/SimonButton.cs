using UnityEngine;

public class SimonButton : MonoBehaviour
{
    public int messageNumber;
    public SimonSaysTask simonTask;
    public void SimonSendMessage()
    {
        simonTask.ButtonMessage(messageNumber);
    }
}
