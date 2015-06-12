using Windows.Devices.Bluetooth.Advertisement;

namespace GameJam2015MonoGame
{
    public interface IContentLoader
    {
        T LoadContent<T>(string assetPath);
    }
}