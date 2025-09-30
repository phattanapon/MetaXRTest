using UnityEngine;
using UnityEngine.Events;

public class DoorSensor : MonoBehaviour
{
    public Transform playerTransform;
    public Animator animator;
    public float requiredDistance;

    public UnityEvent doorOpenEvent;
    public UnityEvent doorCloseEvent;

    private bool isDoorOpen;

    private void Start()
    {
        isDoorOpen = false;
    }

    private void Update()
    {
        if (!isDoorOpen && Vector3.Distance(transform.position, playerTransform.position) < requiredDistance)
        {
            Open();
        }
        else if (isDoorOpen && Vector3.Distance(transform.position, playerTransform.position) > requiredDistance)
        {
            Close();
        }
    }

    public void Open()
    {
        animator.Play("Open");
        isDoorOpen = true;
        doorOpenEvent?.Invoke();
    }

    public void Close()
    {
        animator.Play("Close");
        isDoorOpen = false;
        doorCloseEvent?.Invoke();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, requiredDistance);
    }
}
