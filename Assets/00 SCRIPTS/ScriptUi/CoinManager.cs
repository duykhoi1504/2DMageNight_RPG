using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text coinText;
    [SerializeField] Inventory _inventory;
    public void Update()
    {
        UpdateCoinCount();
    }
    public void UpdateCoinCount()
    {
        coinText.text = _inventory.coin.ToString();
    }
    
}
