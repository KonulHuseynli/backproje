using Core.Entities;
using DataAccess.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Web.Services.Abstract;
using Web.ViewModels.Bespoke;
namespace Web.Services.Concrete
{
    public class BespokeService:IBespokeService
    {
        private readonly IBespokeAnimationRepository _bespokeanimationRepository;

        public BespokeService(IBespokeAnimationRepository bespokeAnimationrepository)
        {
            _bespokeanimationRepository = bespokeAnimationrepository;

        }

        public async Task<BespokeIndexVM> GetAllAsync()
        {
            var model = new BespokeIndexVM
            {

                bespokeAnimation = await _bespokeanimationRepository.GetAsync()
            };
            return model;

        }

       
    }
}
