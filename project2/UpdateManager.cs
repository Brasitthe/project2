using System;
using System.Collections.Generic;
using System.Globalization;

namespace project2
{
    public enum RiskLevel { Low, Medium, High }
    public enum UpdateKind { Update, Modernization }

    public class UpdateResult
    {
        public bool IsValid { get; set; }
        public List<string> Errors { get; set; } = new List<string>();

        public string CurrentVersion { get; set; } = "";
        public string NewVersion { get; set; } = "";
        public UpdateKind Kind { get; set; }

        public int Modules { get; set; }
        public double DbSizeGb { get; set; }
        public int WindowMinutes { get; set; }
        public bool MigrationRequired { get; set; }

        public double TransitionMinutes { get; set; }
        public bool CanProceed { get; set; }
        public RiskLevel Risk { get; set; }

        public List<string> Steps { get; set; } = new List<string>();
    }

    public class UpdateManager
    {
        public const double BaseMinutes = 10.0;
        public const double MinutesPerModule = 5.0;
        public const double MinutesPerGb = 0.5;
        public const double MigrationMinutes = 20.0;

        public const int MinModules = 0;
        public const int MaxModules = 10;
        public const double MinDbSize = 0.1;
        public const double MaxDbSize = 1000.0;
        public const int MinWindow = 1;
        public const int MaxWindow = 480;

        public UpdateResult Calculate(
            string currentVersion,
            string newVersion,
            string modulesText,
            string dbSizeText,
            string windowText,
            bool migrationRequired)
        {
            var result = new UpdateResult
            {
                CurrentVersion = currentVersion ?? "",
                NewVersion = newVersion ?? "",
                MigrationRequired = migrationRequired
            };

            if (!TryParseVersion(currentVersion, out var vCur))
                result.Errors.Add("Некорректная текущая версия.");

            if (!TryParseVersion(newVersion, out var vNew))
                result.Errors.Add("Некорректная новая версия.");

            if (!int.TryParse(modulesText, NumberStyles.Integer, CultureInfo.InvariantCulture, out var modules))
                result.Errors.Add("Количество модулей должно быть целым числом.");
            else if (modules < MinModules || modules > MaxModules)
                result.Errors.Add($"Количество модулей должно быть в диапазоне {MinModules}–{MaxModules}.");

            if (!double.TryParse(dbSizeText, NumberStyles.Float, CultureInfo.InvariantCulture, out var dbSize))
                result.Errors.Add("Размер БД должен быть числом.");
            else if (dbSize < MinDbSize || dbSize > MaxDbSize)
                result.Errors.Add($"Размер БД должен быть в диапазоне {MinDbSize}–{MaxDbSize} ГБ.");

            if (!int.TryParse(windowText, NumberStyles.Integer, CultureInfo.InvariantCulture, out var window))
                result.Errors.Add("Окно обслуживания должно быть целым числом.");
            else if (window < MinWindow || window > MaxWindow)
                result.Errors.Add($"Окно обслуживания должно быть в диапазоне {MinWindow}–{MaxWindow} мин.");

            if (result.Errors.Count > 0)
            {
                result.IsValid = false;
                return result;
            }

            result.Modules = modules;
            result.DbSizeGb = dbSize;
            result.WindowMinutes = window;

            int cmp = vNew.CompareTo(vCur);
            if (cmp == 0)
                result.Errors.Add("Новая версия равна текущей — переход невозможен.");
            else if (cmp < 0)
                result.Errors.Add("Новая версия меньше текущей — переход невозможен.");

            result.Kind = vNew.Major != vCur.Major ? UpdateKind.Modernization : UpdateKind.Update;

            result.TransitionMinutes =
                BaseMinutes
                + modules * MinutesPerModule
                + dbSize * MinutesPerGb
                + (migrationRequired ? MigrationMinutes : 0);

            result.Risk = modules <= 2 ? RiskLevel.Low
                        : modules <= 5 ? RiskLevel.Medium
                        : RiskLevel.High;

            result.CanProceed = result.Errors.Count == 0
                              && result.TransitionMinutes <= window;

            if (result.CanProceed)
                result.Steps = BuildSteps(migrationRequired);

            result.IsValid = result.Errors.Count == 0;
            return result;
        }

        private static List<string> BuildSteps(bool migration)
        {
            var steps = new List<string>
            {
                "1. Обследование текущей системы",
                "2. Подготовка тестовой системы",
                "3. Тестирование"
            };
            int n = 4;
            if (migration)
            {
                steps.Add($"{n++}. Тестовая миграция данных");
                steps.Add($"{n++}. Основная миграция данных");
            }
            steps.Add($"{n++}. Выполнение плана перехода");
            steps.Add($"{n++}. Поддержка пользователей");
            return steps;
        }

        public static bool TryParseVersion(string text, out Version version)
        {
            version = null;
            if (string.IsNullOrWhiteSpace(text)) return false;
            string normalized = text.Trim();
            if (normalized.Count(c => c == '.') == 1) normalized += ".0";
            return Version.TryParse(normalized, out version);
        }
    }
}