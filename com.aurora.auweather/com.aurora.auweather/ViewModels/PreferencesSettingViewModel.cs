﻿// Copyright (c) Aurora Studio. All rights reserved.
//
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using Com.Aurora.AuWeather.Models.Settings;
using Com.Aurora.AuWeather.Models;
using Com.Aurora.Shared.Extensions;
using Windows.System.Threading;
using Com.Aurora.AuWeather.ViewModels.Events;
using Windows.Foundation;
using System.Threading.Tasks;
using Com.Aurora.Shared.MVVM;
using Windows.UI.Xaml;

namespace Com.Aurora.AuWeather.ViewModels
{
    internal class PreferencesSettingViewModel : ViewModelBase
    {
        private Preferences Preferences;
        private ElementTheme theme;

        public PreferencesSettingViewModel()
        {
            Preferences = Preferences.Get();
            Theme1 = Preferences.GetTheme();
            var task = ThreadPool.RunAsync((work) =>
            {
                work.Completed = new AsyncActionCompletedHandler(WorkComplete);

                Data = new DataList();
                Temperature = new TemperatureList();
                Wind = new WindList();
                Speed = new SpeedList();
                Length = new LengthList();
                Pressure = new PressureList();
                Theme = new ThemeList();
                RefreshFreq = new RefreshFreqList();
                Year = new FormatList();
                Month = new FormatList();
                Day = new FormatList();
                Hour = new FormatList();
                Minute = new FormatList();
                Week = new FormatList();

                Year.AddRange(Preferences.YearFormat);
                Month.AddRange(Preferences.MonthFormat);
                Day.AddRange(Preferences.DayFormat);
                Hour.AddRange(Preferences.HourFormat);
                Minute.AddRange(Preferences.MinuteFormat);
                Week.AddRange(Preferences.WeekFormat);
                Separator = Preferences.DateSeparator.ToString();

                Data.SelectedIndex = Data.FindIndex(x =>
                {
                    return (DataSource)x.Value == Preferences.DataSource;
                });
                Temperature.SelectedIndex = Temperature.FindIndex(x =>
                {
                    return (TemperatureParameter)x.Value == Preferences.TemperatureParameter;
                });
                Wind.SelectedIndex = Wind.FindIndex(x =>
                {
                    return (WindParameter)x.Value == Preferences.WindParameter;
                });
                Speed.SelectedIndex = Speed.FindIndex(x =>
                {
                    return (SpeedParameter)x.Value == Preferences.SpeedParameter;
                });
                Length.SelectedIndex = Length.FindIndex(x =>
                {
                    return (LengthParameter)x.Value == Preferences.LengthParameter;
                });
                Pressure.SelectedIndex = Pressure.FindIndex(x =>
                {
                    return (PressureParameter)x.Value == Preferences.PressureParameter;
                });
                Theme.SelectedIndex = Theme.FindIndex(x =>
                {
                    return (RequestedTheme)x.Value == Preferences.Theme;
                });
                RefreshFreq.SelectedIndex = RefreshFreq.FindIndex(x =>
                {
                    return (RefreshState)x.Value == Preferences.RefreshFrequency;
                });

                Year.SelectedIndex = (int)Preferences.YearNumber;
                Month.SelectedIndex = (int)Preferences.MonthNumber;
                Day.SelectedIndex = (int)Preferences.DayNumber;
                Hour.SelectedIndex = (int)Preferences.HourNumber;
                Minute.SelectedIndex = (int)Preferences.MinuteNumber;
                Week.SelectedIndex = (int)Preferences.WeekNumber;

                DisableDynamic = Preferences.DisableDynamic;
                EnableAlarm = Preferences.EnableAlarm;
                EnableSecond = Preferences.EnableImmersiveSecond;
                UseWeekDay = Preferences.UseWeekDayforForecast;
                UseLunarCalendar = Preferences.UseLunarCalendarPrimary;
                Showtt = Preferences.DecorateNumber == 1;
                ShowImmersivett = Preferences.ShowImmersivett;
                EnableEveryDay = Preferences.EnableEveryDay;
                EnablePulltoRefresh = Preferences.EnablePulltoRefresh;
                ThemeasRiseSet = Preferences.ThemeasRiseSet;

                StartTime = Preferences.StartTime;
                EndTime = Preferences.EndTime;
            });
        }

