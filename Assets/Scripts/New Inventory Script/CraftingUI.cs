using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class CraftingUI : MonoBehaviour
{
    [SerializeField] private CraftingRecipeClass[] craftingRecipes;
    [SerializeField] private GameObject[] recipeCraftingSlots;
    [SerializeField] private GameObject craftingSlotHolder;
    public CraftingRecipeClass craftRecipe;
    [SerializeField] private InventoryManager inventory;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        recipeCraftingSlots = new GameObject[craftingSlotHolder.transform.childCount];
        for (int i = 0; i < recipeCraftingSlots.Length; i++)
        {
            recipeCraftingSlots[i] = craftingSlotHolder.transform.GetChild(i).gameObject;
        }

        DisplayRecipes();

    }

    // Update is called once per frame
    void Update()
    {

    }

   

    public void DisplayRecipes()
    {
        for (int i = 0; i < recipeCraftingSlots.Length; i++)
        {
            try
            {
                //Output Item Name
                recipeCraftingSlots[i].transform.GetChild(5).GetComponent<TextMeshProUGUI>().text = craftingRecipes[i].outputItem.item.itemName.ToString();
                //Output Item Image 
                recipeCraftingSlots[i].transform.GetChild(1).GetChild(0).GetComponent<Image>().enabled = true;
                recipeCraftingSlots[i].transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = craftingRecipes[i].outputItem.item.itemIcon;
                recipeCraftingSlots[i].transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>().text = craftingRecipes[i].outputItem.quantity.ToString();
                //Input Item Image
                //1st Slot
                if (craftingRecipes[i].inputItems1.quantity == 0)
                {
                    recipeCraftingSlots[i].transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Image>().enabled = false;
                    recipeCraftingSlots[i].transform.GetChild(2).GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
                }
                else
                {
                    recipeCraftingSlots[i].transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Image>().enabled = true;
                    recipeCraftingSlots[i].transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Image>().sprite = craftingRecipes[i].inputItems1.item.itemIcon;
                    recipeCraftingSlots[i].transform.GetChild(2).GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = craftingRecipes[i].inputItems1.quantity.ToString();
                }
                //2nd Slot
                if (craftingRecipes[i].inputItems2.quantity == 0)
                {
                    recipeCraftingSlots[i].transform.GetChild(2).GetChild(1).GetChild(0).GetComponent<Image>().enabled = false;
                    recipeCraftingSlots[i].transform.GetChild(2).GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
                }
                else
                {
                    recipeCraftingSlots[i].transform.GetChild(2).GetChild(1).GetChild(0).GetComponent<Image>().enabled = true;
                    recipeCraftingSlots[i].transform.GetChild(2).GetChild(1).GetChild(0).GetComponent<Image>().sprite = craftingRecipes[i].inputItems2.item.itemIcon;
                    recipeCraftingSlots[i].transform.GetChild(2).GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>().text = craftingRecipes[i].inputItems2.quantity.ToString();
                }
                //3rd Slot
                if (craftingRecipes[i].inputItems3.quantity == 0)
                {
                    recipeCraftingSlots[i].transform.GetChild(2).GetChild(2).GetChild(0).GetComponent<Image>().enabled = false;
                    recipeCraftingSlots[i].transform.GetChild(2).GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
                }
                else
                {
                    recipeCraftingSlots[i].transform.GetChild(2).GetChild(2).GetChild(0).GetComponent<Image>().enabled = true;
                    recipeCraftingSlots[i].transform.GetChild(2).GetChild(2).GetChild(0).GetComponent<Image>().sprite = craftingRecipes[i].inputItems3.item.itemIcon;
                    recipeCraftingSlots[i].transform.GetChild(2).GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = craftingRecipes[i].inputItems3.quantity.ToString();
                }

            }
            catch
            {
                //Output Item Name
                recipeCraftingSlots[i].transform.GetChild(5).GetComponent<TextMeshProUGUI>().text = "";
                //Output Item Image
                recipeCraftingSlots[i].transform.GetChild(1).GetChild(0).GetComponent<Image>().enabled = false;
                recipeCraftingSlots[i].transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = null;
                recipeCraftingSlots[i].transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
                //Input Item Image
                //1st Slot
                recipeCraftingSlots[i].transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Image>().enabled = false;
                recipeCraftingSlots[i].transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Image>().sprite = null;
                recipeCraftingSlots[i].transform.GetChild(2).GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
                //2nd Slot
                recipeCraftingSlots[i].transform.GetChild(2).GetChild(1).GetChild(0).GetComponent<Image>().enabled = false;
                recipeCraftingSlots[i].transform.GetChild(2).GetChild(1).GetChild(0).GetComponent<Image>().sprite = null;
                recipeCraftingSlots[i].transform.GetChild(2).GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
                //3rd Slot
                recipeCraftingSlots[i].transform.GetChild(2).GetChild(2).GetChild(0).GetComponent<Image>().enabled = false;
                recipeCraftingSlots[i].transform.GetChild(2).GetChild(2).GetChild(0).GetComponent<Image>().sprite = null;
                recipeCraftingSlots[i].transform.GetChild(2).GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
            }
        }
    }

    public void AddRecipes(CraftingRecipeClass craftingRecipe)
    {

    }

    
}

