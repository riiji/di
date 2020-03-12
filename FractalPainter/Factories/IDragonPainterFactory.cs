using FractalPainting.App.Fractals;

namespace FractalPainting.Factories
{
    public interface IDragonPainterFactory
    {
        DragonPainter CreateDragonPainter(DragonSettings settings);
    }
}