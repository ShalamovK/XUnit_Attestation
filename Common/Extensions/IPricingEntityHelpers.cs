using Common.Contracts.Models;

namespace Common.Extensions {
    public static class IPricingEntityHelpers {
        public static decimal GetTotalPrice(this IPricingEntity pricingEntity) {
            return pricingEntity.Qty * pricingEntity.Rate;
        }
    }
}
