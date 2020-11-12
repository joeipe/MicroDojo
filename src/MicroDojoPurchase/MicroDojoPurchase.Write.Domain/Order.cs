using SharedKernel;

namespace MicroDojoPurchase.Write.Domain
{
    public class Order : Entity
    {
        public int StockId { get; set; }
        public int PersonId { get; set; }

        public Stock Stock { get; set; }
        public Person Person { get; set; }
    }
}