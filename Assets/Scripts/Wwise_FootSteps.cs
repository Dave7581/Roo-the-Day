
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AkGameObj))]
public class XRFootsteps : MonoBehaviour
{
    [Header("Wwise")]
    [SerializeField] private AK.Wwise.Event footstepEvent;

    [Header("Footstep Settings")]
    [SerializeField] private float stepInterval = 0.45f;

    private float stepTimer;

    private void Update()
    {
        Keyboard keyboard = Keyboard.current;
        if (keyboard == null) return;

        bool isMoving =
            keyboard.wKey.isPressed ||
            keyboard.aKey.isPressed ||
            keyboard.sKey.isPressed ||
            keyboard.dKey.isPressed;

        if (isMoving)
        {
            stepTimer -= Time.deltaTime;

            if (stepTimer <= 0f)
            {
                PlayFootstep();
                stepTimer = stepInterval;
            }
        }
        else
        {
            stepTimer = 0f;
        }
    }

    private void PlayFootstep()
    {
        if (footstepEvent != null && footstepEvent.IsValid())
        {
            footstepEvent.Post(gameObject);
        }
    }
}
