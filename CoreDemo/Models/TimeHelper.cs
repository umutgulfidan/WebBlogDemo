namespace CoreDemo.Models
{
    public class TimeHelper
    {
        public static string CalcDifference(DateTime date)
        {
            DateTime now = DateTime.Now;
            TimeSpan difference = now - date;
            string timeLabel;
            if (difference.Days >= 1)
            {
                timeLabel = $"{((int)difference.TotalDays)} gün önce ";
            }
            else if (difference.TotalHours >= 1)
            {
                timeLabel = $"{(int)difference.TotalHours} saat önce";
            }
            else if (difference.TotalMinutes >= 1)
            {
                timeLabel = $"{(int)difference.TotalMinutes} dakika önce";
            }
            else
            {
                timeLabel = "Az önce";
            }
            return timeLabel;
        }
    }
}
