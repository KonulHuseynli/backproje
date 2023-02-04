using Core.Entities;
using Core.Utilities.FileService;
using DataAccess.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Web.Areas.Admin.Services.Abstract;
using Web.Areas.Admin.ViewModels.BespokeAnimation;

namespace Web.Areas.Admin.Services.Concrete
{
    public class BespokeAnimationService:IBespokeAnimationService
    {
        private readonly IBespokeAnimationRepository _bespokeAnimationRepository;
        private readonly IFileService _fileService;
        private readonly ModelStateDictionary _modelState;

        public BespokeAnimationService(IBespokeAnimationRepository bespokeAnimationRepository, IActionContextAccessor actionContextAccessor, IFileService fileService)
        {
            _bespokeAnimationRepository = bespokeAnimationRepository;
            _fileService = fileService;
            _modelState = actionContextAccessor.ActionContext.ModelState;
        }


        public async Task<BespokeAnimationIndexVM> GetAsync()
        {
            var model = new BespokeAnimationIndexVM
            {
                BespokeAnimation = await _bespokeAnimationRepository.GetAsync()
            };
            return model;

        }

        public async Task<bool> CreateAsync(BespokeAnimationCreateVM model)
        {

            if (!_modelState.IsValid) return false;

            if (!_fileService.IsImage(model.CoverPhoto))
            {
                _modelState.AddModelError("CoverPhoto", "File image formatinda deyil zehmet olmasa image formasinda secin!!");
                return false;
            }
            if (!_fileService.CheckSize(model.CoverPhoto, 300))
            {
                _modelState.AddModelError("CoverPhoto", "File olcusu 300 kbdan boyukdur");
                return false;
            }
            var bespokeAnimation = new BespokeAnimation
            {
                CreatedAt = DateTime.Now,
                CoverImg = await _fileService.UploadAsync(model.CoverPhoto),
                VideoUrl = model.VideoUrl


            };
            await _bespokeAnimationRepository.CreateAsync(bespokeAnimation);
            return true;
        }


        public async Task<BespokeAnimationUpdateVM> GetUpdateModelAsync(int id)
        {



            var homeVideoComponent = await _bespokeAnimationRepository.GetAsync(id);

            if (homeVideoComponent == null) return null;

            var model = new BespokeAnimationUpdateVM
            {
                Id = homeVideoComponent.Id,
                MainPhotoPath = homeVideoComponent.CoverImg,
                VideoUrl = homeVideoComponent.VideoUrl
            };

            return model;

        }
        public async Task<bool> UpdateAsync(BespokeAnimationUpdateVM model)
        {
            if (!_modelState.IsValid) return false;


            if (model.CoverPhoto != null)
            {
                if (!_fileService.IsImage(model.CoverPhoto))
                {
                    _modelState.AddModelError("CoverPhoto", "File image formatinda deyil zehmet olmasa image formasinda secin!!");
                    return false;
                }
                if (!_fileService.CheckSize(model.CoverPhoto, 2000))
                {
                    _modelState.AddModelError("CoverPhoto", "File olcusu 2000 kbdan boyukdur");
                    return false;
                }
            }

            var homeVideoComponent = await _bespokeAnimationRepository.GetAsync(model.Id);





            if (homeVideoComponent != null)
            {
                homeVideoComponent.Id = model.Id;
                homeVideoComponent.ModifiedAt = DateTime.Now;
                homeVideoComponent.VideoUrl = model.VideoUrl;


                if (model.CoverPhoto != null)
                {
                    homeVideoComponent.CoverImg = await _fileService.UploadAsync(model.CoverPhoto);
                }

                await _bespokeAnimationRepository.UpdateAsync(homeVideoComponent);

            }
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var homeVideoComponent = await _bespokeAnimationRepository.GetAsync(id);
            if (homeVideoComponent != null)
            {
                _fileService.Delete(homeVideoComponent.CoverImg);
                await _bespokeAnimationRepository.DeleteAsync(homeVideoComponent);
                return true;
            }

            return false;
        }

    }
}

    