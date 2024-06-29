using UnityEngine;

[System.Serializable] 
public class RecipeResults : MonoBehaviour
{
    [SerializeField] private GameObject crystal; 
    [SerializeField] private GameObject magicWand; 
    [SerializeField] private GameObject statue; 

    public GameObject Crystal
    {
        get { return crystal; }
        private set { crystal = value; }
    }

    public GameObject MagicWand
    {
        get { return magicWand; }
        private set { magicWand = value; }
    }

    public GameObject Statue
    {
        get { return statue; }
        private set { statue = value; }
    }

}
