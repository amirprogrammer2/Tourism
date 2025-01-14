﻿using static Tourism.Core.Enums.Enums;

namespace Tourism.Core.Entitiy
{
    public class UserArticle
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsApproved { get; set; }
        public string City { get; set; }
        public string Topic { get; set; }
    }
}


