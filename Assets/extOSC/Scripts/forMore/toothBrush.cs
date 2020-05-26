﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class toothBrush : MonoBehaviour
{

    enum action_brush {UP,DOWN,LEFT,RIGHT };

    action_brush making_x= action_brush.UP;
    action_brush making_y = action_brush.LEFT;
    bool im_in = false;
    float total;
    float axis_x = 0.0f;
    float axis_y = 0.0f;
    public float ponderation_time=1.0f;

    public Text counterText;

    // Start is called before the first frame update
    void Start()
    {
        total = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        reloadFinish();
        changeText();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Soy tag in" + other.tag);
        if (other.gameObject.CompareTag("mouth"))
        {
            im_in = true;
            axis_x= GetComponentInParent<Transform>().position.x;
            axis_y = GetComponentInParent<Transform>().position.y;
        }

    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Soy tag out" + other.tag);
        if (other.gameObject.CompareTag("mouth"))
        {

            im_in = false;
        }

    }


    void reloadFinish() {

        if (im_in) {
            Transform temp = GetComponentInParent<Transform>();
            float x_temp =axis_x- temp.position.x;
            if (x_temp > 0 && making_x == action_brush.DOWN) {
                total += Mathf.Abs(x_temp)* ponderation_time;
                axis_x = temp.position.x;
                making_x = action_brush.UP;
            } else if (x_temp < 0 && making_x == action_brush.UP) {

                total += Mathf.Abs(x_temp)* ponderation_time; ;
                axis_x = temp.position.x;
                making_x = action_brush.DOWN;
            }


            float y_temp = axis_y - temp.position.y;

            if (y_temp > 0 && making_y == action_brush.LEFT)
            {
                total += Mathf.Abs(y_temp)* ponderation_time;
                axis_y = temp.position.y;
                making_y = action_brush.RIGHT;
            }
            else if (y_temp < 0 && making_y == action_brush.RIGHT)
            {

                total += Mathf.Abs(y_temp)* ponderation_time;
                axis_y = temp.position.y;
                making_y = action_brush.LEFT;
            }

           

        }

    }


    void changeText() {

        if (total < 0.1)
        {
            counterText.text = "0 %";
        } else if (total >100.0) {
            counterText.text = "Limpios !";
        }
        else
        {
            counterText.text = total.ToString() + " %";
        }


    }


}
