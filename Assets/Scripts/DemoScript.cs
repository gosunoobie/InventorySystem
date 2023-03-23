using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoScript : MonoBehaviour
{
public InventoryManager inventoryManager;
public Item[] itemsToPickUp;

public void PickupItem(int id){
   bool success =  inventoryManager.AddItem(itemsToPickUp[id]);
   Debug.Log(success);
if(success)
Debug.Log("Item Added");
else
Debug.Log("Inventory full. Item Not Added");

}

public void GetSelectedItem(){
   Item recievedItem = inventoryManager.GetSelectedItem(false);
   if(recievedItem != null)
   {
      Debug.Log("Received Item : " + recievedItem);
   }
   else{
      Debug.Log("No item recieved");
   }
}

public void UseSelectedItem(){
   Item recievedItem = inventoryManager.GetSelectedItem(true);
   if(recievedItem != null)
   {
      Debug.Log("Received Item : " + recievedItem);
   }
   else{
      Debug.Log("No item recieved");
   }
}
}
