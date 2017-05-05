using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossRoad : MonoBehaviour {

    [SerializeField]
    Collider2D[] stopLines;

    [SerializeField]
    float fullCycleTimer;
    float fullCycleTime = 0;

    public float durationFirstMode;

    [SerializeField]
    private float durationBreak;

	void Start () {
        durationFirstMode = fullCycleTimer / 2;
	}
	
	void Update () {
        TrafficLight();
	}

    public void Refresh()
    {
        fullCycleTime = 0;
    }

    void TrafficLight()
    {
        fullCycleTime += Time.deltaTime;
        if (fullCycleTime > fullCycleTimer)
        {
            fullCycleTime = 0;
        }

        for (int i = 0; i < stopLines.Length; i++)
        {
            stopLines[i].enabled = true;
        }

        if (fullCycleTime < durationFirstMode - durationBreak / 2)
        {
            stopLines[0].enabled = false;
            stopLines[1].enabled = false;
        }
        if (fullCycleTime > durationFirstMode + durationBreak / 2)
        {
            stopLines[2].enabled = false;
            stopLines[3].enabled = false;
        }
    }
}
