using UnityEngine;
using TMPro;

public class TitlesController : MonoBehaviour
{

    [SerializeField]
    public string[] titles;

    [SerializeField]
    public TMP_Text titleText;

    public Canvas titlesCanvas;

    private int currentTitleIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (titles == null || titles.Length == 0)
        {
            UnityEngine.Debug.LogError("No titles set");
        }
        else if (titleText == null)
        {
            UnityEngine.Debug.LogError("No title mesh set");
        }
        else
        {
            currentTitleIndex = 0;
            titleText.text = titles[currentTitleIndex];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        EventManager.changeGameStateEvent += this.ChangeGameState;
    }

    void OnDisable()
    {
        EventManager.changeGameStateEvent -= this.ChangeGameState;
    }

    void ChangeGameState(GameState nextState)
    {
        switch(nextState)
        {
            case GameState.TitleScreen:
                UnityEngine.Debug.Log(typeof(TitlesController).Name + "Switched to title screen");
                currentTitleIndex = 0;
                titlesCanvas.enabled = true;
                break;
            default:
                UnityEngine.Debug.Log(typeof(TitlesController).Name + "Switched to a state we don't care about");
                break;
        }
    }
}
