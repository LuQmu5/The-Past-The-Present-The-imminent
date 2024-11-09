using TMPro;
using UnityEngine;
using Zenject;

public class LevelProgressDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private int _killedEnemies = 0;
    private int _enemiesOnLevel;

    [Inject]
    public void Construct(LevelCompleteHandler levelCompleteHandler)
    {
        _enemiesOnLevel = levelCompleteHandler.EnemiesOnLevel;
        _text.text = $"{_killedEnemies}/{_enemiesOnLevel}";

        Enemy.Died += OnEnemyDied;
    }

    private void OnEnemyDied()
    {
        _killedEnemies++;

        _text.text = $"{_killedEnemies}/{_enemiesOnLevel}";
    }
}