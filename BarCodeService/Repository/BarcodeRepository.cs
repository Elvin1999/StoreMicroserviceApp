using BarCodeService.DataContext;
using BarCodeService.Dtos;
using BarCodeService.Entities;

namespace BarCodeService.Repository
{
    public class BarcodeRepository : IBarcodeRepository
    {
        private readonly BarcodeContext _context;

        public BarcodeRepository(BarcodeContext context)
        {
            _context = context;
        }

        public void AddBarcode(ProductItemDto model)
        {
            var item = new Barcode
            {
                Code = model.GetHashCode().ToString(),
                ProductName = model.ProductName,
                TotalPrice = model.Volume * model.Price,
                Volume = model.Volume,
            };
            _context.Barcodes.Add(item);
            _context.SaveChanges();
        }
    }
}
