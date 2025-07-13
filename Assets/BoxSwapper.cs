using UnityEngine;
using UnityEngine.InputSystem;

public class BoxSwapper : MonoBehaviour
{
    private GameObject firstBox;
    private GameObject secondBox;

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject clicked = hit.collider.gameObject;
                if (clicked.CompareTag("Box"))
                {
                    if (firstBox == null)
                    {
                        firstBox = clicked;
                        Debug.Log("Selected first box: " + firstBox.name);
                    }
                    else if (secondBox == null && clicked != firstBox)
                    {
                        secondBox = clicked;
                        Debug.Log("Selected second box: " + secondBox.name);
                        SwapBoxes();
                    }
                }
            }
        }
    }

    void SwapBoxes()
    {
        if (firstBox != null && secondBox != null)
        {
            Vector3 temp = firstBox.transform.position;
            firstBox.transform.position = secondBox.transform.position;
            secondBox.transform.position = temp;
        }

        firstBox = null;
        secondBox = null;
    }
}
