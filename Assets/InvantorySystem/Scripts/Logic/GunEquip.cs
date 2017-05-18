using UnityEngine;

public class GunEquip : RuntimeEquipLogic
{
	public override void Equip (GameObject item)
	{
		//Debug.Log ("Enabling gun script on " + item);
		item.GetComponent<Gun> ().enabled = true;
	}
}
