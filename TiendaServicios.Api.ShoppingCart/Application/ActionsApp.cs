using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.ShoppingCart.DTO;
using TiendaServicios.Api.ShoppingCart.Model;
using TiendaServicios.Api.ShoppingCart.Persistence;
using TiendaServicios.Api.ShoppingCart.RemoteServices;

namespace TiendaServicios.Api.ShoppingCart.Application
{
    public interface IActionsApp
    {
        Task<bool> Create(ShoppingCartDTO request);
        Task<ActionResult<ShoppingCartDTO>> Index(int id);
    }

    public class ActionsApp (ShoppingCartContext context, IMapper mapper, IBooksService books) : IActionsApp
    {

        public async Task<bool> Create(ShoppingCartDTO request)
        {
            var data = mapper.Map<ShoppingCartModel>(request);
            context.ShoppingCarts.Add(data);
            var response = await context.SaveChangesAsync();

            if (response == 0)
            {
                throw new Exception("No se pudo guardar la información");
            }

            int id = data.ShoppingCartId;
            if (request.Items != null)
            {
                foreach (var item in request.Items)
                {
                    var detail = new ShoppingCartDetailDTO
                    {
                        CreatedDate = DateTime.Now,
                        Product = item,
                        ShoppingCartId = id
                    };
                    var dataDetail = mapper.Map<ShoppingCartDetailModel>(detail);
                    context.ShoppingCartDetails.Add(dataDetail);
                }
            }

            response = await context.SaveChangesAsync();
            if (response > 0)
            {
                return true;
            }

            throw new Exception("No se pudo guardar la información");
        }

        public async Task<ActionResult<ShoppingCartDTO>> Index(int id)
        {
            var data = await context.ShoppingCarts.Where(x => x.ShoppingCartId == id)
                                    .Select(x => mapper.Map<ShoppingCartDTO>(x)).SingleOrDefaultAsync();
            var items = await context.ShoppingCartDetails.Where(x => x.ShoppingCartId == data.ShoppingCartId)
                                    .Select(x => mapper.Map<ShoppingCartDetailDTO>(x)).ToListAsync();

            var list = new List<CartDetailDTO>();
            foreach (var book in items)
            {
                var response = await books.GetBook(new Guid(book.Product));
                if (response.result)
                {
                    var objBook = response.Book;
                    var shoppingdetail = new CartDetailDTO
                    {
                        Title = objBook.Title,
                        PublisheddDate = objBook.PublisheddDate,
                        BookId = objBook.BookId,
                    };

                    list.Add(shoppingdetail);
                }
            }

            var sessionDTO = new ShoppingCartDTO
            {
                ShoppingCartId = data.ShoppingCartId,
                CreatedDate = data.CreatedDate,
                DetailsList = list
            };

            return sessionDTO;
        }
    }
}