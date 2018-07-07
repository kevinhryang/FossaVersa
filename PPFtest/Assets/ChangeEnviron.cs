using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using System;

public class ChangeEnviron : MonoBehaviour {

    public GameObject[] environs;
    private int index = 0;
    private int max_index;
    public GameObject leftController;
    public GameObject rightController;
    private VRTK_ControllerReference controllerReferenceRight;

    // Use this for initialization
    void Start () {
        rightController.GetComponent<VRTK_ControllerEvents>().GripClicked += new ControllerInteractionEventHandler(rightGripPressed);
        leftController.GetComponent<VRTK_ControllerEvents>().GripClicked += new ControllerInteractionEventHandler(leftGripPressed);

        environs = GameObject.FindGameObjectsWithTag("Environs");
        max_index = environs.Length;
        environs[index].SetActive(true);
        for(int i = index+1; i < max_index; i++)
        {
            environs[i].SetActive(false);
        }
    }

    private void DebugLogger(uint index, string button, string action, ControllerInteractionEventArgs e)
    {
        VRTK_Logger.Info("Controller on index '" + index + "' " + button + " has been " + action
                + " with a pressure of " + e.buttonPressure + " / trackpad axis at: " + e.touchpadAxis + " (" + e.touchpadAngle + " degrees)");
    }

    void rightGripPressed(object sender, ControllerInteractionEventArgs e)
    {
        environs[index].SetActive(false);
        index++;
        if (index > max_index) index = 0;
        environs[index].SetActive(true);
    }

    void leftGripPressed(object sender, ControllerInteractionEventArgs e)
    {
        environs[index].SetActive(false);
        index--;
        if (index < 0) index = max_index;
        environs[index].SetActive(true);
    }
}
