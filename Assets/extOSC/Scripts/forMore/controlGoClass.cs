﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlGoClass : MonoBehaviour
{
    public static controlGoClass instanceGoClass;
    public GameObject manoIzCube;
    public GameObject manoDerCube;
    public GameObject manoIzCubeDown;
    public GameObject manoDerCubeDown;
    public GameObject player;
    public float counter = 0;   //0 a 10 acumulas cajas cuando esta en maximo avanzas, con el tiempo baja

    private Vector3 move;
    // Start is called before the first frame update
    void Awake()
    {
        instanceGoClass = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (counter >= 5) {
            isMoving();
            Debug.Log("move");
        }
        counter -= Time.deltaTime;
        if (counter < 0) {
            counter = 0;
        }
        if (counter > 7) {
            counter = 7;
        }
    }
    void isMoving() {
        //move player
        move = new Vector3(0, 0, 10);
        player.transform.Translate(move);
    }
}
