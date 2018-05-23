﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Helper
{
    public class AuditEntity
    {
        public DateTime? CreatedAt { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime? DeletedAt { get; set; }

        public int DeletedBy { get; set; }

    }
}
