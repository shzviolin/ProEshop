using Microsoft.EntityFrameworkCore;

using ProEShop.DataLayer.Context;
using ProEShop.Entities;
using ProEShop.Services.Contracts;


namespace ProEShop.Services.Services;

public class SellerService : GenericService<Seller>, ISellerService
{
    private readonly DbSet<Seller> _sellers;
    public SellerService(IUnitOfWork uow)
        : base(uow)
    {
        _sellers = uow.Set<Seller>();
    }

    
}

