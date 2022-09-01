using UnityEngine;

public class ImageBehaviour : MonoBehaviour
{
    [SerializeField] SpriteRenderer X, O;
    [SerializeField] Color transparent, normal;
    [SerializeField] PlayerScript playerScript;

    private void OnEnable()
    {
        EventManagerScript.buttonPressed += ChangePlayer;
        EventManagerScript.victory += EmbraceWinner;
    }
    private void OnDisable()
    {
        EventManagerScript.buttonPressed -= ChangePlayer;
        EventManagerScript.victory -= EmbraceWinner;
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
        else
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
        }
        else 
        {
            SetXAsActivePlayer();
        }
    }

}
