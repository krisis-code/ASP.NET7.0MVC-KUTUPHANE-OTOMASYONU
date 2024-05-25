using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KitapKiralamaOtomasyonu.Models
{
	public class borrow
	{
		[Key]
		public Guid BorrowId { get; set; }

		[Required]
		public Guid UserId { get; set; }

		[ValidateNever]
		public Guid BookId { get; set; }
		[ForeignKey("BookId")]

		[ValidateNever]
		public Book book { get; set; }
	}
}
