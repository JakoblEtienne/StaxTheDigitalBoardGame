using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highlighting : MonoBehaviour
{
    Color highlight = Color.red;

    Color originalColor;

    MeshRenderer renderer1;

    void Start()
    {
        renderer1 = GetComponent<MeshRenderer>();
        originalColor = renderer1.material.color;
    }

    void OnMouseOver()
    {
        renderer1.material.color = highlight;
        //Debug.Log("Mouse is over GameObject: " + gameObject.transform.name);
    }

    void OnMouseExit()
    {
        renderer1.material.color = originalColor;
        //Debug.Log("Mouse is no longer on GameObject: " + gameObject.transform.name);
    }
}
