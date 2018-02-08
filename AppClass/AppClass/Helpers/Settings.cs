using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace AppClass.Helpers
{
    public class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;

        public static string GeneralSettings
        {
            get => AppSettings.GetValueOrDefault(nameof(GeneralSettings), string.Empty);

            set => AppSettings.AddOrUpdateValue(nameof(GeneralSettings), value);
        }

        public static string Telefone
        {
            get => AppSettings.GetValueOrDefault(nameof(Telefone), string.Empty);

            set => AppSettings.AddOrUpdateValue(nameof(Telefone), value);
        }

        public static string RM
        {
            get => AppSettings.GetValueOrDefault(nameof(RM), string.Empty);

            set => AppSettings.AddOrUpdateValue(nameof(RM), value);
        }
        
        public static string Data
        {
            get => AppSettings.GetValueOrDefault(nameof(Data), string.Empty);

            set => AppSettings.AddOrUpdateValue(nameof(Data), value);
        }

        public static string CodUnidade
        {
            get => AppSettings.GetValueOrDefault(nameof(CodUnidade), string.Empty);

            set => AppSettings.AddOrUpdateValue(nameof(CodUnidade), value);
        }
        public static string IDTurma
        {
            get => AppSettings.GetValueOrDefault(nameof(IDTurma), string.Empty);

            set => AppSettings.AddOrUpdateValue(nameof(IDTurma), value);
        }
    }
}