using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ElementsUIPoints : MonoBehaviour
{
    public int FireCharges;
    public int WindCharges;
    public int LightningCharges;
    public int EarthCharges;

    TextMeshProUGUI Fire;
    TextMeshProUGUI Wind;
    TextMeshProUGUI Lightning;
    TextMeshProUGUI Earth;

    private void Start()
    {
        FireCharges = 0;
        WindCharges = 0;
        LightningCharges = 0;
        EarthCharges = 0;

        Fire = GameObject.Find("FireText").GetComponent<TextMeshProUGUI>();
        Wind = GameObject.Find("WindText").GetComponent<TextMeshProUGUI>();
        Lightning = GameObject.Find("LightningText").GetComponent<TextMeshProUGUI>();
        Earth = GameObject.Find("EarthText").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        Fire.text = FireCharges.ToString();
        Wind.text = WindCharges.ToString();
        Lightning.text = LightningCharges.ToString();
        Earth.text = EarthCharges.ToString();
    }
}
