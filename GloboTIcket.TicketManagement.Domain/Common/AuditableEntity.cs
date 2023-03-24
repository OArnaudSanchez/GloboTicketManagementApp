using System;

namespace GloboTIcket.TicketManagement.Domain.Common
{
    public class AuditableEntity
    {
        //Common class for Audit Purposes
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime? LastModifiedDate { get; set; }
    }
}