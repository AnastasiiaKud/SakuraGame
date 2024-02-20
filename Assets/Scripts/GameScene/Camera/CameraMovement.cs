using UnityEngine;

public class FollowCamera2D : MonoBehaviour
{
    [Header("Following Camera")]
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset = new Vector3(0, 0, -1);
    private float smoothTime = 0.3f;
    [SerializeField] private float fixedYPosition;

    [Header("Camera Zoom")]
    [SerializeField] private float minCameraSize;
    [SerializeField] private float maxCameraSize;
    [SerializeField] private float yThreshold;
    [SerializeField] private float cameraSizeDecrement;

    private Vector3 velocity = Vector3.zero;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    private void FollowCamera()
    {
        var targetPosition = new Vector3(player.position.x + offset.x, fixedYPosition, player.position.z + offset.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        CameraSizeEditY();
    }

    private void CameraSizeEditY()
    {
        if (player.position.y >= yThreshold)
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, minCameraSize, Time.deltaTime * cameraSizeDecrement);
        else
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, maxCameraSize, Time.deltaTime);
    }

    private void LateUpdate()
    {
        FollowCamera();
    }
}