using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossRoad : MonoBehaviour {

    [SerializeField]
    GameObject stopLine;
    
    [SerializeField]
    Transform asphalt1, asphalt2;

    [SerializeField]
    int numOfStrokes1, numOfStrokes2;

    [SerializeField]
    float stopLineOffset;

    Collider2D[] stopLines1, stopLines2;

    [SerializeField]
    float fullCycleTimer;
    float fullCycleTime = 0;

    public float durationFirstMode;

    [SerializeField]
    private float durationBreak;

	void Start () {
        asphalt1.localScale = new Vector3((numOfStrokes2 + stopLineOffset) * 2 - 0.2f, numOfStrokes1 * 2, 1);
        asphalt2.localScale = new Vector3(numOfStrokes2 * 2, (numOfStrokes1 + stopLineOffset) * 2 - 0.2f, 1);

        stopLines1 = CreateStopLines(1, numOfStrokes1);
        stopLines2 = CreateStopLines(-1, numOfStrokes2);

        durationFirstMode = fullCycleTimer / 2;
	}
	
	void Update () {
        TrafficLight();
	}


    Collider2D[] CreateStopLines(int dir, int count)
    {
        Collider2D[] ans = new Collider2D[count * 2];
        for (int i = 0; i < count * 2; i++)
        {
            Transform newStopLine = Instantiate(stopLine, transform).GetComponent<Transform>();
            newStopLine.rotation = transform.rotation;
            newStopLine.position = transform.position;
            if (dir == -1)
            {
                newStopLine.Rotate(Vector3.forward, 90);
            }

            float offsetZ = 1;
            float offserX;
            if (count == numOfStrokes1)
            {
                offserX = numOfStrokes2 + stopLineOffset;
            }
            else
            {
                offserX = numOfStrokes1 + stopLineOffset;
            }
            
            newStopLine.Translate(offserX, (0.5f + i), offsetZ);
            if (i >= count)
            {
                newStopLine.Translate(-offserX * 2, -(0.5f + i) * 2 + count, 0);
            }
            newStopLine.gameObject.name = " "+i;
            ans[i] = newStopLine.gameObject.GetComponent<Collider2D>();
        }
        return ans;
    }


    void SwitcherOfStopLines(bool mode, ref Collider2D[] stopLines)
    {
        for (int i = 0; i < stopLines.Length; i++)
        {
            stopLines[i].enabled = mode;
        }
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

        SwitcherOfStopLines(true, ref stopLines1);
        SwitcherOfStopLines(true, ref stopLines2);

        // += желтый цвет
        if (fullCycleTime < durationFirstMode - durationBreak / 2 && fullCycleTime > durationBreak / 2)
        {
            SwitcherOfStopLines(false, ref stopLines1);
        }
        if (fullCycleTime > durationFirstMode + durationBreak / 2 && fullCycleTime < fullCycleTimer - durationBreak / 2)
        {
            SwitcherOfStopLines(false, ref stopLines2);
        }
    }
}
