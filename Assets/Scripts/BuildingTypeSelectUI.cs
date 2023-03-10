using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingTypeSelectUI : MonoBehaviour
{
	private BuildingTypeListSO buildingTypeList;

	private Dictionary<BuildingTypeSO, Transform> buildingTransoformDictionary = new Dictionary<BuildingTypeSO, Transform>();

	private void Awake()
	{
		buildingTypeList = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);

		Transform btnTamplate = transform.Find("btnTemplate");
		btnTamplate.gameObject.SetActive(false);

		int index = 0;
		foreach (BuildingTypeSO buildingType in buildingTypeList.list)
		{
			Transform btnTransform = Instantiate(btnTamplate, transform);
			btnTransform.gameObject.SetActive(true);

			float affsetAmount = 150;
			btnTransform.GetComponent<RectTransform>().anchoredPosition = new Vector3(50 + index * affsetAmount, 50, 0);

			btnTransform.Find("image").GetComponent<Image>().sprite = buildingType._sprite;

			btnTransform.GetComponent<Button>().onClick.AddListener(() =>
			{
				BuildingManager.Instance.SetActiveBuildingType(buildingType);

				UpdataActiveBuildingTypeBtn();
			});

			buildingTransoformDictionary[buildingType] = btnTransform;
			index++;
		}
	}
	private void UpdataActiveBuildingTypeBtn()
	{
		foreach (BuildingTypeSO buildingType in buildingTypeList.list)
		{
			Transform btnTransform = buildingTransoformDictionary[buildingType];
			btnTransform.Find("selected").gameObject.SetActive(false);
		}

		BuildingTypeSO activeBuildingType = BuildingManager.Instance.GetActiveBuildingType();
		if (activeBuildingType == null) return;

		Transform activeBtnTransform = buildingTransoformDictionary[activeBuildingType];

		activeBtnTransform.Find("selected").gameObject.SetActive(true);
	}
}
