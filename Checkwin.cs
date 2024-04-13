using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Checkwin : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;

    public Button button;
    private void Awake()
    {
        button.onClick.AddListener(Reset);
    }
    public void Setname(string s)
    {
        text.text = s;
    }
    public void Reset()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
