// Get default input data
const token = document.querySelector("#FinnhubKey").value;
const socket = new WebSocket('wss://ws.finnhub.io?token=' + token);
var stockSymbol = document.querySelector("#StockSymbol").value;

// Connection opened, subcribe to a symbol
socket.addEventListener('open', function (event) {
    socket.send(JSON.stringify(
        {
        'type': 'subcribe',
        'symbol': stockSymbol
        }
    ))
});

// Listen (receive) the messages
socket.addEventListener('message', function (event) {
    // check if get the errors
    if (event.data.type == "error") {
        $(".stock-price").text(event.data.msg);
        return; //exit function
    }

    //data received from server
    //console.log('Message from server ', event.data);

    /* Sample response:
    {"data":[{"p":220.89,"s":"MSFT","t":1575526691134,"v":100}],"type":"trade"}
    type: message type
    data: [ list of trades ]
    s: symbol of the company
    p: Last price
    t: UNIX milliseconds timestamp
    v: volume (number of orders)
    c: trade conditions (if any)
    */

    var eventData = JSON.parse(event.data);
    if (eventData) {
        if (eventData.data) {
            // Get updated data
            var updatedPrice = eventData.data[0].p;
            //var timeStamp = eventData.data[0].t;
            //console.log(updatedPrice, timeStamp);
            //console.log(new Date(timeStamp).toLocaleTimeString());

            // Set the value to the view
            $(".stock-price").text(updatedPrice.toFixed(2)); // Set the value of label
            $("#Price").val(updatePrice.toFixed(2)); // Set the value of input hidden
        }
    }
});

// Unsubcribe
var unsubcribe = function (symbol) {
    // disconnect from server
    socket.send(JSON.stringify(
        {
            'type': 'unsubcribe',
            'symbol': stockSymbol
        }
    ))
}

// When the web is closed, unsubcribe the websocket
window.onunload = function () {
    unsubcribe(stocksymbol);
}