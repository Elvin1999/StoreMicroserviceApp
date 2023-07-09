namespace BarCodeService.Dtos
{
    public class ProductItemDto
    {
        public int ProductId { get; set; }
        public decimal Volume { get; set; }
        public decimal Price { get; set; }
        public string? ProductName { get; set; }

        public override string ToString()
        {
            return $"{ProductId}{Volume}{Price}{ProductName}";
        }
    }//1234567890
}
