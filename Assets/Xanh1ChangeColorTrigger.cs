using UnityEngine;

public class BoxColorChanger : MonoBehaviour
{
    // Danh sách các tag màu mà box có thể va chạm
    [Header("Tag màu hợp lệ (phải có Renderer)")]
    public string[] colorTags = { "red", "blue", "green", "yellow", "purple" };

    private void OnTriggerEnter(Collider other)
    {
        foreach (string tag in colorTags)
        {
            if (other.CompareTag(tag))
            {
                Renderer selfRenderer = GetComponent<Renderer>();
                Renderer otherRenderer = other.GetComponent<Renderer>();

                if (selfRenderer != null && otherRenderer != null)
                {
                    // Đổi màu của box thành màu của vật chạm vào
                    selfRenderer.material.color = otherRenderer.material.color;
                    Debug.Log($"{gameObject.name} đã đổi màu theo {tag}");
                }

                break; // Đã match tag thì thoát khỏi vòng lặp
            }
        }
    }
}
