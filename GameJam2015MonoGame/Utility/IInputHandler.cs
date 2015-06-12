namespace GameJam2015MonoGame.Utility
{
    public interface IInputHandler
    {
        bool JumpPressed{ get; set; }
        bool LeftPressed { get; set; }
        bool RightPressed { get; set; }
    }
}