using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {

    [SerializeField]
    private float maxSpeed;
    private float speed;

    private Transform detecting;
    private bool brake = false;
    private float startOfBrake = 0, endOfBrake = 0;

    void Start()
    {
        speed = maxSpeed;
        detecting = transform.GetChild(0);
    }

	void Update () 
    {
        Drive();
	}

    void Drive()
    {
        brake = false;
        RaycastHit2D hit = Physics2D.Raycast(detecting.position, detecting.position - transform.position);
        if (hit.collider != null)
        {
            Debug.DrawLine(detecting.position, hit.point);
            if (hit.distance < 2f) // magic
            {
                brake = true;
                if (speed <= 0 || hit.distance < 0.00001f)
                {
                    speed = 0;
                }
                else
                {
                    float a = Mathf.Abs(3 * Mathf.Pow(speed, 2) / (2 * hit.distance)); // вывел из кинематического закона движения
                    speed -= 0.01f * a;
                }
            }
        }
        if (!brake && speed < maxSpeed)
        {
            speed += 0.05f; // magic
        }

        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Destroyer")
        {
            Destroy(gameObject);
        }
    }
}
