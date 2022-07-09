using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tama Stats", menuName = "ScriptableObjects/Tama", order = 1)]
public class TamaStats : ScriptableObject
{
    [Header("Sociablity")]
    public string[] sociability;

    [Header("Friendliness")]
    public string[] friendliness;

    [Header("Hygeine")]
    public string[] hygeine;

    [Header("Likes/Dislikes")]
    public string[] likesDislikes;
}
