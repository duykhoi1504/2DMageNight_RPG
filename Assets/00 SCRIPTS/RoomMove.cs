using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Vector2 cameraChange;
    [SerializeField] Vector3 playerChange;
    public CameraController cam;
    //transfer place text name
    [SerializeField] bool isNeedText;
    [SerializeField] string placeName;
    [SerializeField] GameObject text;
    [SerializeField] Text placeText;
    void Start()
    {
        cam= Camera.main.GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cam._minPos += cameraChange;
            cam._maxPos += cameraChange;
            other.transform.position += playerChange;

            isNeedText = true;
            if (isNeedText)
            {
                StartCoroutine(placeNameCo());
            }
        }
        
    }
    private IEnumerator placeNameCo()
    {
        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(4f);
        text.SetActive(false);
        isNeedText = false;
    }
}
