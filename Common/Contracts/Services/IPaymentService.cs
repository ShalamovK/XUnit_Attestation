using Common.Contracts.Services.Base;
using Common.Models.Dtos;
using Common.Responses;

namespace Common.Contracts.Services {
    public interface IPaymentService : IService {
        BaseResponse ProcessNewPayment(PaymentDto payment);
    }
}
