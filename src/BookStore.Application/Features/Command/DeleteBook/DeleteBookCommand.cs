using AutoMapper;
using BookStore.Application.Persistence;
using BookStore.Domin.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Features.Command.DeleteBook
{
    public class DeleteBookCommand : IRequest
    {
        public Guid Id { get; set; }

        public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
        {
         private readonly   IBookRepository _bookRepository;
          private readonly  IMapper _Mapper;
            public DeleteBookCommandHandler(IBookRepository bookRepository,IMapper mapper)
            {
                _bookRepository= bookRepository;
                _Mapper= mapper;
            }
            public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
            {
                var book = await _bookRepository.GetByIdAsync(request.Id);
                if(book == null)
                { }
                else
                {
                    _Mapper.Map(request,book,typeof(DeleteBookCommand),typeof(Book));
                   await _bookRepository.DeleteAsync(book);
                }
            }
        }
    }
}
