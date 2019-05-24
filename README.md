Lottery Code Challenge 
=========
Developed by Michael Whitman


A simple, yet comprehensive Single Page Application, front end built in Angular 7.0 and backend hosted with .NET Core Web API / MVC.

### The Brief

This is a code challenge to build simple application or web page to display a Lottery Draw and jackpot information.
Languages selections: pick any one from C#, Angular or React JS, if using C#, HTML can be server side rendering. 
Requirements:
1. The application will need to connect web api endpoint:
https://data.api.thelott.com/sales/vmax/web/data/lotto/luckylotteries/currentdraw or 
https://data.api.thelott.com/sales/vmax/web/data/lotto/opendraws to get the lotto draw data and jackpot data, then display the OZlotto, Gold Lotto and Powerball.

2. The information display in the web page requires to at least have Lottery product display name, 
logo image, draw date, draw number and jackpack value (Div1Amount). 

3. The application should have at least 2 unit testing cases built in. 

4. The code needs to committed into your github account with a bit readme document. 


### Backend Project Breakdown

+ **Draw Requests:**
All requests made to the backend project go via these DTO's.
A CompanyId must be supplied and MaxDrawCount should be > 0.
```
public class DrawRequest
{
    public string CompanyId { get; set; }
    public int MaxDrawCount { get; set; }
    public string[] OptionalProductFilter { get; set; }
}
```

+ **Controller Endpoints:**
This is the API for the front-end app to communicate with.  It contains 2 Endpoints `Current` and `Open`:
```
/// <summary>
/// Gets a list of the current lotto draws
/// </summary>
[HttpPost("/api/draws/current")]

/// <summary>
/// Gets a list of the open lotto draws
/// </summary>
[HttpPost("/api/draws/open")]
```
+ **Responses:** 
Depending on the endpoint envoked, you will get back either an `OpenDraw` or `CurrentDraw` response object if successful.
```
/// The Id of the lotto draw
string ProductId { get; set; }

/// The number of the draw
int DrawNumber { get; set; }

/// The friendly display name of the draw
string DrawDisplayName { get; set; }

/// The date on which the draw occurs
DateTimeOffset DrawDate { get; set; }

/// The logo representation of the draw 
string DrawLogoUrl { get; set; }

/// The type of draw
string DrawType { get; set; }

/// The monetary value of the division one prize in the draw - Assuming this maybe nullable if the Div1 is unknown
decimal? Div1Amount { get; set; }

/// Is the amount of the division one prize an estimation?
bool IsDiv1Estimated { get; set; }

/// Is the amount of division one prize unknown?
bool IsDiv1Unknown { get; set; }

/// The date / time the draw closes in UTC
DateTimeOffset DrawCloseDateTimeUtc { get; set; }

/// The date / time the draw stops selling tickets in UTC
DateTimeOffset DrawEndSellDateTimeUtc { get; set; }
```
`OpenDraw` unique fields:
```
/// The number of seconds until the draw is commenced
public double DrawCountDownTimerSeconds { get; set; }
```
`CurrentDraw` unique fields:
```
/// The Pending Div 1 Amount, example proves that this is a nullable field
public double? PendingDiv1Amount { get; set; }

/// Is the draw almost sold out?
public bool NearlySoldOut { get; set; }
```

### Front-End Project Breakdown

+ **Dashboard**: This is your starting screen and enables quick navigation to either of the lottery draw screens via the dashboard panel or the top menu.
+ **Current Draws**: This will get the latest data from the back-end API around the current lottery draws.
+ **Open Draws**: This will get the latest data from the back-end API around all available open lottery draws.
+ **FAQ**: Simple page with some helpful information on it.

**Special Notes**: 
- *In order to communicate with the backend on your local computer, the port number must be set correctly in the http service, this is currently set to 44318, if Visual studio changes this, update accordingly*.

- **You will most likely need to restore the angular / npm packages before getting the solution to run, this will not be committed to the repository.**


**TODO: Functionality to be developed next:**

- Implement the pagination and sorting for the lotto draw tables.

- Implement and test optional product filter.

- Write additional tests for the following areas:
    - Repositories - to test data is serialize / de-serialized properly.
    - Controllers - to test exceptions and http handling is robust.
    - Integration Tests - Test solution end to end in new project for additional code coverage / affirmation.
    - Errors - an extension of the above points, ensure api error responses are handled in a suitable fashion.
    - Write front-end field validation
    - Front-end unit tests
    - A little bit front-end layout clean up to be picky.
