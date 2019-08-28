using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraExample : MonoBehaviour {

    public float speed;

    private float currentSpeed;
    private Vector3 curPosition;

	void Start () {

        curPosition = transform.position;
	}
    bool movebool = false;
    float oldy = 0;

    void Update () {
        if (1 == 2) {
            if (Input.GetMouseButton(0))
            {
                if (!movebool)
                {
                    oldy = Input.mousePosition.y;
                    Vector3 tarPos = Input.mousePosition;
                    Vector3 objPos = Camera.main.WorldToScreenPoint(transform.position);
                    movebool = true;
                    Debug.Log("GetMouseButton=");
                }
            }

            if (Input.GetMouseButtonUp(0))
        {
            movebool = false;
        }
        if (movebool)
        {
            transform.position = transform.position - new Vector3(0, (Input.mousePosition.y - oldy)/100, 0);
            Debug.Log("Input.mousePosition.y-oldy=" + (Input.mousePosition.y - oldy));
            oldy = Input.mousePosition.y;
        }
        }

        if (1 == 1)
        {
            Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));


            Debug.Log("move=" + move);
            currentSpeed = speed;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                currentSpeed *= 1.5f;
            }
            curPosition += move.normalized * currentSpeed * Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, curPosition, 5 * Time.deltaTime);
        }
	}
}
