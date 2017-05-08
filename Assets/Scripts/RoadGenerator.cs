using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour {

    [SerializeField]
    GameObject road;
    [SerializeField]
    GameObject stroke;

    public float speedOfGeneration;

    [SerializeField]
    int numOfRoads1, numOfRoads2;

    void CreateRoadStroke(int dir, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Transform newRoad = Instantiate(road, transform).GetComponent<Transform>();
            newRoad.rotation = transform.rotation;
            newRoad.position = transform.position;
            if(dir == -1)
            {
                newRoad.Rotate(Vector3.forward,180);
            }
            float offsetZ = 1;
            newRoad.Translate(0, -(0.5f + i), offsetZ);
            if (i != count - 1)
            {
                Transform newStroke = Instantiate(stroke, transform).GetComponent<Transform>();
                newStroke.rotation = transform.rotation;
                newStroke.position = transform.position;
                newStroke.Translate(0, -dir * (i + 1), 0);
            }

            newRoad.gameObject.GetComponentInChildren<Generator>().timer = speedOfGeneration;
        }
    }

	void Start () {
        CreateRoadStroke(1, numOfRoads1);
        CreateRoadStroke(-1, numOfRoads2);
	}
}
