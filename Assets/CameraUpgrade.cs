using UnityEngine;
using UnityEngine.Rendering.Universal;


public class CameraUpgrade : MonoBehaviour
{


	public Light2D lightCamera;
	public float   multiplierFactorX = 2;
	public float   multiplierFactorY = 1.5f;
	float          ActualScaleX;
	float          ActualScaleY;
	
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
		lightCamera.pointLightOuterRadius = 14;
		lightCamera.pointLightInnerAngle  = 75;
		lightCamera.pointLightOuterAngle  = 75;




	}


	public void CameraLevel3()
	{
		Transform currentTransform = this.transform;
		currentTransform.localScale = new Vector3(
			ActualScaleX = currentTransform.localScale.x * multiplierFactorX,
			ActualScaleY = currentTransform.localScale.y * multiplierFactorY,
			currentTransform.localScale.z);
		lightCamera.pointLightOuterRadius = 21;
		lightCamera.pointLightInnerAngle  = 47;
		lightCamera.pointLightOuterAngle  = 93;
		Debug.Log("BLBLBLLBL");
		
	}
}