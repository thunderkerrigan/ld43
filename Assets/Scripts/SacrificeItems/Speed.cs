using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamekit2D;

namespace Sacrifice
{
    public class Speed : Sacrifice
    {
        public Speed()
        {
        }

        public override string GetsacrificeName()
        {
            return "Sacrify your jump for more speed";
        }

        public override string Getdescription()
        {
            return "Now You're a tank baby!";
        }
        public override void action()
        {
            PlayerCharacter.PlayerInstance.jumpSpeed = 10;
            PlayerCharacter.PlayerInstance.maxSpeed = 20;
        }
    }
}