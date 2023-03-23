using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
public InventorySlot[] inventorySlots;
public GameObject inventoryItemPrefab;
public int maxStack =3;

int selectedSlot = -1;

private void Start() {
    ChangeSelectedSlot(0);
}

private void Update(){
    if(Input.inputString != null){
    bool isNumber = int.TryParse(Input.inputString, out int number);
    if(isNumber && number > 0 && number < 8 )
    ChangeSelectedSlot(number - 1);
    }
}

public void ChangeSelectedSlot(int newValue){
    
    if(selectedSlot >=0)
    inventorySlots[selectedSlot].Deselect();
    
    inventorySlots[newValue].Select();
    selectedSlot = newValue;

}


    public Item GetSelectedItem(bool use){
  InventorySlot slot = inventorySlots[selectedSlot];
  DraggableItem itemToSet = slot.GetComponentInChildren<DraggableItem>();
   if(itemToSet != null)
   {
    Item item = itemToSet.item;
    if(use == true && itemToSet.item.stackable){
        itemToSet.count--;
        if(itemToSet.count <=0)
        Destroy(itemToSet.gameObject);
    
    else{
        itemToSet.RefreshCount();
    }
    return itemToSet.item;
   }}
   
   return null;
    }

public bool AddItem(Item item){

foreach(InventorySlot slot in inventorySlots){
    DraggableItem itemInSlot = slot.GetComponentInChildren<DraggableItem>();
    if(itemInSlot != null && itemInSlot.item == item && itemInSlot.count < maxStack && itemInSlot.item.stackable){
        itemInSlot.count++;
        itemInSlot.RefreshCount();
        return true;
    }


}



foreach(InventorySlot slot in inventorySlots){
    DraggableItem itemInSlot = slot.GetComponentInChildren<DraggableItem>();
    if(itemInSlot == null){
        SpawnNewItem(item,slot);
        return true;
    }

}

return false;

}



void SpawnNewItem(Item item, InventorySlot slot){
GameObject go = Instantiate(inventoryItemPrefab, slot.transform);
DraggableItem inventoryItem = go.GetComponent<DraggableItem>();
inventoryItem.InitialiseItem(item);
}


}
