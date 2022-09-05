using eSports.dal.Data;
using eSports.dal.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace eSports.web.Areas.Admin.Controllers;

public class PlayersController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public PlayersController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET
    public IActionResult Index()
    {
        return View();
    }


    #region API CALLS

    public IActionResult GetAll()
    {
        var players = _unitOfWork.Player.GetAll();

        return Json(new { data = players });
    }

    #endregion
}