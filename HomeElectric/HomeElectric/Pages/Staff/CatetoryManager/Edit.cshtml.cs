using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObject;
using Service.Interface;

namespace HomeElectric.Pages.Staff.CatetoryManager
{
    public class EditModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        public EditModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [BindProperty]
        public Category Category { get; set; }

        // Thêm thuộc tính để lưu trữ tên danh mục ban đầu
        public string OriginalCategoryName { get; set; }

        // Thêm thuộc tính để lưu trạng thái checkbox
        [BindProperty]
        public bool IsDeletedChecked { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _categoryService.GetById(id.Value);

            if (Category == null)
            {
                return NotFound();
            }

            // Lưu trữ tên danh mục ban đầu
            OriginalCategoryName = Category.CategoryName;

            // Set trạng thái checkbox
            IsDeletedChecked = Category.IsDeleted ?? false;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Kiểm tra trùng tên danh mục
            if (Category.CategoryName != OriginalCategoryName)
            {
                var existingCategory = await _categoryService.GetCateName(Category.CategoryName);
                if (existingCategory != null && existingCategory.Id != Category.Id)
                {
                    ModelState.AddModelError("Category.CategoryName", "This category name already exists.");
                    return Page();
                }
            }

            try
            {
                // Cập nhật thời gian chỉnh sửa
                Category.ModificationDate = DateTime.Now;

                // Cập nhật trạng thái IsDeleted
                Category.IsDeleted = IsDeletedChecked;

                // Nếu IsDeleted được chọn là true, cập nhật thời gian xóa
                if (Category.IsDeleted ?? false)
                {
                    Category.DeletionDate = DateTime.Now;
                }

                await _categoryService.Update(Category);
            }
            catch (Exception)
            {
                // Xử lý khi có lỗi xảy ra
                return RedirectToPage("/Error");
            }

            return RedirectToPage("./Index");
        }
    }
}