using UnityEngine;
using UnityEngine.UI;

public class Scenario : MonoBehaviour
{
    [SerializeField] private Text messageText;
    [SerializeField] private string[] scenarios;
    [SerializeField] private string sceneNameToLoad;

    private TextWriter textWriter;
    private float timePerCharacters = 0.1f;

    private void Awake()
    {
        textWriter = GetComponent<TextWriter>();
    }

    private void Start()
    {
        textWriter.AddWriter(messageText, scenarios, timePerCharacters, sceneNameToLoad);
    }
}
