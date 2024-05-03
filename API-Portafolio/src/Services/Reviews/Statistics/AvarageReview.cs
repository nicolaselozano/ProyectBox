
using ApplicationDb.Models;

namespace Reviews.Services
{
    public interface IUtilitiesReviewServices
    {
        MostLikedDTO MostLikedProyect();
    }

    public class UtilitiesReviewServices: IUtilitiesReviewServices
    {
        private readonly ApplicationDbContext _context;

        public UtilitiesReviewServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public MostLikedDTO MostLikedProyect()
        {

            try
            {
                var mostLikedProyect = _context.Review.Where(r => !r.isDeleted)
                .GroupBy(r => r.Proyect.Id)
                .Select(r => new 
                {
                    ProyectId = r.Key,
                    LikeCount = r.Count(r => r.Like)
                })
                .OrderByDescending(r => r.LikeCount)
                .FirstOrDefault();

                MostLikedDTO mostLiked = new MostLikedDTO
                {
                    proyect = _context.Proyects.First(r => r.Id == mostLikedProyect.ProyectId),
                    likeCount = mostLikedProyect.LikeCount
                };

                return mostLiked;
            }
            catch (System.Exception)
            {
                throw;
            }

        }

    }
}