using AutoMapper;
using BookStore.Application.Persistence;
using BookStore.Domin.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Features.Command.UpdateBook
{
    public class UpdateBookCommand :IRequest
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public string Book_Name { get; set; }
        public string Author { get; set; }
        public bool Is_Available { get; set; }

        public decimal Price { get; set; }
        public Guid ShelfShelfId { get; set; }
        public Shelf Shelf { get; set; }

        public class UpdateBookHandler : IRequestHandler<UpdateBookCommand>
        {
            private readonly IBookRepository _bookRepository;
            private readonly IMapper _mapper;

            public UpdateBookHandler(IBookRepository bookRepository,IMapper mapper)
            {
                _bookRepository= bookRepository;
                _mapper= mapper;
            }
            public async Task Handle(UpdateBookCommand request, CancellationToken cancellationToken)
            {
                var book = await _bookRepository.GetByIdAsync(request.Id);
                if(book == null)
                {

                }

                else
                {
                    _mapper.Map(request, book,typeof(UpdateBookCommand),typeof(Book));
                    await _bookRepository.UpdateAsync(book);
                    
                }
            }
        }
    }
}
