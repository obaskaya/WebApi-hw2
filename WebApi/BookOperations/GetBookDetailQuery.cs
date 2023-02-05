﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations
{
	public class GetBookDetailQuery
	{
		private readonly BookStoreDbContext _dbContext;
		private readonly IMapper _mapper;

		public int BookId { get; set; }

		public GetBookDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}
		public BookDetailViewModel Handle()
		{
			var book = _dbContext.Books.Where(book => book.Id == BookId).SingleOrDefault();

			if (book is null) { throw new InvalidOperationException("Book is not found"); }

			BookDetailViewModel vm = _mapper.Map<BookDetailViewModel>(book);

			return vm;
		}
	}
	public class BookDetailViewModel
	{
		public string Title { get; set; }
		public string Genre { get; set; }
		public int PageCount { get; set; }
		public string PublishDate { get; set; }
	}
}

