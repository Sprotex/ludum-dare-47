using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cameraTransform;
    public float maxMoveSpeed;

    private void Update()
    {
        Translate();
        Rotate();
    }

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
    }

    private void Rotate()
    {
        
    }
}
