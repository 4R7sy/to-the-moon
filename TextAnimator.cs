using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextAnimator : MonoBehaviour
{

    public TextMeshProUGUI textcollider;
    bool isVisible = false;
    // Start is called before the first frame update
    void Start()
    {
        textcollider.gameObject.SetActive(isVisible);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            isVisible = !isVisible;
            textcollider.gameObject.SetActive(isVisible);
        }
    }
}
