using System;
using FractalPainting.App.Fractals;
using FractalPainting.Factories;
using FractalPainting.Infrastructure.Common;
using FractalPainting.Infrastructure.UiActions;

namespace FractalPainting.App.Actions
{
    public class DragonFractalAction : IUiAction
    {
        private readonly IDragonPainterFactory dragonPainterFactory;
        private readonly Func<Random, DragonSettingsGenerator> dragonSettingsGeneratorFactory;

        public DragonFractalAction(IDragonPainterFactory dragonPainterFactory, Func<Random, DragonSettingsGenerator> dragonSettingsGeneratorFactory)
        {
            this.dragonPainterFactory = dragonPainterFactory;
            this.dragonSettingsGeneratorFactory = dragonSettingsGeneratorFactory;
        }

        public string Category => "Фракталы";
        public string Name => "Дракон";
        public string Description => "Дракон Хартера-Хейтуэя";

        public void Perform()
        {
            var dragonSettings = dragonSettingsGeneratorFactory.Invoke(new Random()).Generate();
            
            // редактируем настройки:
            SettingsForm.For(dragonSettings).ShowDialog();
            
            var dragonPainter = dragonPainterFactory.CreateDragonPainter(dragonSettings);
            dragonPainter.Paint();
        }
    }
}