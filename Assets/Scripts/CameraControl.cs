using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * 将此script放在相机上面，并将望着的角色放在target_里。
*/
public class CameraControl : MonoBehaviour
{
    private const float Y_ANGLE_MIN = 0.0f;
    private const float Y_ANGLE_MAX = 50.0f;

	[Tooltip("看着的目标，玩家的角色")]
	public Transform Target_;
	[Tooltip("相机距离")]
	public float distance_ = 10.0f;
	[Tooltip("玩家移动速度")]
	public float movingspeed_ = 10.0f;

    private float currentX_ = 0.0f;
    private float currentY_ = 45.0f;

    void Update()
	{ 
		//移动目标
		var right = Input.GetAxis("Horizontal") * transform.right;
		var forward = Input.GetAxis("Vertical") * transform.forward;

		Target_.Translate ((right + forward).normalized * Time.deltaTime * movingspeed_);

		//查看转移的方向
		currentX_ += Input.GetAxis("Mouse X");
		currentY_ += Input.GetAxis("Mouse Y");
		currentY_ = Mathf.Clamp(currentY_, Y_ANGLE_MIN, Y_ANGLE_MAX);

		//计算新的位置
		Vector3 dir = new Vector3(0, 0, -distance_);
		Quaternion rotation = Quaternion.Euler(currentY_, currentX_, 0);

		//相机新的位置
		transform.position = Target_.position + rotation * dir;
		transform.LookAt(Target_.position);
    }
}
