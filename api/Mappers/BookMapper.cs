using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Models;

namespace api.Mappers
{
    public static class BookMapper
    {
        public static Book ToBookCreateDto(this BookDto bookModel)
        {
            return new Book
            {
                Title = bookModel.Title,
                Author = bookModel.Author,
                Description = bookModel.Description
            };
        }

        public static BookDto ToBookDto(this Book bookModel)
        {
            return new BookDto
            {
                Id = bookModel.Id,
                Title = bookModel.Title,
                Author = bookModel.Author,
                Description = bookModel.Description
            };
        }
    }
}