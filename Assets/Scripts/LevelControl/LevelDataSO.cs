using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "NewLevelData", 
    menuName = "ScriptableObjects/Levels/LevelData", order = 1)]
public class LevelDataSO : ScriptableObject
{
 [SerializeField]public List<EnemiesAttackVector> _enemiesAttackVectors;
    [SerializeField] public GameObject _levelBackground;
    [SerializeField] public float _verticalOffset;


}
