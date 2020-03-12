using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractalPainting.App.Actions
{
    public struct Category
    {
        public static readonly Dictionary<string, Category> AllCategories = new Dictionary<string, Category>()
        {
            {"Файл",      new Category(10, "Файл")},
            {"Фракталы",  new Category(20, "Фракталы") },
            {"Настройки", new Category(30, "Настройки") }
        };

        public string Name;
        public int Priority;

        public Category(int priority, string name)
        {
            Priority = priority;
            Name = name;
        }
    }
}
