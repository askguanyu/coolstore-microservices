using System.Reactive.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VND.Fw.Infrastructure.AspNetCore;
using VND.Fw.Infrastructure.AspNetCore.CleanArch;
using VND.FW.Infrastructure.AspNetCore;

namespace VND.CoolStore.Services.Cart.v1.UseCases.UpdateItemInCart
{
  [ApiVersion("1.0")]
  [Route("api/carts")]
  public class CartController : EvtControllerBase
  {
    public CartController(IMediator mediator) : base(mediator) { }

    [HttpPut]
    [Auth(Policy = "access_cart_api")]
    public async Task<IActionResult> Put(UpdateItemInCartRequest request) =>
      await Eventor.SendStream<UpdateItemInCartRequest, UpdateItemInCartResponse>(request, x => x.Result);
  }
}