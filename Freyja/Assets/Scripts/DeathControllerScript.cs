using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

/// <summary>
/// This class should be pretty self explanatory.
/// </summary>
public class DeathControllerScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI deathText;
    private string[] deathTextArray = new string[] {
        "You are one dead chicken/turkey hybrid thingy!",
        "Lol.. You died..",
        "You just died, how does it feel?"
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
        deathText.text = deathTextArray[Random.Range(0, deathTextArray.Length)];
    }
}
