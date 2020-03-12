using System;
using System.Windows.Forms;
using FractalPainting.App.Actions;
using FractalPainting.Factories;
using FractalPainting.Infrastructure.Common;
using FractalPainting.Infrastructure.UiActions;
using Ninject;
using Ninject.Extensions.Factory;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Conventions.Syntax;

namespace FractalPainting.App
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            try
            {
                var container = new StandardKernel();

                // start here
                // container.Bind<TService>().To<TImplementation>();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                container.Bind<AppSettings>().ToMethod((context) => context.Kernel.Get<SettingsManager>().Load());
                container.Bind<IObjectSerializer>().To<XmlObjectSerializer>();
                container.Bind<IBlobStorage>().To<FileBlobStorage>();

                container.Bind<Palette>().ToSelf().InSingletonScope();
                container.Bind<IImageHolder, PictureBoxImageHolder>().To<PictureBoxImageHolder>().InSingletonScope();
                container.Bind<IDragonPainterFactory>().ToFactory();

                container.Bind(x =>
                    x.FromThisAssembly().SelectAllClasses().InheritedFrom<IUiAction>().BindAllInterfaces());

                Application.Run(container.Get<MainForm>());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
        }
    }
}