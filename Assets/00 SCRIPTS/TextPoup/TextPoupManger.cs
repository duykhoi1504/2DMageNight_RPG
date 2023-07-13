using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class TextPoupManger : ObjectPoolingX<TextPoupManger>
{
    // Start is called before the first frame update
    [SerializeField] GameObject textPoup;

    public void getTextPoup(GameObject parent, float damage, Color color)
    {
        //Instantiate(bullet, this.transform.position, newRotation);
        GameObject g2 = this.GetObject(textPoup);
        g2.GetComponent<TextMesh>().text = "-" + damage.ToString();
        g2.GetComponent<TextMesh>().color = color;
        g2.transform.rotation = parent.transform.rotation;
        g2.transform.position = parent.transform.position;
        g2.transform.localPosition += new Vector3(0f, 1f, 0f);
        g2.SetActive(true);

    }
    public void getTextPoupPositive(GameObject parent, float damage, Color color)
    {
        //Instantiate(bullet, this.transform.position, newRotation);
        GameObject g2 = this.GetObject(textPoup);
        g2.GetComponent<TextMesh>().text = "+" + damage.ToString();
        g2.GetComponent<TextMesh>().color = color;
        g2.transform.rotation = parent.transform.rotation;
        g2.transform.position = parent.transform.position;
        g2.transform.localPosition += new Vector3(0f, 1f, 0f);
        g2.SetActive(true);

    }
}
