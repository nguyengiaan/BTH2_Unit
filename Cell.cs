using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cell : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite xsprite;
    public Sprite ysprite;
    private Image Image;
    private Button button; 
    public Board board;
    public int col;
    public int row;
    public GameObject windowobject;
    private Transform canva;
    void Start()
    {
       Image=GetComponent<Image>(); 
        button=GetComponent<Button>();
        button.onClick.AddListener(Onclick);
        board = FindObjectOfType<Board>();
        canva = FindObjectOfType<Canvas>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeImage(string s)
    {
        if (s == "x")
        {
            Image.sprite = xsprite;
        }
        else
        {
            Image.sprite = ysprite;
        }
    }
    public void Onclick()
    {
        
        ChangeImage(board.currenturn);
        if(board.Check(this.row, this.col))
        {
            GameObject window = Instantiate(windowobject,canva);
            window.GetComponent<Checkwin>().Setname(board.currenturn+" Win");
        }

        if (board.currenturn =="x")
        {
            board.currenturn = "o";
        }
        else
        {
            board.currenturn = "x";
        }
    }
}
