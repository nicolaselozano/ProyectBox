
using ApplicationDb.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using Proyects.Models;
using Reviews.Model;
using Users.Models;

namespace Reviews.Services
{
    public interface IReviewServices
    {
        Review AddReview(ReviewDTO review);
        Review GetReviewUser(Guid PId,Guid UId);
        Review UpdateReview(ReviewDTO UId);
        int GetReviewCount(Guid PId);
        Review DeleteReview(Guid PId, Guid UId);
        List<Review> GetProyectReviews(Guid PId,int page,int pageSize);
    }

    public class ReviewService:IReviewServices
    {
        private readonly ApplicationDbContext _context;

        public ReviewService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Review AddReview(ReviewDTO review)
        {

            try
            {

                User userExist = _context.Users.FirstOrDefault(u => !u.isDeleted && u.Id == review.UserId);
                
                Proyect proyectExist = _context.Proyects.FirstOrDefault(p => !p.isDeleted && p.Id == review.ProyectId);

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
        
        public List<Review> GetProyectReviews(Guid PId, int skip,int pageSize)
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
                Review review = _context.Review.First(r => !r.isDeleted && r.User.Id == updateReview.UserId && r.Proyect.Id == updateReview.ProyectId);
                if (review == null)
                {
                    throw new Exception("No se encontro una review con los datos de id recibidos");
                }

                review.Like = updateReview.like;
                _context.Update(review);
                _context.SaveChanges();
                
                return review;

            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
        public Review GetReviewUser (Guid PId,Guid UId)
        {
            try
            {
               
                Review review = _context.Review
                    .Include(r => r.User)
                    .Include(r => r.Proyect)
                    .First(r => !r.isDeleted && r.User.Id == UId && r.Proyect.Id == PId);

                Console.WriteLine($"Review: {review.Like}");
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
                .Where(r => r.Proyect.Id == PId && !r.isDeleted)
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
    }
}