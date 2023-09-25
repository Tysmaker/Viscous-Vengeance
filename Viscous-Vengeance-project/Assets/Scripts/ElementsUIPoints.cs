using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ElementsUIPoints : MonoBehaviour
{
    public int elementScore = 0;

    public TMP_Text text;

    private void Update()
    {
        text.text = elementScore.ToString();
    }
}
