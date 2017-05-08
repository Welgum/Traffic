using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

    [SerializeField]
    GameObject car;

    //[SerializeField]
    public float timer; // плотность машин
    float time = 0;

    BankOfColors bankOfColors;

    void Start()
    {
        time += Random.Range(0f, 1f);
        bankOfColors = GameObject.Find("GameManager").GetComponent<BankOfColors>();
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time > timer)
        {
            Vector3 startPos = transform.position;
            startPos.z = car.transform.position.z;
            Instantiate(car, startPos, transform.rotation).GetComponent<SpriteRenderer>().color = bankOfColors.colors[Random.Range(0, bankOfColors.colors.Length)];
            time = Random.Range(0f, 1f);
        }
    }
}
