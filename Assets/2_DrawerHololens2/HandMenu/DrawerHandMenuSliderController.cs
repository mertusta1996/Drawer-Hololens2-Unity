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

public class DrawerHandMenuSliderController : MonoBehaviour
{
    public void ApplySliderChange(DrawerHandMenuSlider slider)
    {
        var drawing = DrawerScript.instance;
        var drawingColor = drawing.drawingColor;
        var maxValueChange = slider.MRTKPinchSliderElement.parameterValues.maxValue - slider.MRTKPinchSliderElement.parameterValues.minValue;
        switch (slider.MRTKPinchSliderElement.colorOperationEnum)
        {
            case DrawerHandMenuSlider.colorEnum.red:
                drawing.drawingColor = new Color(ApplyNewValues(slider)/ maxValueChange, drawingColor.g/ maxValueChange, drawingColor.b / maxValueChange);
                break;
            case DrawerHandMenuSlider.colorEnum.green:
                drawing.drawingColor = new Color(drawingColor.r / maxValueChange, ApplyNewValues(slider) / maxValueChange, drawingColor.b / maxValueChange);
                break;
            case DrawerHandMenuSlider.colorEnum.blue:
                drawing.drawingColor = new Color(drawingColor.r / maxValueChange, drawingColor.g / maxValueChange, ApplyNewValues(slider) / maxValueChange);
                break;
            case DrawerHandMenuSlider.colorEnum.startWidth:
                drawing.startWidth = ApplyNewValues(slider);
                break;
            case DrawerHandMenuSlider.colorEnum.endWidth:
                drawing.endWidth = ApplyNewValues(slider);
                break;
        }

        DrawerScript.instance.resultColorMesh.material.color = DrawerScript.instance.drawingColor;
    }

    public float ApplyNewValues(DrawerHandMenuSlider slider)
    {
        var parameter = slider.MRTKPinchSliderElement.parameterValues;
        parameter.actualValue = parameter.minValue + (slider.MRTKPinchSliderElement.slider.SliderValue * (parameter.maxValue - parameter.minValue));

        var actualValue = parameter.actualValue;
        return actualValue;
    }
}
