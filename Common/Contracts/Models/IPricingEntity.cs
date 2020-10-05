namespace Common.Contracts.Models {
    public interface IPricingEntity {
        int Qty { get; set; }
        decimal Rate { get; set; }
        decimal TotalPrice();
    }
}
