using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using PetStore.Core.Models;
using PetStore.Data;
using System;
using System.Threading.Tasks;

namespace PetStore.API.Controllers
{
    [Produces("application/json")]
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public OrdersController(IOrdersRepository ordersRepository, 
            IProductService productService, IMapper mapper)
        {
            _ordersRepository = ordersRepository ?? 
                throw new ArgumentNullException(nameof(ordersRepository));
            _productService = productService ?? 
                throw new ArgumentNullException(nameof(productService));
            _mapper = mapper ?? 
                throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Get an order for a specific id
        /// </summary>
        /// <param name="id">The id of the order</param>
        /// <returns>An ActionResult of type Order</returns>
        /// <response code="200">Returns the requested order</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/json")]
        [Route("{id}", Name = "GetOrder")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            // get entity from repository
            var orderEntity = await _ordersRepository.GetOrderAsync(id);
            if (orderEntity == null)
            {
                return NotFound();
            }

            // map entity to model
            var order = _mapper.Map<Order>(orderEntity);

            return Ok(order);
        }

        /// <summary>
        /// Create an order with specified line items
        /// </summary>
        /// <param name="orderForCreation">The order to create</param>
        /// <returns>An ActionResult of type Order</returns>
        /// <response code="422">Validation error</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity,
            Type = typeof(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary))]
        public async Task<ActionResult<Order>> CreateOrder(
            [FromBody] OrderForCreation orderForCreation)
        {
            // model validation
            if (orderForCreation == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                // return 422 - Unprocessable Entity when validation fails
                return new UnprocessableEntityObjectResult(ModelState);
            }

            // map model to entity
            var orderEntity = _mapper.Map<Core.Entities.Order>(orderForCreation);

            // get product details
            foreach (var orderItem in orderEntity.Items)
            {
                var productDetail = await _productService.GetProductDetailAsync(orderItem.ProductId);
                if (productDetail == null)
                {
                    // return not found if no details were found
                    return NotFound();
                }
                orderItem.Name = productDetail.name;
                orderItem.Price = productDetail.price;
            }

            // add the entity to the repository
            _ordersRepository.AddOrder(orderEntity);

            // save the changes
            await _ordersRepository.SaveChangesAsync();

            // Fetch the order from the data store to include items
            await _ordersRepository.GetOrderAsync(orderEntity.Id);

            // return CreatedAtRoute to include location in header
            return CreatedAtRoute("GetOrder",
                new { id = orderEntity.Id },
                _mapper.Map<Order>(orderEntity));
        }
    }
}
