﻿using System;
using System.Collections.Generic;

namespace DataAccess.DBModels
{
    public partial class SeminarDetail
    {
        public int SeminarId { get; set; }
        public string Title { get; set; } = null!;
        public DateTime Date { get; set; }
        public string Place { get; set; } = null!;
        public string? Lectures { get; set; }
        public string Crowed { get; set; } = null!;
        public string? Program { get; set; }
    }
}
