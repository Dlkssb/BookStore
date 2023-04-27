using AutoMapper;
using BookStore.Application.Persistence;
using BookStore.Domin.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Features.Queries.GetBookList
{
    public class GetBookListQuery :IRequest<List<Book>>
    {
                 

        public GetBookListQuery()
        {
            
        }

        public class GetBookQueryHandler : IRequestHandler<GetBookListQuery, List<Book>>
        {
            private readonly IBookRepository _bookRepository;
            private readonly IMapper _mapper;
            public async Task<List<Book>> Handle(GetBookListQuery request, CancellationToken cancellationToken)
            {
              var books=  await _bookRepository.GetAllAsync();

                return _mapper.Map<List<Book>>(books);
            }
        }
    }
}
