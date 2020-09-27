namespace Common.Contracts.Models {
    public interface IPricingEntity {
        public int Qty { get; set; }
        public decimal Rate { get; set; }
    }
}
