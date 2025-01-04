using BlogApp.Core.Entities;

namespace BlogApp.BL.DTOs.CategoryDTOs
{
	public class CategoryListItem
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Icon { get; set; }

		public static implicit operator CategoryListItem(Category cat)
		{
			return new CategoryListItem
			{
				Id = cat.Id,
				Name = cat.Name,
				Icon = cat.Icon
			};
		}

	}
}