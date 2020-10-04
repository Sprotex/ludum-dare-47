using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cameraTransform;
    public float maxMoveSpeed;

    private Vector3 gravityMovement = Vector3.zero;
    private void Update() => Translate();

    private void Translate()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var movementForward = Vector3.Cross(cameraTransform.right, Vector3.up);
        var movementRight = cameraTransform.right;
        var motionVector = movementForward * vertical + movementRight * horizontal;
        if (motionVector.sqrMagnitude > 1f)
            motionVector.Normalize();
        controller.Move(motionVector * maxMoveSpeed * Time.deltaTime);
        if (controller.isGrounded)
            gravityMovement = Vector3.zero;
        else
            gravityMovement += Physics.gravity * Time.deltaTime;
        controller.Move(gravityMovement * Time.deltaTime);
    }
}
