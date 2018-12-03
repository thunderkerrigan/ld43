using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Gamekit2D;

namespace Sacrifice
{

    public class SacrificeMenuButton : MonoBehaviour
    {

        public Button buttonComponent;
        public Text nameLabel;


        [HideInInspector] private Sacrifice sacrifice;
        [HideInInspector] public GameObject item;

        // Use this for initialization
        void Start()
        {
            buttonComponent.onClick.AddListener(HandleClick);
        }

        public void Setup(GameObject currentSacrifice)
        {
            item = currentSacrifice;
            sacrifice = currentSacrifice.GetComponent<Sacrifice>();
            nameLabel.text = sacrifice.GetsacrificeName();
        }

        public void HandleClick()
        {
            // scrollList.TryTransferItemToOtherShop (item);
			sacrifice.action();
        }
    }
}