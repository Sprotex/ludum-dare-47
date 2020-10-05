using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string stepEvent;
    public CharacterController controller;

    private bool isMoving = false;

    private void PlaySound()
    {
        if (!isMoving)
            return;
        var instance = FMODUnity.RuntimeManager.CreateInstance(stepEvent);
        instance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform));
        instance.start();
        instance.release();
    }

    private void Update() => isMoving = controller.isGrounded && controller.velocity.sqrMagnitude > 0.01f;
    private void Start() => InvokeRepeating(nameof(PlaySound), 0f, .5f);
}
