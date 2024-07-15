namespace TimeVista2._0.Models
{
    using System;

    public partial class tbl_shift
    {
        public int id { get; set; }
        public TimeSpan start_time { get; set; }
        public TimeSpan end_time { get; set; }
        public bool status { get; set; }
        public DateTime? created_at { get; set; }

        // Concatenated property for display
        public string ShiftDisplay
        {
            get { return $"{start_time.ToString(@"hh\:mm\:ss")} - {end_time.ToString(@"hh\:mm\:ss")}"; }
        }
    }
}
