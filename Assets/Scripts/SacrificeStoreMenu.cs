using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SacrificeStoreMenu : MonoBehaviour
{
    public GameObject storePanel;
    public SimpleObjectPool buttonObjectPool;

    private List<SacrificeMenuButton> buttons = new List<SacrificeMenuButton>();
    // private List<Power> = [];

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
int checkpoint = PlayerPrefs.GetInt("reachedCheckpoints", 1);
createMenu(checkpoint);
    }

    public void hideMenu()
    {
        storePanel.SetActive(false);
        

    }

    void createMenu(int checkpoint)
    {
        if (checkpoint > buttons.Count)
        {
            GameObject newButton = buttonObjectPool.GetObject();
            newButton.transform.SetParent(storePanel.transform);
            newButton.transform.localScale = storePanel.transform.localScale;
            newButton.transform.localPosition = new Vector3(0, 0, 0);
           // newButton.transform.SetPositionAndRotation(new Vector3(0,0,0), Quaternion.identity);
            Sacrifice sacrifice = new Speed();
            SacrificeMenuButton sacrificeMenuButton = newButton.GetComponent<SacrificeMenuButton>();
            buttons.Add(sacrificeMenuButton);
            sacrificeMenuButton.Setup(sacrifice);
        }
    }


}
