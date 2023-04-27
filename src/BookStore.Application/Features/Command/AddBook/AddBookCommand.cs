using AutoMapper;
using BookStore.Application.Persistence;
using BookStore.Domin.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Features.Command.AddBook
{
    public class AddBookCommand :IRequest<Guid>
    {

        public string Book_Name { get; set; }
        public string Author { get; set; }
        public bool Is_Available { get; set; }

        public decimal Price { get; set; }
        public Guid ShelfShelfId { get; set; }
        public Shelf Shelf { get; set; }
        
        public class AddBookCommandHandler : IRequestHandler<AddBookCommand, Guid>
        {
            private readonly IBookRepository _bookRepository;
            private readonly IMapper _mapper;

            public AddBookCommandHandler(IBookRepository bookRepository,IMapper mapper)
            {
                _bookRepository= bookRepository;
                _mapper = mapper;
            }

            public async Task<Guid> Handle(AddBookCommand request, CancellationToken cancellationToken)
            {
                var book= _mapper.Map<Book>(request);
                await _bookRepository.AddAsync(book);
                return book.Id;
            }
        }
    }
}
