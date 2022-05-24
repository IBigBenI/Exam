using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace Exam.Models
{
    public class Records
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Text { get; set; }
        public string Response { get; set; }
    }
}
