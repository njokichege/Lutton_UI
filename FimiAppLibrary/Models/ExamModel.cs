﻿namespace FimiAppLibrary.Models
{
    public class ExamModel
    {
        public int ExamId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ExamTypeId { get; set; }
        public int TermId { get; set; }
        public int SchoolYear { get; set; }
    }
}
