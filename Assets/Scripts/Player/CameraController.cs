using UnityEngine;
using Unity.Cinemachine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    [SerializeField] ParticleSystem speedupParticleSystem;
    [SerializeField] float minFOV = 20f;
    [SerializeField] float maxFOV = 20f;
    [SerializeField] float zoomDuration = 1f;
    [SerializeField] float zoomSpeedModify = 5f;

    CinemachineCamera cinemachineCamera;

    void Awake()
    {
        cinemachineCamera = GetComponent<CinemachineCamera>();
    }

    public void ChangeCameraFOV(float speedAmout)
    {
        StopAllCoroutines();
        StartCoroutine(ChangeFOVRoutine(speedAmout));

        if (speedAmout > 0)
        {
            speedupParticleSystem.Play();
        }
    }

    IEnumerator ChangeFOVRoutine(float speedAmout)
    {
        float startFOV = cinemachineCamera.Lens.FieldOfView;
        float targetFOV = Mathf.Clamp(startFOV + speedAmout * zoomSpeedModify, minFOV, maxFOV);

        float elapsedTime = 0f;

        while (elapsedTime < zoomDuration)
        {
            float t = elapsedTime / zoomDuration;
            elapsedTime += Time.deltaTime;

            cinemachineCamera.Lens.FieldOfView = Mathf.Lerp(startFOV, targetFOV, t);
            yield return null;
        }

        cinemachineCamera.Lens.FieldOfView = targetFOV;
    }

}
