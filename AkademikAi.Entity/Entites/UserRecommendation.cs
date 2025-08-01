﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademikAi.Entity.Entites
{
    public class UserRecommendation
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int RecommendationType { get; set; } // 0: test, 1: sınav, 2: konu tekrarı
        public string RecommendationText { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public bool IsApplied { get; set; }
        public DateTime? ReadAt { get; set; }
        public DateTime? AppliedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid RelatedTopicId { get; set; }

        public virtual AppUser User { get; set; }
        public virtual Topics Topic { get; set; }
    }
}
