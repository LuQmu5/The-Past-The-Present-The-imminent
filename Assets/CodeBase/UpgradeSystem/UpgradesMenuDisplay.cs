using UnityEngine;
using UnityEngine.UI;

public class UpgradesMenuDisplay : MonoBehaviour
{
    [SerializeField] private Image _panel;
    [SerializeField] private Transform _container;
    [SerializeField] private UpgradeDisplay _upgradeDisplayPrefab;
    [SerializeField] private UpgradeData[] _data;

    public void Show()
    {
        _panel.gameObject.SetActive(true);

        foreach (UpgradeData data in _data)
        {
            UpgradeDisplay upgrade = Instantiate(_upgradeDisplayPrefab, _container);
            upgrade.Init(data);
            upgrade.ChooseButtonClicked += OnUpgradeChosen;
        }
    }

    private void OnUpgradeChosen(UpgradeData data)
    {
        foreach (var upgrade in _container.GetComponentsInChildren<UpgradeDisplay>())
        {
            Destroy(upgrade.gameObject);
        }

        _panel.gameObject.SetActive(false);

        print("Chosen: " + data.Header);
    }
}
