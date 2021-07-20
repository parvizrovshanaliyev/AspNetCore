using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ProductApp.Application.Dto;
using ProductApp.Application.Interfaces.Repositories;
using ProductApp.Application.Wrappers;

namespace ProductApp.Application.Features.Queries.GetAllProduct
{
    public class GetAllProductQuery : IRequest<ServiceResponse<List<ProductViewDto>>>
    {

        public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, ServiceResponse<List<ProductViewDto>>>
        {
            private readonly IProductRepository _repository;
            private readonly IMapper _mapper;

            public GetAllProductQueryHandler(
                IProductRepository repository,
                IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            #region Implementation of IRequestHandler<in GetAllProductQuery,List<ProductViewDto>>

            public async Task<ServiceResponse<List<ProductViewDto>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
            {
                var entities = await _repository.GetAllAsync();
                var dto = _mapper.Map<List<ProductViewDto>>(entities);
                return new ServiceResponse<List<ProductViewDto>>(dto);
            }

            #endregion
        }
    }
}
