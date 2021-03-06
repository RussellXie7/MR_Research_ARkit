﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class HideBearMesh : MonoBehaviour, IInputClickHandler{

    public GameObject BearToHide;

    private GameObject myBear;
    private List<MeshRenderer> bearMeshes;
    private Color myColor;

    private bool isShow;

    // Use this for initialization
    void Start () {
        myBear = BearToHide;
        bearMeshes = new List<MeshRenderer>();
        isShow = true;

        foreach(MeshRenderer mr in myBear.GetComponentsInChildren<MeshRenderer>(true))
        {
            if (mr.gameObject.tag != "InnerStructure")
            {
                bearMeshes.Add(mr);
            }
        }

        myColor = transform.GetComponent<MeshRenderer>().material.color;
	}


    public void OnInputClicked(InputClickedEventData eventData)
    {
        ToggleBearMesh();
    }

    public void ToggleBearMesh()
    {
        if (isShow)
        {
            foreach(MeshRenderer mr in bearMeshes)
            {
                mr.enabled = false;
            }

            isShow = false;
            transform.GetComponent<MeshRenderer>().material.color = Color.cyan;
        }
        else
        {
            foreach (MeshRenderer mr in bearMeshes)
            {
                mr.enabled = true;
            }

            isShow = true;
            transform.GetComponent<MeshRenderer>().material.color = myColor;
        }
    }

}
