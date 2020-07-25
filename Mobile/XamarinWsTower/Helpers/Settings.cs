using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinWsTower.Helpers
{
    //! Arquivo de configuração do app. Atualmente só configura o tema do app.
    class Settings
    {
        public enum Theme
        {
            LightTheme,
            DarkTheme
        }
        public static void SetTheme(Theme theme)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                switch (theme)
                {
                    case Theme.LightTheme:
                        Application.Current.Resources.MergedDictionaries.Add(new Themes.LightTheme());
                        break;
                    case Theme.DarkTheme:
                        Application.Current.Resources.MergedDictionaries.Add(new Themes.DarkTheme());
                        break;
                    default:
                        break;
                }
            });
        }
    }
}
