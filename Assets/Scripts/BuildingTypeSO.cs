using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/BuildingType")]
public class BuildingTypeSO : ScriptableObject
{
    public Sprite _sprite;
    public string nameString;
    public GameObject prefab;
    public ResourceGeneratorData resourceGeneratorData;
}
