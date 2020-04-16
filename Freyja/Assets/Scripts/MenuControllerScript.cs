using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

/// <summary>
/// Everything in this class should be self explanatory.
/// </summary>
public class MenuControllerScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI randomMenuText;
    private string[] menuTextArray = new string[] {
        "Let's have a quack of a time!",
        "To quack, or not to quack.. that is the... quack",
        "Quack me maybe?"
    };

    // Start is called before the first frame update
    void Awake()
    {
        SetDeathText();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadNewGame()
    {
        SceneManager.LoadScene("Game");
    }

    private void SetDeathText()
    {
        randomMenuText.text = menuTextArray[Random.Range(0, menuTextArray.Length)];
    }
}