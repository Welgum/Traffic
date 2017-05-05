using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossRoadUI : MonoBehaviour {

    [SerializeField]
    Slider sliderTime;

    [SerializeField]
    Text txtLeft, txtRight;

    [SerializeField]
    Image menu;

    [SerializeField]
    Button submitButton, crossRoadButton;

    [SerializeField]
    CrossRoad crossRoadScript;
	
	void Update () {
        txtLeft.text = (Mathf.RoundToInt(100 * sliderTime.value)).ToString() + "%";
        txtRight.text = (100 - Mathf.RoundToInt(100 * sliderTime.value)).ToString() + "%";

        crossRoadScript.durationFirstMode = 10 * sliderTime.value;
	}

    public void LeftButton()
    {
        sliderTime.value = 0.1f;
        crossRoadScript.durationFirstMode = 10 * sliderTime.value;
        crossRoadScript.Refresh();
    }

    public void RightButton()
    {
        sliderTime.value = 0.9f;
        crossRoadScript.durationFirstMode = 10 * sliderTime.value;
        crossRoadScript.Refresh();
    }

    public void SubmitButton()
    {
        menu.gameObject.SetActive(false);
        submitButton.gameObject.SetActive(false);
        crossRoadButton.gameObject.SetActive(true);
    }

    public void CrossRoadButton()
    {
        menu.gameObject.SetActive(true);
        submitButton.gameObject.SetActive(true);
        crossRoadButton.gameObject.SetActive(false);
    }
}
