using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamekit2D;

namespace Sacrifice
{
    public class MeleeWeapon : Sacrifice
    {

        public override string GetsacrificeName()
        {
            return "Melee Weapon";
        }

        public override string Getdescription()
        {
            return "You call this a knive? this is a knife!";
        }
        public override void action()
        {
            //TODO
            PlayerInput.Instance.EnableMeleeAttacking();
        }
    }
}