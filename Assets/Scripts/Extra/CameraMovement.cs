using UnityEngine;
public class CameraMovement : MonoBehaviour
{
    private float movingSpeed = 0.2f;


    void LateUpdate()
    {

        transform.localPosition += new Vector3(movingSpeed, 0, 0);
        // transform.position += Vector3.right * Time.deltaTime * movingSpeed;

    }
}
