using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentTime;
    public int hunger;
    public CropData selectedCropToPlant;

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    //Called when a crop is planted
    //Listening to the Crop.onPlantCrop event.
    public void OnPlantCrop(CropData crop)
    {

    }

    //Called when a crop has been harvested.
    //Listening to the Crop.onCropHarvest event.
    public void OnHarvestCrop(CropData crop)
    {

    }

    //Do we have enough seeds to plant?
   /* public bool CanPlantCrop()
    {

    }    
   */

}
