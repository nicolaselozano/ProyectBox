
using Microsoft.AspNetCore.Mvc;
using Reviews.Services;

[ApiController]
[Route("api/[controller]")]
public class ReviewController:ControllerBase
{
    private readonly IReviewServices _reviewService;

    public ReviewController(IReviewServices reviewServices)
    {
        _reviewService = reviewServices;
    }

    [HttpPost]
    public IActionResult AddReview([FromBody] AddReviewDTO newReview)
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

}