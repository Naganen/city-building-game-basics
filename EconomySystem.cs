using UnityEngine;

public class EconomySystem : MonoBehaviour
{
    public int[] currencies; // Currency types declared with integers

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddCurrency(int currency, int amount)
    {
        currencies[currency] += amount;
    }

    public void RemoveCurrency(int currency, int amount)
    {
        currencies[currency] -= amount;
    }

    public int GetCurrency(int currency)
    {
        return currencies[currency];
    }
}
