using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FertilityCare.Domain.Enums;
using FertilityCare.UseCase.DTOs.Blogs;
using FertilityCare.UseCase.Interfaces.Repositories;
using FertilityCare.UseCase.Interfaces.Services;

namespace FertilityCare.UseCase.Implements
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IDoctorRepository _doctorRepository;
        public BlogService(IBlogRepository blogRepository,
            IUserProfileRepository userProfileRepository,
            IDoctorRepository doctorRepository)
        {
            _blogRepository = blogRepository;
            _userProfileRepository = userProfileRepository;
            _doctorRepository = doctorRepository;
        }
        public async Task<BlogDTO> CreateNewBlog(CreateBlogRequestDTO request)
        {
            var userProfile = await _userProfileRepository.FindByIdAsync(Guid.Parse(request.UserProfileId));
            var status = (_doctorRepository.FindByIdAsync(Guid.Parse(request.UserProfileId)) is null)
                ? BlogStatus.Process : BlogStatus.Approved;

            return new BlogDTO()
            {
                UserProfileId = request.UserProfileId,
                UserName = userProfile.FirstName + " " + userProfile.MiddleName + " " + userProfile.LastName,
                Content = request.Content,
                Status = status,
                CreatedAt = DateTime.Now,
                UpdatedAt = null,
                ImageUrl = request.ImageUrl,
                AvatarUrl = userProfile.AvatarUrl
            };
        }

        public Task<List<BlogDTO>> GetAllBlog(BlogQueryDTO query)
        {
            throw new NotImplementedException();
        }

        public Task<List<BlogDTO>> GetBlogByDoctorId(BlogQueryDTO query)
        {
            throw new NotImplementedException();
        }

        public Task<BlogDTO> UpdateBlog(string blogId, CreateBlogRequestDTO request)
        {
            throw new NotImplementedException();
        }
    }
}
