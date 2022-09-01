public class EventManagerScript 
{

    public delegate void PlayerHasPressButton(int x, int y, bool whoIsNow);
    public static event PlayerHasPressButton buttonPressed;

    public static void PlayerPressButtonFunction(int x, int y, bool whoIsNow)
    {
        buttonPressed?.Invoke(x,y,whoIsNow);
    }

    public delegate void WeHaveWinner(bool winner);
    public static event WeHaveWinner victory;

    public static void GetWinner(bool winner)
    {
        victory?.Invoke(winner);
    }

    public delegate void WeHaveDraw();
    public static event WeHaveDraw draw;
    public static void SetDraw() => draw?.Invoke();


}
