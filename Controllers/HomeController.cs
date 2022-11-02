using DeckOfCardsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DeckOfCardsAPI.Controllers
{
    public class HomeController : Controller
    {
        CardDAL api = new CardDAL();
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string deckID)
        {
            return View();
        }

        public IActionResult DrawCards()
        {
            Deck newDeck = api.NewDeck();
            ViewData["DeckID"] = newDeck.deck_id;//I'm trying to pass newdeck ID to DrawMoreCards function below so that it saves the cards from the deck
            //Deck drawCards = api.DrawCards(newDeck.deck_id);
            newDeck = api.DrawCards(newDeck.deck_id);

            //deckID = newDeck.deck_id;
            //newDeck = api.DrawCards(deckID);
            return View(newDeck);


            //return View(drawCards);
        }

        public IActionResult DrawMoreCards(Deck updateDeck)
        {
            updateDeck = api.DrawCards("ViewData[\"DeckID\"]");

            return View(updateDeck);


            //return View(drawCards);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}