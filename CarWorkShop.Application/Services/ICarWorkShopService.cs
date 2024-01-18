using CarWorkShop.Application.DataTranferObject;

namespace CarWorkShop.Application.Services
{
    public interface ICarWorkShopService
    {
        Task Create(CarWorkShopObject carWorkShopDto);
        Task<IEnumerable<CarWorkShopObject>> GetAll();
    }
}