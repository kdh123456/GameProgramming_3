using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
	[SerializeField]
	private CinemachineVirtualCamera cinemachineVirtualCamera;

	private float orthographicSize;
	private float targetOrthographicSize;

	private void Awake()
	{
		orthographicSize = cinemachineVirtualCamera.m_Lens.OrthographicSize;
	}

	private void Update()
	{
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");
		Vector3 moveDir = new Vector3(x, y, 0);
		float moveSpeed = 50f;

		float zoomAmount = 2f;
		transform.position += moveDir * moveSpeed * Time.deltaTime;

		targetOrthographicSize += -Input.mouseScrollDelta.y* zoomAmount;

		float minOrthographicSize = 10f;
		float maxOrthographicSize = 30f;

		targetOrthographicSize = Mathf.Clamp(targetOrthographicSize, minOrthographicSize, maxOrthographicSize);

		float zoomSpeed = 5f;
		orthographicSize = Mathf.Lerp(orthographicSize, targetOrthographicSize, Time.deltaTime* zoomSpeed);

		cinemachineVirtualCamera.m_Lens.OrthographicSize = orthographicSize;
	}
}
