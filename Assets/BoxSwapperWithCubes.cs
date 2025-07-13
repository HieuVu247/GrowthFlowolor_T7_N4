using UnityEngine;
using UnityEngine.InputSystem;

public class BoxSwapperWithCubes : MonoBehaviour
{
    [Header("Các Cube sẽ bị ẩn và hiện")]
    public GameObject[] cubesToHide;

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
                   
                    foreach (GameObject cube in cubesToHide)
                    {
                        if (!cube.activeSelf)
                            cube.SetActive(true);
                    }

                    if (firstBox == null)
                    {
                        firstBox = clicked;
                        Debug.Log("Chọn box 1: " + firstBox.name);
                    }
                    else if (secondBox == null && clicked != firstBox)
                    {
                        secondBox = clicked;
                        Debug.Log("Chọn box 2: " + secondBox.name);
                        SwapBoxesAndHideCubes();
                    }
                }
            }
        }
    }

    void SwapBoxesAndHideCubes()
    {
        if (firstBox != null && secondBox != null)
        {
            
            Vector3 temp = firstBox.transform.position;
            firstBox.transform.position = secondBox.transform.position;
            secondBox.transform.position = temp;

            Debug.Log("Đã đổi chỗ " + firstBox.name + " và " + secondBox.name);

            
            foreach (GameObject cube in cubesToHide)
            {
                cube.SetActive(false);
            }

            // Reset
            firstBox = null;
            secondBox = null;
        }
    }
}
