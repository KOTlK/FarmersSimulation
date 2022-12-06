using System;
using TMPro;
using UnityEngine;

namespace Game.Runtime.View.DateTime
{
    public class DateTimeView : MonoBehaviour, ITimeView, IDateView
    {
        [SerializeField] private TMP_Text _date, _time;
        [SerializeField] private DateViewType _dateViewType;
        
        private enum DateViewType
        {
            MonthDayYear,
            DayMonthYear
        };
        
        public void DisplayTime(int minutes, int hours)
        {
            var minutesVisualization = minutes switch
            {
                0 => "00",
                _ => minutes.ToString()
            };
            
            var hoursVisualization = hours switch
            {
                0 => "00",
                _ => hours.ToString()
            };
            
            _time.text = $"{hoursVisualization}:{minutesVisualization}";
        }

        public void DisplayDate(int month, int day, int year)
        {
            _date.text = _dateViewType switch
            {
                DateViewType.MonthDayYear => $"{month}.{day}.{year}",
                DateViewType.DayMonthYear => $"{day}.{month}.{year}",
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}