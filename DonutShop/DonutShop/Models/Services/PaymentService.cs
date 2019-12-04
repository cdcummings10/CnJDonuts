using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Controllers.Bases;
using DonutShop.Models.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonutShop.Models.Services
{
    public class PaymentService : IPayment
    {
        private IConfiguration _configuration;

        public PaymentService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Run(decimal total, int creditCardID, Address address)
        {
            //declaration of sandbox environment
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;

            ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType()
            {
                name = _configuration["AuthNetLoginID"],
                ItemElementName = ItemChoiceType.transactionKey,
                Item = _configuration["AuthNetTransactionKey"]
            };
            creditCardType creditCard = null;
            switch (creditCardID)
            {
                case 1:
                    creditCard = new creditCardType
                    {
                        cardNumber = _configuration["Visa"],
                        expirationDate = "1222"
                    };
                    break;
                case 2:
                    creditCard = new creditCardType
                    {
                        cardNumber = _configuration["MasterCard"],
                        expirationDate = "1021"
                    };
                    break;
                case 3:
                    creditCard = new creditCardType
                    {
                        cardNumber = "4111111111111111",
                        expirationDate = "1219"
                    };
                    break;
                default:
                    break;
            }

            customerAddressType bilingAddress = new customerAddressType()
            {
                firstName = address.FirstName,
                lastName = address.LastName,
                address = address.StreetAddress,
                city = address.City,
                zip = address.ZipCode
            };

            var paymentType = new paymentType { Item = creditCard };

            var transactionRequest = new transactionRequestType()
            {
                transactionType = transactionTypeEnum.authCaptureTransaction.ToString(),
                amount = total,
                payment = paymentType,
                billTo = bilingAddress
            };

            var request = new createTransactionRequest { transactionRequest = transactionRequest };
            var controller = new createTransactionController(request);
            controller.Execute();

            var response = controller.GetApiResponse();

            if(response != null)
            {
                if(response.messages.resultCode == messageTypeEnum.Ok)
                {
                    return "Transaction Successful! Thank you for your purchase.";
                }
                else
                {
                    return "Transaction Failed. Error Code: " + response.transactionResponse.errors[0].errorCode;
                }
            }

            return "Something went wrong! Please try again.";
        }
    }
}
