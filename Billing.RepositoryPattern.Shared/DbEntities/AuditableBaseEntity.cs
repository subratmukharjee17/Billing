﻿using System;

namespace Domain.Common
{
    public abstract class AuditableBaseEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
