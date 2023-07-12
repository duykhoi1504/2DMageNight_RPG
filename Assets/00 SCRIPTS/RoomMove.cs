using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] Vector2 cameraChangeMax;
    [SerializeField] Vector2 cameraChangeMin;
    [SerializeField] Vector3 playerChange;
    public CameraController cam;
    //transfer place text name
    [SerializeField] bool isNeedText;
    [SerializeField] string placeName;
    [SerializeField] GameObject text;
    [SerializeField] Text placeText;
    [SerializeField] string  nameSong;
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
            AudioManager.Instant.PlayMusic(nameSong);
            cam._minPos = cameraChangeMin;
            cam._maxPos = cameraChangeMax;
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
