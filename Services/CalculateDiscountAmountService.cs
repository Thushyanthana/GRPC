
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server
{
    public class CalculateDiscountAmountService : CalculateDiscountAmount.CalculateDiscountAmountBase
    {
        private readonly ILogger<CalculateDiscountAmountService> _logger;
        public CalculateDiscountAmountService(ILogger<CalculateDiscountAmountService> logger)
        {
            _logger = logger;
        }


        public override Task<CalculateReply> AmountCalculate(CalculateRequest request, ServerCallContext context)
        {
            //It is for ensure as breakpoint 
            _logger.LogInformation("I am here");
            return Task.FromResult(new CalculateReply
            {
                Customerdiscount = ReturnDiscount(request.Customertype)
            });
        }


        private double ReturnDiscount(string customertype)
        {
            double discount = 0.0;

            if (customertype == "GOLD")
            {
                discount = 15.6;
            }
            else if (customertype == "PLATINUM")
            {
                discount = 20.6;
            }
            else if (customertype == "DIAMOND")
            {
                discount = 25.6;
            }

            return discount;

        }



    }
}
