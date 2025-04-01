using UnityEngine;
using UnityEngine.Events;

public class Crop : MonoBehaviour
{
    private CropData currentCrop;
    private int plantTime;

    public SpriteRenderer sr;

    public static event UnityAction<CropData> OnPlantCrop;
    public static event UnityAction<CropData> OnHarvestCrop;


    //Returns the time Crop has been planted for
    int CropProgress()
    {
        return GameManager.instance.currentTime - plantTime;
    }

    //Can we harvest the crop?
    public bool CanHarvest()
    {
        return CropProgress() >= currentCrop.timeToGrow;
    }

    //Called when crop is harvested.
    public void Harvest()
    {
        if (CanHarvest())
        {
            OnHarvestCrop?.Invoke(currentCrop);
            Destroy(gameObject);
        }
    }

    //Called when crop has progressed
    public void UpdateCropSprite()
    {
        int cropProg = CropProgress();

        if (CropProgress() < currentCrop.timeToGrow)
        {
            sr.sprite = currentCrop.growProgressSprites[cropProg];
        }
        else
        {
            sr.sprite = currentCrop.readyToHarvestSprite;
        }
    }

    public void Plant(CropData crop)
    {
        currentCrop = crop;
        plantTime = GameManager.instance.currentTime;
        UpdateCropSprite();

        OnPlantCrop?.Invoke(crop);
    }
}
