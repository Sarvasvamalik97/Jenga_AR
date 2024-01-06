using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    Vector3 mousePosition;
    [SerializeField] private float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private Vector3 GetMousePosition()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePosition();
        this.GetComponent<Rigidbody>().freezeRotation = true;
    }

    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
        this.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        RotationPrevention.instance.PreventOtherBlocksFromRotating(this.gameObject);
        this.GetComponent<Rigidbody>().freezeRotation = true;
    }

    private void OnMouseUp()
    {
        RotationPrevention.instance.RemoveConstraints();
        this.GetComponent<Rigidbody>().freezeRotation = false;
    }
}