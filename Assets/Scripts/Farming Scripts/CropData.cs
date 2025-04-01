using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu (fileName = "Crop Data", menuName = "New Crop Data")]
public class CropData : ScriptableObject
{
    public int timeToGrow;
    public Sprite[] growProgressSprites;
    public Sprite[] readyToHarvestSprite;

    public int hungerFilled;

}
