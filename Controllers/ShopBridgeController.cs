using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopBridge.CQRS.Command;
using ShopBridge.CQRS.Query;
using ShopBridge.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopBridge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopBridgeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ShopBridgeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ShopBridgeController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var listner = await _mediator.Send(new GetShopBridgeQuery());
            if (listner.Succeeded)
            {
                return Ok();
            }
            else if (listner.DidError)
            {
                var json = JsonConvert.SerializeObject(new
                {
                    error = listner.ErrorMessage
                });
                return Ok(json);
            }
            return Ok();
        }

        

        // POST api/<ShopBridgeController>
        [HttpPost]
        public async Task<IActionResult>  Post([FromBody] ShopBridgeDataContract data)
        {
            var listener = await _mediator.Send(new ShopBridgeAddCommand(data));

            if (listener.Succeeded)
            {
                List<ShopBridgeDataContract> arraydata = new List<ShopBridgeDataContract>();
                arraydata.Add(listener.Model);

                var json = JsonConvert.SerializeObject(new
                {
                    data = arraydata
                });
                return Ok(json);
            }
            else if (listener.DidError)
            {
                var json = JsonConvert.SerializeObject(new
                {
                    error = listener.ErrorMessage
                });
                return Ok(json);
            }
            return Ok();
        }

        // PUT api/<ShopBridgeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] ShopBridgeDataContract data)
        {
            var listener = await _mediator.Send(new ShopBridgeUpdateCommand
            {
                _rowID = id,
                _inputData = data
            });

            if (listener.Succeeded)
            {
                List<ShopBridgeDataContract> arraydata = new List<ShopBridgeDataContract>();
                arraydata.Add(listener.Model);

                var json = JsonConvert.SerializeObject(new
                {
                    data = arraydata
                });
                return Ok(json);
            }
            else if (listener.DidError)
            {
                var json = JsonConvert.SerializeObject(new
                {
                    error = listener.ErrorMessage
                });
                return Ok(json);
            }
            return Ok();
        }

        // DELETE api/<ShopBridgeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var listener = await _mediator.Send(new ShopBridgeDeleteCommand
            {
                rowID = id
            });

            if (listener.Succeeded)
            {

                return Ok("{}");
            }
            else if (listener.DidError)
            {
                var json = JsonConvert.SerializeObject(new
                {
                    error = listener.ErrorMessage
                });
                return Ok(json);
            }
            return Ok();
        }
    }
}
