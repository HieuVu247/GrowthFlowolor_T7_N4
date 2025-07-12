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

                // Nếu click vào box (tag = "Box")
                if (clicked.CompareTag("Box"))
                {
                    // Mỗi khi click vào 1 box, hiện lại các cube nếu đang bị ẩn
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
            // Đổi vị trí của 2 box
            Vector3 temp = firstBox.transform.position;
            firstBox.transform.position = secondBox.transform.position;
            secondBox.transform.position = temp;

            Debug.Log("Đã đổi chỗ " + firstBox.name + " và " + secondBox.name);

            // Ẩn các cube được chỉ định
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
