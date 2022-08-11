/* 
*  __  __   ______   _____    _______ 
* |  \/  | |  ____| |  __ \  |__   __|
* | \  / | | |__    | |__) |    | |   
* | |\/| | |  __|   |  _  /     | |   
* | |  | | | |____  | | \ \     | |   
* |_|  |_| |______| |_|  \_\    |_|   
*                                     
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;

public class DrawerScript : MonoBehaviour, IMixedRealityPointerHandler
{
    private LineRenderer lineRenderer;
    public GameObject drawingPrefab;
    public Material drawingMaterial;
    public Color32 drawingColor;
    public MeshRenderer resultColorMesh;
    public float startWidth = 0.04f;
    public float endWidth = 0.04f;

    public static DrawerScript instance;

    public void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        Material lineMaterial = Instantiate(drawingMaterial);
        lineMaterial.color = drawingColor;
        resultColorMesh.material = lineMaterial; 
    }

    public void OnPointerDragged(MixedRealityPointerEventData eventData)
    {
        FreeDraw(eventData);
    }

    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {
    }

    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {
        AddDrawing();
    }

    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
    }
    void AddDrawing()
    {
        GameObject drawing = Instantiate(drawingPrefab);
        lineRenderer = drawing.GetComponent<LineRenderer>();
        lineRenderer.startWidth = startWidth;
        lineRenderer.endWidth = endWidth;
    }

    void FreeDraw(MixedRealityPointerEventData eventData)
    {
        Material lineMaterial = Instantiate(drawingMaterial);
        lineMaterial.color = drawingColor;
        lineRenderer.material = lineMaterial;
        var handPos = eventData.Pointer.Position;
        Vector3 mousePos = new Vector3(handPos.x, handPos.y, handPos.z);

        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, mousePos);
    }
}