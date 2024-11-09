using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade Data", menuName = "StaticData/Upgrades", order = 54)]
public class UpgradeData : ScriptableObject
{
    [field: SerializeField] public string Header { get; private set; }
    [field: SerializeField] public string Description { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
}