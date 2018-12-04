using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamekit2D;


namespace Sacrifice
{
    public class DistanceWeapon : Sacrifice
    {

        public override string GetsacrificeName()
        {
            return "Distance Weapon";
        }

        public override string Getdescription()
        {
            return "Lock and loaded!";
        }
        public override void action()
        {
            //TODO
            PlayerInput.Instance.EnableRangedAttacking();
        }
    }
}