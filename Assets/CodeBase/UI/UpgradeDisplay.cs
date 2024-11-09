using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UpgradeDisplay : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _header;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private Button _chooseButton;

    private UpgradeData _data;

    public event Action<UpgradeData> ChooseButtonClicked;

    public void Init(UpgradeData data)
    {
        _data = data;

        _icon.sprite = _data.Icon;
        _header.text = _data.Header;
        _description.text = _data.Description;

        _chooseButton.onClick.AddListener(OnChooseButtonClicked);
    }

    private void OnDestroy()
    {
        _chooseButton.onClick.RemoveListener(OnChooseButtonClicked);
    }

    private void OnChooseButtonClicked()
    {
        ChooseButtonClicked?.Invoke(_data);
    }
}
