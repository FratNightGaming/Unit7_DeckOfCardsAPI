using RestSharp;

namespace DeckOfCardsAPI.Models
{
    public class CardDAL
    {
        //public string key = "8b4c6759"; possibly a leftover key from different api?

        public Deck NewDeck()
        {
            string url = $"https://deckofcardsapi.com/api/deck/new/shuffle/?deck_count=1";

            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.GetAsync<Deck>(request);
            Deck results = response.Result;

            return results;
        }

        public Deck DrawCards(string id)
        {
            string url = $"https://deckofcardsapi.com/api/deck/{id}/draw/?count=5";

            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.GetAsync<Deck>(request);
            Deck results = response.Result;

            return results;
        }
    }
}
/*Task: Work with an API that generates JSON data to display information on a web page. 

Build Specifications:
Work with the Deck of Cards API, documented at https://deckofcardsapi.com/
Make a call to the API to generate a new deck.Capture the deck ID returned.
Draw 5 cards from the deck and display their names and images inside a web page.

Hints:
Install a browser plugin to view JSON data such as:
https://chrome.google.com/webstore/detail/json-formatter/bcjindcccaagfpapjjmafapmmgkkhgoa?hl=en


Extra Challenges:
On the page that displays the cards, have a button to draw the next 5 cards from the same deck.  You'll need to pass the ID along, either coded into the URL or as a hidden field.
Add "Keep" functionality to the cards view.  When the user clicks the draw again button, keep the cards they chose to keep and only draw to replace the others.  (Checkboxes might be the easiest way to accomplish the keep.)
*/