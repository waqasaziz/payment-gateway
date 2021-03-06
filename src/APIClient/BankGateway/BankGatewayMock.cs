﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APiClient.BankGateway
{
    using DataContracts;
    public interface IBankGateway
    {
        Task<BankGatewayResponse> SubmitPayment(BankGatewayRequest request);
    }
    public class BankGatewayMock : IBankGateway
    {
        private const string TestCardNumber = "1111111111111111";

        public Task<BankGatewayResponse> SubmitPayment(BankGatewayRequest request)
        {
            var result = new BankGatewayResponse
            {
                CardNumber = request.CardNumber,
                NameOnCard = request.NameOnCard,
                ExpiryDate = request.ExpiryDate,
                SecurityCode = request.SecurityCode,
                Amount = request.Amount,
                Identifier = Guid.NewGuid().ToString(),
                Status = BankGatewayPaymentStatus.Failed
            };

            if (request.CardNumber == TestCardNumber)
                result.Status = BankGatewayPaymentStatus.Successfull;

            return Task.FromResult(result);

        }
    }
}
