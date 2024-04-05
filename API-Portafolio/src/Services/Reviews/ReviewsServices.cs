
using ApplicationDb.Models;
using Proyects.Models;
using Reviews.Model;
using Users.Models;

namespace Reviews.Services
{
    public interface IReviewServices
    {
        Review AddReview(AddReviewDTO review);
    }

    public class ReviewService:IReviewServices
    {
        private readonly ApplicationDbContext _context;

        public ReviewService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Review AddReview(AddReviewDTO review)
        {

            try
            {

                User userExist = _context.Users.FirstOrDefault(u => u.Id == review.UserId);
                
                Proyect proyectExist = _context.Proyects.FirstOrDefault(p => p.Id == review.ProyectId);


                Review newReview = new Review{

                    Like = review.like,
                    Proyect = proyectExist,
                    User = userExist,

                };

                _context.Review.Add(newReview);

                Console.WriteLine("Review Creada : ",newReview);
                _context.SaveChanges();

            }
            catch (Exception)
            {
                
                throw;
            }
            finally
            {

            }

            return new Review();
        }
    }
}