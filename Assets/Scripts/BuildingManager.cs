using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager Instance { get; private set; }

    private BuildingTypeListSO buildingTypeList;

    private BuildingTypeSO activeBuildingType;

    private Camera mainCam;

    private void Start()
    {
        Instance = this;
        mainCam = Camera.main;
        buildingTypeList = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);
        activeBuildingType = buildingTypeList.list[0];
    }


    private void Update()
    {

		if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
		{
			CreateBuiling();
		}
	}

    private void CreateBuiling()
    {
        GameObject building = Instantiate(activeBuildingType.prefab);
        building.transform.position = GetMouseWorldPosition();
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        return mousePos;
    }

    public void SetActiveBuildingType(BuildingTypeSO buildingType)
    {
        activeBuildingType = buildingType;
	}

    public BuildingTypeSO GetActiveBuildingType()
    {
        return activeBuildingType;
    }
}
