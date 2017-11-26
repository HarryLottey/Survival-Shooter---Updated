using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altar : MonoBehaviour
{

    
    public void BlessWeapon(Weapon curWep)
    {
        curWep.blessedWeapon = true;
    }



}
