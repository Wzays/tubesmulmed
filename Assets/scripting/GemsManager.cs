using UnityEngine;
using TMPro;

public class GemsManager : MonoBehaviour
{
    public static GemsManager Instance;

    public int gemscount = 0;
    public TextMeshProUGUI gemsText;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateGemsUI();
    }

   public void AddGem(int amount)
{
    gemscount += amount;
    Debug.Log("Added gem. Total: " + gemscount);
    UpdateGemsUI();
}
    void UpdateGemsUI()
    {
        gemsText.text = gemscount.ToString();
    }
}