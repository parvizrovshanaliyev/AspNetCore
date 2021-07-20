using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ProductApp.Application.Dto;
using ProductApp.Application.Interfaces.Repositories;
using ProductApp.Application.Wrappers;
using ProductApp.Domain.Entities;

namespace ProductApp.Application.Features.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<ServiceResponse<Guid>>
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public  class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ServiceResponse<Guid>>
        {
            private readonly IProductRepository _repository;
            private readonly IMapper _mapper;

            public CreateProductCommandHandler(IProductRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            #region Implementation of IRequestHandler<in CreateProductCommand,ServiceResponse<List<ProductViewDto>>>

            public async Task<ServiceResponse<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<Product>(request);

                await _repository.AddAsync(entity);

                return new ServiceResponse<Guid>(entity.Id);
            }

            #endregion
        }
    }
}
