using System;

namespace NotificationCenter.Core.Events
{
    public class CertificateExpirationEvent : BaseEvent
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int SerialNumber { get; set; }

        public CertificateExpirationEvent()
            : base("CertificateExpiration")
        {

        }
    }
}
