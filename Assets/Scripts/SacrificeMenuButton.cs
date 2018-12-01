using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SacrificeMenuButton : MonoBehaviour {
    
    public Button buttonComponent;
    public Text nameLabel;
    
    private Sacrifice item;
    
    // Use this for initialization
    void Start () 
    {
        buttonComponent.onClick.AddListener (HandleClick);
    }
    
    public void Setup(Sacrifice currentSacrifice)
    {
        item = currentSacrifice;
        nameLabel.text = currentSacrifice.name;
        
    }
    
    public void HandleClick()
    {
        // scrollList.TryTransferItemToOtherShop (item);
    }
}