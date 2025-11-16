using UnityEngine;
using UnityEngine.Rendering.Universal;


public class CameraUpgrade : MonoBehaviour
{


	public Light2D lightCamera;
	public float   multiplierFactorX = 1.4f;
	public float   multiplierFactorY = 1.5f;
  
	float ActualScaleX;
	float ActualScaleY;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		Transform currentTransform = this.transform;




      
         
	}
	public void CameraLevel1()
	{
		Transform currentTransform = this.transform;
		currentTransform.localScale = new Vector3(
			ActualScaleX = currentTransform.localScale.x * multiplierFactorX,
			ActualScaleY = currentTransform.localScale.y * multiplierFactorY,
			currentTransform.localScale.z);
		lightCamera.pointLightOuterRadius = 15;
		lightCamera.pointLightOuterAngle  = 83;




	}


	public void CameraLevel3()
	{
		Transform currentTransform = this.transform;
		currentTransform.localScale = new Vector3(
			ActualScaleX = currentTransform.localScale.x * multiplierFactorX,
			ActualScaleY = currentTransform.localScale.y * multiplierFactorY,
			currentTransform.localScale.z);
		lightCamera.pointLightOuterRadius = 18;
		lightCamera.pointLightOuterAngle  = 84;
	}
}