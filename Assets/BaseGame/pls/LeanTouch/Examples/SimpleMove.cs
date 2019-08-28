using UnityEngine;

// This script will move the GameObject based on finger gestures
public class SimpleMove : MonoBehaviour
{
    protected virtual void LateUpdate()
    {
        if (bMove)
        {
            // This will move the current transform based on a finger drag gesture
            Lean.LeanTouch.MoveObject(transform, Lean.LeanTouch.DragDelta);
        }
    }

    private bool bMove = false;
    public void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            bMove = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            bMove = false;
        }
        if (Input.GetMouseButtonUp(1))
        {
            bMove = false;
        }

    }

}