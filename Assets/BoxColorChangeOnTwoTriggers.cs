using UnityEngine;
using System.Collections.Generic;

public class BoxChangeColorOnTwoTriggers : MonoBehaviour
{
    [Header("Cần chạm đồng thời 2 tag này")]
    public string tag1 = "trigger1";
    public string tag2 = "trigger2";

    [Header("Màu đặc biệt khi đủ 2 tag")]
    public Color specialColor = Color.yellow;

    private HashSet<string> tagsInContact = new HashSet<string>();
    private Color originalColor;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        if (rend != null)
        {
            originalColor = rend.material.color;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tag1) || other.CompareTag(tag2))
        {
            tagsInContact.Add(other.tag);
            UpdateColor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (tagsInContact.Contains(other.tag))
        {
            tagsInContact.Remove(other.tag);
            UpdateColor(); // Kiểm tra lại sau khi rời
        }
    }

    void UpdateColor()
    {
        if (tagsInContact.Contains(tag1) && tagsInContact.Contains(tag2))
        {
            // Đổi sang màu đặc biệt
            rend.material.color = specialColor;
            Debug.Log("→ Đổi sang màu đặc biệt vì đang chạm cả 2 tag.");
        }
        else
        {
            // Trở lại màu gốc
            rend.material.color = originalColor;
            Debug.Log("→ Trở về màu gốc vì không còn đủ 2 tag.");
        }
    }
}
