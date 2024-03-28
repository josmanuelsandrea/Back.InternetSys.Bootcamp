﻿using BackendBootcamp.DBModels;

namespace BackendBootcamp.Models
{
    public class PaymentModelReq
    {
        public DateTime Paymentdate { get; set; }
        public int Clientid { get; set; }
        public decimal Amount { get; set; }
        public int Contractid { get; set; }
    }
}
