using UnityEngine;
using UnityEngine.UI;

public class TextBehaviour : MonoBehaviour
{
    [SerializeField] Text X, O;
    [SerializeField] Color transparent, normal;
    [SerializeField] PlayerScript playerScript;
    [SerializeField] string xWin, oWin;
    [SerializeField] string playAgain = "Do you want to \nplay again?";
    [SerializeField] string draw = "This is a draw!";


    private void OnEnable()
    {
        EventManagerScript.buttonPressed += ChangePlayer;
        EventManagerScript.victory += EmbraceWinner;
        EventManagerScript.draw += SetDraw;
    }
    private void OnDisable()
    {
        EventManagerScript.buttonPressed -= ChangePlayer;
        EventManagerScript.victory -= EmbraceWinner;
        EventManagerScript.draw -= SetDraw;
    }
    private void Start()
    {
        SetOAsActivePlayer();
    }
    public void ChangePlayer(int x, int y, bool whoIsNow)
    {
        if (!whoIsNow)
        {
            SetOAsActivePlayer();
        }
        else if (whoIsNow)
        {
            SetXAsActivePlayer();
        }
    }
    public void SetXAsActivePlayer()
    {
        O.color = transparent;
        X.color = normal;
    }
    public void SetOAsActivePlayer()
    {
        O.color = normal;
        X.color = transparent;
    }
    private void EmbraceWinner(bool winner)
    {
        if (winner)
        {
            SetOAsActivePlayer();
            SetOAsWinnerText();
        }
        else
        {
            SetXAsActivePlayer();
            SetXAsWinnerText();
        }
    }
    private void SetOAsWinnerText()
    {
        O.text = oWin;
        X.color = normal;
        X.text = playAgain;
    }
    private void SetXAsWinnerText()
    {
        X.text = xWin;
        O.color = normal;
        O.text = playAgain;
    }
    private void SetDraw()
    {
        O.color = normal;
        X.color = normal;
        X.text = draw;
        O.text = playAgain;
    }
}
