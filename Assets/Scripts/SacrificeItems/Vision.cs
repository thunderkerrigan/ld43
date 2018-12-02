using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sacrifice
{
    public class Vision : Sacrifice
    {
        private Coroutine fadingIn;
        public override string GetsacrificeName()
        {
            return "Vision";
        }

        public override string Getdescription()
        {
            return "Now you see me! now you don't!";
        }
        public override void action()
        {
            if (fadingIn == null)
            {
                fadingIn = StartCoroutine(fadeIn());
            }
        }

        private IEnumerator fadeIn()
        {
            float intensity = 0f;
            while (intensity <= 1f)
            {
                //first get the camera then coroutine the shaders to progressively get grayscale; same with directional light.
                GameObject cameraGameObject = GameObject.Find("MainCamera");
                BWEffect cameraEffect = cameraGameObject.GetComponent<BWEffect>();
                Light light = GameObject.FindWithTag("Light").GetComponent<Light>();
                cameraEffect.intensity = intensity;
                light.intensity = 1f - intensity;
                yield return new WaitForSeconds(.2f);
                intensity += .1f;
            }
        }
    }
}