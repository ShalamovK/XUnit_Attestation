using AutoMapper;
using Common.Contracts;
using Common.Contracts.Services;
using Common.Extensions;
using Common.Models.Dtos;
using Common.Models.Entities;
using Common.Responses;
using Logic.Services.Base;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Logic.Services {
    public class PaymentService : BaseService, IPaymentService {
        public PaymentService(IMapper mapper, IServiceProvider serviceHost, IUnitOfWork unitOfWork) 
            : base(mapper, serviceHost, unitOfWork) {
        }

        public BaseResponse ProcessNewPayment(PaymentDto payment) {
            Random random = new Random();

            Payment newPayment = new Payment {
                Id = Guid.NewGuid(),
                Amount = payment.Amount,
                Date = DateTime.Now,
                InvoiceId = payment.InvoiceId,
                TransactionNum = random.RandomString(10)
            };

            _unitOfWork.Payments.Add(newPayment);
            _unitOfWork.Commit();

            _serviceHost.GetRequiredService<IInvoiceService>().UpdateInvoiceBalance(payment.InvoiceId);

            return new BaseResponse(true);
        }
    }
}
