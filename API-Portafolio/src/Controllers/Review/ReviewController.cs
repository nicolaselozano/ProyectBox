
using Microsoft.AspNetCore.Mvc;
using Reviews.Model;
using Reviews.Services;

[ApiController]
[Route("api/[controller]")]
public class ReviewController:ControllerBase
{
    private readonly IReviewServices _reviewService;
    private readonly IUtilitiesReviewServices _utilsService;

    public ReviewController(IReviewServices reviewService, IUtilitiesReviewServices utilsService)
    {
        _reviewService = reviewService;
        _utilsService = utilsService;
    }

    [HttpGet]
    public IActionResult GetReview([FromQuery] Guid PId, [FromQuery] string userEmail)
    {
        try
        {

            
            bool review = _reviewService.GetReviewUser(PId, userEmail);

            return Ok(review);

        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"Error al obtener la review : {ex.Message}");
            return StatusCode(500,ex.Message);
        }
    }

    [HttpGet("proyect")]
    public IActionResult GetProyectReviews([FromQuery] Guid PId,[FromQuery]int page = 1,[FromQuery] int pageSize= 10)
    {
        try
        {   

            int skip = (page - 1) * pageSize;
            
            List<Review> reviews = _reviewService.GetProyectReviews(PId,skip,pageSize);
            
            return Ok(reviews);

        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"Error al obtener las review : {ex.Message}");
            return StatusCode(500,ex.Message);
        }
    }

    [HttpPost]
    [TokenValidationMiddleware]
    [CheckPermissionM("user:user")]
    public IActionResult AddReview([FromBody] ReviewDTO newReview)
    {

        try
        {
            
            var entity = _reviewService.AddReview(newReview);

            return Ok(entity);
            
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al crear la review : {ex.Message}");
            return StatusCode(500,ex.Message);
        }
        finally
        {
            Console.WriteLine("Peticion para creacion de review terminada");
        }

    }
    [HttpGet("count")]
    public IActionResult GetReviewCount ([FromQuery] Guid PId)
    {
        try
        {
            int count = _reviewService.GetReviewCount(PId);

            return Ok(count);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al obtener todas las reviews : {ex.Message}");
            return StatusCode(500,ex.Message);
        }
    }
    [HttpGet("mostv")]
    public IActionResult GetMostVotedReview()
    {
        try
        {
            return Ok(_utilsService.MostLikedProyect());
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }

}