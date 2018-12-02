using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sacrifice
{

    public interface ISacrifiable
    {
        string GetsacrificeName();

        string Getdescription();
    }

    public abstract class Sacrifice : MonoBehaviour, ISacrifiable
    {
        public abstract string GetsacrificeName();

        public abstract string Getdescription();
        public abstract void action();
    }
}