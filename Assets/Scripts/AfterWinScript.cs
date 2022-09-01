using UnityEngine;

public class AfterWinScript : MonoBehaviour
{
    [SerializeField] GameObject xSprite, oSprite;
    // If winner is true - O win, false - x win
    // As the event will tell, destroy sprit that belongs to looser, or bouth
    private void OnEnable()
    {
        EventManagerScript.victory += DestoryTheLooser;
        EventManagerScript.draw += DestroyBouthAsDraw;
    }
    private void OnDisable()
    {
        EventManagerScript.victory -= DestoryTheLooser;
        EventManagerScript.draw -= DestroyBouthAsDraw;
    }
    private void DestoryTheLooser(bool winner)
    {
        if (winner)
        {
            Destroy(xSprite);
        }
        else
        {
            Destroy(oSprite);
        }
    }
    private void DestroyBouthAsDraw()
    {
        Destroy(xSprite);
        Destroy(oSprite);
    }

}
