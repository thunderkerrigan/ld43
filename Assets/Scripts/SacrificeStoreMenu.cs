using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Sacrifice
{

    public class SacrificeStoreMenu : MonoBehaviour
    {
        public GameObject storePanel;
        public SimpleObjectPool buttonObjectPool;
        private List<SacrificeMenuButton> buttons = new List<SacrificeMenuButton>();
        public List<GameObject> sacrifices = new List<GameObject>();
        private List<GameObject> activeSacrifices = new List<GameObject>();



        void Awake()
        {
            PlayerPrefs.SetInt("reachedCheckpoints", 0);

            foreach (GameObject item in sacrifices)
            {
                GameObject sacrificeGameObject = GameObject.Instantiate(item);
                activeSacrifices.Add(sacrificeGameObject);
            }
        }
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void showMenu()
        {
            storePanel.SetActive(true);
            int checkpoint = PlayerPrefs.GetInt("reachedCheckpoints", 0);
            createMenu(checkpoint);
        }

        public void hideMenu()
        {
            storePanel.SetActive(false);


        }

        void createMenu(int checkpoint)
        {
            int index = 0;
            while (index < checkpoint)
            {
                SacrificeMenuButton existingButton = buttons.FindLast(button => button.item == activeSacrifices[index]);
                if (existingButton == null)
                {
                    GameObject sacrificeGameObject = activeSacrifices[index];
                    GameObject newButton = buttonObjectPool.GetObject();
                    newButton.transform.SetParent(storePanel.transform, false);
                    Vector3 newPosition = newButton.transform.position + (Vector3.up/5 * index);
                    newButton.transform.SetPositionAndRotation(newPosition, Quaternion.identity);
                    SacrificeMenuButton sacrificeMenuButton = newButton.GetComponent<SacrificeMenuButton>();
                    buttons.Add(sacrificeMenuButton);
                    sacrificeMenuButton.Setup(sacrificeGameObject);
                }
                index++;
            }
        }


    }
}