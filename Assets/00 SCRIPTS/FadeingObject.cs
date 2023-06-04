using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FadeingObject : MonoBehaviour
{
    // Start is called before the first frame update
    public float inFade = 0.5f;
    public float outFade = 1f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //this.gameObject.GetComponent<Tilemap>().color = transparency;
            Renderer renderer = GetComponent<Renderer>();

            // Lấy màu hiện tại của vật thể
            Color currentColor = renderer.material.color;

            // Đặt độ trong suốt cho màu hiện tại
            currentColor.a = inFade;

            // Đặt màu mới cho vật thể
            renderer.material.color = currentColor;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //this.gameObject.GetComponent<Tilemap>().color = Color.red;
            Renderer renderer = GetComponent<Renderer>();

            // Lấy màu hiện tại của vật thể
            Color currentColor = renderer.material.color;

            // Đặt độ trong suốt cho màu hiện tại
            currentColor.a = outFade;

            // Đặt màu mới cho vật thể
            renderer.material.color = currentColor;
        }
    }
}
