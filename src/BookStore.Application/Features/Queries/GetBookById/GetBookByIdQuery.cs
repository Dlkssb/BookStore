using AutoMapper;
using BookStore.Application.Persistence;
using BookStore.Domin.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Features.Queries.GetBookById
{
    public class GetBookByIdQuery :IRequest<Book>
    {
        Guid Id;

        public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, Book>
        {
            private readonly IBookRepository _bookRepository;
            private readonly IMapper _mapper;

            public GetBookByIdHandler(IBookRepository bookRepository, IMapper mapper)
            {
                _bookRepository = bookRepository;
                _mapper = mapper;
            }
            public async Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
            {
                var book = await _bookRepository.GetByIdAsync(request.Id);
              
                
                if(book==null)
                { throw new Exception("Not Found"); }

                else
                {
                    return _mapper.Map<Book>(book);
                }
            }
        }
    }
}
