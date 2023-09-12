using System;
using TMPro;
using UnityEngine;

namespace Pixygon.Highscores {
    public class DateSelecter : MonoBehaviour {
        [SerializeField] private TextMeshProUGUI _dayText;
        [SerializeField] private TextMeshProUGUI _monthText;
        [SerializeField] private TextMeshProUGUI _yearText;
        
        [SerializeField] private int _startOffset = 0;
        
        private DateTime time;

        public Action<string> OnDateChange;

        private void Start() {
            time = DateTime.Today;
            time.Subtract(new TimeSpan(_startOffset, 0, 0, 0));
            SetDate();
        }
        public void OnChangeDay(bool up) {
            time.AddDays(up ? 1 : -1);
            SetDate();
        }

        public void OnChangeMonth(bool up) {
            time.AddMonths(up ? 1 : -1);
            SetDate();
        }

        public void OnChangeYear(bool up) {
            time.AddYears(up ? 1 : -1);
            SetDate();
        }

        private void SetDate() {
            //if(time >= DateTime.Today)
            //    time = DateTime.Today;
            //if (time <= new DateTime(2023, 8, 22)) ;
            //    time = new DateTime(2023, 8, 23);
            _dayText.text = time.Day.ToString();
            _monthText.text = time.Month.ToString();
            _yearText.text = time.Year.ToString();
            OnDateChange?.Invoke($"{time.Year}-{time.Month}-{time.Day}");
        }
    }
}
