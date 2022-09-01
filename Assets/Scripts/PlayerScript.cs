using UnityEngine;
public class PlayerScript : MonoBehaviour
{
    // If isNow = true - the turn belongs to nought (O), if false - to X
    private static bool isNowO;

    private void OnEnable()
    {
        EventManagerScript.buttonPressed += ChangePlayer;
    }
    private void OnDisable()
    {
        EventManagerScript.buttonPressed -= ChangePlayer;
    }

    private void Start()
    {
        isNowO = true;
    }

    //Those variables are from event, but won't be used in this function
    private void ChangePlayer(int x, int y, bool whoIsNow)
    {
        isNowO = !isNowO;
    }
    public bool GetWhoIsNow()
    {
        return isNowO;
    } //Let world know!

}

