﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProEShop.Common;
using ProEShop.Common.Constants;
using ProEShop.Common.Helpers;
using ProEShop.Common.IdentityToolkit;
using ProEShop.DataLayer.Context;
using ProEShop.Services.Contracts;
using ProEShop.ViewModels.Categories;

namespace ProEShop.Web.Pages.Admin.Category
{
    public class IndexModel : PageBase
    {
        #region Constructor

        private readonly ICategoryService _categoryService;
        private readonly IUploadFileService _uploadFile;
        private readonly IUnitOfWork _uow;
        public IndexModel(ICategoryService categoryService, IUploadFileService uploadFile, IUnitOfWork uow)
        {
            _categoryService = categoryService;
            _uploadFile = uploadFile;
            _uow = uow;
        }

        #endregion

        public ShowCategoriesViewModel Categories { get; set; }
        = new();

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnGetGetDataTableAsync(ShowCategoriesViewModel categories)
        {
            if (!ModelState.IsValid)
            {
                return Json(new JsonResultOperation(false, PublicConstantStrings.ModelStateErrorMessage)
                {
                    Data = ModelState.GetModelStateErrors()
                });
            }
            categories.Pagination.Take = 1;
            return Partial("List", await _categoryService.GetCategories(categories));
        }

        public IActionResult OnGetAdd()
        {
            var model = new AddCategoryViewModel
            {
                MainCategories = _categoryService.GetCategoriesToShowInSelectBox()
                .CreateSelectListItem(firstItemText: "خودش دسته اصلی باشد")
            };
            return Partial("Add", model);
        }
        public async Task<IActionResult> OnPostAdd(AddCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new JsonResultOperation(false, PublicConstantStrings.ModelStateErrorMessage)
                {
                    Data = ModelState.GetModelStateErrors()
                });
            }

            string pictureFileName = null;
            if (model.Picture.IsFileUploaded())
                pictureFileName = model.Picture.GenerateFileName();

            var category = new Entities.Category
            {
                Title = model.Title,
                Slug = model.Slug,
                Description = model.Description,
                ShowInMenus = model.ShowInMenus,
                ParentId = model.ParentId == 0 ? null : model.ParentId,
                Picture = pictureFileName
            };
            var result = await _categoryService.AddAsync(category);
            if (!result.Ok)
            {
                return Json(new JsonResultOperation(false, PublicConstantStrings.DuplicateErrorMessage)
                {
                    Data = result.Columns.SetDuplicateColumnErrorMessages<AddCategoryViewModel>()
                });
            }
            await _uow.SaveChangesAsync();
            await _uploadFile.SaveFile(model.Picture, pictureFileName, "images", "categories");

            return Json(new JsonResultOperation(true, "دسته بندی مورد نظر با موفقیت اضافه شد."));
        }
    }
}

