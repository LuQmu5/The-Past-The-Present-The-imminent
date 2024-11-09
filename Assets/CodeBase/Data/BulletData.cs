using UnityEngine;

[CreateAssetMenu(fileName = "Bullet Data", menuName = "StaticData/Bullets", order = 54)]
public class BulletData : ScriptableObject
{
    [field: SerializeField] public Bullet Prefab { get; private set; }
    [field: SerializeField] public BulletTypes Type { get; private set; }
}