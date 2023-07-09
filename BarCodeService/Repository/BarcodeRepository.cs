using BarCodeService.DataContext;
using BarCodeService.Dtos;
using BarCodeService.Entities;
using System.Text;

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
            var fullString = model.ToString();
            var base64Bytes = Encoding.UTF8.GetBytes(fullString);
            var hash = Convert.ToBase64String(base64Bytes);
            var item = _context.Barcodes.FirstOrDefault(b => b.Code == hash);
            if (item == null)
            {
            var data = new Barcode
            {
                Code = hash,
                ProductName = model.ProductName,
                TotalPrice = model.Volume * model.Price,
                Volume = model.Volume,
                ProductId = model.ProductId,
            };
            _context.Barcodes.Add(data);
            _context.SaveChanges();
            }
        }
    }
}
