
using ApplicationDb.Models;
using Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using Proyects.Models;
using Reviews.Model;
using Users.Models;
using Notification.Services;

namespace Reviews.Services
{
    public interface IReviewServices
    {
        Review AddReview(ReviewDTO review);
        bool GetReviewUser(Guid PId,string userEmail);
        UserLikeProductsDTO GetAllReviewsUser(Guid userId,int page, int pageSize);
        Review GetReviewByEmail (Guid PId,string userEmail);
        Review UpdateReview(ReviewDTO review);
        int GetReviewCount(Guid PId);
        Review DeleteReview(Guid PId, Guid UId);
        List<Review> GetProyectReviews(Guid PId, int skip = 10 ,int pageSize=10);
    }

    public class ReviewService:IReviewServices
    {
        private readonly ApplicationDbContext _context;
        private readonly NClientHubService _likedProyectService;

        public ReviewService(ApplicationDbContext context,NClientHubService likedProyectService)
        {
            _likedProyectService = likedProyectService;
            _context = context;
        }
        private async Task NClientHubTaskAsync(string pid,string userEmail,string EUser)
        {
            Review review = GetReviewByEmail(Guid.Parse(pid),userEmail);

            foreach (var UserP in review.Proyect.UserProyects)
            {
                Console.WriteLine("NClientHubTaskAsync : " +UserP.Proyects.Name);
                await _likedProyectService.SendNotification(EUser,$" Tu proyecto {UserP.Proyects.Name} fue likeado por {UserP.User.Email}","",UserP.User.Email);
                
            }
        }
        public Review AddReview(ReviewDTO review)
        {

            try
            {
                

                User userExist = _context.Users.FirstOrDefault(u => !u.isDeleted && u.Email == review.emailUser);

                Review reviewExist = _context.Review.FirstOrDefault(r => r.User.Email == review.emailUser && r.PId == review.proyectId);

                if (reviewExist != null)
                {   
                    return UpdateReview(review);
                }
                
                Proyect proyectExist = _context.Proyects.FirstOrDefault(p => !p.isDeleted && p.Id == review.proyectId);

                if (userExist == null || proyectExist == null)
                {
                    throw new Exception("No existe el proyecto o el usuario ingresado");
                }
                
                Review newReview = new Review{

                    Like = review.like,
                    Proyect = proyectExist,
                    User = userExist,

                };

                _context.Review.Add(newReview);

                Console.WriteLine("Review Creada : ",newReview);
                _context.SaveChanges();

                return newReview;

            }
            catch (Exception)
            {
                
                throw;
            }
        }
        
        public List<Review> GetProyectReviews(Guid PId, int skip = 10 ,int pageSize=10)
        {

            try
            {
                List<Review> AllProductReviews = _context.Review
                .Skip(skip)
                .Take(pageSize)
                .Where(r => !r.isDeleted && r.Proyect.Id == PId).ToList();
                
                return AllProductReviews;
            }
            catch (System.Exception)
            {
                
                throw;
            }



        }
        public Review UpdateReview (ReviewDTO updateReview)
        {
            try
            {
                Review review = _context.Review.First(r => !r.isDeleted && r.User.Email == updateReview.emailUser && r.Proyect.Id == updateReview.proyectId);
                if (review == null)
                {
                    throw new Exception("No se encontro una review con los datos de id recibidos");
                }

                review.Like = updateReview.like;
                _context.Update(review);
                _context.SaveChanges();
                
                if(review.Like)
                {
                    NClientHubTaskAsync(updateReview.proyectId.ToString(),updateReview.emailUser,review.User.Email);
                }
                
                return review;

            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public Review GetReviewByEmail (Guid PId,string userEmail)
        {
            try
            {
                var review = _context.Review
                    .Include(r => r.User)
                    .Include(r => r.Proyect)
                        .ThenInclude(p => p.UserProyects)
                            .ThenInclude(up => up.User)
                    .FirstOrDefault(r => !r.isDeleted && r.User.Email == userEmail && r.Proyect.Id == PId);
                if (review == null) throw new Exception("Error no se encontro");
                
                Console.WriteLine($"Review: {review}");
                review.Proyect.UserProyects = _context.UserProyects
                    .Where(up => up.ProyectsId == review.Proyect.Id)
                    .Include(up => up.User)
                    .ToList();

                
                return review;
            }
            catch (System.Exception e)
            {
                
                throw new Exception("Error getting the review : ", e);
                
            }
        }

        public bool GetReviewUser (Guid PId,string userEmail)
        {
            try
            {
                Review reviewExist = _context.Review.FirstOrDefault(r => !r.isDeleted && r.User.Email == userEmail && r.Proyect.Id == PId);

                Review reviewExist = _context.Review.FirstOrDefault(r => !r.isDeleted && r.User.Email == userEmail && r.Proyect.Id == PId);

                if (reviewExist == null) {
                    throw new Exception("Error no se encontro");
                }

                bool review = _context.Review.Any(r => !r.isDeleted && r.User.Email == userEmail && r.Proyect.Id == PId && r.Like == true);

                Console.WriteLine($"Review: {review}");

                if (review == null)
                {
                    return review;

                }
                else
                {
                    return review;
                }
            }
            catch (System.Exception e)
            {
                
                throw new Exception("Error getting the review : ", e);
                
            }
        }
        public int GetReviewCount(Guid PId)
        {
            try
            {
                int count = _context.Review
                .Where(r => r.Proyect.Id == PId && !r.isDeleted && r.Like)
                .Count();
                
                return count;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
        public Review DeleteReview(Guid PId, Guid UId)
        {
            try
            {

                Review review = _context.Review.First(r => r.User.Id == UId && r.Proyect.Id == PId);

                review.isDeleted = !review.isDeleted;

                _context.SaveChanges();

                return review;

            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
        public UserLikeProductsDTO GetAllReviewsUser(Guid userId,int page, int pageSize)
        {
            try
            {
                int skip = (page - 1) * pageSize;
                var response = _context.Review.Where(r => r.User.Id == userId && !r.isDeleted && r.Like)
                .Skip(skip)
                .Take(pageSize)
                .Include(r => r.Proyect)
                .Select(r => new Proyect {
                    Id = r.Proyect.Id,
                    Image = r.Proyect.Image,
                    Description = r.Proyect.Description,
                    ImagesP = r.Proyect.ImagesP,
                    isDeleted = r.Proyect.isDeleted,
                    Name = r.Proyect.Name,
                    Role = r.Proyect.Role,
                    Url = r.Proyect.Url,
                })
                .ToList();

                if (response == null)
                {
                    throw new Exception("No se encontraron proyectos likeados por el Usuario");
                }

                UserLikeProductsDTO userLike = new UserLikeProductsDTO {
                    Proyects = response,
                    UserId = userId.ToString()
                };

                return userLike;
            }
            catch (System.Exception e)
            {
                Console.WriteLine("Obtencion de likes del usuario fallida : ",e);
                throw;
            }
        }
    }    
}