        private async void WorkComplete(IAsyncAction asyncInfo, AsyncStatus asyncStatus)
        {
            await Task.Delay(500);
            OnFetchDataComplete();
        }

        public EventHandler<FetchDataCompleteEventArgs> FetchDataComplete;

        private void OnFetchDataComplete()
        {
            FetchDataComplete?.Invoke(this, new FetchDataCompleteEventArgs());
        }

        internal void SetFormatValue(string name, string v)
        {
            if (name == "Year")
            {
                Preferences.YearNumber = (uint)Array.IndexOf(Preferences.YearFormat, v);
            }
            if (name == "Month")
            {
                Preferences.MonthNumber = (uint)Array.IndexOf(Preferences.MonthFormat, v);
            }
            if (name == "Day")
            {
                Preferences.DayNumber = (uint)Array.IndexOf(Preferences.DayFormat, v);
            }
            if (name == "Hour")
            {
                Preferences.HourNumber = (uint)Array.IndexOf(Preferences.HourFormat, v);
            }
            if (name == "Minute")
            {
                Preferences.MinuteNumber = (uint)Array.IndexOf(Preferences.MinuteFormat, v);
            }
            if (name == "Week")
            {
                Preferences.WeekNumber = (uint)Array.IndexOf(Preferences.WeekFormat, v);
            }
            SaveAll();
        }

        internal void ReloadTheme()
        {
            Theme1 = Preferences.GetTheme();
        }

        internal void SetEnumValue(Enum value)
        {
            if (value is TemperatureParameter)
            {
                Preferences.Set((TemperatureParameter)value);
            }
            else if (value is WindParameter)
            {
                Preferences.Set((WindParameter)value);
            }
            else if (value is SpeedParameter)
            {
                Preferences.Set((SpeedParameter)value);
            }
            else if (value is LengthParameter)
            {
                Preferences.Set((LengthParameter)value);
            }
            else if (value is PressureParameter)
            {
                Preferences.Set((PressureParameter)value);
            }
            else if (value is RefreshState)
            {
                Preferences.Set((RefreshState)value);
            }
            else if (value is RequestedTheme)
            {
                Preferences.Set((RequestedTheme)value);
            }
            SaveAll();
        }

        internal void SaveAll()
        {
            Preferences.Save();
        }

        internal void SetSeparator(string text)
        {
            if (text.Length > 0)
                Preferences.DateSeparator = text[0];
            SaveAll();
        }

        public DataList Data { get; private set; }
        public TemperatureList Temperature { get; private set; }
        public WindList Wind { get; private set; }
        public SpeedList Speed { get; private set; }
        public LengthList Length { get; private set; }
        public PressureList Pressure { get; private set; }
        public ThemeList Theme { get; private set; }
        public RefreshFreqList RefreshFreq { get; private set; }

        public FormatList Hour { get; private set; }
        public FormatList Minute { get; private set; }
        public FormatList Year { get; private set; }
        public FormatList Month { get; private set; }
        public FormatList Day { get; private set; }
        public FormatList Week { get; private set; }

        public TimeSpan StartTime { get; internal set; }
        public TimeSpan EndTime { get; internal set; }

        public string Separator { get; internal set; }
        public bool DisableDynamic { get; private set; }
        public bool EnableAlarm { get; private set; }
        public bool EnableSecond { get; private set; }
        public bool UseWeekDay { get; private set; }
        public bool UseLunarCalendar { get; private set; }
        public bool Showtt { get; private set; }
        public bool ShowImmersivett { get; private set; }
        public bool EnableEveryDay { get; private set; }
        public bool EnablePulltoRefresh { get; private set; }
        public bool ThemeasRiseSet { get; internal set; }

        public ElementTheme Theme1
        {
            get
            {
                return theme;
            }

            set
            {
                SetProperty(ref theme, value);
            }
        }

        internal void Settt(bool isOn)
        {
            Showtt = isOn;
            if (isOn)
            {
                Preferences.DecorateNumber = 1;
            }
            else
            {
                Preferences.DecorateNumber = 0;
            }
            SaveAll();
        }

