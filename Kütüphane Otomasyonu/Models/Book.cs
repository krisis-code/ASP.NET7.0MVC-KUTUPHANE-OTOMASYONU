using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using SinemaOtomasyonu.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KitapKiralamaOtomasyonu.Models
{
    public class Book
    {
		
			[Key]
			public Guid BookId { get; set; }

			[Required(ErrorMessage = "Kitap adı gereklidir.")]
			public string BookName { get; set; }

			public string Description { get; set; }

			[Required(ErrorMessage = "Yazar adı gereklidir.")]
			public string Writer { get; set; }

			[Required(ErrorMessage = "Fiyat gereklidir.")]
			public double Price { get; set; }

		    [ValidateNever]
			public Guid BookGenreId { get; set; }
		    [ForeignKey("BookGenreId")]

		    [ValidateNever]
		    public BookGenres BookGenres { get; set; }

			[ValidateNever]
			public string ImageUrl { get; set; }
		}

	}