        internal void SetBool(string name, bool isOn)
        {
            switch (name)
            {
                case "UseWeekDay":
                    Preferences.UseWeekDayforForecast = isOn;
                    UseWeekDay = isOn;
                    break;
                case "EnableEveryDay":
                    Preferences.EnableEveryDay = isOn;
                    EnableEveryDay = isOn;
                    break;
                case "EnableAlarm":
                    Preferences.EnableAlarm = isOn;
                    EnableAlarm = isOn;
                    break;
                case "EnableSecond":
                    Preferences.EnableImmersiveSecond = isOn;
                    EnableSecond = isOn;
                    break;
                case "ShowImmersivett":
                    Preferences.ShowImmersivett = isOn;
                    ShowImmersivett = isOn;
                    break;
                case "DisableDynamic":
                    Preferences.DisableDynamic = isOn;
                    DisableDynamic = isOn;
                    break;
                case "EnablePulltoRefresh":
                    Preferences.EnablePulltoRefresh = isOn;
                    EnablePulltoRefresh = isOn;
                    break;
                case "ThemeasRiseSet":
                    Preferences.ThemeasRiseSet = isOn;
                    ThemeasRiseSet = isOn;
                    break;
                default:
                    break;
            }
            SaveAll();
        }

        internal void SetEnd(TimeSpan newTime)
        {
            EndTime = newTime;
            Preferences.EndTime = newTime;
            SaveAll();
        }

        internal void SetStart(TimeSpan newTime)
        {
            StartTime = newTime;
            Preferences.StartTime = newTime;
            SaveAll();
        }

        internal async Task SetSource(DataSource caiyun)
        {
            await Preferences.Set(caiyun);
            SaveAll();
        }
    }

    public class FormatList : List<string>
    {
        public int SelectedIndex { get; internal set; } = 0;
    }

    public class TemperatureList : List<EnumSelector>
    {
        public TemperatureList()
        {
            foreach (TemperatureParameter item in Enum.GetValues(typeof(TemperatureParameter)))
            {
                Add(new EnumSelector(item, item.GetDisplayName()));
            }
        }

        public int SelectedIndex { get; internal set; } = 0;
    }

    public class DataList : List<EnumSelector>
    {
        public DataList()
        {
            foreach (DataSource item in Enum.GetValues(typeof(DataSource)))
            {
                Add(new EnumSelector(item, item.GetDisplayName()));
            }
        }

        public int SelectedIndex { get; internal set; } = 0;
    }

    public class PressureList : List<EnumSelector>
    {
        public PressureList()
        {
            foreach (PressureParameter item in Enum.GetValues(typeof(PressureParameter)))
            {
                Add(new EnumSelector(item, item.GetDisplayName()));
            }
        }

        public int SelectedIndex { get; internal set; } = 0;
    }

    public class WindList : List<EnumSelector>
    {
        public WindList()
        {
            foreach (WindParameter item in Enum.GetValues(typeof(WindParameter)))
            {
                Add(new EnumSelector(item, item.GetDisplayName()));
            }
        }
        public int SelectedIndex { get; internal set; } = 0;
    }

    public class SpeedList : List<EnumSelector>
    {
        public SpeedList()
        {
            foreach (SpeedParameter item in Enum.GetValues(typeof(SpeedParameter)))
            {
                Add(new EnumSelector(item, item.GetDisplayName()));
            }
        }
        public int SelectedIndex { get; internal set; } = 0;
    }

    public class LengthList : List<EnumSelector>
    {
        public LengthList()
        {
            foreach (LengthParameter item in Enum.GetValues(typeof(LengthParameter)))
            {
                Add(new EnumSelector(item, item.GetDisplayName()));
            }
        }
        public int SelectedIndex { get; internal set; } = 0;
    }

    public class RefreshFreqList : List<EnumSelector>
    {
        public RefreshFreqList()
        {
            foreach (RefreshState item in Enum.GetValues(typeof(RefreshState)))
            {
                Add(new EnumSelector(item, item.GetDisplayName()));
            }
        }
        public int SelectedIndex { get; internal set; } = 0;
    }

    public class ThemeList : List<EnumSelector>
    {
        public ThemeList()
        {
            foreach (RequestedTheme item in Enum.GetValues(typeof(RequestedTheme)))
            {
                Add(new EnumSelector(item, item.GetDisplayName()));
            }
        }
        public int SelectedIndex { get; internal set; } = 0;
    }

    public class EnumSelector
    {
        public Enum Value { get; private set; }
        public string Title { get; private set; }

        public EnumSelector(Enum e, string t)
        {
            Value = e;
            Title = t;
        }
    }
}
